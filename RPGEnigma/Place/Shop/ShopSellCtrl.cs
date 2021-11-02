using System;
using RPGEnigma.Menu;

namespace RPGEnigma.Place.Shop
{
    public class ShopSellCtrl : IMenuItem
    {
        public ShopSellCtrl()
        {
            name = "Vendre";
        }

        public string name { get; set; }

        public void InitItem()
        {
            Console.Clear();
            Console.WriteLine("--- VENTE ---");
        }
    }
}
