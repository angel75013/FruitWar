using FruitWar.Models.Player;
using System.Collections.Generic;

namespace FruitWar.Engine
{
    public interface IField
    {
        char[,] BoardField { get; set; }
        void InitializeBoard();
        void PrintReports(IList<Player> players);
    }
}