using FruitWar.Engine;
using FruitWar.Models.Warriors;

namespace FruitWar.Factories
{
    public interface IWarriorFactory
    {
        Warrior FactoryWarrior(int inputNumber);
    }
}