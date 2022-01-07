using System;
using System.Collections.Generic;
using RPGEnigma.Utils;

namespace RPGEnigma.Menu
{
    /**
     * Classe MenuCtrl
     * Défini le corps d'un menu
     * Le menu à plusieurs possibilités dont être une List de String ou IMenuItem
     */
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

        /**
         * Surchage de constructeur afin de faire le choix du menu en question
         */
        public MenuCtrl(List<string> places, string question = "Où voulez vous aller ?")
        {
            _options = places;
            _question = question;
        }

        /**
         * Défini si le menu est de quelle List
         */
        public bool DefineIsListIMenuItem()
        {
            if (_places.Count > 0)
            {
                return true;
            }
            return false;
        }

        /**
         * Quand le menu est List<IMenuItem> on utilise la fonction de l'interface pour l'index saisi
         */
        public void ChooseMenuItemAction(string question)
        {
            int step = ConsoleUtils.AskPlayerReturnInt(question, 0, _places.Count);
            _places[step].InitItem();
        }

        /**
         * Permet de construire le menu en console et demande à l'utilisateur que faire
         */
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
