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

        public CharacterStat(int power, int dexterity, int intelligence, int discretion)
        {
            Power = power;
            Dexterity = dexterity;
            Intelligence = intelligence;
            Discretion = discretion;
        }
    }
}
