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
     * Classe simulant achat du joueur
     */
    public class ShopBuyCtrl : IMenuItem
    {
        private List<ItemCtrl> _items;

        public ShopBuyCtrl()
        {
            name = "Acheter";
        }

        public string name { get; set; }

        public void InitItem()
        {
            _items = GetRequest.GetItemToBuy(GameHome.Party.Hero.Level);
            Console.Clear();
            Console.WriteLine("--- ACHAT ---");
            Console.WriteLine("Argent : {0}\n", GameHome.Party.Hero.Money);
            ManageMenu();
        }

        /**
         * Menu du shop d'achat
         */
        private void ManageMenu()
        {
            List<string> menu = new List<string>();
            foreach (ItemCtrl item in _items)
            {
                menu.Add(item.Libelle+" -> "+item.Price);
            }
            menu.Add("Retour");
            MenuCtrl menuCtrl = new MenuCtrl(menu);
            menuCtrl.BuildMenu();
            WaitAction();
        }

        /*
         * Attend l'action du joueur (achat ou retour)
         */
        private void WaitAction()
        {
            int action = ConsoleUtils.AskPlayerReturnInt("Choisir un item que vous voulez acheter :", 0, _items.Count+2);
            if (action > _items.Count-1)
            {
                RouteCtrl._shop.InitItem();
            } else
            {
                ProcessBuying(_items[action]);
            }
        }

        /**
         * Logique d'achat
         */
        private void ProcessBuying(ItemCtrl item)
        {
            if (GameHome.Party.Hero.Money < item.Price)
            {
                Console.Clear();
                Console.WriteLine("Vous n'avez pas assez d'argent pour acheter cet item\nAppuyer sur une touche pour continuer.");
                Console.Read();
                InitItem();
            } else
            {
                if (GameHome.Party.Hero.AsNotEquipment(item))
                {
                    if (item is Consomable)
                    {
                        if (GameHome.Party.Hero.AsNotItem(item) && !GameHome.Party.Hero.IsNotFull())
                        {
                            ResetShop("Inventaire plein");
                        } else { GameHome.Party.Hero.AddConsomable(item); }
                    } else if (item is Equipment)
                    {
                        GameHome.Party.Hero.AddEquipment(item);
                    } else
                    {
                        if (GameHome.Party.Hero.IsNotFull())
                        {
                            GameHome.Party.Hero.AddLoot(item);
                        } else { ResetShop("Inventaire plein"); }
                    }
                    Console.WriteLine("Achat de cet item : {0}", item.Libelle);
                } else
                {
                    ResetShop("Vous avez déjà cet item");
                }
            }
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
