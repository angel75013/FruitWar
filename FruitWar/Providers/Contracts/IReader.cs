using System;

namespace FruitWar.Providers
{
    public interface IReader
    {
        string ReadLine();
        ConsoleKeyInfo ReadKey();
    }
}