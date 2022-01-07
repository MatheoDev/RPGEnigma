using System;
using System.Collections.Generic;
using RPGEnigma.Game;
using RPGEnigma.Menu;
using RPGEnigma.Place.Shop;
using RPGEnigma.Utils;

namespace RPGEnigma.Place
{
    public class HomeCtrl : IMenuItem
    {
        private List<IMenuItem> _places = new List<IMenuItem>();

        public HomeCtrl()
        {
            name = "Home";
        }

        public string name { get; set; }

        private void BuildWelcoming()
        {
            Console.WriteLine("{0} vous revoilà, prêt pour partir de nouveau à l'aventure ? \n", GameHome.Party.Hero.Name);
            ConsoleUtils.WriteInfosHero();
        }

        public void InitItem()
        {
            Console.Clear();
            Console.WriteLine("--- HOME ---");
            BuildWelcoming();
            RouteMenuCtrl._homeMenu.BuildMenu();
        }
    }
}
