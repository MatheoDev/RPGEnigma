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

        /**
         * Methode verifiant s'il détient déjà l'item en question
         */
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

        /**
         * Methode verifiant s'il détient déjà l'item en question
         */
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

        /**
         * Methode verifiant s'il détient déjà l'item en question
         */
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
    }
}
