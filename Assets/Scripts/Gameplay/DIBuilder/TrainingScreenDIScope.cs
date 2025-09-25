using System.Collections.Generic;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace SotongStudio.Trainee.Gameplay.Training.Screen.CharacterStat
{
    public class TrainingScreenDIScope : ScopeInstallHelper
    {
        [SerializeField] private List<CharStatItemLogic> _charStatItems;
        [SerializeField] private TrainingFacilityView _charStatView;
        public override void Install(IContainerBuilder builder)
        {
            builder.Register<CharacterTrainingDataService>(Lifetime.Singleton)
                 .As<ITrainingFacilityDataService>()
                 .As<ITrainingFacilityDataUpdateService>();

            builder.Register<TrainingFacilityLogic>(Lifetime.Singleton)
                   .As<ITrainingFacilityLogic>()
                   .As<ITrainingFacilityPlayerAction>()

                   .WithParameter<ITrainingFacilityView>(_charStatView)
                   .WithParameter<IReadOnlyList<ICharacterStatItemLogic>>(_charStatItems);

            builder.Register<TrainingController>(Lifetime.Singleton).As<ITrainingController>();
            builder.RegisterEntryPoint<TrainingCoordinator>(Lifetime.Singleton)
                    .As<IStartable>();

            builder.RegisterBuildCallback(resolver =>
            {
                foreach (var statItem in _charStatItems)
                {
                    resolver.Inject(statItem);
                }
            });
        }
    }
}
