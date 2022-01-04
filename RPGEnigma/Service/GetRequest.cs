using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using RPGDatabase;
using RPGDatabase.Models.Character;
using RPGDatabase.Models.Enum;
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
                foreach (Party party in rpgContext.PartySet.Include("Story").Include("Hero.Loots"))
                {
                    listParty.Add(party);
                }
            }
            return listParty;
        }

        public static List<Monster> GetMonsters(LevelStory story)
        {
            List<Monster> monsters = new List<Monster>();
            using (RpgContext rpg = new RpgContext())
            {
                foreach(Monster monster in rpg.MonsterSet)
                {
                    if (monster.Type == TypeEnum.WATER && story.Level > 0 && story.Level < 6 && monster.Level == 1)
                    {
                        monsters.Add(monster);
                    }
                    if (monster.Type == TypeEnum.FIRE && story.Level > 5 && story.Level < 11 && monster.Level == 2)
                    {
                        monsters.Add(monster);
                    }
                    if (monster.Type == TypeEnum.ROCK && story.Level > 10 && story.Level < 16 && monster.Level == 3)
                    {
                        monsters.Add(monster);
                    }
                    if (monster.Type == TypeEnum.WIND && story.Level > 15 && story.Level < 21 && monster.Level == 4)
                    {
                        monsters.Add(monster);
                    }
                }
            }
            return monsters;
        }

        /**
         * Creation de la partie et du héros
         */
        public static void SetPartyHero(string nameHero)
        {
            using (RpgContext rpgContext = new RpgContext())
            {
                Hero hero = new Hero(nameHero);
                LevelStory story = new LevelStory();
                story.IleType = TypeEnum.WATER;
                story.Level = 1;
                story.Pourcentage = 0;
                hero.Power = 6;
                hero.Dexterity = 4;
                hero.Intelligence = 2;
                rpgContext.PartySet.Add(new Party(nameHero, hero, story));
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
