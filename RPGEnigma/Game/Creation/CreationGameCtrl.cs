using System;
using RPGDatabase.Models.Character;
using RPGEnigma.Game.Naration;
using RPGEnigma.Menu;
using RPGEnigma.Service;
using RPGEnigma.Utils;

namespace RPGEnigma.Game.Creation
{
    public class CreationGameCtrl
    {
        public CreationGameCtrl()
        {
            ProcessCreating();
        }

        public void ProcessCreating()
        {
            NarationDialogue.Beginning();
            string nameHero = ConsoleUtils.AskPlayerReturnString("Quelle est votre nom?\n", true);
            CreatePartAndHero(nameHero);
        }

        public void CreatePartAndHero(string nameHero)
        {
            GetRequest.SetPartyHero(nameHero);
            RouteCtrl._menuPrincipal.InitItem();
        }
    }
}
