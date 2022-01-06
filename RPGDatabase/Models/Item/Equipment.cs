using System;
using System.Collections.Generic;
using RPGDatabase.Models.Enum;
using RPGDatabase.Models.ManyToMany;

namespace RPGDatabase.Models.Item
{
    /**
     * Entité Equipement
     */
    public class Equipment : ItemCtrl
    {
        public List<HeroEquipment> HeroEquipments { get; set; }
    }
}
