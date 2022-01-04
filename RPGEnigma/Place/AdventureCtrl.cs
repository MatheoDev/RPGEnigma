using System;
using System.Collections.Generic;
using RPGDatabase.Models.Character;
using RPGEnigma.Game;
using RPGEnigma.Game.Naration;
using RPGEnigma.Menu;
using RPGEnigma.Service;
using RPGEnigma.Utils;

namespace RPGEnigma.Place
{
    public class AdventureCtrl : IMenuItem
    {
        public AdventureCtrl()
        {
            name = "AVENTURE";
        }

        public string name { get; set; }

        public List<Monster> monsters;

        public Monster currentMonster;

        public void InitItem()
        {
            Console.Clear();
            Console.WriteLine("--- AVENTURE ---");
            ConsoleUtils.WriteInfosStory();
            ConsoleUtils.WriteInfosHero();
            DefineMonsterToFight();
            Console.Read();
        }

        public void Game()
        {
            //NarationDialogue.RecapOfTheRound();
        }

        public void DefineMonsterToFight()
        {
            monsters = GetRequest.GetMonsters(GameHome.Party.Story);
            if (GameHome.Party.Story.Level % 5 == 1 || GameHome.Party.Story.Level % 5 == 2)
            {
                currentMonster = monsters.Find(m => m.Name.Contains("Bébé"));
            }
            else if (GameHome.Party.Story.Level % 5 == 3 || GameHome.Party.Story.Level % 5 == 4)
            {
                currentMonster = monsters.Find(m => !m.Name.Contains("Bébé") && !m.Name.Contains("Boss"));
            }
            else if (GameHome.Party.Story.Level % 5 == 0)
            {
                currentMonster = monsters.Find(m => m.Name.Contains("Boss"));
            }
        }

        public void ResultGame()
        {

        }

        //lvl > si 100 fini partie, tant que pv 0, get monstre en fonction du type et du lvl voila voila
    }
}
