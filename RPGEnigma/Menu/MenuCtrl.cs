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
            ChooseMenuItemAction();
        }

        public void ChooseMenuItemAction()
        {
            int step = ConsoleUtils.AskPlayerReturnInt("Où voulez vous aller ?", 0, _places.Count);
            _places[step].InitItem();
        }
    }
}
