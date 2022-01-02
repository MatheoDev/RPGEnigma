using System;
using RPGDatabase.Models.Character;

namespace RPGDatabase.Models.GamePart
{
    /**
     * Entité Partie
     */
    public class Party
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public Hero Hero { get; set; }

        public Party()
        {
        }

        public Party(string name, Hero hero)
        {
            Name = name;
            Hero = hero;
        }
    }
}
