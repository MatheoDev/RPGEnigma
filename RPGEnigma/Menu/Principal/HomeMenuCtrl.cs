using System;
using System.Collections.Generic;
using RPGDatabase.Models.GamePart;
using RPGEnigma.Game;
using RPGEnigma.Game.Creation;
using RPGEnigma.Service;
using RPGEnigma.Utils;

namespace RPGEnigma.Menu.Principal
{
    public class HomeMenuCtrl : IMenuItem
    {
        private List<Party> _parties;

        private GameHome _currentGame;

        public HomeMenuCtrl()
        {
            name = "Menu Principal";
        }

        public string name { get; set; }

        public void InitItem()
        {
            _parties = GetRequest.GetParty();
            ManageMenu();
        }

        public bool CheckNumberOfParty()
        {
            return _parties.Count != 0 ? true : false;
        }

        public void ManageMenu()
        {
            if (CheckNumberOfParty())
            {
                ConsoleUtils.WriteMenuConsole(_parties);
                int numberParty = ConsoleUtils.AskPlayerReturnInt("Choisir une partie :", 0, _parties.Count);
                _currentGame = new GameHome(_parties[numberParty]);
            } else
            {
                Console.WriteLine("Créez une partie");
                new CreationGameCtrl();
            }
        }
    }
}
