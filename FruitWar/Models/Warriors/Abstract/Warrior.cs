namespace FruitWar.Models.Warriors
{
    public abstract class Warrior
    {
        private int speed;
        private int power;

        public Warrior(int speed,int power)
        {
            this.speed = speed;
            this.power = power;
        }
        public int Speed
        {
            get
            {
                return speed;
            }
            set
            {
                this.speed = value;
            }
        }
        public int Power
        {
            get
            {
                return power;
            }
            set
            {
                this.power = value;
            }
        }
    }
}
