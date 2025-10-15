using SotongStudio.Plugins.DI.LogicLoader;
using SotongStudio.Trainee.Gameplay.Facility.Recruit.Screen;
using VContainer;
using VContainer.Unity;

namespace SotongStudio.Trainee
{
    public static class RecruitDIRootRegistration
    {
        public static IContainerBuilder RegisterRecruitRootDI(this IContainerBuilder builder)
        {
            builder.RegisterEntryPoint<RecruitFacilityController>(Lifetime.Singleton).As<IRecruitFacilityController>().As<IAsyncStartable>();
            builder.RegisterEntryPoint<RecruitFacilityCoordinator>(Lifetime.Singleton).As<IAsyncStartable>();

            builder.Register<RecruitLogicLoader>(Lifetime.Singleton).As<ILogicLoader<IRecruitFacilityLogic>>();
            return builder;
        }
    }
}
