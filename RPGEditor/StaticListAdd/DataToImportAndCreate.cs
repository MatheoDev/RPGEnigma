using System;
using System.Collections.Generic;
using RPGDatabase.Models.Character;
using RPGDatabase.Models.Enum;
using RPGDatabase.Models.Item;

namespace RPGEditor.StaticListAdd
{
    public static class DataToImportAndCreate
    {
        public static List<Monster> CreateMonster()
        {
            List<Monster> monsters = new List<Monster>();
            for (int i = 1; i < 6; i++)
            {
                Monster monster = new Monster("Bébé dragon d'eau", TypeEnum.WATER);
                monster.Level = i;
                monster.PvMax = 60 * i;
                monster.Pv = monster.PvMax;
                monster.Power = 5 * i;
                monster.Dexterity = 3 * i;
                monster.Money = 10 * i;
                monster.ExperienceLvl = 7 * i;
                Monster dragon = new Monster("Dragon d'eau", TypeEnum.WATER);
                dragon.Level = i;
                dragon.PvMax = 90 * i;
                dragon.Pv = dragon.PvMax;
                dragon.Power = 6 * i;
                dragon.Dexterity = 6 * i;
                dragon.Money = 15 * i;
                dragon.ExperienceLvl = 10 * i;
                Monster dragonBoss = new Monster("Dragon Boss d'eau", TypeEnum.WATER);
                dragonBoss.Level = i;
                dragonBoss.PvMax = 110 * i;
                dragonBoss.Pv = dragonBoss.PvMax;
                dragonBoss.Power = 10 * i;
                dragonBoss.Dexterity = 5 * i;
                dragonBoss.Money = 25 * i;
                dragonBoss.ExperienceLvl = 20 * i;
                monsters.Add(monster);
                monsters.Add(dragon);
                monsters.Add(dragonBoss);
            }
            for (int i = 1; i < 6; i++)
            {
                Monster monster = new Monster("Bébé dragon de feu", TypeEnum.FIRE);
                monster.Level = i;
                monster.PvMax = 60 * i;
                monster.Pv = monster.PvMax;
                monster.Power = 5 * i;
                monster.Dexterity = 3 * i;
                monster.Money = 10 * i;
                monster.ExperienceLvl = 7 * i;
                Monster dragon = new Monster("Dragon de feu", TypeEnum.FIRE);
                dragon.Level = i;
                dragon.PvMax = 90 * i;
                dragon.Pv = dragon.PvMax;
                dragon.Power = 6 * i;
                dragon.Dexterity = 6 * i;
                dragon.Money = 15 * i;
                dragon.ExperienceLvl = 10 * i;
                Monster dragonBoss = new Monster("Dragon Boss de feu", TypeEnum.FIRE);
                dragonBoss.Level = i;
                dragonBoss.PvMax = 110 * i;
                dragonBoss.Pv = dragonBoss.PvMax;
                dragonBoss.Power = 10 * i;
                dragonBoss.Dexterity = 5 * i;
                dragonBoss.ExperienceLvl = 20 * i;
                dragonBoss.Money = 25 * i;
                monsters.Add(monster);
                monsters.Add(dragon);
                monsters.Add(dragonBoss);
            }
            for (int i = 1; i < 6; i++)
            {
                Monster monster = new Monster("Bébé dragon de roche", TypeEnum.ROCK);
                monster.Level = i;
                monster.PvMax = 60 * i;
                monster.Pv = monster.PvMax;
                monster.Power = 5 * i;
                monster.Dexterity = 3 * i;
                monster.Money = 10 * i;
                monster.ExperienceLvl = 7 * i;
                Monster dragon = new Monster("Dragon de roche", TypeEnum.ROCK);
                dragon.Level = i;
                dragon.PvMax = 90 * i;
                dragon.Pv = dragon.PvMax;
                dragon.Power = 6 * i;
                dragon.Dexterity = 6 * i;
                dragon.Money = 15 * i;
                dragon.ExperienceLvl = 10 * i;
                Monster dragonBoss = new Monster("Dragon Boss de roche", TypeEnum.ROCK);
                dragonBoss.Level = i;
                dragonBoss.PvMax = 110 * i;
                dragonBoss.Pv = dragonBoss.PvMax;
                dragonBoss.Power = 10 * i;
                dragonBoss.Dexterity = 5 * i;
                dragonBoss.Money = 25 * i;
                dragonBoss.ExperienceLvl = 20 * i;
                monsters.Add(monster);
                monsters.Add(dragon);
                monsters.Add(dragonBoss);
            }
            for (int i = 1; i < 6; i++)
            {
                Monster monster = new Monster("Bébé dragon de vent", TypeEnum.WIND);
                monster.Level = i;
                monster.PvMax = 60 * i;
                monster.Pv = monster.PvMax;
                monster.Power = 5 * i;
                monster.Dexterity = 3 * i;
                monster.Money = 10 * i;
                monster.ExperienceLvl = 7 * i;
                Monster dragon = new Monster("Dragon de vent", TypeEnum.WIND);
                dragon.Level = i;
                dragon.PvMax = 90 * i;
                dragon.Pv = dragon.PvMax;
                dragon.Power = 6 * i;
                dragon.Dexterity = 6 * i;
                dragon.Money = 15 * i;
                dragon.ExperienceLvl = 10 * i;
                Monster dragonBoss = new Monster("Dragon Boss de vent", TypeEnum.WIND);
                dragonBoss.Level = i;
                dragonBoss.PvMax = 110 * i;
                dragonBoss.Pv = dragonBoss.PvMax;
                dragonBoss.Power = 10 * i;
                dragonBoss.Dexterity = 5 * i;
                dragonBoss.Money = 25 * i;
                dragonBoss.ExperienceLvl = 20 * i;
                monsters.Add(monster);
                monsters.Add(dragon);
                monsters.Add(dragonBoss);
            }
            return monsters;
        }

