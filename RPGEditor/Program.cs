using System;
using System.Linq;
using RPGDatabase;
using RPGDatabase.Models.Character;
using RPGDatabase.Models.Enum;
using RPGDatabase.Models.Item;

namespace RPGEditor
{
    class Program
    {
        static void Main(string[] args)
        {
            using (RpgContext rpgContext = new RpgContext())
            {
                if (rpgContext.EquipmentSet.Count() < 5)
                {
                    rpgContext.EquipmentSet.Add(new Equipment("Casque", 10, TypeEnum.FIRE, 100));
                    rpgContext.EquipmentSet.Add(new Equipment("Gilet", 10, TypeEnum.FIRE, 100));
                    rpgContext.EquipmentSet.Add(new Equipment("Pantalon", 10, TypeEnum.FIRE, 100));
                    rpgContext.EquipmentSet.Add(new Equipment("Chaussure", 10, TypeEnum.FIRE, 100));
                    rpgContext.EquipmentSet.Add(new Equipment("Bouclier", 10, TypeEnum.FIRE, 100));
                    rpgContext.SaveChanges();
                }

                if (rpgContext.ConsomableSet.Count() < 3)
                {
                    rpgContext.ConsomableSet.Add(new Consomable("Pomme", 10, TypeEnum.FIRE, 50));
                    rpgContext.ConsomableSet.Add(new Consomable("Banane", 10, TypeEnum.FIRE, 50));
                    rpgContext.ConsomableSet.Add(new Consomable("Soupe", 10, TypeEnum.FIRE, 50));
                    rpgContext.SaveChanges();
                }

                if (rpgContext.WeaponSet.Count() < 4)
                {
                    rpgContext.WeaponSet.Add(new Weapon("Epée", 10, TypeEnum.FIRE, 10, 100));
                    rpgContext.WeaponSet.Add(new Weapon("Hache", 10, TypeEnum.FIRE, 10, 100));
                    rpgContext.WeaponSet.Add(new Weapon("Katana", 10, TypeEnum.FIRE, 10, 100));
                    rpgContext.WeaponSet.Add(new Weapon("Dague", 10, TypeEnum.FIRE, 10, 100));
                    rpgContext.SaveChanges();
                }
            }
        }
    }
}
