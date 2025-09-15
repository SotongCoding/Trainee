using SotongStudio.Trainee.Service.AdventureGenerator;
using SotongStudio.Trainee.Service.PotencyGenerator;
using SotongStudio.Trainee.Shared.Adventure.Data;
using UnityEngine;
using VContainer;

namespace SotongStudio.Trainee
{
    public class DITest : SceneScope
    {
        protected override void AddRegistration(IContainerBuilder builder)
        {
            builder.Register<AdventureGenerator>(Lifetime.Singleton);
            builder.Register<PotencyGeneratorService>(Lifetime.Singleton);

            builder.Register<AdventureMetaDataService>(Lifetime.Singleton).As<IAdventureMetaDataService>();
        }
    }
}
