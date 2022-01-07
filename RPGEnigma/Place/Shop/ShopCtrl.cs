using System;
using System.Collections.Generic;
using RPGEnigma.Menu;

namespace RPGEnigma.Place.Shop
{
    /**
     * Classe du menu SHOP
     */
    public class ShopCtrl : IMenuItem
    {
        List<IMenuItem> _options = new List<IMenuItem>();

        public ShopCtrl()
        {
            name = "SHOP";
        }

        public string name
        {
            get; set;
        }

        public void InitItem()
        {
            Console.Clear();
            Console.WriteLine("--- SHOP ---");
            RouteMenuCtrl._shopMenu.BuildMenu();
        }
    }
}
