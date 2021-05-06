using Evercell.Core;
using Evercell.Interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media.Imaging;

namespace Evercell.Mvvm.ViewModel
{
    class SimulationViewModel : ObservableObject, IContext
    {
        private Graphics graphics;

        public ICommand NextStep => new RelayCommand(CreateBitmap);

        public BitmapImage ImageSource
        {
            get => GetValue<BitmapImage>();
            private set => SetValue(value);
        }

        public SimulationViewModel()
        {

        }

        private void CreateBitmap()
        {
            ImageSource = new BitmapImage(new Uri(@"", UriKind.Absolute));
            var src = BitmapImage2Bitmap(ImageSource);
            graphics = Graphics.FromImage(src);
            graphics.FillRectangle(Brushes.Red, 0, 0, 250, 250);
            ImageSource = Bitmap2BitmapImage(src);
        }

        private Bitmap BitmapImage2Bitmap(BitmapImage bitmapImage)
        {
            using (MemoryStream outStream = new MemoryStream())
            {
                BitmapEncoder enc = new BmpBitmapEncoder();
                enc.Frames.Add(BitmapFrame.Create(bitmapImage));
                enc.Save(outStream);
                Bitmap bitmap = new Bitmap(outStream);

                return new Bitmap(bitmap);
            }
        }

        [System.Runtime.InteropServices.DllImport("gdi32.dll")]
        public static extern bool DeleteObject(IntPtr hObject);

        private BitmapImage Bitmap2BitmapImage(Bitmap bitmap)
        {
            IntPtr hBitmap = bitmap.GetHbitmap();
            BitmapImage retval;

            try
            {
                retval = (BitmapImage)Imaging.CreateBitmapSourceFromHBitmap(
                             hBitmap,
                             IntPtr.Zero,
                             Int32Rect.Empty,
                             BitmapSizeOptions.FromEmptyOptions());
            }
            finally
            {
                DeleteObject(hBitmap);
            }

            return retval;
        }
    }
}
