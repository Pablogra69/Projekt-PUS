using System.Windows;
using System.Windows.Controls;

namespace Client_WPF_1._0
{
    /// <summary>
    /// Interaction logic for Window_SelectionList.xaml
    /// </summary>
    public partial class Window_SelectionList : Window
    {
        public Window_SelectionList()
        {
            InitializeComponent();
            GetListOrders();
        }
        
        C_ResponseFromService responseFromService = new C_ResponseFromService();
        

        private void Button_DeleteOrder_Click(object sender, RoutedEventArgs e)
        {
            string s_SelectedOrederNew = "";
            string s_SelectedOrederOld = "";
            foreach (var item in ListBox_NewOrder.SelectedItems)
            {
                s_SelectedOrederNew = item.ToString();
            }
           

            foreach (var item in ListBox_OldOrder.SelectedItems)
            {
                s_SelectedOrederOld = item.ToString();
            }

            if (s_SelectedOrederNew != "")
            {
                ListBox_NewOrder.Items.RemoveAt(ListBox_NewOrder.SelectedIndex);
                responseFromService.m_DeleteOrder(s_SelectedOrederNew);
            }
                
            else
            {
                ListBox_OldOrder.Items.RemoveAt(ListBox_OldOrder.SelectedIndex);
                responseFromService.m_DeleteOrder(s_SelectedOrederOld);
            }

        }

        private void Button_SelectOrder_Click(object sender, RoutedEventArgs e)
        {
            
            string s_SelectedOrederNew = "";
            string s_SelectedOrederOld = "";
            foreach (var item in ListBox_NewOrder.SelectedItems)
            {
                s_SelectedOrederNew = item.ToString();
            }


            foreach (var item in ListBox_OldOrder.SelectedItems)
            {
                s_SelectedOrederOld = item.ToString();
            }

            if (s_SelectedOrederNew != "")
            {
                Clipboard.SetText(s_SelectedOrederNew);
            }

            else
            {
                Clipboard.SetText(s_SelectedOrederOld);
            }

           

            this.Close();

        }

        private void Button_Back_Click(object sender, RoutedEventArgs e)
        {
            Clipboard.SetText("");
            this.Close();

        }

        private void ButtonAddOrder_Click(object sender, RoutedEventArgs e)
        {
            
            string s_FilePath = string.Empty;
            string s_FileName = string.Empty;

            Microsoft.Win32.OpenFileDialog op = new Microsoft.Win32.OpenFileDialog();

            op.Filter = "Excel files (*.xml)|*.xml|All files (*.*)|*.*";
            op.FilterIndex = 1;
            op.RestoreDirectory = true;

            if (op.ShowDialog() == true)
            {
                s_FilePath = op.FileName;
                s_FileName = op.SafeFileName;
                
                responseFromService.m_AddSelectOrder(s_FilePath, s_FileName);
                ListBox_NewOrder.Items.Clear();
                ListBox_OldOrder.Items.Clear();
                GetListOrders();
            }

        }



        private void GetListOrders()
        {
            
            string[] list = responseFromService.m_GetListOrder();
            if (list == null)
            {
                return;
            }
            
            foreach (string item in list)
            {
                if (item.Contains("Wybrane")) ListBox_OldOrder.Items.Add(item);
                else ListBox_NewOrder.Items.Add(item);
            }

        }

        private void CheckBox_Click(object sender, RoutedEventArgs e)
        {
            

            ListBox_OldOrder.SelectedIndex = -1;
            var cb = sender as CheckBox;
            var item = cb.DataContext;

            
            ListBox_NewOrder.SelectedItem = item;
            
        }

        private void CheckBox_Click2(object sender, RoutedEventArgs e)
        {
            foreach (var temp in ListBox_NewOrder.SelectedItems)
            {
                
            }

            ListBox_NewOrder.SelectedIndex = -1;
            

            var cb = sender as CheckBox;
            var item = cb.DataContext;

            ListBox_OldOrder.SelectedItem = item;
            

        }

    }
}
