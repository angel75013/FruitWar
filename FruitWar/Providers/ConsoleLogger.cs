using System;

namespace FruitWar.Providers
{
    public class ConsoleLogger : ILogger
    {
        public void Clear()
        {
            Console.Clear();
        }

        public void Log(string message)
        {
            Console.WriteLine(message);
        }

        public void LogLine()
        {
            Console.WriteLine();
        }

        public void LogOnSameLine(string message)
        {
            Console.Write(message);
        }
    }
}
