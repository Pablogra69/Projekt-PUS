using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace Client_WPF_1._0
{
    
    public partial class Window_Image : Window
    {
        public Window_Image(BitmapImage image)
        {
            InitializeComponent();
            MyImage.Source = image;
        }

        private void MyImage_MouseDown(object sender, MouseButtonEventArgs e)
        {
            
            this.Close();
            
        }

        private void MyImage_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)  this.Close();
                
        }
    }
}
