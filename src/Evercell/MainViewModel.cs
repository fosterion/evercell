using Evercell.Controllers;
using Evercell.Core;
using Evercell.Enums;
using Evercell.Interfaces;
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
        private ThemeController _theme;

        private HomeViewModel _home;
        private SimulationViewModel _sim;
        private SavedViewModel _save;

        public ICommand SwitchToHomeCommand => new RelayCommand(() => SwitchContextTo(_home));
        public ICommand SwitchToSimulationCommand => new RelayCommand(() => SwitchContextTo(_sim));
        public ICommand SwitchToSavedCommand => new RelayCommand(() => SwitchContextTo(_save));
        public ICommand SwitchSettingsVisibilityCommand => new RelayCommand(SwitchSettingsVisibility);
        public ICommand SwitchThemeCommand => new RelayCommand(SwitchTheme);
        public ICommand ExitCommand => new RelayCommand(Exit);

        public object CurrentContext
        {
            get => GetValue<object>();
            private set => SetValue(value);
        }

        public string SettingsText
        {
            get => GetValue<string>();
            private set => SetValue(value);
        }

        public bool IsSettingsOpen
        {
            get => GetValue<bool>();
            private set => SetValue(value);
        }

        public MainViewModel()
        {
            _theme = new ThemeController();
            _home = new HomeViewModel();
            _sim = new SimulationViewModel();
            _save = new SavedViewModel();

            

            CurrentContext = _home;
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

        private void SwitchTheme()
        {
            _theme.SwitchTheme();
        }

        private void Exit()
        {
            Environment.Exit(0);
        }
    }
}
