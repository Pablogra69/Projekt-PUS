using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace Client_WPF_1._0
{
  
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            C_CheckConnectionWiFi _CheckConnectionWiFi = new C_CheckConnectionWiFi();
            //System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls;

            //if(_CheckConnectionWiFi.CheckForInternetConnection()== false)
            //{

            //        MessageBox.Show("Brak połączenia z internetem");
            //        this.Close();

            //}

            //if (c_Response.m_IsServerConnect() == false)
            //{

            //    MessageBox.Show("Brak połączenia z serwerem");
            //    this.Close();

            //}
            textboxactive();
          
        }



        string[] tablica;
        C_ResponseFromService c_Response = new C_ResponseFromService();
        BitmapImage bitmap;


        #region Buttons

        private void Button_Back_Click(object sender, RoutedEventArgs e)
        {
            this.Close();

        }
        private void Button_Scan_Click(object sender, RoutedEventArgs e)
        {

            m_SelectProduct();
            m_GetImage(textBoxCatalog.Text);
            
            textboxactive();

        }

        private void Button_Location_Change_Click(object sender, RoutedEventArgs e)
        {

            m_PutLocation();
            textboxactive();

        }

        private void Button_Location_List_Click(object sender, RoutedEventArgs e)
        {
            Window_LocationControl window_LocationControl = new Window_LocationControl();
            window_LocationControl.ShowDialog();
        }

        private void Button_Print_Click(object sender, RoutedEventArgs e)
        {
            if (textBoxCatalog.Text == "") return;

            BluetoothPrinterConnection bluetoothPrinterConnection = new BluetoothPrinterConnection();
            bluetoothPrinterConnection.replaceParameterValuesZPL(tablica);

            textboxactive();
        }

        private void Button_Empty_Click(object sender, RoutedEventArgs e)
        {
            if (textBoxCatalog.Text == "")
            {
                MessageBox.Show("Błąd, wyszukaj produkt...");
                textboxactive();
                return;
            }
            string[] tempArray = new string[1];
            tempArray[0] = textBoxCatalog.Text;
            if (c_Response.m_EmptyProduct(tempArray, 0))
            {
                MessageBox.Show("OK!!", "Operacja zakończona z sukcesem.");
            }
            else
            {
                MessageBox.Show("Błąd", "Wystąpił pewien błąd...");
            }


            textboxactive();
        } 
         
        private void Button_Selection_Click(object sender, RoutedEventArgs e)
        {
            Window_Select window_Select = new Window_Select();
            window_Select.ShowDialog();
            textboxactive();
        }

        private void Button_BadImage_Click(object sender, RoutedEventArgs e)
        {
            if (textBoxCatalog.Text == "")
            {
                MessageBox.Show("Błąd, wyszukaj produkt...");
                textboxactive();
                return;
            }

            string[] tempArray = new string[1];
            tempArray[0] = textBoxCatalog.Text;

            if (c_Response.m_BadPicture(tempArray, 0))
            {
                MessageBox.Show("OK!!", "Operacja zakończona z sukcesem.");
            }
            else
            {
                MessageBox.Show("Błąd", "Wystąpił pewien błąd...");
            }


            textboxactive();
        }

        private void Button_ShowList_Click(object sender, RoutedEventArgs e)
        {
            Window_ListPictureEmpty window_List = new Window_ListPictureEmpty();
            window_List.ShowDialog();

            textboxactive();
        }

        private void Image_JPG_MouseDown(object sender, MouseButtonEventArgs e)
        {

            Window_Image window_Image = new Window_Image(bitmap);
            window_Image.ShowDialog();

            textboxactive();
        }
        #endregion



        private void textboxactive()
        {

            textBoxActive.Text = "";
            
            
            textBoxActive.Focus();
            textBoxActive.SelectAll();

        }

        public void m_GetImage(string id)
        {
            
            C_GetImage c_GetImage = new C_GetImage();
            bitmap = c_GetImage.m_GetImage(id);
            Image_JPG.Source = bitmap;

        }

        private void m_PutLocation()
        {
            
            if (textBoxCatalog.Text == "" || textBoxLocation.Text == "") return;
            textBoxLocation.Text = (c_Response.m_PutProduct(tablica[0], textBoxLocation.Text, true));
            
            textboxactive();

        }

        public void m_SelectProduct()
        {


            
            if (textBoxActive.Text == "") return;

            if (RadioButton_Ean.IsChecked == true)
                tablica = c_Response.m_GetProduct(textBoxActive.Text, 1);

            if (RadioButton_Catalog.IsChecked == true)
                tablica = c_Response.m_GetProduct(textBoxActive.Text, 0);

            if (tablica == null) return;


            if (tablica[1] != null) tablica[1] = tablica[1].Replace('ą', 'a').Replace('Ć', 'C').Replace('ć', 'c').Replace('ę', 'e').Replace('ł', 'l').Replace('ń', 'n').Replace('ó', 'o').Replace('ś', 's').Replace('Ś', 's').Replace('ź', 'z').Replace('Ź', 'Z').Replace('ż', 'z').Replace('Ż', 'Z').Replace('Ł', 'L');
            textBoxName.Text = tablica[1];
            textBoxValue.Text = tablica[2];
            textBoxValueBook.Text = tablica[9];
            textBoxCatalog.Text = tablica[3];
            textBoxBarCode.Text = tablica[4];
            textBoxLocation.Text = tablica[5];
            labelPrice.Content = tablica[8] + " zł";
            textBoxActive.Text = "123456";

            if (textBoxCatalog.Text != null)
                m_GetImage(textBoxCatalog.Text);

            textBoxActive.SelectAll();

            textboxactive();

        }



        private void OnKeyDownHandler(object sender, KeyEventArgs e)
        {
            
            if (e.Key == Key.Enter & textBoxActive.IsFocused) m_SelectProduct();
            

        }

        private void textBoxLocation_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.Key == Key.Enter)
            {
                m_PutLocation();
                textboxactive();
            }

        }

        private void RadioButton_Catalog_Click(object sender, RoutedEventArgs e)
        {
            textboxactive();
        }
    }
}
