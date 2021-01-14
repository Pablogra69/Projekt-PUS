using System;
using System.Data;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace Client_WPF_1._0
{

    public partial class Window_LocationControl : Window
    {
        public Window_LocationControl()
        {
            InitializeComponent();

            textBoxLocation_1.Focus();


        }
        string[] TableCatalogEmpty;
        C_ResponseFromService c_responseFromService = new C_ResponseFromService();

        #region Buttons
        private void Button_back_Click(object sender, RoutedEventArgs e)
        {

            this.Close();

        }

        private void Button_Shearch_Click(object sender, RoutedEventArgs e)
        {

            operationSelect();
            Ean.Focus();

        }

        private void Button_Empty_Click(object sender, RoutedEventArgs e)
        {

            if (TableCatalogEmpty == null)
            {
                MessageBox.Show("Błąd, Dodaj produkty do listy...");
                return;
            }

            if (c_responseFromService.m_EmptyProduct(TableCatalogEmpty, 0))
            {
                MessageBox.Show("OK!!", "Operacja zakończona z sukcesem.");
            }
            else
            {
                MessageBox.Show("Błąd", "Wystąpił pewien błąd...");
            }

            Ean.Focus();

        }

        private void button_Picture_Click(object sender, RoutedEventArgs e)
        {

            if (TableCatalogEmpty == null)
            {
                MessageBox.Show("Błąd, Dodaj produkty do listy...");
                return;
            }

            if (c_responseFromService.m_BadPicture(TableCatalogEmpty, 0))
            {
                MessageBox.Show("OK!!", "Operacja zakończona z sukcesem.");
            }
            else
            {
                MessageBox.Show("Błąd", "Wystąpił pewien błąd...");
            }

            Ean.Focus();

        }

        private void Image_JPG_MouseDown(object sender, MouseButtonEventArgs e)
        {

            BitmapImage bitmap = new BitmapImage();
            DataRowView dataRowView = (DataRowView)((Image)e.Source).DataContext;
            string s_IndexRow = dataRowView[8].ToString();

            if (s_IndexRow != "")
            {
                bitmap = new BitmapImage(new Uri(s_IndexRow));
            }

            Window_Image window_Image = new Window_Image(bitmap);
            window_Image.ShowDialog();

            Ean.Focus();

        }

        #endregion


        public void operationSelect()
        {

            C_ResponseFromService c_Response = new C_ResponseFromService();
            DataTable dataTable;

            try
            {
                if (textBoxLocation_1.Text != "" & textBoxLocation_2.Text != "" & textBoxLocation_3.Text != "")
                {

                    dataTable = (c_Response.m_GetListProduct(textBoxLocation_1.Text + "-"
                    + textBoxLocation_2.Text + "-" + textBoxLocation_3.Text));

                    if (dataTable != null)
                        DataGridSQL.ItemsSource = dataTable.DefaultView;

                }

                else if (textBoxLocation_1.Text != "" & textBoxLocation_2.Text != "")
                {
                    dataTable = (c_Response.m_GetListProduct(textBoxLocation_1.Text + "-"
                   + textBoxLocation_2.Text));

                    if (dataTable != null)
                        DataGridSQL.ItemsSource = dataTable.DefaultView;
                }

                else if (textBoxLocation_1.Text != "")
                {
                    dataTable = (c_Response.m_GetListProduct(textBoxLocation_1.Text));

                    if (dataTable != null)
                        DataGridSQL.ItemsSource = dataTable.DefaultView;
                }
                else return;
            }
            catch (Exception e)
            {

            }

        }

        private void ShearchEan(string s_EAN)
        {

            try
            {
                for (int i = 0; i < DataGridSQL.Items.Count; i++)
                {
                    DataGridRow row = (DataGridRow)DataGridSQL.ItemContainerGenerator.ContainerFromIndex(i);

                    TextBlock cellContent = DataGridSQL.Columns[7].GetCellContent(row) as TextBlock;

                    if (cellContent != null && cellContent.Text.Equals(s_EAN))
                    {
                        object item = DataGridSQL.Items[i];
                        DataGridSQL.SelectedItem = item;
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



        #region events
        private void CheckBox_Grid_Click(object sender, RoutedEventArgs e)
        {
            if (TableCatalogEmpty == null)
                TableCatalogEmpty = new string[DataGridSQL.Items.Count];

            DataRowView dataRowView = (DataRowView)((CheckBox)e.Source).DataContext;
            CheckBox checkBox = (CheckBox)e.Source;
            bool isChecked = checkBox.IsChecked ?? false;

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
            else
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

            Ean.Focus();

        }

        private void OnKeyDownHandler(object sender, KeyEventArgs e)
        {
            


            if (e.Key == Key.Enter)
            {
                operationSelect();
                Ean.Text = "";
                Ean.Focus();
            }
        }

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

        #endregion
    }
}
