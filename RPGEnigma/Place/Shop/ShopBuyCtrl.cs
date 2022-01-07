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
            _items = GetRequest.GetItemToBuy(GameHome.Hero.Level);
            Console.Clear();
            Console.WriteLine("--- ACHAT ---");
            Console.WriteLine("Argent : {0}\n", GameHome.Hero.Money);
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
            if (GameHome.Hero.Money < item.Price)
            {
                Console.Clear();
                Console.WriteLine("Vous n'avez pas assez d'argent pour acheter cet item\nAppuyer sur une touche pour continuer.");
                Console.Read();
                InitItem();
            } else
            {
                if (item is Consomable)
                {
                    ProcessBuyingConsom(item);
                } else if (item is Weapon)
                {
                    ProcessBuyingWeapon(item);
                } else
                {
                    ProcessBuyingEquipt(item);
                }
            }
        }

        /**
         * Logique d'achat pour une arme
         */
        private void ProcessBuyingWeapon(ItemCtrl item)
        {
            if (GameHome.Hero.HaveWeapon(item.Id))
            {
                ResetShop("Vous avez déjà acheté cet item");
            } else
            {
                GetRequest.SetWeaponHero(item.Id, GameHome.Hero.Id);
                ResetShop("Vous avez acheté "+item.Libelle);
            }
        }

        /**
         * Logique d'achat pour un equipement
         */
        private void ProcessBuyingEquipt(ItemCtrl item)
        {
            if (GameHome.Hero.HaveEquipment(item.Id))
            {
                ResetShop("Vous avez déjà acheté cet item");
            }
            else
            {
                GetRequest.SetEquipmentHero(item.Id, GameHome.Hero.Id);
                ResetShop("Vous avez acheté " + item.Libelle);
            }
        }

        /**
         * Logique d'achat pour un consommable
         */
        private void ProcessBuyingConsom(ItemCtrl item)
        {
            if (GameHome.Hero.HaveConsommable(item.Id))
            {
                ResetShop("Vous avez déjà acheté cet item");
            } else
            {
                GetRequest.SetConsomableHero(item.Id, GameHome.Hero.Id);
                ResetShop("Vous avez acheté " + item.Libelle);
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
