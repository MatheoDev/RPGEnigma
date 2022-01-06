using System;
using System.Collections.Generic;
using RPGDatabase.Models.Item;

namespace RPGDatabase.Models.Character
{
    /**
     * Entité Personnage
     */
    public class CharacterCtrl
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Level { get; set; }

        public int ExperienceLvl { get; set; }

        public int Money { get; set; }

        public int Pv { get; set; }

        public int PvMax { get; set; }

        public int Power { get; set; }

        public int Dexterity { get; set; }

        public int Intelligence { get; set; }

        public int Discretion { get; set; }
    }
}
