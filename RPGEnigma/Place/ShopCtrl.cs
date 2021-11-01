using System;
using RPGEnigma.Menu;

namespace RPGEnigma.Place
{
    public class ShopCtrl : IMenuItem
    {
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
            Console.WriteLine("SHOP");
        }
    }
}
