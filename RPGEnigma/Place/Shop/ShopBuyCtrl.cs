using System;
using RPGEnigma.Menu;

namespace RPGEnigma.Place.Shop
{
    public class ShopBuyCtrl : IMenuItem
    {
        public ShopBuyCtrl()
        {
            name = "Acheter";
        }

        public string name { get; set; }

        public void InitItem()
        {
            Console.Clear();
            Console.WriteLine("--- ACHAT ---");

        }
    }
}
