using System;
using RPGEnigma.Menu;
using RPGEnigma.Utils;

namespace RPGEnigma.Place
{
    public class AdventureCtrl : IMenuItem
    {
        public AdventureCtrl()
        {
            name = "AVENTURE";
        }

        public string name { get; set; }

        public void InitItem()
        {
            Console.Clear();
            Console.WriteLine("--- AVENTURE ---");
            ConsoleUtils.WriteInfosStory();
            ConsoleUtils.WriteInfosHero();
        }
    }
}
