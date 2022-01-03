using System;
using System.Linq;
using RPGDatabase;
using RPGDatabase.Models.Character;
using RPGDatabase.Models.Enum;
using RPGDatabase.Models.Item;
using RPGEditor.StaticListAdd;

namespace RPGEditor
{
    class Program
    {
        static void Main(string[] args)
        {
            using (RpgContext rpgContext = new RpgContext())
            {
                foreach (Monster monster in DataToImportAndCreate.CreateMonster())
                {
                    rpgContext.MonsterSet.Add(monster);
                }

                foreach (Consomable consomable in DataToImportAndCreate.CreateConsomable())
                {
                    rpgContext.ConsomableSet.Add(consomable);
                }

                foreach (Equipment equipment in DataToImportAndCreate.CreateEquipment())
                {
                    rpgContext.EquipmentSet.Add(equipment);
                }

                foreach (Weapon weapon in DataToImportAndCreate.CreateWeapon())
                {
                    rpgContext.WeaponSet.Add(weapon);
                }

                rpgContext.SaveChanges();
            }
        }
    }
}
