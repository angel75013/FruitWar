using FruitWar.Engine;
using FruitWar.Models.Player;
using System.Collections.Generic;

namespace FruitWar.Factories
{
    public interface IPlayerGenerator
    {
        IList<Player> GeneratePlayersPositions(IField field, IList<int> playerChoices);
    }
}