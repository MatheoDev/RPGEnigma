using System;
using System.Collections.Generic;

namespace RPGEnigma.Utils
{
    public class ConsoleUtils
    {
        public ConsoleUtils()
        {
        }

        static void WriteMenuConsole(List<string> show)
        {
            for (int i = 0; i < show.Count; i++)
            {
                Console.WriteLine("{0} : {1}",i , show[i]);
            }
        }

        static int AskPlayerReturnInt(string question)
        {
            int number;
            do
            {
                Console.WriteLine(question);
            } while (!int.TryParse(Console.ReadLine(), out number));
            return number;
        }

        static char AskPlayerReturnChar(string question)
        {
            char letter;
            do
            {
                Console.WriteLine(question);
            } while (!char.TryParse(Console.ReadLine(), out letter));
            return letter;
        }

        static string AskPlayerReturnString(string question)
        {
            Console.WriteLine(question);
            return Console.ReadLine();
        }
    }
}
