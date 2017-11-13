using FruitWar.Container;
using FruitWar.Engine;
using Ninject;

namespace FruitWar
{
    public class Start
    {
        static void Main(string[] args)
        {
            IKernel kernel = new StandardKernel(new FruitWarNinjectModule());
            IEngine engine = kernel.Get<IEngine>();
            engine.Start();
        }
    }
}
