using System;
using System.Linq;
using RPGDatabase;
using RPGDatabase.Models.Character;

namespace RPGEditor
{
    class Program
    {
        static void Main(string[] args)
        {
            using (RpgContext rpgContext = new RpgContext())
            {
                if (rpgContext.HeroSet.Count() < 1)
                {
                    rpgContext.HeroSet.Add(new Hero("Mat"));
                    rpgContext.SaveChanges();
                }
            }

            using (RpgContext rpgContext = new RpgContext())
            {
                foreach(Hero hero in rpgContext.HeroSet)
                {
                    Console.WriteLine("ID: {0}, Name: {1}, Lvl: {2}, Money: {3}", hero.Id, hero.Name, hero.Level, hero.Money);
                }
            }
        }
    }
}
