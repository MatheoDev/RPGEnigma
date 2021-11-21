using System;
using RPGDatabase.Models.Character;
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
            string nameHero = ConsoleUtils.AskPlayerReturnString("Quel sera le nom de votre Héros (le nom de la partie sera le même) ?");
            CreatePartAndHero(nameHero);
        }

        public void CreatePartAndHero(string nameHero)
        {
            GetRequest.SetPartyHero(nameHero);
            RouteCtrl._menuPrincipal.InitItem();
        }
    }
}
