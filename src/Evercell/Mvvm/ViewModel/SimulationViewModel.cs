using Evercell.Core;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace Evercell.Mvvm.ViewModel
{
    class SimulationViewModel : ObservableObject, IContext
    {
        private Graphics graphics;

        public ICommand NextStep => new RelayCommand(CreateBitmap);

        public Bitmap ImageSource
        {
            get => GetValue<Bitmap>(nameof(ImageSource));
            private set => SetValue(nameof(ImageSource), value);
        }

        public SimulationViewModel()
        {

        }

        private void CreateBitmap()
        {
            ImageSource = new Bitmap(500, 500);
            graphics = Graphics.FromImage(ImageSource);
            graphics.FillRectangle(Brushes.Red, 0, 0, 250, 250);
        }
    }
}
