using System;
namespace RPGDatabase.Models.Character
{
    public class CharacterStat
    {
        public int Id { get; set; }

        public int Power { get; set; }

        public int Dexterity { get; set; }

        public int Intelligence { get; set; }

        public int Discretion { get; set; }

        public CharacterStat()
        {
            Power = 0;
            Dexterity = 0;
            Intelligence = 0;
            Discretion = 0;
        }
    }
}
