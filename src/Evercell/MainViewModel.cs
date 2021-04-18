using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evercell
{
    class MainViewModel
    {
        public string ButtonText { get; private set; }

        public MainViewModel()
        {
            ButtonText = "This is the button text";
        }
    }
}
