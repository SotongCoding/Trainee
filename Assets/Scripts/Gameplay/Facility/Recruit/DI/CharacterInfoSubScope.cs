using System.Collections.Generic;
using SotongStudio.Trainee.Gameplay.Facility.Recruit.Screen;
using UnityEngine;
using VContainer;

namespace SotongStudio.Trainee.Gameplay.Facility.Recruit.DI
{
    public class CharacterInfoSubScope : ScopeInstallHelper
    {
        [SerializeField] private CharBasicInfoView _basicInfo;
        [SerializeField] private List<CharStatInfoItemLogic> _statInfoItems;

        public override void Install(IContainerBuilder builder)
        {
            builder.Register<RecruitAdventureProfileSubLogic>(Lifetime.Singleton).As<IRecruitAdventureProfileSubLogic>()
                   .WithParameter<ICharBasicInfoView>(_basicInfo)
                   .WithParameter<IReadOnlyList<ICharStatInfoItemLogic>>(_statInfoItems);
        }
    }
}
