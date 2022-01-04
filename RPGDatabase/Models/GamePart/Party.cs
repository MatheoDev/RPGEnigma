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

        public LevelStory Story { get; set; }

        public Party()
        {
            Story = new LevelStory();
        }

        public Party(string name, Hero hero, LevelStory story)
        {
            Name = name;
            Hero = hero;
            Story = story;
        }
    }
}
