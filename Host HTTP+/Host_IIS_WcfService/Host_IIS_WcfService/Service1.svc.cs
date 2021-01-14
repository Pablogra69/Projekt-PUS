using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.ServiceModel;

namespace Host_IIS_WcfService
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    public class Service1 : IService1
    {
        //DataSource = @"mistral\heljos",
        //InitialCatalog = "Wapro2016",
        //DataSource = @"LAPTOP-4SEPM230",
        //        InitialCatalog = "WAPRO_DEMO",
        //        UserID = "sa",

        //        //Password = "qazwsx890",
        //        Password = "Wapro3000",
        SqlConnection sQLconnection = new SqlConnection(ConfigurationManager.ConnectionStrings["Test"].ConnectionString);


        #region MainWindow
        public bool IsServerConnected()
        {
            using (sQLconnection)
            {
                try
                {
                    sQLconnection.Open();
                    return true;
                }
                catch (SqlException)
                {
                    return false;
                }
            }
        }
        public string[] GetData(string i_Id, int i_Operation)
        {
            DataTable data = new DataTable("ARTYKUL");
            string[] tablica = new string[10];
            string sOperation = "";


            ///
            //Wybór operacji


            if (i_Operation == 1)
                sOperation = "SELECT a.LOKALIZACJA, a.INDEKS_KATALOGOWY, a.NAZWA,  a.STAN, a.ZAREZERWOWANO, a.KOD_KRESKOWY, " +
                    "a.ID_ARTYKULU, a.[POLE1], c.CENA_BRUTTO FROM [dbo].[ARTYKUL]  AS a INNER JOIN [dbo].[CENA_ARTYKULU] AS c  " +
                    "ON c.ID_ARTYKULU = a.ID_ARTYKULU " +
                    "where a.ID_MAGAZYNU =  @s1 and KOD_KRESKOWY = @s3 and c.ID_CENY = @s2";
            else
                sOperation = "SELECT a.LOKALIZACJA, a.INDEKS_KATALOGOWY, a.NAZWA,  a.STAN, a.ZAREZERWOWANO, a.KOD_KRESKOWY, " +
                    "a.ID_ARTYKULU, a.[POLE1], c.CENA_BRUTTO FROM [dbo].[ARTYKUL]  AS a INNER JOIN [dbo].[CENA_ARTYKULU] AS c  " +
                    "ON c.ID_ARTYKULU = a.ID_ARTYKULU " +
                    "where a.ID_MAGAZYNU =  @s1 and INDEKS_KATALOGOWY = @s3 and c.ID_CENY = @s2";




            try
            {
                sQLconnection.Open();
                SqlCommand cmd1 = new SqlCommand(sOperation, sQLconnection);
                cmd1.Parameters.AddWithValue("@s1", "1");
                cmd1.Parameters.AddWithValue("@s2", "4");
                cmd1.Parameters.AddWithValue("@s3", i_Id);
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd1);

                sqlDataAdapter.Fill(data);
                cmd1.Dispose();
                sqlDataAdapter.Dispose();

                if (i_Operation == 1)
                    sOperation = "KOD_KRESKOWY = '" + i_Id + "'";
                else
                    sOperation = "INDEKS_KATALOGOWY = '" + i_Id + "'";

                DataRow[] result = data.Select(sOperation);



                tablica[0] = result[0]["ID_ARTYKULU"].ToString();
                tablica[1] = result[0]["NAZWA"].ToString();
                tablica[2] = Convert.ToInt64(result[0]["STAN"]) + "";
                tablica[9] = Convert.ToInt64(result[0]["ZAREZERWOWANO"]) + "";
                tablica[3] = result[0]["INDEKS_KATALOGOWY"].ToString();
                tablica[4] = result[0]["KOD_KRESKOWY"].ToString();
                tablica[5] = result[0]["LOKALIZACJA"].ToString();
                tablica[6] = result[0]["POLE1"].ToString();
                tablica[8] = Math.Round((decimal)result[0]["CENA_BRUTTO"], 2).ToString();
                return tablica;

            }
            catch (Exception ex)
            {
                tablica[1] = "Product doesn't exist";
                tablica[2] = "Product doesn't exist";
                tablica[4] = "Product doesn't exist";
                tablica[5] = "Product doesn't exist";
                tablica[7] = "Product doesn't exist";
                return tablica;
            }
            finally
            {

                sQLconnection.Close();

            }
        }

        public void PutProduct(string id, string lokalizacja, bool idOrCatalog)
        {
            try
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = sQLconnection;
                    command.CommandType = CommandType.Text;
                    if (idOrCatalog)
                        command.CommandText = "UPDATE[dbo].[ARTYKUL]  SET[LOKALIZACJA] = @staffName where ID_MAGAZYNU = @staffMag and ID_ARTYKULU = @staffID";
                    else
                        command.CommandText = "UPDATE[dbo].[ARTYKUL]  SET[LOKALIZACJA] = @staffName where ID_MAGAZYNU = @staffMag and INDEKS_KATALOGOWY = @staffID";

                    command.Parameters.AddWithValue("@staffID", id);
                    command.Parameters.AddWithValue("@staffName", lokalizacja);
                    command.Parameters.AddWithValue("@staffMag", "1");

                    sQLconnection.Open();
                    command.ExecuteNonQuery();

                }
            }
            catch (SqlException)
            {

            }
            finally
            {
                sQLconnection.Close();
            }
        }



        public DataTable GetDataList(string s_IdLocal)
        {

            DataTable data = new DataTable("ARTYKUL");
            try
            {
                sQLconnection.Open();
                string sOperation = "SELECT a.LOKALIZACJA, a.INDEKS_KATALOGOWY, a.NAZWA,  a.STAN, a.ZAREZERWOWANO, a.KOD_KRESKOWY, " +
                    "a.ID_ARTYKULU, c.CENA_BRUTTO FROM [dbo].[ARTYKUL]  AS a INNER JOIN [dbo].[CENA_ARTYKULU] AS c  " +
                    "ON c.ID_ARTYKULU = a.ID_ARTYKULU " +
                    "where a.ID_MAGAZYNU = '1' and c.ID_CENY = '4' and a.STAN > 0 and [LOKALIZACJA] LIKE '%" + s_IdLocal + "%'";

                SqlCommand cmd1 = new SqlCommand(sOperation, sQLconnection);
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd1);

                sqlDataAdapter.Fill(data);
                cmd1.Dispose();
                sqlDataAdapter.Dispose();
                data.DefaultView.RowFilter = "[LOKALIZACJA] LIKE '%" + s_IdLocal + "%'";
                data.DefaultView.Sort = "LOKALIZACJA ASC";
                DataTable dataOutput = data.DefaultView.ToTable();


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
            catch (Exception ex)
            {
                return data;
            }
            finally
            {
                sQLconnection.Close();
            }


        }


        #endregion


        #region List picture or empty product
        public string[] GetListProductEmpty()
        {

            string s = "";
            string[] list = new string[100];
            byte i = 0;

            using (StreamReader sr = File.OpenText(@"C:\Users\Paweł\Desktop\WCF\Dane\Product.txt"))
            {
                while ((s = sr.ReadLine()) != null)
                {
                    list[i] = s;
                    i++;
                }
            }

            return list;

        }

        public void AddEmptyProduct(string[] list, int b_Open_Write)
        {

            string fileName = @"C:\Users\Paweł\Desktop\WCF\Dane\Product.txt";

            if (b_Open_Write == 0)
            {
                if (File.Exists(fileName))
                {
                    string[] arrayTemp = GetListProductEmpty();
                    using (StreamWriter sw = File.AppendText(fileName))
                    {
                        foreach (string temp in list)
                        {

                            if (m_checkFile(arrayTemp, temp))
                                sw.WriteLine(temp + " Utworzono: " + DateTime.Now.ToString());
                        }
                    }
                }
                else
                {
                    using (StreamWriter sw = File.AppendText(fileName))
                    {
                        foreach (string temp in list)
                        {

                            if (temp != null || temp != "")
                                sw.WriteLine(temp + " Utworzono: " + DateTime.Now.ToString());
                        }
                    }
                }
            }

            if (b_Open_Write == 2)
            {
                File.Delete(fileName);
                using (StreamWriter sw = File.AppendText(fileName))
                {
                    foreach (string temp in list)
                    {
                        if (temp != null || temp != "")
                        {
                            sw.WriteLine(temp);
                        }
                    }

                }
            }
        }

        public void AddPicture(string[] list, int b_Open_Write)
        {
            string fileName = @"C:\Users\Paweł\Desktop\WCF\Dane\Pictures.txt";

            if (b_Open_Write == 0)
            {
                if (File.Exists(fileName))
                {
                    string[] arrayTemp = GetListPicture();
                    using (StreamWriter sw = File.AppendText(fileName))
                    {
                        foreach (string temp in list)
                        {

                            if (m_checkFile(arrayTemp, temp))
                                sw.WriteLine(temp + " Utworzono: " + DateTime.Now.ToString());
                        }
                    }
                }
                else
                {
                    using (StreamWriter sw = File.AppendText(fileName))
                    {
                        foreach (string temp in list)
                        {

                            if (temp != null || temp != "")
                                sw.WriteLine(temp + " Utworzono: " + DateTime.Now.ToString());
                        }
                    }
                }
            }

            if (b_Open_Write == 2)
            {
                File.Delete(fileName);
                using (StreamWriter sw = File.AppendText(fileName))
                {
                    foreach (string temp in list)
                    {
                        if (temp != null || temp != "")
                        {
                            sw.WriteLine(temp);
                        }
                    }

                }
            }
        }

        public string[] GetListPicture()
        {

            string s = "";
            string[] list = new string[100];
            byte i = 0;

            using (StreamReader sr = File.OpenText(@"C:\Users\Paweł\Desktop\WCF\Dane\Pictures.txt"))
            {

                while ((s = sr.ReadLine()) != null)
                {
                    list[i] = s;
                    i++;
                }

            }

            return list;

        }

        public bool m_checkFile(string[] arrayTemp, string item)
        {

            foreach (string s in arrayTemp)
            {
                if (s == null || s == "") return true;
                if (item == null || item == "") return false;

                if (s.Contains(item.Substring(0, 6))) return false;
            }

            return true;
        }

        #endregion

        #region Selecting


        public void AddOrder(byte[] b_XML, string s_Filename)
        {
            string s_PathName = @"C:\Users\Paweł\Desktop\WCF\Dane\" + s_Filename;
            C_GetOrder c_GetOrder = new C_GetOrder();

            if (File.Exists(s_PathName))
            {
                s_PathName = c_GetOrder.m_ChangeFileName(s_PathName);
            }
            File.WriteAllBytes(s_PathName, b_XML);

        }

        public DataTable GetOrder(string s_FileName)
        {
           
            C_GetOrder c_GetOrder = new C_GetOrder();

            return c_GetOrder.GetOrderHelp(s_FileName);

        }

        public string[] GetListOrders()
        {
            string s_PathName = @"C:\Users\Paweł\Desktop\WCF\Dane";
            string[] listOrders = Directory.GetFiles(s_PathName, "*.xml",
                                         SearchOption.TopDirectoryOnly);
            for (int i = 0; i < listOrders.Length; i++)
            {
                listOrders[i] = Path.GetFileName(listOrders[i]);
            }

            return listOrders;
        }

        public void DeleteOrder(string s_Filename)
        {

            string s_PathName = @"C:\Users\Paweł\Desktop\WCF\Dane\" + s_Filename;
            File.Delete(s_PathName);

        }

        #endregion

    }
}

