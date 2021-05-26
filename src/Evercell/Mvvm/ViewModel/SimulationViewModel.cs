using Evercell.Core;
using Evercell.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Media;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media.Imaging;
using System.Data;

namespace Evercell.Mvvm.ViewModel
{
    class SimulationViewModel : ObservableObject, IContext
    {
        public BitmapSource VisualField { get; set; }

        public SimulationViewModel()
        {
            NewMethod3();
        }

        private void NewMethod2()
        {
            double dpi = 96;
            int width = 128;
            int height = 128;
            byte[] pixelData = new byte[width * height];

            for (int y = 0; y < height; y++)
            {
                int yIndex = y * width;
                for (int x = 0; x < width; x++)
                {
                    pixelData[x + yIndex] = (byte)(x + y);
                }
            }

            BitmapSource bmpSource = BitmapSource.Create(width, height, dpi, dpi,
                PixelFormats.Gray8, null, pixelData, width);

            VisualField = bmpSource;
        }

        private void NewMethod3()
        {
            Color[,] colorArray = new Color[3, 3];

            for (int i = 0; i < 3; ++i)
            {
                colorArray[0, i] = Colors.Red;
                colorArray[1, i] = Colors.Green;
                colorArray[2, i] = Colors.Blue;

            }
            var height = colorArray.GetUpperBound(0) + 1;
            var width = colorArray.GetUpperBound(1) + 1;
            var pixelFormat = PixelFormats.Bgra32;
            var stride = width * 4; // bytes per row

            byte[] pixelData = new byte[height * stride];

            for (int y = 0; y < height; ++y)
            {
                for (int x = 0; x < width; ++x)
                {
                    var color = colorArray[y, x];
                    var index = (y * stride) + (x * 4);

                    pixelData[index] = color.B;
                    pixelData[index + 1] = color.G;
                    pixelData[index + 2] = color.R;
                    pixelData[index + 3] = color.A; // color.A;
                }
            }

            var bitmap = BitmapSource.Create(width, height, 96, 96, pixelFormat, null, pixelData, stride);
            VisualField = bitmap;
        }
    }
}
