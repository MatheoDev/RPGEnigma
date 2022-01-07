using System;
using RPGDatabase.Models.Character;
using RPGEnigma.Utils;

namespace RPGEnigma.Game.Naration
{
    /**
     * Classe de la naration
     */
    public static class NarationDialogue
    {
        private static string TEXT_BEGIN = "Bienvenue dans le monde de Soyakichu" +
            "\nUn monde perdu rempli de dragon, j'aimerais vous confier une tâche importante!" +
            "\nMais avant de vous expliquer j'aimerais qu'on fasse plus ample connaissance...\n";

        private static string TEXT_PRENSETATION = "Enchanté(e) :hero!\n" +
            "J'espère que tu es de bonne écoute.\n" +
            "Notre monde est un endroit flottant pour te balader d'une île à une autre\n" +
            "il faudra que tu battes le dragon final de chaque île il t'y emmenera avec\n" +
            "respect une fois vaincu...\n" +
            "Ton but dans cette aventure est d'aller chercher un trésor détenu par\n" +
            "la plus forte des civilisations de ce monde. Le chemin sera de rude épreuve.\n" +
            "En selle :hero et bon courage, prend donc le chemin au dos de ce dragon amical.\n" +
            "Appuyer sur une touche pour continuer.";

        private static string TEXT_PRESENTATION_ROUND = ":hero! Te voici sur l'île des dragon de :type.\n" +
            "Il te faudra dans un premier temps battre le(s) :monster pour pouvoir passer au niveau suivant.\n" +
            "Je te souhaite bon courage, LEZGOOO...\n" +
            "Appuyer sur une touche pour continuer.";

        private static string TEXT_LOOSE_GAME = "RHA! Dommage c'était moins une, reviens plus fort en achetant des items\n" +
            "tu devrais avoir plus de chance :hero! J'espère que tu ne t'es pas fait trop mal durant le combat, tu peux\n" +
            "aller te reposer à la TAVERNE si tu est trop mal en point.\n" +
            "Appuyer sur une touche pour continuer.";

        private static string TEXT_WIN_ROUND_GAME = "Bravo :hero! Tu as réussi a vaincre ce monstre tu peux passer à l'étape suivante";

        private static string TEXT_CHANGE_ILE_GAME = "Félicitations :hero, tu as vaincu le Boss de l'île tu peux maintenant\n" +
            "te diriger vers la prochaine île : :type. Monte sur le dos de ce dragon pour y aller!\n" +
            "Appuyer sur une touche pour continuer.";

        private static string TEXT_TERMINATE_GAME = ":hero..... Je te félicite pour cet exploit, tu as remporté tous les combats\n" +
            "et tu as fait preuve de courage et de force pour parvenir jusqu'ici. GG, tu as temriné le jeu à 100%\n" +
            "Tu as bien mérité de prendre ce trésor, il est tout à toi.\n" +
            "Appuyer sur une touche pour continuer.";

        public static void Beginning()
        {
            ConsoleUtils.WriteLetterByLetter(TEXT_BEGIN);
        }

        public static void HistoryAndStart(string name)
        {
            TEXT_PRENSETATION = TEXT_PRENSETATION.Replace(":hero", name);
            ConsoleUtils.WriteLetterByLetter(TEXT_PRENSETATION);
            Console.Read();
        }

        public static void RecapOfTheRound(Monster monster, string nameHero)
        {
            TEXT_PRESENTATION_ROUND = TEXT_PRESENTATION_ROUND.Replace(":hero", nameHero);
            TEXT_PRESENTATION_ROUND = TEXT_PRESENTATION_ROUND.Replace(":monster", monster.Name);
            TEXT_PRESENTATION_ROUND = TEXT_PRESENTATION_ROUND.Replace(":type", monster.Type.ToString());
            ConsoleUtils.WriteLetterByLetter(TEXT_PRESENTATION_ROUND);
            Console.Read();
        }

        public static void LooseGame(string name)
        {
            TEXT_LOOSE_GAME = TEXT_LOOSE_GAME.Replace(":hero", name);
            ConsoleUtils.WriteLetterByLetter(TEXT_LOOSE_GAME);
            Console.Read();
        }

        public static void WinRound(string name)
        {
            TEXT_WIN_ROUND_GAME = TEXT_WIN_ROUND_GAME.Replace(":hero", name);
            ConsoleUtils.WriteLetterByLetter(TEXT_WIN_ROUND_GAME);
            Console.Read();
        }

        public static void CongratsChangeIle(string name, string type)
        {
            TEXT_CHANGE_ILE_GAME = TEXT_CHANGE_ILE_GAME.Replace(":hero", name);
            TEXT_CHANGE_ILE_GAME = TEXT_CHANGE_ILE_GAME.Replace(":type", type);
            ConsoleUtils.WriteLetterByLetter(TEXT_CHANGE_ILE_GAME);
            Console.Read();
        }

        public static void TerminateTheGame(string name)
        {
            TEXT_TERMINATE_GAME = TEXT_TERMINATE_GAME.Replace(":hero", name);
            ConsoleUtils.WriteLetterByLetter(TEXT_TERMINATE_GAME);
            Console.Read();
        }
    }
}
