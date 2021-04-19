using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using CrystalFramework.Commands;
using Evercell.Options;

namespace Evercell
{
    class GameViewModel
    {
        public ICommand Comm => new CrystalCommand(SetSomething, () => true);

        public OptionsViewModel Menu { get; private set; }

        public string ButtonText { get; private set; }

        public GameViewModel()
        {
            ButtonText = "Open game menu";
            Menu = new OptionsViewModel();
        }

        private void SetSomething()
        {
            Menu.IsOpen = true;
        }
    }
}
