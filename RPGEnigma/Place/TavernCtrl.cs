using System;
using RPGEnigma.Menu;

namespace RPGEnigma.Place
{
    public class TavernCtrl : IMenuItem
    {
        public TavernCtrl()
        {
            name = "TAVERN";
        }

        public string name
        {
            get; set;
        }

        public void InitItem()
        {
            Console.Clear();
            Console.WriteLine("TAVERN");
        }
    }
}
