using System;
using RPGEnigma.Utils;

namespace RPGEnigma.Game.Naration
{
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
            "En selle :hero et bon courage, prend donc le chemin au dos de ce dragon amical.";

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
    }
}
