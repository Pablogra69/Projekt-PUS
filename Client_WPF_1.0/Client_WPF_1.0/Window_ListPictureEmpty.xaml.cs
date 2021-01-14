using System;
using System.Windows;

namespace Client_WPF_1._0
{
    
    public partial class Window_ListPictureEmpty : Window
    {
        public Window_ListPictureEmpty()
        {
           
            InitializeComponent();
            getListPictures();
            getListProduct();
          
        }
        
        C_ResponseFromService c_Response = new C_ResponseFromService();


        private void Button_Back_Click(object sender, RoutedEventArgs e)
        {
            
            this.Close();
           
        }

        private void Button_ProductModify_Click(object sender, RoutedEventArgs e)
        {
           
            string[] arrayTemp = TextBlock_Product.Text.Split(new string[] { System.Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            

            c_Response.m_EmptyProduct(arrayTemp, 2);

        }

        private void Button_PictureModify_Click(object sender, RoutedEventArgs e)
        {
            
            string[] arrayTemp = TextBlock_Picture.Text.Split(new string[] { System.Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            c_Response.m_BadPicture(arrayTemp, 2);

        }

        public void getListProduct()
        {
            string[] arrayTemp = c_Response.m_GetListProductsEmpty();

            if (arrayTemp == null) return;
            foreach (string g in arrayTemp)
            {
                if (g == null || g == "") return;
                else TextBlock_Product.Text += g + Environment.NewLine;
            }

        }

        public void getListPictures()
        {
            
            string[] arrayTemp = c_Response.m_GetListPicture();

            if (arrayTemp == null) return;

            foreach (string g in arrayTemp)
            {
                if (g == null || g == "") return;
                else TextBlock_Picture.Text += g + Environment.NewLine;
            }

        }

    }
    
}
