using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using RPGDatabase;
using RPGDatabase.Models.Character;
using RPGDatabase.Models.Enum;
using RPGDatabase.Models.GamePart;
using RPGDatabase.Models.Item;
using RPGDatabase.Models.ManyToMany;

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
                foreach (Party party in rpgContext.PartySet.Include("Story").Include("Hero"))
                {
                    listParty.Add(party);
                }
            }
            return listParty;
        }

        /**
         * Hero de la partie
         */
        public static Hero GetHero(int id)
        {
            using (RpgContext context = new RpgContext())
            {
                return context.HeroSet.Include(h => h.HeroConsomables).Include(h => h.HeroEquipments).Include(h => h.HeroWeapons).Where(h => h.Id == id).First();
            }
        } 

        /**
         * Liste des monstres de notre niveau de jeu
         */
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
                Hero hero = new Hero();
                hero.Name = nameHero;
                hero.Level = 1;
                hero.Money = 100;
                hero.Pv = 70;
                hero.PvMax = 70;
                hero.ExperienceLvl = 0;
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
         * Insere la liaison entre héro et arme
         */
        public static void SetWeaponHero(int itemId, int heroId)
        {
            using (RpgContext context = new RpgContext())
            {
                HeroWeapon hw = new HeroWeapon()
                {
                    HeroId = heroId,
                    WeaponId = itemId
                };
                context.HeroWeapon.Add(hw);
                context.SaveChanges();
            }
        }

        /**
         * Retire la liaison entre héro et arme
         */
        public static void RemoveWeaponHero(int itemId, int heroId)
        {
            using (RpgContext context = new RpgContext())
            {
                HeroWeapon hw = context.HeroWeapon.Where(hw => hw.HeroId == heroId && hw.WeaponId == itemId).First();
                context.HeroWeapon.Remove(hw);
                context.SaveChanges();
            }
        }

        /**
         * Insere la liaison entre héro et equipement
         */
        public static void SetEquipmentHero(int itemId, int heroId)
        {
            using (RpgContext context = new RpgContext())
            {
                HeroEquipment he = new HeroEquipment()
                {
                    HeroId = heroId,
                    EquipmentId = itemId
                };
                context.HeroEquipment.Add(he);
                context.SaveChanges();
            }
        }

        /**
         * Retire la liaison entre héro et equipement
         */
        public static void RemoveEquipmentHero(int itemId, int heroId)
        {
            using (RpgContext context = new RpgContext())
            {
                HeroEquipment he = context.HeroEquipment.Where(he => he.HeroId == heroId && he.EquipmentId == itemId).First();
                context.Entry(he).State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        /**
         * Insere la liaison entre héro et conso
         */
        public static void SetConsomableHero(int itemId, int heroId)
        {
            using (RpgContext context = new RpgContext())
            {
                HeroConsomable hc = new HeroConsomable()
                {
                    HeroId = heroId,
                    ConsomableId = itemId
                };
                context.HeroConsomable.Add(hc);
                context.SaveChanges();
            }
        }

        /**
         * Retire la liaison entre héro et conso
         */
        public static void RemoveConsomableHero(int itemId, int heroId)
        {
            using (RpgContext context = new RpgContext())
            {
                HeroConsomable hc = context.HeroConsomable.Where(hc => hc.HeroId == heroId && hc.ConsomableId == itemId).First();
                context.HeroConsomable.Remove(hc);
                context.SaveChanges();
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
         * Recupère les items du Hero
         */
        public static List<ItemCtrl> GiveItemsHero(List<string> menu, Hero hero)
        {
            List<ItemCtrl> items = GetItemToBuy(hero.Level);
            List<ItemCtrl> itemsHero = new List<ItemCtrl>();
            foreach (HeroConsomable conso in hero.HeroConsomables)
            {
                ItemCtrl item = items.Find(i => i.Id == conso.ConsomableId);
                itemsHero.Add(item);
                menu.Add(item.Libelle + " -> " + item.Price);
            }
            foreach (HeroEquipment equip in hero.HeroEquipments)
            {
                ItemCtrl item = items.Find(i => i.Id == equip.EquipmentId);
                itemsHero.Add(item);
                menu.Add(item.Libelle + " -> " + item.Price);
            }
            foreach (HeroWeapon weap in hero.HeroWeapons)
            {
                ItemCtrl item = items.Find(i => i.Id == weap.WeaponId);
                itemsHero.Add(item);
                menu.Add(item.Libelle + " -> " + item.Price);
            }
            return itemsHero;
        }

        /**
         * Recupère les consommables du Hero pour combat 
         */
        public static List<ItemCtrl> GiveConsoHeroFight(List<string> menu, Hero hero)
        {

            List<ItemCtrl> items = GetItemToBuy(hero.Level);
            List<ItemCtrl> itemsHero = new List<ItemCtrl>();
            foreach (HeroConsomable conso in hero.HeroConsomables)
            {
                ItemCtrl item = items.Find(i => i.Id == conso.ConsomableId);
                itemsHero.Add(item);
                menu.Add(item.Libelle + " -> " + item.Pv);
            }
            return itemsHero;
        }

        /**
         * Recupère les armes du Hero pour combat 
         */
        public static List<Weapon> GiveWeapHeroFight(List<string> menu, Hero hero)
        {

            List<ItemCtrl> items = GetItemToBuy(hero.Level);
            List<Weapon> itemsHero = new List<Weapon>();
            foreach (HeroWeapon weap in hero.HeroWeapons)
            {
                ItemCtrl item = items.Find(i => i.Id == weap.WeaponId);
                using (RpgContext context = new RpgContext())
                {
                    Weapon weapon = context.WeaponSet.Where(i => i.Id == item.Id).First();
                    itemsHero.Add(weapon);
                }
                menu.Add(item.Libelle + " -> " + item.Pv);
            }
            return itemsHero;
        }

        /**
         * Sauvegarde du héros en base
         */
        public static void SavePart(Hero hero, LevelStory story)
        {
            using (RpgContext rpgContext = new RpgContext())
            {
                rpgContext.Update(story);
                rpgContext.Update(hero);
                rpgContext.SaveChanges();
            }
        }
    }
}
