using System;
using System.Collections.Generic;
using RPGDatabase.Models.GamePart;
using RPGEnigma.Game;
using RPGEnigma.Game.Creation;
using RPGEnigma.Service;
using RPGEnigma.Utils;

namespace RPGEnigma.Menu.Principal
{
    /**
     * Classe du menu principale
     */
    public class HomeMenuCtrl : IMenuItem
    {
        private List<Party> _parties;

        private GameHome _currentGame;

        private CreationGameCtrl _creationGame;

        public HomeMenuCtrl()
        {
            name = "MENU PRINCIPAL";
        }

        public string name { get; set; }

        public void InitItem()
        {
            _parties = GetRequest.GetParty();
            Console.Clear();
            Console.WriteLine("--- MENU PRINCIPAL ---");
            ManageMenu();
        }

        /**
         * Verifie le nombre de partie 
         */
        private bool CheckNumberOfParty()
        {
            return _parties.Count != 0 ? true : false;
        }

        /**
         * Permet de faire soit une création de partie ou bien de lancer le jeu pour une partie
         */
        private void MakeSomething(int numberParty)
        {
            if (numberParty == _parties.Count)
            {
                _creationGame = new CreationGameCtrl();
            }
            else
            {
                _currentGame = new GameHome(_parties[numberParty]);
            }
        }

        /**
         * Permet de créer le menu principale 
         */
        private void ManageMenu()
        {
            if (CheckNumberOfParty())
            {
                int numberParty = 0;
                ConsoleUtils.WriteMenuConsole(_parties);
                if (_parties.Count < 3)
                {
                    Console.WriteLine("{0} : Créez une nouvelle partie \n", _parties.Count);
                    numberParty = ConsoleUtils.AskPlayerReturnInt("Choisir une partie :", 0, _parties.Count+1);
                } else
                {
                    numberParty = ConsoleUtils.AskPlayerReturnInt("Choisir une partie :", 0, _parties.Count);
                }
                MakeSomething(numberParty);
            } else
            {
                _creationGame = new CreationGameCtrl();
            }
        }
    }
}
