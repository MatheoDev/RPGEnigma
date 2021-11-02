using System;
using RPGEnigma.Place;
using RPGEnigma.Place.Shop;

namespace RPGEnigma.Menu
{
    public static class RouteCtrl
    {
        public static IMenuItem _home = new HomeCtrl();

        public static IMenuItem _shop = new ShopCtrl();

        public static IMenuItem _shopSell = new ShopSellCtrl();

        public static IMenuItem _shopBuy = new ShopBuyCtrl();

        public static IMenuItem _tavern = new TavernCtrl();
    }
}
