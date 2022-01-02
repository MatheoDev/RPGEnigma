using System;
using System.Collections.Generic;
using RPGEnigma.Game;
using RPGEnigma.Menu;
using RPGEnigma.Place.Shop;

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
            Console.WriteLine("Pv: {0}/{1}\nNiveau: {2} | {3}Xp\nArgent: {4}\n",
                GameHome.Party.Hero.Pv, GameHome.Party.Hero.PvMax, GameHome.Party.Hero.Level,
                GameHome.Party.Hero.ExperienceLvl, GameHome.Party.Hero.Money);
            Console.WriteLine("Force: {0}\nDextérité: {1}\nIntelligence: {2}\nDiscrétion: {3}\n",
                GameHome.Party.Hero.Stats.Power, GameHome.Party.Hero.Stats.Dexterity,
                GameHome.Party.Hero.Stats.Intelligence, GameHome.Party.Hero.Stats.Discretion);
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
