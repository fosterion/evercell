using Evercell.Core;
using Evercell.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace Evercell.Mvvm.ViewModel
{
    class ThemeViewModel : ObservableObject
    {
        public Brush LogoTextColor
        {
            get => GetValue<Brush>(nameof(LogoTextColor));
            set => SetValue(nameof(LogoTextColor), value);
        }

        public Brush ShellColor
        {
            get => GetValue<Brush>(nameof(ShellColor));
            set => SetValue(nameof(ShellColor), value);
        }

        public Brush ContentColor
        {
            get => GetValue<Brush>(nameof(ContentColor));
            set => SetValue(nameof(ContentColor), value);
        }

        public Brush ButtonOverlayColor
        {
            get => (SolidColorBrush)Application.Current.Resources["DynButtonOverlayColor"];
            set => Application.Current.Resources["DynButtonOverlayColor"] = value;
        }

        public Brush ButtonOverlayTextColor
        {
            get => (SolidColorBrush)Application.Current.Resources["DynButtonOverlayTextColor"];
            set => Application.Current.Resources["DynButtonOverlayTextColor"] = value;
        }

        public Brush ButtonSelectedColor
        {
            get => (SolidColorBrush)Application.Current.Resources["DynButtonSelectedColor"];
            set => Application.Current.Resources["DynButtonSelectedColor"] = value;
        }

        public Brush ButtonSelectedTextColor
        {
            get => (SolidColorBrush)Application.Current.Resources["DynButtonSelectedTextColor"];
            set => Application.Current.Resources["DynButtonSelectedTextColor"] = value;
        }

        public ThemeViewModel()
        {
            SetLightTheme();
        }

        internal void SwitchTo(ThemeStyle style)
        {
            switch (style)
            {
                case ThemeStyle.LightTheme:
                    SetLightTheme();
                    break;
                case ThemeStyle.DarkTheme:
                    SetDarkTheme();
                    break;
                default:
                    throw new NotImplementedException("Unknown theme style");
            }
        }

        private void SetLightTheme()
        {
            LogoTextColor = ToSolidColorBrush("#F5F5F5");
            ShellColor = ToSolidColorBrush("#F5F5F5");
            ContentColor = ToSolidColorBrush("#E1E4E6");
            ButtonOverlayColor = ToSolidColorBrush("#E1E4E6");
            ButtonOverlayTextColor = new SolidColorBrush(Colors.Gray);
            ButtonSelectedColor = ToSolidColorBrush("#E1E4E6");
            ButtonSelectedTextColor = new SolidColorBrush(Colors.Teal);
        }

        private void SetDarkTheme()
        {
            LogoTextColor = new SolidColorBrush(Colors.Teal);
            ShellColor = ToSolidColorBrush("#272537");
            ContentColor = ToSolidColorBrush("#22202F");
            ButtonOverlayColor = ToSolidColorBrush("#22202F");
            ButtonOverlayTextColor = new SolidColorBrush(Colors.Gray);
            ButtonSelectedColor = ToSolidColorBrush("#22202F");
            ButtonSelectedTextColor = new SolidColorBrush(Colors.Teal);
        }

        private SolidColorBrush ToSolidColorBrush(string hexCode)
        {
            return (SolidColorBrush)new BrushConverter().ConvertFromString(hexCode);
        }
    }
}
