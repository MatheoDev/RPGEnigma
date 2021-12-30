using System;
using RPGEnigma.Utils;

namespace RPGEnigma.Game.Naration
{
    public static class NarationDialogue
    {
        private static string TEXT_BEGIN = "Bienvenue dans le monde de Soyakichu" +
            "\nUn monde perdu rempli de dragon, j'aimerais vous confier une tâche importante!" +
            "\nMais avant de vous expliquer j'aimerais qu'on fasse plus ample connaissance...\n";

        public static void Beginning()
        {
            ConsoleUtils.WriteLetterByLetter(TEXT_BEGIN);
        }
    }
}
