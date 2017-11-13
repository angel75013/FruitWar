using FruitWar.Common;
using FruitWar.Container;
using FruitWar.Factories;
using FruitWar.Models.Player;
using FruitWar.Providers;
using Ninject;
using System;
using System.Collections.Generic;

namespace FruitWar.Engine
{
    public class FruitWarEngine : IEngine
    {
        private readonly IFruitGenerator fruitfactory;
        private readonly IPlayerGenerator playerFactory;
        private readonly ILogger logger;
        private readonly IReader reader;
        private readonly IField field;
        private IList<Player> players;
        Player winner;

        public FruitWarEngine(IField field, IFruitGenerator fruitfactory, IPlayerGenerator playerFactory, ILogger logger, IReader reader)
        {
            this.field = field;
            this.fruitfactory = fruitfactory;
            this.playerFactory = playerFactory;
            this.logger = logger;
            this.reader = reader;
            this.players = new List<Player>(ApplicationConstants.NumberOfPlayers);
        }

        public void Start()
        {
            InitGame();
            StartPlaying();
        }

        private void StartPlaying()
        {
            ConsoleKeyInfo keyInfo;

            for (int i = 0; ; i++)
            {
                //extended if more than 2 players, turn roles
                var playerToPlay = players[i % players.Count];
                var turnsToPlay = playerToPlay.Warrior.Speed;
                while (turnsToPlay > 0)
                {
                    logger.Log(string.Format(ApplicationConstants.MakeAMove, playerToPlay.Symbol));
                    keyInfo = reader.ReadKey();

                    this.field.BoardField[playerToPlay.Row, playerToPlay.Col] = ApplicationConstants.FieldSymbol;
                    switch (keyInfo.Key)
                    {

                        case ConsoleKey.UpArrow:
                            if (CheckBorder(playerToPlay.Row - 1, playerToPlay.Col))
                            {
                                turnsToPlay--;
                                CheckField(--playerToPlay.Row, playerToPlay.Col, this.field, playerToPlay);
                                MoveToNewPosition(playerToPlay.Row, playerToPlay.Col, this.field, playerToPlay);
                            }
                            break;
                        case ConsoleKey.RightArrow:
                            if (CheckBorder(playerToPlay.Row, playerToPlay.Col + 1))
                            {
                                turnsToPlay--;
                                CheckField(playerToPlay.Row, ++playerToPlay.Col, this.field, playerToPlay);
                                MoveToNewPosition(playerToPlay.Row, playerToPlay.Col, this.field, playerToPlay);
                            }
                            break;
                        case ConsoleKey.DownArrow:
                            if (CheckBorder(playerToPlay.Row + 1, playerToPlay.Col))
                            {
                                turnsToPlay--;
                                CheckField(++playerToPlay.Row, playerToPlay.Col, this.field, playerToPlay);
                                MoveToNewPosition(playerToPlay.Row, playerToPlay.Col, this.field, playerToPlay);
                            }
                            break;
                        case ConsoleKey.LeftArrow:
                            if (CheckBorder(playerToPlay.Row, playerToPlay.Col - 1))
                            {
                                turnsToPlay--;
                                CheckField(playerToPlay.Row, --playerToPlay.Col, this.field, playerToPlay);
                                MoveToNewPosition(playerToPlay.Row, playerToPlay.Col, this.field, playerToPlay);
                            }
                            break;
                        default:
                            logger.Log(ApplicationConstants.InvalidKeyEntry);
                            break;
                    }
                }
            }
        }

        private void MoveToNewPosition(int row, int col, IField field, Player playerToPlay)
        {
            field.BoardField[row, col] = playerToPlay.Symbol;
            logger.Clear();
            this.field.PrintReports(players);
        }
        private bool CheckBorder(int x, int y)
        {
            if (x > ApplicationConstants.MaxValueField || y > ApplicationConstants.MaxValueField
                || x < ApplicationConstants.MinValueField || y < ApplicationConstants.MinValueField)
            {
                logger.Log(ApplicationConstants.HitBord);
                return false;
            }
            return true;
        }

        private void CheckField(int row, int col, IField field, Player player)
        {
            if (field.BoardField[row, col] == ApplicationConstants.AppleSymbol)
            {
                player.Warrior.Speed++;
            }
            else if (field.BoardField[row, col] == ApplicationConstants.PearSymbol)
            {
                player.Warrior.Power++;
            }
            else if (field.BoardField[row, col] != player.Symbol && field.BoardField[row, col] != ApplicationConstants.FieldSymbol)
            {
                GameOver();
            }
        }
        public void Reset()
        {
            IKernel kernel = new StandardKernel(new FruitWarNinjectModule());
            IEngine engine = kernel.Get<IEngine>();
            engine.Start();
        }

        private void GameOver()
        {
            int best = players[0].Warrior.Power;
            for (int i = 1; i < players.Count; i++)
            {
                if (players[i].Warrior.Power > best)
                {
                    best = players[i].Warrior.Power;
                }
            }
            var counter = 0;
            foreach (var player in players)
            {
                if (player.Warrior.Power == best)
                {
                    counter++;
                    winner = player;
                }
            }
            //we have more than one player with best result
            if (counter > 1)
            {
                logger.Log(ApplicationConstants.Draw);
            }
            else
            {
                logger.Log(string.Format(ApplicationConstants.WinnerMessage,
                                   winner.Symbol, winner.Warrior.GetType().Name, winner.Warrior.Power, winner.Warrior.Speed));

            }
            logger.Log(ApplicationConstants.Rematch);
            string result = reader.ReadLine();
            if (result == "y")
            {
                logger.Clear();
                Reset();
                Start();
            }
            else
            {
                Environment.Exit(0);
            }
        }

        private void InitGame()
        {
            //read choice players
            List<int> playerChoices = new List<int>(ApplicationConstants.NumberOfPlayers);
            for (int i = 1; i < ApplicationConstants.NumberOfPlayers + 1; i++)
            {
                string name = "Player" + i;
                logger.Log(string.Format(ApplicationConstants.ChooseCharacter, name));
                var number = int.Parse(reader.ReadLine());
                if (number != 1 && number != 2 && number != 3)
                {
                    logger.Log(ApplicationConstants.InvalidNumber);
                    i--;
                    continue;
                }
                playerChoices.Add(number);
            }
            //initialize game object, field,players
            field.InitializeBoard();
            players = this.playerFactory.GeneratePlayersPositions(this.field, playerChoices);
            fruitfactory.GenerateFruitsPositions(field, players);
            field.PrintReports(players);
        }
    }
}

