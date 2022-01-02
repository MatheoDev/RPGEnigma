using System;
using RPGDatabase.Models.Enum;

namespace RPGDatabase.Models.Item
{
    /**
     * Entité des armes
     */
    public class Weapon : ItemCtrl
    {
        public int Power { get; set; }

        public Weapon(string libelle, int pv, TypeEnum type, int price, int power) : base(libelle, pv, type, price)
        {
            Power = power;
        }
    }
}
