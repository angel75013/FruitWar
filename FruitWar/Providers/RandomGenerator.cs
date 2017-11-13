using FruitWar.Common;
using System;

namespace FruitWar.Providers
{
    public class RandomGenerator:IRandom
    {
        
        private Random r = new Random();
        public int GetRandomValue()
        {
            return r.Next(ApplicationConstants.MinValue, ApplicationConstants.MaxValue);
        }
    }
}
