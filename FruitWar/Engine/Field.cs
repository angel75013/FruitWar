using FruitWar.Common;
using FruitWar.Models.Player;
using FruitWar.Providers;
using System.Collections.Generic;

namespace FruitWar.Engine
{
    public class Field:IField
    {
        private char[,] boardField;
        private readonly ILogger logger;

        public Field(ILogger logger)
        {
            this.BoardField = new char[ApplicationConstants.MATRIX_ROWS, ApplicationConstants.MATRIX_COLUMNS];
            this.logger = logger;
        }
        public char[,] BoardField {
            get { return this.boardField; }
            set { this.boardField = value; }
        }
        public void InitializeBoard()
        {
            int rowLength = this.boardField.GetLength(0);
            int colLength = this.boardField.GetLength(1);
            logger.Clear();
            for (int i = 0; i < rowLength; i++)
            {
                for (int j = 0; j < colLength; j++)
                {
                    boardField[i, j] = ApplicationConstants.FieldSymbol;
                }
            }
        }
        public void PrintReports(IList<Player> players)
        {
            int rowLength = this.boardField.GetLength(0);
            int colLength = this.boardField.GetLength(1);

            for (int i = 0; i < rowLength; i++)
            {
                logger.LogLine();
                for (int j = 0; j < colLength; j++)
                {
                    logger.LogOnSameLine(boardField[i, j] + " ");
                }
                logger.LogLine();
            }
            foreach (var player in players)
            {
                logger.Log(player.ToString());
            } 
        }      
    }
}
