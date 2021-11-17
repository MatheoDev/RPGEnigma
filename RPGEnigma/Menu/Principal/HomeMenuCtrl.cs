using System;
using RPGDatabase.Models.GamePart;
using RPGEnigma.Service;

namespace RPGEnigma.Menu.Principal
{
    public class HomeMenuCtrl
    {
        private MenuCtrl _menu;

        public HomeMenuCtrl()
        {
        }

        public bool CheckNumberOfParty()
        {
            return GetRequest.GetParty().Count != 0 ? true : false;
        }

        public void ManageMenu()
        {
            if (CheckNumberOfParty())
            {
                foreach(Party party in GetRequest.GetParty())
                {
                    Console.WriteLine(party.Name);
                }
            } else
            {
                Console.WriteLine("Créez une partie");
            }
        }
    }
}
