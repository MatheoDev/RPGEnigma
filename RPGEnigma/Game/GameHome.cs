using System;
using RPGDatabase.Models.GamePart;
using RPGEnigma.Menu;

namespace RPGEnigma.Game
{
    /**
     * Classe permettant d'avoir la partie courante
     */
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
