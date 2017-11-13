using FruitWar.Models.Warriors;
using System;

namespace FruitWar.Factories
{
    public class WarriorFactory:IWarriorFactory
    {
        public  Warrior FactoryWarrior(int inputNumber)
        {
            switch (inputNumber)
            {
                case 1: return new Turtle(1, 3);
                case 2: return new Monkey(2, 2);
                case 3: return new Pigeon(3, 1);                
                default: throw new ArgumentException("Invalid type", "type");
            }
        }
    }
}
