using System;
using System.Collections.Generic;
using RPGDatabase.Models.Item;

namespace RPGDatabase.Models.Character
{
    /**
     * Entité Héro
     */
    public class Hero : CharacterCtrl
    {
        public List<Equipment> Equipments { get; set; }

        public Hero() : base()
        {
            Equipments = new List<Equipment>();
        }

        public Hero(string name) : base(name)
        {
            Equipments = new List<Equipment>();
        }

        public bool AsNotEquipment(ItemCtrl item)
        {
            foreach (Equipment equipment in Equipments)
            {
                if (equipment.Libelle == item.Libelle)
                {
                    return false;
                }
            }

            return true;
        }

        public bool AsNotItem(ItemCtrl item)
        {
            foreach (ItemCtrl loot in Loots)
            {
                if (loot.Libelle == item.Libelle)
                {
                    return false;
                }
            }

            return true;
        }

        public bool IsNotFull()
        {
            if (Loots.Count == 7)
            {
                return false;
            }
            return true;
        }

        public void AddConsomable(ItemCtrl item)
        {
            if (AsNotItem(item))
            {
                AddLoot(item);
            } else
            {
                foreach (ItemCtrl loot in Loots)
                {
                    if (loot.Libelle == item.Libelle)
                    {
                        loot.Quantity = loot.Quantity + 1;
                    }
                }
            }
        }

        public void AddEquipment(ItemCtrl equipment)
        {
            if (AsNotEquipment(equipment))
            {
                Equipments.Add((Equipment)equipment);
            }
        }

        public void AddLoot(ItemCtrl item)
        {
            if (IsNotFull())
            {
                Loots.Add(item);
            }
        }

        public void RemoveConsommable(ItemCtrl item)
        {
            bool remove = false;
            foreach (ItemCtrl loot in Loots)
            {
                if (loot.Libelle == item.Libelle)
                {
                    if (loot.Quantity > 1)
                    {
                        item.Quantity = item.Quantity - 1;
                        remove = true;
                    }
                }
            }
            if (!remove)
            {
                Loots.Remove(item);
            }
        }
    }
}