        public static List<Consomable> CreateConsomable()
        {
            List<Consomable> consomables = new List<Consomable>();
            for (int i = 1; i < 6; i++)
            {
                Consomable consomable = new Consomable();
                consomable.Libelle = "Pomme";
                consomable.Pv = 10 * i;
                consomable.Price = 10 * i;
                consomable.Quantity = 1;
                consomable.Level = i;
                consomables.Add(consomable);
                Consomable banane = new Consomable();
                consomable.Libelle = "Banane";
                consomable.Pv = 5 * i;
                consomable.Price = 5 * i;
                consomable.Quantity = 1;
                banane.Level = i;
                consomables.Add(banane);
                Consomable soupe = new Consomable();
                consomable.Libelle = "Soupe";
                consomable.Pv = 15 * i;
                consomable.Price = 15 * i;
                consomable.Quantity = 1;
                soupe.Level = i;
                consomables.Add(soupe);
            }
            return consomables;
        }

        public static List<Weapon> CreateWeapon()
        {
            List<Weapon> weapons = new List<Weapon>();
            for (int i = 1; i < 6; i++)
            {
                Weapon weapon = new Weapon();
                weapon.Libelle = "Epée de feu";
                weapon.Pv = 10 * i;
                weapon.Type = TypeEnum.FIRE;
                weapon.Price = 15 * i;
                weapon.Power = 7 * i;
                weapon.Level = i;
                Weapon hache = new Weapon();
                hache.Libelle = "Hache de feu";
                hache.Pv = 5 * i;
                hache.Type = TypeEnum.FIRE;
                hache.Price = 10 * i;
                hache.Power = 10 * i;
                hache.Level = i;
                Weapon dague = new Weapon();
                dague.Libelle = "Dague de feu";
                dague.Pv = 4 * i;
                dague.Type = TypeEnum.FIRE;
                dague.Price = 15 * i;
                dague.Power = 15 * i;
                dague.Level = i;
                weapons.Add(weapon);
                weapons.Add(hache);
                weapons.Add(dague);
            }
            for (int i = 1; i < 6; i++)
            {
                Weapon weapon = new Weapon();
                weapon.Libelle = "Epée de d'eau";
                weapon.Pv = 10 * i;
                weapon.Type = TypeEnum.WATER;
                weapon.Price = 15 * i;
                weapon.Power = 7 * i;
                weapon.Level = i;
                Weapon hache = new Weapon();
                hache.Libelle = "Hache de d'eau";
                hache.Pv = 5 * i;
                hache.Type = TypeEnum.WATER;
                hache.Price = 10 * i;
                hache.Power = 10 * i;
                hache.Level = i;
                Weapon dague = new Weapon();
                dague.Libelle = "Dague de d'eau";
                dague.Pv = 4 * i;
                dague.Type = TypeEnum.WATER;
                dague.Price = 15 * i;
                dague.Power = 15 * i;
                dague.Level = i;
                weapons.Add(weapon);
                weapons.Add(hache);
                weapons.Add(dague);
            }
            for (int i = 1; i < 6; i++)
            {
                Weapon weapon = new Weapon();
                weapon.Libelle = "Epée de vent";
                weapon.Pv = 10 * i;
                weapon.Type = TypeEnum.WIND;
                weapon.Price = 15 * i;
                weapon.Power = 7 * i;
                weapon.Level = i;
                Weapon hache = new Weapon();
                hache.Libelle = "Hache de vent";
                hache.Pv = 5 * i;
                hache.Type = TypeEnum.WIND;
                hache.Price = 10 * i;
                hache.Power = 10 * i;
                hache.Level = i;
                Weapon dague = new Weapon();
                dague.Libelle = "Dague de vent";
                dague.Pv = 4 * i;
                dague.Type = TypeEnum.WIND;
                dague.Price = 15 * i;
                dague.Power = 15 * i;
                dague.Level = i;
                weapons.Add(weapon);
                weapons.Add(hache);
                weapons.Add(dague);
            }
            for (int i = 1; i < 6; i++)
            {
                Weapon weapon = new Weapon();
                weapon.Libelle = "Epée de roche";
                weapon.Pv = 10 * i;
                weapon.Type = TypeEnum.ROCK;
                weapon.Price = 15 * i;
                weapon.Power = 7 * i;
                weapon.Level = i;
                Weapon hache = new Weapon();
                hache.Libelle = "Hache de roche";
                hache.Pv = 5 * i;
                hache.Type = TypeEnum.ROCK;
                hache.Price = 10 * i;
                hache.Power = 10 * i;
                hache.Level = i;
                Weapon dague = new Weapon();
                dague.Libelle = "Dague de roche";
                dague.Pv = 4 * i;
                dague.Type = TypeEnum.ROCK;
                dague.Price = 15 * i;
                dague.Power = 15 * i;
                dague.Level = i;
                weapons.Add(weapon);
                weapons.Add(hache);
                weapons.Add(dague);
            }
            return weapons;
        }

