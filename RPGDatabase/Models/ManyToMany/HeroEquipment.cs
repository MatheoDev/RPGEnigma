using System;
using RPGDatabase.Models.Character;
using RPGDatabase.Models.Item;

namespace RPGDatabase.Models.ManyToMany
{
    public class HeroEquipment
    {
        public int Id { get; set; }

        public int HeroId { get; set; }

        public Hero Hero { get; set; }

        public int EquipmentId { get; set; }

        public Equipment Equipment { get; set; }
    }
}
