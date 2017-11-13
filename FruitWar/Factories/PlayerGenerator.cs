using FruitWar.Common;
using FruitWar.Engine;
using FruitWar.Models.Player;
using FruitWar.Providers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FruitWar.Factories
{
    public class PlayerGenerator:IPlayerGenerator
    {       
        private readonly IWarriorFactory factory;
        private readonly IField field;
        private readonly IRandom r;
        private IList<Player> listPlayers;
        public PlayerGenerator(IWarriorFactory factory,IField field, IRandom r)
        {
            this.factory = factory;
            this.field = field;
            this.r = r;
            this.listPlayers= new List<Player>(ApplicationConstants.NumberOfPlayers);
        }
        public IList<Player> GeneratePlayersPositions(IField field, IList<int> playerChoices)
        {           

            for (int i = 0; i < playerChoices.Count; i++)
            {
                var warrior = this.factory.FactoryWarrior(playerChoices[i]);
                int coordX = r.GetRandomValue();
                int coordY = r.GetRandomValue();
                char symbol = (char)(i + ApplicationConstants.AsCiiCode);
                if (listPlayers.Count() == 0)
                {
                    var player = new Player(symbol, coordX, coordY, warrior);
                    this.field.BoardField[player.Row, player.Col] = player.Symbol;
                    listPlayers.Add(player);
                }
                else
                {
                    for (int j = 0; j < listPlayers.Count; j++)
                    {
                        while ((Math.Abs(listPlayers[j].Row - coordX) + Math.Abs(listPlayers[j].Col - coordY)) < ApplicationConstants.MinRequiredDifference)
                        {
                            coordX = r.GetRandomValue();
                            coordY= r.GetRandomValue();
                            //if more than 3 players, must restart the counter
                            j = 0;
                        }                        
                    }
                    var playerNext = new Player(symbol, coordX, coordY, warrior);
                    this.field.BoardField[playerNext.Row, playerNext.Col] = playerNext.Symbol;
                    listPlayers.Add(playerNext);
                }
            }
            return listPlayers;
        }      
    }
}
