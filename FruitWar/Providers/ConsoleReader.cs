using System;

namespace FruitWar.Providers
{
    public class ConsoleReader : IReader
    {
        public ConsoleKeyInfo ReadKey()
        {
           return Console.ReadKey();
        }

        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