        public static List<Equipment> CreateEquipment()
        {
            List<Equipment> equipments = new List<Equipment>();
            for (int i = 1; i < 6; i++)
            {
                Equipment casque = new Equipment();
                casque.Libelle = "Casque";
                casque.Pv = 10 * i;
                casque.Price = 20 * i;
                casque.Level = i;
                equipments.Add(casque);
                Equipment gilet = new Equipment();
                gilet.Libelle = "Gilet";
                gilet.Pv = 10 * i;
                gilet.Price = 20 * i;
                gilet.Level = i;
                equipments.Add(gilet);
                Equipment pantalon = new Equipment();
                pantalon.Libelle = "Pantalon";
                pantalon.Pv = 10 * i;
                pantalon.Price = 20 * i;
                pantalon.Level = i;
                equipments.Add(pantalon);
                Equipment shoes = new Equipment();
                shoes.Libelle = "Chaussure";
                shoes.Pv = 10 * i;
                shoes.Price = 20 * i;
                shoes.Level = i;
                equipments.Add(shoes);
                Equipment shield = new Equipment();
                shield.Libelle = "Bouclier";
                shield.Pv = 10 * i;
                shield.Price = 20 * i;
                shield.Level = i;
                equipments.Add(shield);
            }
            return equipments;
        }
    }
}
