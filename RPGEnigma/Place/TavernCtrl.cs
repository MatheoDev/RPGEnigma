using System;
using System.Collections.Generic;
using RPGEnigma.Menu;

namespace RPGEnigma.Place
{
    public class TavernCtrl : IMenuItem
    {
        private List<string> _menuList = new List<string>();

        private MenuCtrl _menu;

        public TavernCtrl()
        {
            name = "TAVERNE";
            _menuList.Add("Se reposer");
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
            _menu.BuildMenu();
        }
    }
}
