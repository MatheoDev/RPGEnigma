using System;
using System.Collections.Generic;
using RPGEnigma.Utils;

namespace RPGEnigma.Menu
{
    public class MenuCtrl
    {
        private List<IMenuItem> _places;

        public MenuCtrl(List<IMenuItem> places)
        {
            _places = places;
            ConsoleUtils.WriteMenuConsole(_places);
        }
    }
}
