using System;
using System.Collections.Generic;

namespace RPGEnigma.Menu
{
    public static class RouteMenuCtrl
    {
        public static MenuCtrl _homeMenu = buildHomeMenu();

        public static MenuCtrl _shopMenu = buildShopMenu();

        private static MenuCtrl buildHomeMenu()
        {
            List<IMenuItem> menu = new List<IMenuItem>();

            menu.Add(RouteCtrl._adventure);
            menu.Add(RouteCtrl._shop);
            menu.Add(RouteCtrl._tavern);
            menu.Add(RouteCtrl._townHall);

            return new MenuCtrl(menu);
        }

        private static MenuCtrl buildShopMenu()
        {
            List<IMenuItem> menu = new List<IMenuItem>();

            menu.Add(RouteCtrl._shopBuy);
            menu.Add(RouteCtrl._shopSell);
            menu.Add(RouteCtrl._home);

            return new MenuCtrl(menu, "Que voulez vous faire ?");
        }
    }
}
