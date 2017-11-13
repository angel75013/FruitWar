namespace FruitWar.Models.Warriors
{
    public class Monkey:Warrior
    {
        private const int MonkeySpeed = 2;
        private const int MonkeyPower = 2;

        public Monkey(int MonkeySpeed,int MonkeyPower) :base(MonkeySpeed, MonkeyPower)
        {

        }
    }
}
