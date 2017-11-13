using FruitWar.Common;
using FruitWar.Engine;
using FruitWar.Models.Fruits;
using FruitWar.Models.Player;
using FruitWar.Providers;
using System;
using System.Collections.Generic;

namespace FruitWar.Factories
{
    public class FruitGenerator:IFruitGenerator
    {              
        private readonly IRandom r;
        private readonly IField board;
        private List<Fruit> allFruits;
        public FruitGenerator(IField board,IRandom r)
        {
            this.board = board;
            this.r = r;
            allFruits= new List<Fruit>(ApplicationConstants.NumberFruits);
        }
        public void GenerateFruitsPositions(IField board,IList<Player>players)
        {
            int counter = 0;

            while (counter < ApplicationConstants.NumberFruits)
            {
                int x = r.GetRandomValue();
                int y = r.GetRandomValue();
                if (CheckFruitPosition(allFruits, x, y, board, players))
                {
                    counter++;
                    if (counter <= ApplicationConstants.NumberApples)
                    {
                        var apple = new Apple(x, y);
                        board.BoardField[x, y] = apple.SymbolPresentation;
                        allFruits.Add(apple);
                    }
                    else
                    {
                        var pear = new Pear(x, y);
                        board.BoardField[x, y] = pear.SymbolPresentation;
                        allFruits.Add(pear);
                    }
                }
            }
        }

        private bool CheckFruitPosition(List<Fruit> allFruits, int x, int y, IField board, IList<Player> players)
        {
            var isInRange = true;
            foreach (var player in players)
            {
                if (board.BoardField[x, y] == player.Symbol)
                {
                    isInRange = false;
                }
            }
           
            foreach (var fruit in allFruits)
            {
                if (Math.Abs(x - fruit.CoordX) + Math.Abs(y - fruit.CoordY) < ApplicationConstants.MinRequiredDifferenceFruits)
                {
                    isInRange = false;
                    break;
                }
            }
            return isInRange;
        }       
    }
}
