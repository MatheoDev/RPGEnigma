using System;
using System.Collections.Generic;
using RPGDatabase.Models.Enum;
using RPGDatabase.Models.ManyToMany;

namespace RPGDatabase.Models.Item
{
    /**
     * Entité des armes
     */
    public class Weapon : ItemCtrl
    {
        public int Power { get; set; }

        public List<HeroWeapon> HeroWeapons { get; set; }
    }
}
