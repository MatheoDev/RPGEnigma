using System;
using RPGDatabase.Models.Character;

namespace RPGDatabase.Models.GamePart
{
    public class Party
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public Hero hero { get; set; }

        public Party()
        {
        }
    }
}
