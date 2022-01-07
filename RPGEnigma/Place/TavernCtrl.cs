using System;
using System.Collections.Generic;
using RPGEnigma.Game;
using RPGEnigma.Menu;
using RPGEnigma.Utils;

namespace RPGEnigma.Place
{
    /**
     * Classe gerant la taverne
     */
    public class TavernCtrl : IMenuItem
    {
        private List<string> _menuList = new List<string>();

        private MenuCtrl _menu;

        public TavernCtrl()
        {
            name = "TAVERNE";
            _menuList.Add("Se reposer -> 25");
            _menuList.Add("Retourner au menu");
            _menu = new MenuCtrl(_menuList);
        }

        public string name
        {
            get; set;
        }

        public void InitItem()
        {
            Console.Clear();
            Console.WriteLine("--- TAVERN ---");
            Console.WriteLine("Point de vie de votre héros : {0}/{1}", GameHome.Party.Hero.Pv, GameHome.Party.Hero.PvMax);
            _menu.BuildMenu();
            WaitAction();
        }

        /**
         * Attend l'action du joueur
         * Soit on se repose pour 25$ et on récupère tout ses points de vie
         * Soit on retourne au menu
         */
        private void WaitAction()
        {
            int action = ConsoleUtils.AskPlayerReturnInt("Que voulez vous faire ?", 0, 2);
            if (action == 0)
            {
                GameHome.Hero.Money = GameHome.Party.Hero.Money - 25;
                GameHome.Hero.Pv = GameHome.Hero.PvMax;
                Console.Clear();
                Console.WriteLine("Vous vous êtes reposé pour 25$\nAppuyez sur une touche pour continuer");
                Console.Read();
                RouteCtrl._home.InitItem();
            } else
            {
                RouteCtrl._home.InitItem();
            }
        }
    }
}
