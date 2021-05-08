using Evercell.Core;
using Evercell.Interfaces;
using Evercell.Mvvm.Model;
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

namespace Evercell.Mvvm.ViewModel
{
    class SimulationViewModel : ObservableObject, IContext
    {
        public Cell[,] Source;

        public SimulationViewModel()
        {
            Source = new Cell[50, 50];

            for (int i = 0; i < Source.Length / 50; i++)
            {
                Source[i, i] = new Cell()
                {
                    Color = Brushes.Aquamarine,
                    IsAlive = true
                };
            }
        }
    }
}
