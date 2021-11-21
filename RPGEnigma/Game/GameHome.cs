using System;
using RPGDatabase.Models.GamePart;
using RPGEnigma.Menu;

namespace RPGEnigma.Game
{
    public class GameHome
    {
        public static Party Party { get; set; }

        public GameHome(Party party)
        {
            Party = party;
            RouteCtrl._home.InitItem();
        }
    }
}
