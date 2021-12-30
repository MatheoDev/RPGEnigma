using System;
using RPGDatabase.Models.Enum;

namespace RPGDatabase.Models.Item
{
    public class Consomable : ItemCtrl
    {
        public Consomable(string libelle, int pv, TypeEnum type, int price) : base(libelle, pv, type, price)
        {
        }
    }
}
