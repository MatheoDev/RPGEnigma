using System;
using System.Collections.Generic;
using RPGDatabase.Models.Character;
using RPGDatabase.Models.Enum;
using RPGEnigma.Game;
using RPGEnigma.Game.Naration;
using RPGEnigma.Menu;
using RPGEnigma.Service;
using RPGEnigma.Utils;

namespace RPGEnigma.Place
{
    /**
     * Classe simulant l'aventure (combat)
     */
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
            if (GameHome.Party.Story.Pourcentage == 100)
            {
                Console.Clear();
                TerminateGame();
            } else
            {
                Game();
            }
        }

        /**
         * Deroulement du jeu
         */
        public void Game()
        {
            bool isOver = false;
            int round = 0;
            NarationDialogue.RecapOfTheRound(currentMonster, GameHome.Hero.Name);
            Console.Clear();
            while (!isOver)
            {
                if (GameHome.Hero.Pv == 0)
                {
                    isOver = true;
                } else if (currentMonster.Pv == 0)
                {
                    isOver = true;
                }
                // CONSOLE : STAT HERO + MONSTER
                if (!isOver && round % 2 == 0)
                {
                    // HERO ACTION -> ATTAQUE OU SE SOIGNE
                } else if(!isOver && round % 2 != 0)
                {
                    // MONSTER ACTION -> ATTAQUE
                }
            }

            if (GameHome.Hero.Pv != 0)
            {
                // CHANGEMENT DES VALEURS QUAND HERO WIN
                WinHeroChangeStat();
                WinARound();
            } else
            {
                // DOMMAGE RETURN MENU PAS DE CONSEQUENCE
                LooseGameProcess();
            }
        }

        /**
         * Determine quel type de monstre nous allons rencontrer pour ce round
         */
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

        /**
         * Affecte les valeurs si win
         */
        public void WinHeroChangeStat()
        {
            GameHome.Party.Story.Level = GameHome.Party.Story.Level + 1;
            GameHome.Party.Story.Pourcentage = GameHome.Party.Story.Pourcentage + 5;
            GameHome.Hero.PvMax = 20 * GameHome.Hero.Level + GameHome.Hero.PvMax;
            GameHome.Hero.Power = 2 * GameHome.Hero.Level + GameHome.Hero.Power;
            GameHome.Hero.Money = currentMonster.Money + GameHome.Hero.Money;
            GameHome.Hero.ExperienceLvl = GameHome.Hero.ExperienceLvl + currentMonster.ExperienceLvl * GameHome.Hero.Intelligence;
            GameHome.Hero.Dexterity = 2 * GameHome.Hero.Level + GameHome.Hero.Dexterity;
            GameHome.Hero.Intelligence = 2 * GameHome.Hero.Level + GameHome.Hero.Intelligence;
            if (GameHome.Hero.ExperienceLvl % (100 * GameHome.Hero.Level) == 0)
            {
                GameHome.Hero.ExperienceLvl = 0;
                GameHome.Hero.Level = GameHome.Hero.Level + 1;
            }
            if (GameHome.Party.Story.Level == 6)
            {
                GameHome.Party.Story.IleType = TypeEnum.FIRE;
            }
            else if (GameHome.Party.Story.Level == 11)
            {
                GameHome.Party.Story.IleType = TypeEnum.ROCK;
            }
            else if (GameHome.Party.Story.Level == 16)
            {
                GameHome.Party.Story.IleType = TypeEnum.WIND;
            }

            if (GameHome.Party.Story.Pourcentage == 100)
            {
                InitItem();
            }
        }

        /**
         * Action lorsque nous perdons le round
         */
        public void LooseGameProcess()
        {
            NarationDialogue.LooseGame(GameHome.Hero.Name);
            RouteCtrl._home.InitItem();
        }

        /**
         * Action lorsque nous gagnons le round
         */
        public void WinARound()
        {
            NarationDialogue.WinRound(GameHome.Hero.Name);
            if (GameHome.Party.Story.Level % 5 == 1)
            {
                NarationDialogue.CongratsChangeIle(GameHome.Hero.Name, GameHome.Party.Story.IleType.ToString());
            }
            RouteCtrl._home.InitItem();
        }

        /**
         * Message de fin quand on a fini le jeu
         */
        public void TerminateGame()
        {
            NarationDialogue.TerminateTheGame(GameHome.Hero.Name);
            GameHome.Hero.Money = 1000000 + GameHome.Hero.Money;
            RouteCtrl._home.InitItem();
        }
    }
}
