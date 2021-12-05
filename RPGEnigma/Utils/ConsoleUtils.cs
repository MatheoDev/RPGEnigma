using System;
using System.Collections.Generic;
using System.Threading;
using RPGDatabase.Models.GamePart;
using RPGEnigma.Menu;

namespace RPGEnigma.Utils
{
    /**
     * Classe ConsoleUtils
     * Permet de faire toute action sur la console
     * Demander une info ou afficher une info
     */
    public class ConsoleUtils
    {
        public ConsoleUtils()
        {
        }

        public static void WriteMenuConsole(List<IMenuItem> show)
        {
            for (int i = 0; i < show.Count; i++)
            {
                Console.WriteLine("{0} : {1}",i , show[i].name);
            }
            Console.WriteLine("");
        }

        public static void WriteMenuConsole(List<string> show)
        {
            for (int i = 0; i < show.Count; i++)
            {
                Console.WriteLine("{0} : {1}", i, show[i]);
            }
            Console.WriteLine("");
        }

        public static void WriteMenuConsole(List<Party> show)
        {
            for (int i = 0; i < show.Count; i++)
            {
                Console.WriteLine("{0} : {1}", i, show[i].Name);
            }
            Console.WriteLine("");
        }

        public static int AskPlayerReturnInt(string question, int min = int.MinValue, int max = int.MaxValue)
        {
            int number;
            do
            {
                Console.WriteLine(question);
            } while (!int.TryParse(Console.ReadLine(), out number) || number < min || number > max-1);
            return number;
        }

        public static char AskPlayerReturnChar(string question)
        {
            char letter;
            do
            {
                Console.WriteLine(question);
            } while (!char.TryParse(Console.ReadLine(), out letter));
            return letter;
        }

        public static string AskPlayerReturnString(string question)
        {
            Console.WriteLine(question);
            return Console.ReadLine();
        }

        public static void WriteLetterByLetter(string text)
        {
            foreach(char letter in text)
            {
                Console.Write(letter);
                Thread.Sleep(40);
            }
        }
    }
}
