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

        public CharacterStat Stats { get; set; }

        public int Level { get; set; }

        public int ExperienceLvl { get; set; }

        public int Money { get; set; }

        public int Pv { get; set; }

        public int PvMax { get; set; }

        public List<ItemCtrl> Loots { get; set; }

        public CharacterCtrl()
        {
            Loots = new List<ItemCtrl>();
        }

        public CharacterCtrl(string name)
        {
            Name = name;
            Level = 1;
            ExperienceLvl = 0;
            Money = 100;
            PvMax = 30;
            Pv = PvMax;
            Loots = new List<ItemCtrl>();
            Stats = new CharacterStat();
        }
    }
}
