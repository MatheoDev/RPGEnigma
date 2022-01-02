using System;
using System.Collections.Generic;
using RPGDatabase.Models.Item;
using RPGEnigma.Game;
using RPGEnigma.Menu;
using RPGEnigma.Utils;

namespace RPGEnigma.Place.Shop
{
    /**
     * Classe simulant la vente d'un item
     */
    public class ShopSellCtrl : IMenuItem
    {
        private List<string> _menuString;

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
            foreach (ItemCtrl item in GameHome.Party.Hero.Loots)
            {
                _menuString.Add(item.Libelle+" -> "+item.Price);
            }
            foreach (ItemCtrl item in GameHome.Party.Hero.Equipments)
            {
                _menuString.Add(item.Libelle + " -> " + item.Price);
            }
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
                if (action >= GameHome.Party.Hero.Loots.Count)
                {
                    int index = GameHome.Party.Hero.Loots.Count == 0 ? action : action - GameHome.Party.Hero.Loots.Count;
                    ProcessSelling(GameHome.Party.Hero.Equipments[index]);
                } else
                {
                    ProcessSelling(GameHome.Party.Hero.Loots[action]);
                }
            }
        }

        /**
         * Processus de vente
         */
        private void ProcessSelling(ItemCtrl item)
        {
            if (item is Equipment)
            {
                GameHome.Party.Hero.Equipments.Remove((Equipment)item);
                GameHome.Party.Hero.Money = GameHome.Party.Hero.Money + item.Price;
            } else if (item is Consomable)
            {
                GameHome.Party.Hero.RemoveConsommable(item);
                GameHome.Party.Hero.Money = GameHome.Party.Hero.Money + item.Price;
            } else
            {
                GameHome.Party.Hero.Loots.Remove(item);
                GameHome.Party.Hero.Money = GameHome.Party.Hero.Money + item.Price;
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
