using FruitWar.Engine;
using FruitWar.Factories;
using FruitWar.Providers;
using Ninject.Modules;

namespace FruitWar.Container
{
    class FruitWarNinjectModule : NinjectModule
    {
        public override void Load()
        {
            this.Bind<IField>().To<Field>().InSingletonScope();
            this.Bind<IFruitGenerator>().To<FruitGenerator>().InSingletonScope();
            this.Bind<IEngine>().To<FruitWarEngine>().InSingletonScope();
            this.Bind<IWarriorFactory>().To<WarriorFactory>().InSingletonScope();
            this.Bind<IPlayerGenerator>().To<PlayerGenerator>().InSingletonScope();
            this.Bind<ILogger>().To<ConsoleLogger>().InSingletonScope();
            this.Bind<IReader>().To<ConsoleReader>().InSingletonScope();
            this.Bind<IRandom>().To<RandomGenerator>().InSingletonScope();
        }
    }
}
