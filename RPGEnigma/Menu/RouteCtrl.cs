using System;
using RPGEnigma.Menu.Principal;
using RPGEnigma.Place;
using RPGEnigma.Place.Shop;

namespace RPGEnigma.Menu
{
    /**
     * Classe static RouteCtrl
     * Permet de recupérer un objet connu pour tout le projet
     * (utile pour éviter un prbl de référence dans les menus)
     */
    public static class RouteCtrl
    {
        public static IMenuItem _menuPrincipal = new HomeMenuCtrl();

        public static IMenuItem _home = new HomeCtrl();

        public static IMenuItem _shop = new ShopCtrl();

        public static IMenuItem _adventure = new AdventureCtrl();

        public static IMenuItem _shopSell = new ShopSellCtrl();

        public static IMenuItem _shopBuy = new ShopBuyCtrl();

        public static IMenuItem _tavern = new TavernCtrl();

        public static IMenuItem _townHall = new TownhallCtrl();
    }
}
