using System;
using RPGDatabase.Models.Enum;

namespace RPGDatabase.Models.Item
{
    /**
     * Entité Equipement
     */
    public class Equipment : ItemCtrl
    {
        public Equipment(string libelle, int pv, TypeEnum type, int price) : base(libelle, pv, type, price)
        {
        }
    }
}
