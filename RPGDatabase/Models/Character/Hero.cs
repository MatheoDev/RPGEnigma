using System;
using System.Collections.Generic;
using RPGDatabase.Models.Item;

namespace RPGDatabase.Models.Character
{
    public class Hero : CharacterCtrl
    {
        public List<Equipment> Equipments { get; set; }

        public Hero() : base()
        {
        }

        public Hero(string name) : base(name)
        {
            Equipments = new List<Equipment>();
        }
    }
}
