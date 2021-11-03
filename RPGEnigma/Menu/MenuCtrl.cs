using System;
using System.Collections.Generic;
using RPGEnigma.Utils;

namespace RPGEnigma.Menu
{
    public class MenuCtrl
    {
        private List<IMenuItem> _places = new List<IMenuItem>();

        private List<string> _options = new List<string>();

        private string _question;

        public MenuCtrl(List<IMenuItem> places, string question = "Où voulez vous aller ?")
        {
            _places = places;
            _question = question;
        }

        public MenuCtrl(List<string> places, string question = "Où voulez vous aller ?")
        {
            _options = places;
            _question = question;
        }

        public bool DefineIsListIMenuItem()
        {
            if (_places.Count > 0)
            {
                return true;
            }
            return false;
        }

        public void ChooseMenuItemAction(string question)
        {
            int step = ConsoleUtils.AskPlayerReturnInt(question, 0, _places.Count);
            _places[step].InitItem();
        }

        public void BuildMenu()
        {
            if (DefineIsListIMenuItem())
            {
                ConsoleUtils.WriteMenuConsole(_places);
                ChooseMenuItemAction(_question);
            } else
            {
                ConsoleUtils.WriteMenuConsole(_options);
            }
        }
    }
}
