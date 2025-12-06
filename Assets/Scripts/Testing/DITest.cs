using SotongStudio.Trainee.Gameplay.Facility.Training;
using SotongStudio.Trainee.Service.AdventureGenerator;
using SotongStudio.Trainee.Service.PotencyGenerator;
using SotongStudio.Trainee.Shared.Adventure.Data;
using VContainer;

namespace SotongStudio.Trainee
{
    public class DITest : SceneScope
    {
        protected override void AddRegistration(IContainerBuilder builder)
        {
            builder.Register<AdventureGenerator>(Lifetime.Singleton);
            builder.Register<PotencyGeneratorService>(Lifetime.Singleton);

            builder.Register<AdventureMetaDataService>(Lifetime.Singleton).As<IAdventureMetaDataProvider>();
            builder.Register<TrainingService>(Lifetime.Singleton).As<ITrainingService>();

        }
    }
}
