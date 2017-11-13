namespace FruitWar.Models.Warriors
{
    public class Turtle:Warrior
    {
        private const int TurtleSpeed= 1;
        private const int TurtlePower = 3;

        public Turtle(int TurtleSpeed,int  TurtlePower) :base(TurtleSpeed, TurtlePower)
        {

        }
    }
}
