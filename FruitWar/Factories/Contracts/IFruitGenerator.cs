using FruitWar.Engine;
using FruitWar.Models.Fruits;
using FruitWar.Models.Player;
using System.Collections.Generic;

namespace FruitWar.Factories
{
    public interface IFruitGenerator
    {
        void GenerateFruitsPositions(IField board, IList<Player> players);       
    }
}