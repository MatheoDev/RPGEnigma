using System;
using RPGDatabase.Models.Character;
using RPGDatabase.Models.GamePart;
using RPGEnigma.Menu;
using RPGEnigma.Service;

namespace RPGEnigma.Game
{
    /**
     * Classe permettant d'avoir la partie courante
     */
    public class GameHome
    {
        public static Party Party { get; set; }
        public static Hero Hero { get; set; }

        public GameHome(Party party)
        {
            Party = party;
            Hero = GetRequest.GetHero(party.Hero.Id);
            RouteCtrl._home.InitItem();
        }
    }
}
