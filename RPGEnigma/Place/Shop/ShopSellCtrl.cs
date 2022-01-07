using System;
using System.Collections.Generic;
using RPGDatabase.Models.Item;
using RPGEnigma.Game;
using RPGEnigma.Menu;
using RPGEnigma.Service;
using RPGEnigma.Utils;

namespace RPGEnigma.Place.Shop
{
    /**
     * Classe simulant la vente d'un item
     */
    public class ShopSellCtrl : IMenuItem
    {
        private List<string> _menuString;

        private List<ItemCtrl> _itemsToSell;

        public ShopSellCtrl()
        {
            name = "Vendre";
        }

        public string name { get; set; }

        public void InitItem()
        {
            Console.Clear();
            Console.WriteLine("--- VENTE ---");
            Console.WriteLine("Argent : {0}\n", GameHome.Party.Hero.Money);
            ManageMenu();
        }

        /**
         * Menu du shop vente
         */
        private void ManageMenu()
        {
            _menuString = new List<string>();
            _itemsToSell = GetRequest.GiveItemsHero(_menuString, GameHome.Hero);
            _menuString.Add("Retour");
            MenuCtrl menu = new MenuCtrl(_menuString);
            menu.BuildMenu();
            WaitAction();
        }

        /**
         * Attendre l'action de l'utilisateur
         */
        private void WaitAction()
        {
            int action = ConsoleUtils.AskPlayerReturnInt("Que voulez-vous vendre ?", 0, _menuString.Count);
            if (action ==_menuString.Count-1)
            {
                RouteCtrl._shop.InitItem();
            } else
            {
                ProcessSelling(_itemsToSell[action]);
            }
        }

        /**
         * Processus de vente
         */
        private void ProcessSelling(ItemCtrl item)
        {
            if (item is Consomable)
            {
                GetRequest.RemoveConsomableHero(item.Id, GameHome.Hero.Id);
            } else if (item is Weapon)
            {
                GetRequest.RemoveWeaponHero(item.Id, GameHome.Hero.Id);
            } else
            {
                GetRequest.RemoveEquipmentHero(item.Id, GameHome.Hero.Id);
            }
            ResetShop("Vous avez vendu cet item : " + item.Libelle);
        }

        /**
         * Reset le shop en cas d'erreur d'achat
         */
        private void ResetShop(string sentence)
        {
            Console.Clear();
            Console.WriteLine("{0}\nAppuyer sur une touche pour continuer.", sentence);
            Console.Read();
            InitItem();
        }
    }
}
