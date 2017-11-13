using FruitWar.Common;

namespace FruitWar.Models.Fruits
{
    public class Apple : Fruit
    {
        public Apple(int coordinateX, int coordinateY)
            : base(ApplicationConstants.ApplePower, ApplicationConstants.AppleSymbol, coordinateX, coordinateY)
        {           
        }
    }
}
