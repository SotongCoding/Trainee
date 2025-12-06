using System.Collections.Generic;
using UnityEngine;
using VContainer;

namespace SotongStudio.Trainee.Gameplay.Facility.Training.Screen.CharacterStat
{
    public class TrainingScreenDIScope : ScopeInstallHelper
    {
        [SerializeField] private List<CharStatItemLogic> _charStatItems;
        [SerializeField] private TrainingFacilityView _charStatView;
        public override void Install(IContainerBuilder builder)
        {
            builder.Register<TrainingFacilityLogic>(Lifetime.Singleton)
                   .As<ITrainingFacilityLogic>()
                   .As<ITrainingFacilityPlayerAction>()

                   .WithParameter<ITrainingFacilityView>(_charStatView)
                   .WithParameter<IReadOnlyList<ICharacterStatItemLogic>>(_charStatItems);

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
