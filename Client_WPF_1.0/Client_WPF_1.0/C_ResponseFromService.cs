using Client_WPF_1._0.ServiceHost;
using System;
using System.Data;
using System.IO;
using System.ServiceModel;
using System.Windows;
using System.Windows.Media.Imaging;

namespace Client_WPF_1._0
{
    class C_ResponseFromService
    {

        #region MainWindow
        public string[] m_GetProduct(string index, int i_Operation)
        {

            using (Service1Client ddd = new Service1Client())
            {
                try
                {
                    string[] tab = ddd.GetData(index, i_Operation);
                    ddd.Close();

                    return tab;
                }
                catch (TimeoutException timeout)
                {
                    ddd.Abort();
                    MessageBox.Show("Serwer nie odpowiada");
                    return null;
                }
                catch (CommunicationException commException)
                {
                    ddd.Abort();
                    MessageBox.Show("Błąd połaczenia z serwerem");
                    return null;
                }
                catch (Exception e)
                {
                    ddd.Abort();
                    MessageBox.Show(e.Message);
                    return null; 
                }
            }
        
        }

        public string m_PutProduct(string id, string lokalizacja, bool idOrCatalog)
        {

            using (Service1Client dd = new Service1Client())
            {
                try
                {
                    dd.PutProduct(id, lokalizacja, idOrCatalog);
                    dd.Close();

                    return "Success";
                }
                catch (TimeoutException timeout)
                {
                    dd.Abort();
                    MessageBox.Show("Serwer nie odpowiada");
                    return null;
                }
                catch (CommunicationException commException)
                {
                    dd.Abort();
                    MessageBox.Show("Błąd połaczenia z serwerem");
                    return null;
                }
                catch (Exception e)
                {
                    dd.Abort();
                    MessageBox.Show(e.Message);
                    return null;
                }
            }

        }

        public bool m_IsServerConnect()
        {
            using (Service1Client dd = new Service1Client())
            {

                try
                {
                    bool temp = dd.IsServerConnected();
                    dd.Close();

                    return temp;
                }
                catch (TimeoutException timeout)
                {

                    dd.Abort();
                    MessageBox.Show("Serwer nie odpowiada");
                    return false;
                }
                catch (CommunicationException commException)
                {

                    dd.Abort();
                    MessageBox.Show("Błąd połaczenia z serwerem");
                    return false;
                }
                catch (Exception e)
                {
                    dd.Abort();
                    MessageBox.Show(e.Message);
                    return false;
                }
            }
            
        }
        #endregion

        #region Location control
        public DataTable m_GetListProduct(string s_IdLocal)
        {
           
            using (Service1Client dd = new Service1Client())
            {

                try
                {
                    DataTable dataOutput = dd.GetDataList(s_IdLocal).DefaultView.ToTable();
                    dataOutput.Columns.Add("Image", typeof(BitmapImage));
                   
                    C_GetImage c_GetImage = new C_GetImage();
                    byte temp = 0;

                    foreach (DataRow rows in dataOutput.Rows)
                    {
                        dataOutput.Rows[temp]["Image"] = c_GetImage.m_GetImage((string)rows["INDEKS_KATALOGOWY"]);
                        temp++;
                    }
                    dd.Close();
                    
                    return dataOutput;
                }
                catch (TimeoutException timeout)
                {
                    
                    dd.Abort();
                    MessageBox.Show("Serwer nie odpowiada");
                    return null;
                }
                catch (CommunicationException commException)
                {
                    
                    dd.Abort();
                    MessageBox.Show("Błąd połaczenia z serwerem");
                    return null;
                }
                catch (Exception e)
                {
                    dd.Abort();
                    MessageBox.Show(e.Message);
                    return null;
                }
            }

        }

        #endregion


        #region Bad picture or empty product
        public bool m_BadPicture(string[] s_Id, int i_Operation)
        {
            
            using (Service1Client dd = new Service1Client())
            {
                try
                {
                    dd.AddPicture(s_Id, i_Operation);
                    dd.Close();

                    return true;
                }
                catch (TimeoutException timeout)
                {
                    dd.Abort();
                    MessageBox.Show("Serwer nie odpowiada");
                    return false;
                }
                catch (CommunicationException commException)
                {
                    dd.Abort();
                    MessageBox.Show("Błąd połaczenia z serwerem");
                    return false;
                }
                catch (Exception e)
                {
                    dd.Abort();
                    MessageBox.Show(e.Message);
                    return false;
                }
            }

        }

        public bool m_EmptyProduct(string[] s_Id, int i_Operation)
        {

            using (Service1Client dd = new Service1Client())
            {
                try
                {
                    dd.AddEmptyProduct(s_Id, i_Operation);
                    dd.Close();

                    return true;
                }
                catch (TimeoutException timeout)
                {
                    dd.Abort();
                    MessageBox.Show("Serwer nie odpowiada");
                    return false;
                }
                catch (CommunicationException commException)
                {
                    dd.Abort();
                    MessageBox.Show("Błąd połaczenia z serwerem");
                    return false;
                }
                catch (Exception e)
                {
                    dd.Abort();
                    MessageBox.Show(e.Message);
                    return false;
                }
            }

        }

