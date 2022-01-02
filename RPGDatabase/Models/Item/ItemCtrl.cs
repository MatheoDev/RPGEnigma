using System;
using RPGDatabase.Models.Enum;

namespace RPGDatabase.Models.Item
{
    /**
     * Entité des items
     */
    public class ItemCtrl
    {
        public int Id { get; set; }

        public string Libelle { get; set; }

        public int Price { get; set; }

        public int Quantity { get; set; }

        public int Pv { get; set; }

        public int Level { get; set; }

        public TypeEnum Type { get; set; }

        public ItemCtrl(string libelle, int pv, TypeEnum type, int price)
        {
            Pv = pv;
            Libelle = libelle;
            Quantity = 1;
            Level = 1;
            Type = type;
            Price = price;
        }
    }
}
