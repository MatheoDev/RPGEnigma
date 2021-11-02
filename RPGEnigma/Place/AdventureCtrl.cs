using System;
using RPGEnigma.Menu;

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
        }
    }
}
