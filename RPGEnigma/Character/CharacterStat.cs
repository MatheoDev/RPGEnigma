using System;
namespace RPGEnigma.Character
{
    public class CharacterStat
    {
        private int _power;

        private int _dexterity;

        private int _intelligence;

        private int _discretion;

        public CharacterStat(int power, int dexterity, int intelligence, int discretion)
        {
            Power = power;
            Dexterity = dexterity;
            Intelligence = intelligence;
            Discretion = discretion;
        }

        public int Power { get => _power; set => _power = value; }

        public int Dexterity { get => _dexterity; set => _dexterity = value; }

        public int Intelligence { get => _intelligence; set => _intelligence = value; }

        public int Discretion { get => _discretion; set => _discretion = value; }
    }
}
