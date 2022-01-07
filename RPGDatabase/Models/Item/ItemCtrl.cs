using System;
using RPGDatabase.Models.Character;
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
    }
}
