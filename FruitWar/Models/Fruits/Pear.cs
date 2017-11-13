using FruitWar.Common;

namespace FruitWar.Models.Fruits
{
    public class Pear:Fruit
    {             
        public Pear(int coordinateX, int coordinateY) 
            :base(ApplicationConstants.PearPower, ApplicationConstants.PearSymbol, coordinateX, coordinateY)
        {          
        }
    }
}
