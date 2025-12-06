using SotongStudio.Plugins.DI.LogicLoader;
using SotongStudio.Trainee.Gameplay.Facility.Training.DI;
using SotongStudio.Trainee.Gameplay.Facility.Training.Screen;
using VContainer;
using VContainer.Unity;

namespace SotongStudio.Trainee.Gameplay.Facility.Training
{
    public static class TrainingVacilityDIBuild
    {
        public static IContainerBuilder RegisterTrainingFacilityRootDI(this IContainerBuilder builder)
        {
            builder.Register<TrainingFacilityLogicLoader>(Lifetime.Singleton).As<ILogicLoader<ITrainingFacilityLogic>>();

            builder.RegisterEntryPoint<TrainingFacilityCoordinator>(Lifetime.Singleton).As<IAsyncStartable>();
            builder.Register<TrainingFacilityController>(Lifetime.Singleton).As<ITrainingFacilityController>();

            builder.Register<CharacterTrainingDataService>(Lifetime.Singleton)
                 .As<ITrainingFacilityDataService>()
                 .As<ITrainingFacilityDataUpdateService>();

            return builder;
        }
    }
}
