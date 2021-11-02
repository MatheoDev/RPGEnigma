using System;
using System.Collections.Generic;
using RPGEnigma.Menu;

namespace RPGEnigma.Place.Shop
{
    public class ShopCtrl : IMenuItem
    {
        List<IMenuItem> _options = new List<IMenuItem>();

        public ShopCtrl()
        {
            name = "SHOP";
            _options.Add(new ShopBuyCtrl());
            _options.Add(new ShopSellCtrl());
        }

        public string name
        {
            get; set;
        }

        public void InitItem()
        {
            Console.Clear();
            Console.WriteLine("--- SHOP ---");
            new MenuCtrl(_options, "Que voulez vous faire ?");
        }
    }
}
