using SotongStudio.Trainee.Gameplay.Village.Screen;
using VContainer;
using UnityEngine;
using System.Collections.Generic;


namespace SotongStudio.Trainee.Gameplay.Village
{
    public class VillageSceneScope : SceneScope
    {
        [SerializeField] private List<VillageFacilityTrigger> _facilityTriggers;
        [SerializeField] private VillageView _view;
        protected override void AddRegistration(IContainerBuilder builder)
        {

            builder.Register<VillageLogic>(Lifetime.Singleton)
                   .As<IVillageLogic>()
                   .As<IVillagePlayerAction>()
                   .WithParameter<IReadOnlyList<IVillageFacilityTrigger>>(_facilityTriggers)
                   .WithParameter<IVillageView>(_view);
        }
    }
}
