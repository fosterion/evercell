using Evercell.Core;
using Evercell.Enums;
using Evercell.Mvvm.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media;

namespace Evercell
{
    class MainViewModel : ObservableObject
    {
        public ICommand SwitchToHomeCommand => new RelayCommand(() => SwitchContextTo(Home));

        public ICommand SwitchToSimulationCommand => new RelayCommand(() => SwitchContextTo(Simulation));

        public ICommand SwitchToSavedCommand => new RelayCommand(() => SwitchContextTo(Saved));

        public ICommand SwitchSettingsVisibilityCommand => new RelayCommand(SwitchSettingsVisibility);

        public ICommand ExitCommand => new RelayCommand(Exit);

        public HomeViewModel Home { get; private set; }

        public SimulationViewModel Simulation { get; private set; }

        public SavedViewModel Saved { get; private set; }

        public ThemeViewModel Theme { get; private set; }

        public object CurrentContext
        {
            get => GetValue<object>(nameof(CurrentContext));
            private set => SetValue(nameof(CurrentContext), value);
        }

        public string SettingsText
        {
            get => GetValue<string>(nameof(SettingsText));
            private set => SetValue(nameof(SettingsText), value);
        }

        public bool IsSettingsOpen
        {
            get => GetValue<bool>(nameof(IsSettingsOpen));
            private set => SetValue(nameof(IsSettingsOpen), value);
        }

        public MainViewModel()
        {
            Home = new HomeViewModel();
            Simulation = new SimulationViewModel();
            Saved = new SavedViewModel();

            Theme = new ThemeViewModel();

            CurrentContext = Home;
            SettingsText = "Open settings";
        }

        private void SwitchContextTo(IContext context)
        {
            if (CurrentContext != context)
            {
                CurrentContext = context;
            }
        }

        private void SwitchSettingsVisibility()
        {
            IsSettingsOpen ^= true;

            if (IsSettingsOpen)
                SettingsText = "Close settings";
            else
                SettingsText = "Open settings";
        }

        private void Exit()
        {
            Theme.SwitchTo(ThemeStyle.DarkTheme);
            //Environment.Exit(0);
        }
    }
}
