using System;
namespace RPGDatabase.Models.Character
{
    public class CharacterCtrl
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public CharacterStat Stats { get; set; }

        public int Level { get; set; }

        public int ExperienceLvl { get; set; }

        public int Money { get; set; }

        public CharacterCtrl()
        {
        }

        public CharacterCtrl(string name)
        {
            Name = name;
            Level = 0;
            ExperienceLvl = 0;
            Money = 10;
        }

        public CharacterCtrl(CharacterStat stats)
        {
            Stats = stats;
            Level = 0;
            ExperienceLvl = 0;
            Money = 0;
        }
    }
}
