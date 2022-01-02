using System;
using System.Collections.Generic;
using RPGEnigma.Game;
using RPGEnigma.Menu;
using RPGEnigma.Service;
using RPGEnigma.Utils;

namespace RPGEnigma.Place
{
    public class TownhallCtrl : IMenuItem
    {
        private List<string> _menuList = new List<string>();

        private MenuCtrl _menu;

        public TownhallCtrl()
        {
            name = "MAIRIE";
            _menuList.Add("Sauvegarder la partie");
            _menuList.Add("Retourner au menu");
            _menu = new MenuCtrl(_menuList);
        }

        public string name { get; set; }

        public void InitItem()
        {
            Console.Clear();
            Console.WriteLine("--- MAIRIE ---");
            _menu.BuildMenu();
            WaitAction();
        }

        private void WaitAction()
        {
            int action = ConsoleUtils.AskPlayerReturnInt("Voulez vous sauvegarder ?", 0, 2);
            if (action == 0)
            {
                GetRequest.SavePart(GameHome.Party.Hero);
                Console.Clear();
                Console.WriteLine("Vous avez sauvegardé la partie\nAppuyez sur une touche pour continuer");
                Console.Read();
                RouteCtrl._home.InitItem();
            } else
            {
                RouteCtrl._home.InitItem();
            }
        }
    }
}
