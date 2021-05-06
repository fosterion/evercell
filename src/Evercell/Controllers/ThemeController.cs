using Evercell.Core;
using Evercell.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace Evercell.Controllers
{
    class ThemeController
    {
        public Brush LogoColor
        {
            get => GetBrush();
            set => SetBrush(value);
        }

        public Brush ShellColor
        {
            get => GetBrush();
            set => SetBrush(value);
        }

        public Brush ContentColor
        {
            get => GetBrush();
            set => SetBrush(value);
        }

        public Brush ButtonHoverColor
        {
            get => GetBrush();
            set => SetBrush(value);
        }

        public Brush ButtonHoverTextColor
        {
            get => GetBrush();
            set => SetBrush(value);
        }

        public Brush ButtonSelectedColor
        {
            get => GetBrush();
            set => SetBrush(value);
        }

        public Brush ButtonSelectedTextColor
        {
            get => GetBrush();
            set => SetBrush(value);
        }

        private Brush GetBrush([CallerMemberName] string resource = null)
        {
            return (SolidColorBrush)Application.Current.Resources[resource];
        }

        private void SetBrush(Brush value, [CallerMemberName] string resource = null)
        {
            Application.Current.Resources[resource] = value;
        }

        public ThemeController()
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
            LogoColor = ToSolidColorBrush("#272537");
            ShellColor = ToSolidColorBrush("#F5F5F5");
            ContentColor = ToSolidColorBrush("#E1E4E6");
            ButtonHoverColor = ToSolidColorBrush("#E1E4E6");
            ButtonHoverTextColor = ToSolidColorBrush("#808080");
            ButtonSelectedColor = ToSolidColorBrush("#E1E4E6");
            ButtonSelectedTextColor = ToSolidColorBrush("#008080");
        }

        private void SetDarkTheme()
        {
            LogoColor = ToSolidColorBrush("#008080"); // new SolidColorBrush(Colors.Teal);
            ShellColor = ToSolidColorBrush("#272537");
            ContentColor = ToSolidColorBrush("#22202F");
            ButtonHoverColor = ToSolidColorBrush("#22202F");
            ButtonHoverTextColor = ToSolidColorBrush("#808080");
            ButtonSelectedColor = ToSolidColorBrush("#22202F");
            ButtonSelectedTextColor = ToSolidColorBrush("#008080");
        }

        private SolidColorBrush ToSolidColorBrush(string hexCode)
        {
            return (SolidColorBrush)new BrushConverter().ConvertFromString(hexCode);
        }
    }
}
