using System;
using System.IO;
using System.Windows.Media.Imaging;

namespace Client_WPF_1._0
{
    class  C_GetImage
    {

       
        public BitmapImage m_GetImage(string id)
        {
            BitmapImage bitmap;
            string s_URL = @"file:///D:/Zdjecia/Zdjecia/" +id+ "/" + id + ".jpg";
            
            try
            {
                bitmap = new BitmapImage(new Uri(s_URL));
                return bitmap;
            }
            catch(Exception e)
            {
                return null;
            }
            if (File.Exists(s_URL))
            {
                bitmap = new BitmapImage(new Uri(s_URL));
                
            }
            else
            {
               bitmap = new BitmapImage(new Uri(@"Empty.png"));
            }


            return bitmap;
        }
    }
}
