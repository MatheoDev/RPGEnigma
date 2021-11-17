using System;
using RPGDatabase.Models.GamePart;
using RPGEnigma.Menu;

namespace RPGEnigma.Game
{
    public class GameHome
    {
        public Party _party { get; set; }

        public GameHome(Party party)
        {
            _party = party;
            RouteCtrl._home.InitItem();
        }
    }
}
