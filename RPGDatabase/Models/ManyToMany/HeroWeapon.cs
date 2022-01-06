using System;
using RPGDatabase.Models.Character;
using RPGDatabase.Models.Item;

namespace RPGDatabase.Models.ManyToMany
{
    public class HeroWeapon
    {
        public int Id { get; set; }

        public int HeroId { get; set; }

        public Hero Hero { get; set; }

        public int WeaponId { get; set; }

        public Weapon Weapon { get; set; }
    }
}
