using System;
using System.Linq;

namespace Task1
{
    internal class Program
    {
        private static void Main()
        {
            var value = "";

            do
            {
                try
                {
                    Console.WriteLine("Please enter some text (to exit enter q):");
                    value = Console.ReadLine();

                    Console.WriteLine(value?.ElementAt(0));
                }
                catch
                {
                    Console.WriteLine("Error! The text should not be empty");
                }

            } while (value != "q");
        }
    }
}