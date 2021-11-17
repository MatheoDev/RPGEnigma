using System;
using System.Collections.Generic;
using RPGDatabase;
using RPGDatabase.Models.GamePart;

namespace RPGEnigma.Service
{
    /**
     * Classe GetRequest
     * Permet de faire toute requete vers la BDD 
     * afin de recupérer les valeurs que nous voulons
     */
    public static class GetRequest
    {
        /**
         * Liste des Parties
         */
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
