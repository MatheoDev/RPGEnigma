using System;
using RPGDatabase.Models.Character;
using RPGDatabase.Models.Item;

namespace RPGDatabase.Models.ManyToMany
{
    /**
     * CLASSE MANY TO MANY BTW HERO & CONSOMABLE
     */
    public class HeroConsomable
    {
        public int Id { get; set; }

        public int HeroId { get; set; }

        public Hero Hero { get; set; }

        public int ConsomableId { get; set; }

        public Consomable Consomable { get; set; }
    }
}
