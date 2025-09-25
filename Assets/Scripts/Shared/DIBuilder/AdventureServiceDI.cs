using SotongStudio.Trainee.Service.AdventureGenerator;
using SotongStudio.Trainee.Service.PotencyGenerator;
using SotongStudio.Trainee.Shared.Adventure.Data;
using VContainer;

namespace SotongStudio.Trainee
{
    public static class AdventureServiceDI 
    {
        public static void RegisterAdverntureServiceDI(this IContainerBuilder builder)
        {
            builder.Register<AdventureGenerator>(Lifetime.Singleton);
            builder.Register<PotencyGeneratorService>(Lifetime.Singleton);

            builder.Register<AdventureMetaDataService>(Lifetime.Singleton)
                   .As<IAdventureMetaDataService>()
                   .As<IAdventureMetaDatUpdateService>();
        }
    }
}
