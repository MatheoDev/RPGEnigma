using System;
using System.Collections.Generic;
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

        public void InitItem()
        {
            Console.Clear();
            Console.WriteLine("--- HOME ---");
            RouteMenuCtrl._homeMenu.BuildMenu();
        }
    }
}
