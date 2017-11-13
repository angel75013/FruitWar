namespace FruitWar.Models.Fruits
{
    public abstract class Fruit
    {
        private int superPower;
        private char symbolPresentation;
        private int x;
        private int y;


        public Fruit(int superPower, char symbolPresentation, int x, int y)
        {
            this.superPower = superPower;
            this.symbolPresentation = symbolPresentation;
            this.CoordX = x;
            this.CoordY = y;
        }

        public int SuperPower
        {
            get
            {
                return superPower;
            }
            set
            {
                this.superPower = value;
            }
        }
        public char SymbolPresentation
        {
            get
            {
                return symbolPresentation;
            }
            set
            {
                this.symbolPresentation = value;
            }
        }
        public int CoordX
        {
            get
            {
                return x;
            }
            set
            {
                this.x = value;
            }
        }
        public int CoordY
        {
            get
            {
                return y;
            }
            set
            {
                this.y = value;
            }
        }
    }
}
