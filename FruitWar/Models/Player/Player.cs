using FruitWar.Models.Warriors;

namespace FruitWar.Models.Player
{
    public class Player
    {
        private int rowPosition;
        private int colPosition;
        private Warrior warrior;
        private char symbol;

        public Player(char symbol, int rowPosition, int colPosition, Warrior warrior)
        {
            this.Row = rowPosition;
            this.Col = colPosition;
            this.Symbol = symbol;
            this.Warrior = warrior;
        }
        public char Symbol {
            get
            {
                return this.symbol;
            }
            set
            {
                this.symbol = value;
            }
        }
        public int Row
        {
            get
            {
                return this.rowPosition;
            }
            set
            {
                this.rowPosition = value;
            }
        }
        public int Col
        {
            get
            {
                return this.colPosition;
            }
            set
            {
                this.colPosition = value;
            }
        }
        public Warrior Warrior
        {
            get
            {
                return warrior;
            }
            set
            {
                this.warrior = value;
            }
        }
     
        public override string ToString()
        {
            return string.Format("Player {0}: {1} Power; {2} Speed", this.Symbol, this.warrior.Power,this.warrior.Speed);           
        }

    }
}