        public string[] m_GetListPicture()
        {

            using (Service1Client dd = new Service1Client())
            {
                try
                {
                    string[] s_Id = dd.GetListPicture();
                    dd.Close();     
                    
                    return s_Id;
                }
                catch (TimeoutException timeout)
                {
                    dd.Abort();
                    MessageBox.Show("Serwer nie odpowiada");
                    return null;
                }
                catch (CommunicationException commException)
                {
                    dd.Abort();
                    MessageBox.Show(commException.Message);
                    return null;
                }
                catch (Exception e)
                {
                    dd.Abort();
                    MessageBox.Show(e.Message);
                    return null;
                }
            }

        }

        public string[] m_GetListProductsEmpty()
        {

            using (Service1Client dd = new Service1Client())
            {
                try
                {
                    string[] s_Id = dd.GetListProductEmpty();
                    dd.Close();
                    
                    return s_Id;
                }
                catch (TimeoutException timeout)
                {
                    dd.Abort();
                    MessageBox.Show("Serwer nie odpowiada");
                    return null;
                }
                catch (CommunicationException commException)
                {
                    dd.Abort();
                    MessageBox.Show("Błąd połaczenia z serwerem");
                    return null;
                }
                catch (Exception e)
                {
                    dd.Abort();
                    MessageBox.Show(e.Message);
                    return null;
                }
            }
        }

        #endregion



        #region Selecting orders


        public void m_DeleteOrder(string s_FileName)
        {
            using (Service1Client dd = new Service1Client())
            {
                try
                {
                    dd.DeleteOrder(s_FileName);
                }
                catch (TimeoutException timeout)
                {
                    dd.Abort();
                    MessageBox.Show("Serwer nie odpowiada");
                }
                catch (CommunicationException commException)
                {
                    dd.Abort();
                    MessageBox.Show("Błąd połaczenia z serwerem");
                }
                catch (Exception e)
                {
                    dd.Abort();
                    MessageBox.Show(e.Message);
                }
            }
        }
        
        public DataTable m_GetSelectOrder(string s_FileName)
        {
            
            using (Service1Client dd = new Service1Client())
            {
                try
                {
                    DataTable dataOutput = dd.GetOrder(@s_FileName).DefaultView.ToTable();
                    dataOutput.Columns.Add("Image", typeof(BitmapImage));
                    byte temp = 0;
                    C_GetImage c_GetImage = new C_GetImage();
                    foreach (DataRow rows in dataOutput.Rows)
                    {
                        dataOutput.Rows[temp]["Image"] = c_GetImage.m_GetImage((string)rows["INDEKS_KATALOGOWY"]);
                        temp++;
                    }
                    dd.Close();

                    return dataOutput;
                }
                catch (TimeoutException timeout)
                {
                    dd.Abort();
                    MessageBox.Show("Serwer nie odpowiada");
                    return null;
                }
                catch (CommunicationException commException)
                {
                    dd.Abort();
                    MessageBox.Show("Błąd połaczenia z serwerem");
                    return null;
                }
                catch (Exception e)
                {
                    dd.Abort();
                    MessageBox.Show(e.Message);
                    return null;
                }
            }
        }

        public string[] m_GetListOrder()
        {

            using (Service1Client dd = new Service1Client())
            {
                try
                {
                    return dd.GetListOrders();
                }
                catch (TimeoutException timeout)
                {
                    dd.Abort();
                    MessageBox.Show("Serwer nie odpowiada");
                    return null;
                }
                catch (CommunicationException commException)
                {
                    dd.Abort();
                    MessageBox.Show("Błąd połaczenia z serwerem");
                    return null;
                }
                catch (Exception e)
                {
                    dd.Abort();
                    MessageBox.Show(e.Message);
                    return null;
                }
            }
        }

        public void m_AddSelectOrder(string s_FilePath, string s_FileName)
        {
           
            using (Service1Client dd = new Service1Client())
            {
                try
                {
                    byte[] array;
                    array = File.ReadAllBytes(s_FilePath);
                    dd.AddOrder(array, s_FileName);
                    dd.Close();
                }
                catch (TimeoutException timeout)
                {
                    dd.Abort();
                    MessageBox.Show("Serwer nie odpowiada");
                }
                catch (CommunicationException commException)
                {
                    dd.Abort();
                    MessageBox.Show("Błąd połaczenia z serwerem");
                }
                catch (Exception e)
                {
                    dd.Abort();
                    MessageBox.Show(e.Message);
                }
            }
        }
        #endregion
    }
}
