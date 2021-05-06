using Evercell.Enums;
using Evercell.Extensions;
using System;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Media;

namespace Evercell.Controllers
{
    class ThemeController
    {
        private ThemeStyle currentTheme;

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

        internal void SwitchTheme()
        {
            if (currentTheme is ThemeStyle.LightTheme)
            {
                SetDarkTheme();
            }
            else
            {
                SetLightTheme();
            }
        }

        private void SetLightTheme()
        {
            LogoColor = SetColor("#272537");
            ShellColor = SetColor("#F5F5F5");
            ContentColor = SetColor("#E1E4E6");
            ButtonHoverColor = SetColor("#E1E4E6");
            ButtonHoverTextColor = new SolidColorBrush(Colors.Gray);
            ButtonSelectedColor = SetColor("#E1E4E6");
            ButtonSelectedTextColor = SetColor(ThemeColor.Teal);

            currentTheme = ThemeStyle.LightTheme;
        }

        private void SetDarkTheme()
        {
            LogoColor = SetColor(ThemeColor.Teal); // new SolidColorBrush(Colors.Teal);
            ShellColor = SetColor("#272537");
            ContentColor = SetColor("#22202F");
            ButtonHoverColor = SetColor("#22202F");
            ButtonHoverTextColor = SetColor("#808080");
            ButtonSelectedColor = SetColor("#22202F");
            ButtonSelectedTextColor = SetColor(ThemeColor.Teal);

            currentTheme = ThemeStyle.DarkTheme;
        }

        private SolidColorBrush SetColor(string hex)
        {
            return (SolidColorBrush)new BrushConverter().ConvertFromString(hex);
        }

        private SolidColorBrush SetColor(ThemeColor color)
        {
            var hex = color.GetDescription();
            return (SolidColorBrush)new BrushConverter().ConvertFromString(hex);
        }
    }
}
