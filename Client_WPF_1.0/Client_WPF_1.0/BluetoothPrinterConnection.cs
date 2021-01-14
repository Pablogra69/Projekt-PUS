using Microsoft.Win32.SafeHandles;
using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;

namespace Client_WPF_1._0
{
    class BluetoothPrinterConnection
    {
        public void replaceParameterValuesZPL(string[] tabParamets)
        {
           // Encoding wind1252 = Encoding.GetEncoding(1252);
          //  Encoding utf8 = Encoding.UTF8;
          //  byte[] wind1252Bytes = wind1252.GetBytes("Ceżśćłóa");
            //byte[] utf8Bytes = Encoding.Convert(wind1252, utf8, wind1252Bytes);
           // string utf8String = Encoding.UTF8.GetString(utf8Bytes);

            string zplData = "! 0 200 200 240 1"
                + "PW 559\r\n"
                + "TONE 25\r\n"
                + "SPEED 2\r\n"
                + "SETFF 8 5\r\n"
                + "ON-FEED FEED\r\n"
                + "WAIT 8\r\n"
                + "POSTFEED 20\r\n"
                + "! U1 setvar “wlan.channel_mask” “0x1FFF”\r\n"
                + "JOURNAL\r\n"
                + "TEXT 5 1 70 0 123456789ABCDEFGHIJKLMNOPQRSTUVWX\r\n"
                + "BARCODE 128 1 1 50 70 143 EAN_Kod_kreskowy\r\n"
                + "T 5 3 322 122 ABCDEFGH\r\n"
                + "T 5 1 70 54 Pole_dodatkowe1\r\n"
                + "T 4 3 140 54 1234567\r\n"
                + "T 5 1 70 89 Cena:\r\n";
            if (tabParamets[8].Length == 7) zplData += "T 5 2 473 89 zl\r\n" + "FORM\r\n" + "PRINT\r\n";
            if (tabParamets[8].Length == 6) zplData += "T 5 2 430 89 zl\r\n" + "FORM\r\n" + "PRINT\r\n";
            if (tabParamets[8].Length == 5) zplData += "T 5 2 378 89 zl\r\n" + "FORM\r\n" + "PRINT\r\n";
            if (tabParamets[8].Length == 4) zplData += "T 5 2 328 89 zl\r\n" + "FORM\r\n" + "PRINT\r\n";
            if (tabParamets[8].Length == 3) zplData += "T 5 2 300 89 zl\r\n" + "FORM\r\n" + "PRINT\r\n";

            StringBuilder zpl = new StringBuilder();
            zpl.Append(zplData);
            zpl = zpl.Replace("123456789ABCDEFGHIJKLMNOPQRSTUVWX", tabParamets[1]);
            zpl = zpl.Replace("ABCDEFGH", tabParamets[3]);
            zpl = zpl.Replace("1234567", tabParamets[8]);
            zpl = zpl.Replace("EAN_Kod_kreskowy", tabParamets[4]);
            zpl = zpl.Replace("Pole_dodatkowe1", tabParamets[6]);

            Print(zpl.ToString());

        }


        [DllImport("kernel32.dll", SetLastError = true)]
        static extern SafeFileHandle CreateFile(string lpFileName, FileAccess dwDesiredAccess,
        uint dwShareMode, IntPtr lpSecurityAttributes, FileMode dwCreationDisposition,
        uint dwFlagsAndAttributes, IntPtr hTemplateFile);

        private void Print(string DataToPrint)
        {

            Byte[] buffer = new byte[DataToPrint.Length];
            buffer = System.Text.Encoding.ASCII.GetBytes(DataToPrint);

            SafeFileHandle printer = CreateFile("COM4:", FileAccess.ReadWrite, 0, IntPtr.Zero, FileMode.Open, 0, IntPtr.Zero);

            if (printer.IsInvalid == true)
            {
                return;
            }

            FileStream lpt1 = new FileStream(printer, FileAccess.ReadWrite);
            lpt1.Write(buffer, 0, buffer.Length);
            lpt1.Close();

        }
    }
}