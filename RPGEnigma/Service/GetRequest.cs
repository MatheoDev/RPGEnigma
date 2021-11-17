using System;
using System.Collections.Generic;
using RPGDatabase;
using RPGDatabase.Models.GamePart;

namespace RPGEnigma.Service
{
    public static class GetRequest
    {
        public static List<Party> GetParty()
        {
            List<Party> listParty = new List<Party>();
            using (RpgContext rpgContext = new RpgContext())
            {
                foreach (Party party in rpgContext.PartySet)
                {
                    listParty.Add(party);
                }
            }
            return listParty;
        }
    }
}
