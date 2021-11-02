using System;
using System.Collections.Generic;
using RPGEnigma.Utils;

namespace RPGEnigma.Menu
{
    public class MenuCtrl
    {
        private List<IMenuItem> _places;

        private string _question;

        public MenuCtrl(List<IMenuItem> places, string question = "Où voulez vous aller ?")
        {
            _places = places;
            _question = question;

        }

        public void ChooseMenuItemAction(string question)
        {
            int step = ConsoleUtils.AskPlayerReturnInt(question, 0, _places.Count);
            _places[step].InitItem();
        }

        public void BuildMenu()
        {
            ConsoleUtils.WriteMenuConsole(_places);
            ChooseMenuItemAction(_question);
        }
    }
}
