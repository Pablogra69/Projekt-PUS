using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace Host_IIS_WcfService
{
    public class C_GetOrder
    {

        public DataTable GetOrderHelp(string @s_FileName)
        {
            //jalky bylop w service
            //string s_PathName = @"C:Users\Exist\Desktop\";
            //Nie obsuluguje service
            string s_PathName2 = @"C:\Users\Paweł\Desktop\WCF\Dane\";

            List<string> CatalogList = new List<string>();
            List<string> ValueList = new List<string>();
            System.Xml.XmlDocument xml = new System.Xml.XmlDocument();

            try
            {
                xml.Load(s_PathName2 + s_FileName);
                System.Xml.XmlNodeList xnList = xml.SelectNodes("/orders/order/rows/row");
                System.IO.FileInfo fi = new System.IO.FileInfo(s_PathName2 + s_FileName);

                foreach (System.Xml.XmlNode xnItem in xnList)
                {
                    CatalogList.Add(xnItem["products_sku"].InnerText);
                    ValueList.Add(xnItem["quantity"].InnerText);
                }

                string[] katalog = CatalogList.ToArray();
                string[] wartosc = ValueList.ToArray();
                string[,] tablica = new string[katalog.Length, 6];
                int[] myInts = Array.ConvertAll(wartosc, s => int.Parse(s));

                var result =
                    katalog
                        .Zip(myInts, (f, q) => new { f, q })
                        .GroupBy(x => x.f, x => x.q)
                        .Select(x => new { katalog = x.Key, myInts = x.Sum() })
                        .ToArray();

                var totalProductByCatalog = result.Select(x => x.katalog).ToArray();
                var totalquantity = result.Select(x => x.myInts).ToArray();



                if (fi.Exists)
                {
                    if (System.IO.Path.GetFileNameWithoutExtension(s_PathName2 + s_FileName).Contains("Wybrane"))
                        return GetDataList(katalog, wartosc);

                    else
                        fi.MoveTo(m_ChangeFileName(s_PathName2 + "Wybrane" + s_FileName));
                }


                return GetDataList(katalog, wartosc);

            }
            catch (Exception E)
            {
                return null;
            }

        }

        public string m_ChangeFileName(string fullPath)
        {
            int count = 1;

            string fileNameOnly = System.IO.Path.GetFileNameWithoutExtension(fullPath);
            string extension = System.IO.Path.GetExtension(fullPath);
            string path = System.IO.Path.GetDirectoryName(fullPath);
            string newFullPath = fullPath;

            while (System.IO.File.Exists(newFullPath))
            {
                string tempFileName = string.Format("{0}({1})", fileNameOnly, count++);
                newFullPath = System.IO.Path.Combine(path, tempFileName + extension);
            }

            return newFullPath;
        }

        public DataTable GetDataList(string[] katalog, string[] value)
        {

            SqlConnection sQLconnection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["Test"].ConnectionString);
            DataTable data = new DataTable("ARTYKUL");

            string Tempkatalog = "";
            for (int i = 0; i < katalog.Length; i++)
            {
                if (i == katalog.Length - 1) Tempkatalog += "'" + katalog[i] + "')";
                else Tempkatalog += "'" + katalog[i] + "', ";
            }

            using (sQLconnection)
            {

                try
                {
                    sQLconnection.Open();
                    string sOperation = "SELECT LOKALIZACJA, INDEKS_KATALOGOWY, NAZWA,   STAN, ZAREZERWOWANO, KOD_KRESKOWY, ID_ARTYKULU " +
                        "FROM [dbo].[ARTYKUL] " +
                        "where ID_MAGAZYNU = '1' and INDEKS_KATALOGOWY IN (" + Tempkatalog;

                    SqlCommand cmd1 = new SqlCommand(sOperation, sQLconnection);
                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd1);

                    sqlDataAdapter.Fill(data);
                    cmd1.Dispose();
                    sqlDataAdapter.Dispose();
                    data.DefaultView.RowFilter = "[INDEKS_KATALOGOWY] IN (" + Tempkatalog;
                }
                catch (Exception ex)
                {
                    return data;
                }
                finally
                {
                    sQLconnection.Close();
                }
            }

            try
            {
                DataTable dataOutput = data.DefaultView.ToTable();

                while (dataOutput.Rows.Count < katalog.Length)
                {
                    dataOutput.Rows.Add();
                }

                dataOutput.Columns.Add("ILE", typeof(string));
                byte temp = 0;
                byte n = 0;
                bool b_checkCatalog;

                foreach (string c in katalog)
                {
                    b_checkCatalog = true;
                    foreach (DataRow dr in dataOutput.Rows)
                    {
                        if (dr["INDEKS_KATALOGOWY"].ToString() == c)
                        {
                            b_checkCatalog = true;
                            break;
                        }
                        else
                        {
                            b_checkCatalog = false;
                        }
                    }

                    if (b_checkCatalog == false)
                    {
                        dataOutput.Rows[dataOutput.Rows.Count - 1 - temp]["INDEKS_KATALOGOWY"] = c.ToString();
                        dataOutput.Rows[dataOutput.Rows.Count - 1 - temp]["ILE"] = value[n];
                        temp++;
                    }
                    else
                    {
                        dataOutput.Rows[n]["ILE"] = value[n];
                    }
                    n++;
                }
                dataOutput.DefaultView.Sort = "LOKALIZACJA ASC";
                dataOutput = dataOutput.DefaultView.ToTable();

                //DataTable dtCloned = dataOutput.Clone();
                //dtCloned.Columns[3].DataType = typeof(Int32);
                //dtCloned.Columns[4].DataType = typeof(Int32);
                //foreach (DataRow row in dataOutput.Rows)
                //{
                //    dtCloned.ImportRow(row);
                //}
                byte i = 0;
                foreach (DataRow dr in dataOutput.Rows)
                {
                    
                    dataOutput.Rows[i]["STAN"] = Convert.ToInt64(dataOutput.Rows[i]["STAN"]);
                    dataOutput.Rows[i]["ZAREZERWOWANO"] = Convert.ToInt64(dataOutput.Rows[i]["ZAREZERWOWANO"]);
                    i++;
                }


                return dataOutput;
            }
            catch
            {
                return data;
            }
        }

    }
}