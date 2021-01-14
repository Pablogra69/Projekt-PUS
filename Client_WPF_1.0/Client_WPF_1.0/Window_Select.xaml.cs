using System;
using System.Data;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace Client_WPF_1._0
{
    /// <summary>
    /// Interaction logic for Window_Select.xaml
    /// </summary>
    public partial class Window_Select : Window
    {
        public Window_Select()
        {
            InitializeComponent();
        }

        C_ResponseFromService responseFromService = new C_ResponseFromService();
        string[] TableCatalogEmpty;


        #region Buttons
        private void Button_Empty_Click(object sender, RoutedEventArgs e)
        {

            if (TableCatalogEmpty == null)
            {
                MessageBox.Show("Błąd, Dodaj produkty do listy...");
                return;
            }

            if (responseFromService.m_EmptyProduct(TableCatalogEmpty, 0))
            {
                MessageBox.Show("OK!!", "Operacja zakończona z sukcesem.");
            }
            else
            {
                MessageBox.Show("Błąd", "Wystąpił pewien błąd...");
            }

            Ean.Text = "";
            Ean.Focus();
        }

        private void Button_back_Click(object sender, RoutedEventArgs e)
        {

            this.Close();

        }

        private void button_Picture_Click(object sender, RoutedEventArgs e)
        {

            if (TableCatalogEmpty == null)
            {
                MessageBox.Show("Błąd, Dodaj produkty do listy...");
                return;
            }

            if (responseFromService.m_BadPicture(TableCatalogEmpty, 0))
            {
                MessageBox.Show("OK!!", "Operacja zakończona z sukcesem.");
            }
            else
            {
                MessageBox.Show("Błąd", "Wystąpił pewien błąd...");
            }

            Ean.Text = "";
            Ean.Focus();
        }

        private void Button_Shearch_Click(object sender, RoutedEventArgs e)
        {

            Window_SelectionList window_SelectionList = new Window_SelectionList();
            window_SelectionList.ShowDialog();

            string s_xml = Clipboard.GetText();
            Clipboard.Clear();

            if (s_xml.Contains(".xml"))
            {
                DataGridSQL.ItemsSource = (responseFromService.m_GetSelectOrder(s_xml).DefaultView);
            }

            Ean.Text = "";
            Ean.Focus();
        }

        private void Image_JPG_MouseDown(object sender, MouseButtonEventArgs e)
        {

            BitmapImage bitmap = new BitmapImage();
            DataRowView dataRowView = (DataRowView)((Image)e.Source).DataContext;
            string s_IndexRow = dataRowView[8].ToString();
            if (s_IndexRow != "")
                bitmap = new BitmapImage(new Uri(s_IndexRow));

            Window_Image window_Image = new Window_Image(bitmap);
            window_Image.ShowDialog();

            Ean.Text = "";
            Ean.Focus();
        }
        #endregion



        #region Events
        private void Ean_KeyDown(object sender, KeyEventArgs e)
        {

            //if (e.Key == Key.Enter)
            //{
            //    if (Ean.Text.Length == 13 & Ean.IsFocused)
            //    {
            //        ShearchEan(Ean.Text);
            //        Ean.Text = "";
            //    }
            //    else Ean.Text = "";
            //}

            if (e.Key == Key.Enter)
            {
                if (Ean.IsFocused)
                {
                    ShearchEan(Ean.Text);
                    
                }
                

                    Ean.Text = "";
                    Ean.Focus();
                

            }
        }

        private void CheckBox_Grid_Click(object sender, RoutedEventArgs e)
        {

            DataRowView dataRowView = (DataRowView)((CheckBox)e.Source).DataContext;
            CheckBox checkBox = (CheckBox)e.Source;
            bool isChecked = checkBox.IsChecked ?? false;

            if (TableCatalogEmpty == null)
                TableCatalogEmpty = new string[DataGridSQL.Items.Count];
            //Check list 
            if (isChecked == true)
            {
                foreach (string g in TableCatalogEmpty)
                {
                    if (g == dataRowView[1].ToString())
                    {
                        return;
                    }
                }

                for (int i = 0; i < TableCatalogEmpty.Length; i++)
                    if (TableCatalogEmpty[i] == null || TableCatalogEmpty[i] == "")
                    {
                        TableCatalogEmpty[i] = dataRowView[1].ToString();
                        return;
                    }
            }
            else //Delete record if exixis on list checked
            {
                for (int i = 0; i < TableCatalogEmpty.Length; i++)
                {
                    if (TableCatalogEmpty[i] == dataRowView[1].ToString())
                    {
                        TableCatalogEmpty[i] = "";
                        return;
                    }
                }
            }
            Ean.Text = "";
            Ean.Focus();

        }

        private void TextBox_Catalog_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.SystemKey == Key.F10)
            {
                AddNewLocation();
                Ean.Text = "";
                Ean.Focus();
            }

            if (e.Key == Key.Enter)
            {
                Ean.Text = "";
                Ean.Focus();
            }

        }

        private void TextBox_Catalog_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            TextBox_Catalog.SelectAll();
        }

        #endregion events
        private void AddNewLocation()
        {
            if (TextBox_Catalog.Text.Length < 4 || textBoxLocation_1.Text.Length < 3)
            {
                MessageBox.Show("Wprawdz poprawne dane lokalizacji lub katolgu");
                return;
            }
            else
            {
                TextBox_Catalog.Text = responseFromService.m_PutProduct(TextBox_Catalog.Text, textBoxLocation_1.Text, false);
            }





        }

        private void ShearchEan(string s_EAN)
        {

            try
            {
                for (int i = 0; i < DataGridSQL.Items.Count; i++)
                {
                    DataGridRow row = (DataGridRow)DataGridSQL.ItemContainerGenerator.ContainerFromIndex(i);

                    TextBlock cellContent = DataGridSQL.Columns[8].GetCellContent(row) as TextBlock;

                    if (cellContent != null && cellContent.Text.Equals(s_EAN))
                    {
                        object item = DataGridSQL.Items[i];
                        //DataGridSQL.SelectedItem = item;
                        DataGridSQL.ScrollIntoView(item);


                        row.Background = System.Windows.Media.Brushes.Pink;
                        row.MoveFocus(new TraversalRequest(FocusNavigationDirection.Next));
                        Ean.Focus();
                        break;
                    }
                }
            }
            catch (Exception e)
            {

            }

        }


    }
}
