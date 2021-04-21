using Evercell.Core;
using Evercell.Mvvm.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Evercell
{
    class MainViewModel : ObservableObject
    {
        public ICommand SwitchToHomeCommand => new RelayCommand(() => SwitchTo(Home), () => true);

        public ICommand SwitchToSimulationCommand => new RelayCommand(() => SwitchTo(Simulation), () => true);

        public HomeViewModel Home { get; private set; }

        public SimulationViewModel Simulation { get; private set; }

        public object CurrentContext
        {
            get => GetValue<object>(nameof(CurrentContext));
            private set => SetValue(nameof(CurrentContext), value);
        }

        public MainViewModel()
        {
            Home = new HomeViewModel();
            Simulation = new SimulationViewModel();

            CurrentContext = Home;
        }

        private void SwitchTo(IContext context)
        {
            if (CurrentContext != context)
            {
                CurrentContext = context;
            }
        }
    }
}
