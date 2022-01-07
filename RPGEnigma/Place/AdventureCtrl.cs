using System;
using System.Collections.Generic;
using RPGDatabase.Models.Character;
using RPGDatabase.Models.Enum;
using RPGDatabase.Models.Item;
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
            DefineMonsterToFight();
            NarationDialogue.RecapOfTheRound(currentMonster, GameHome.Hero.Name);
            bool isOver = false;
            int round = 0;
            while (!isOver)
            {
                Console.Clear();
                ConsoleUtils.WriteInfosStory();
                ConsoleUtils.WriteInfosCombat(currentMonster, GameHome.Hero);
                if (GameHome.Hero.Pv <= 0)
                {
                    isOver = true;
                } else if (currentMonster.Pv <= 0)
                {
                    isOver = true;
                }
                // CONSOLE : STAT HERO + MONSTER
                if (!isOver && round % 2 == 0)
                {
                    // HERO ACTION -> ATTAQUE OU SE SOIGNE
                    // function to do an action choose item to fight
                    InteractionOfPlayer();
                } else if(!isOver && round % 2 != 0)
                {
                    // MONSTER ACTION -> ATTAQUE
                    // function to attaque with the monster
                    InteractionOfBot();
                }
                round = round + 1;
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

        public void InteractionOfPlayer()
        {
            Console.WriteLine("0: Attaquer\n1: Se soigner");
            int action = ConsoleUtils.AskPlayerReturnInt("Attaquer ou se restaurer de la vie?", 0, 2);
            Console.WriteLine("");
            if (action == 0)
            {
                if (GameHome.Hero.HeroWeapons.Count > 0)
                {
                    List<string> menu = new List<string>();
                    List<Weapon> items = GetRequest.GiveWeapHeroFight(menu, GameHome.Hero);
                    MenuCtrl menuCtrl = new MenuCtrl(menu);
                    Console.WriteLine("Liste:\n");
                    menuCtrl.BuildMenu();
                    int actionWeap = ConsoleUtils.AskPlayerReturnInt("Quel armes voulez vous utiliser?", 0, items.Count);
                    currentMonster.Pv = currentMonster.Pv - (GameHome.Hero.Power + items[actionWeap].Power);
                } else
                {
                    currentMonster.Pv = currentMonster.Pv - GameHome.Hero.Power;
                }
                ConsoleUtils.WriteLetterByLetter("Vous attaquez le dragon!");
                Console.Read();
            } else
            {
                List<string> menu = new List<string>();
                List<ItemCtrl> items = GetRequest.GiveConsoHeroFight(menu, GameHome.Hero);
                MenuCtrl menuCtrl = new MenuCtrl(menu);
                if (items.Count == 0)
                {
                    Console.WriteLine("Vous n'avez pas de soin");
                    InteractionOfPlayer();
                } else
                {
                    Console.WriteLine("Liste:\n");
                    menuCtrl.BuildMenu();
                    int actionConso = ConsoleUtils.AskPlayerReturnInt("Que voulez vous manger?", 0, items.Count);
                    if (GameHome.Hero.Pv + items[actionConso].Pv > GameHome.Hero.PvMax)
                    {
                        GameHome.Hero.Pv = GameHome.Hero.PvMax;
                    }
                    else
                    {
                        GameHome.Hero.Pv = GameHome.Hero.Pv + items[actionConso].Pv;
                    }
                }
            }
        }

        public void InteractionOfBot()
        {
            ConsoleUtils.WriteLetterByLetter("Le dragon vous attaque!");
            Console.Read();
            GameHome.Hero.Pv = GameHome.Hero.Pv - currentMonster.Power;
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
