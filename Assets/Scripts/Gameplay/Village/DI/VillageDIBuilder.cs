using SotongStudio.Plugins.DI.LogicLoader;
using SotongStudio.Trainee.Gameplay.Village.Screen;
using VContainer;
using VContainer.Unity;

namespace SotongStudio.Trainee
{
    public static class VillageDIBuilder
    {
        public static IContainerBuilder RegisterVillageRootDI(this IContainerBuilder builder)
        {
            builder.Register<VillageLogicLoader>(Lifetime.Singleton).As<ILogicLoader<IVillageLogic>>();

            builder.RegisterEntryPoint<VillageCoordinator>(Lifetime.Singleton).As<IAsyncStartable>();

            builder.Register<VillageController>(Lifetime.Singleton).As<IVillageController>();


            return builder;
        }
    }
}
