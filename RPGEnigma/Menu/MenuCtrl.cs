using System;
using System.Collections.Generic;
using RPGEnigma.Utils;

namespace RPGEnigma.Menu
{
    public class MenuCtrl
    {
        private List<IMenuItem> _places;

        public MenuCtrl(List<IMenuItem> places, string question = "Où voulez vous aller ?")
        {
            _places = places;
            ConsoleUtils.WriteMenuConsole(_places);
            ChooseMenuItemAction(question);
        }

        public void ChooseMenuItemAction(string question)
        {
            int step = ConsoleUtils.AskPlayerReturnInt(question, 0, _places.Count);
            _places[step].InitItem();
        }
    }
}
