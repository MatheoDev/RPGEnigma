using System;
using System.Collections.Generic;
using RPGEnigma.Menu;
using RPGEnigma.Place.Shop;
using RPGEnigma.Place;

namespace RPGEnigma
{
    class Program
    {
        static void Main(string[] args)
        {
            List<IMenuItem> places = new List<IMenuItem>();
            places.Add(new ShopCtrl());
            places.Add(new TavernCtrl());

            new MenuCtrl(places);
        }
    }
}
