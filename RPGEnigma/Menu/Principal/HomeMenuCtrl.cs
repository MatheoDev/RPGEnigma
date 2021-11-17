using System;
using RPGEnigma.Service;

namespace RPGEnigma.Menu.Principal
{
    public class HomeMenuCtrl
    {
        public HomeMenuCtrl()
        {
            Console.WriteLine(CheckNumberOfParty());
        }

        public bool CheckNumberOfParty()
        {
            return GetRequest.GetParty().Count != 0 ? true : false;
        }
    }
}
