using System;
using RPGEnigma.Menu;

namespace RPGEnigma.Place
{
    public class TownhallCtrl : IMenuItem
    {
        public TownhallCtrl()
        {
            name = "MAIRIE";
        }

        public string name { get; set; }

        public void InitItem()
        {
            Console.Clear();
            Console.WriteLine("--- MAIRIE ---");
        }
    }
}
