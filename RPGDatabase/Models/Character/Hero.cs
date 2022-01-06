using System;
using System.Collections.Generic;
using RPGDatabase.Models.GamePart;
using RPGDatabase.Models.Item;
using RPGDatabase.Models.ManyToMany;

namespace RPGDatabase.Models.Character
{
    /**
     * Entité Héro
     */
    public class Hero : CharacterCtrl
    {
        public int PartyId { get; set; }

        public Party Party { get; set; }

        public List<HeroEquipment> HeroEquipments { get; set; }

        public List<HeroConsomable> HeroConsomables { get; set; }

        public List<HeroWeapon> HeroWeapons { get; set; }

        public Hero()
        {
            HeroConsomables = new List<HeroConsomable>();
            HeroEquipments = new List<HeroEquipment>();
            HeroWeapons = new List<HeroWeapon>();
        }

        public bool HaveEquipment(int itemId)
        {
            foreach (HeroEquipment equipment in HeroEquipments)
            {
                if (equipment.EquipmentId == itemId)
                {
                    return true;
                }
            }

            return false;
        }

        public bool HaveWeapon(int itemId)
        {
            foreach (HeroWeapon weapon in HeroWeapons)
            {
                if (weapon.WeaponId == itemId)
                {
                    return true;
                }
            }

            return false;
        }

        public bool HaveConsommable(int itemId)
        {
            foreach (HeroConsomable consomable in HeroConsomables)
            {
                if (consomable.ConsomableId == itemId)
                {
                    return true;
                }
            }

            return false;
        }

        public void AddEquipment(HeroEquipment equipment)
        {
            HeroEquipments.Add(equipment);
        }

        public void AddConsomable(HeroConsomable consomable)
        {
            HeroConsomables.Add(consomable);
        }

        public void AddWeapon(HeroWeapon weapon)
        {
            HeroWeapons.Add(weapon);
        }

        //public void RemoveConsommable(ItemCtrl item)
        //{
        //    bool remove = false;
        //    foreach (ItemCtrl loot in Consom)
        //    {
        //        if (loot.Libelle == item.Libelle)
        //        {
        //            if (loot.Quantity > 1)
        //            {
        //                item.Quantity = item.Quantity - 1;
        //                remove = true;
        //            }
        //        }
        //    }
        //    if (!remove)
        //    {
        //        Loots.Remove(item);
        //    }
        //}
    }
}
