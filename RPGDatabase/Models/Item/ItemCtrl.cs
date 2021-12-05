using System;
namespace RPGDatabase.Models.Item
{
    public class ItemCtrl
    {
        public int Id { get; set; }

        public string Libelle { get; set; }

        public int Quantity { get; set; }

        public int Pv { get; set; }

        public ItemCtrl(string libelle, int pv)
        {
            Pv = pv;
            Libelle = libelle;
            Quantity = 1;
        }
    }
}
