using System;
namespace RPGDatabase.Models.Item
{
    public class Weapon : ItemCtrl
    {
        public int Power { get; set; }

        public Weapon(string libelle, int pv, int power) : base(libelle, pv)
        {
            Power = power;
        }
    }
}
