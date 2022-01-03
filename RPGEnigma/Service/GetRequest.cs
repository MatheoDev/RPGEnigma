using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using RPGDatabase;
using RPGDatabase.Models.Character;
using RPGDatabase.Models.GamePart;
using RPGDatabase.Models.Item;

namespace RPGEnigma.Service
{
    /**
     * Classe GetRequest
     * Permet de faire toute requete vers la BDD 
     * afin de recupérer les valeurs que nous voulons
     */
    public static class GetRequest
    {
        /**
         * Liste des Parties
         */
        public static List<Party> GetParty()
        {
            List<Party> listParty = new List<Party>();
            using (RpgContext rpgContext = new RpgContext())
            {
                foreach (Party party in rpgContext.PartySet.Include("Hero.Stats"))
                {
                    listParty.Add(party);
                }
            }
            return listParty;
        }

        /**
         * Creation de la partie et du héros
         */
        public static void SetPartyHero(string nameHero)
        {
            using (RpgContext rpgContext = new RpgContext())
            {
                Hero hero = new Hero(nameHero);
                hero.Stats.Power = 6;
                hero.Stats.Dexterity = 4;
                hero.Stats.Intelligence = 2;
                rpgContext.PartySet.Add(new Party(nameHero, hero));
                rpgContext.SaveChanges();
            }
        }

        /**
         * Liste des items (pour le shop)
         */
        public static List<ItemCtrl> GetItemToBuy(int levelHero)
        {
            List<ItemCtrl> listItem = new List<ItemCtrl>();
            using (RpgContext rpgContext = new RpgContext())
            {
                foreach (Equipment equipment in rpgContext.EquipmentSet)
                {
                    if (equipment.Level == levelHero)
                    {
                        listItem.Add(equipment);
                    }
                }
                foreach (Consomable consomable in rpgContext.ConsomableSet)
                {

                    if (consomable.Level == levelHero)
                    {
                        listItem.Add(consomable);
                    }
                }
                foreach (Weapon weapon in rpgContext.WeaponSet)
                {

                    if (weapon.Level == levelHero)
                    {
                        listItem.Add(weapon);
                    }
                }
            }
            return listItem;
        }

        /**
         * Sauvegarde du héros en base
         */
        public static void SavePart(Hero hero)
        {
            using (RpgContext rpgContext = new RpgContext())
            {
                rpgContext.Update(hero);
                rpgContext.SaveChanges();
            }
        }
    }
}
