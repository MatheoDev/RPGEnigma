using System;
namespace RPGDatabase.Character
{
    public class CharacterCtrl
    {
        private string name;

        private CharacterStat stats;

        private int level;

        private int experienceLvl;

        private int money;

        public string Name { get => name; set => name = value; }

        public CharacterStat Stats { get => stats; set => stats = value; }

        public int Level { get => level; set => level = value; }

        public int ExperienceLvl { get => experienceLvl; set => experienceLvl = value; }

        public int Money { get => money; set => money = value; }

        public CharacterCtrl(CharacterStat stats)
        {
            Stats = stats;
            Level = 0;
            ExperienceLvl = 0;
            Money = 0;
        }
    }
}
