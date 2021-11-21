using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using RPGDatabase;
using RPGDatabase.Models.Character;
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
                foreach (Party party in rpgContext.PartySet.Include("Hero.Stats"))
                {
                    listParty.Add(party);
                }
            }
            return listParty;
        }

        public static void SetPartyHero(string nameHero)
        {
            using (RpgContext rpgContext = new RpgContext())
            {
                rpgContext.PartySet.Add(new Party(nameHero, new Hero(nameHero)));
                rpgContext.SaveChanges();
            }
        }
    }
}
