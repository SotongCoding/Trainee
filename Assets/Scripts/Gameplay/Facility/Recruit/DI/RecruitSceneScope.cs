using SotongStudio.Trainee.Gameplay.Facility.Recruit.Screen;
using UnityEngine;
using VContainer;

namespace SotongStudio.Trainee.Gameplay.Facility.Recruit.DI
{
    public class RecruitSceneScope : SceneScope
    {
        [SerializeField] private RecruitFacilityView _view;
        protected override void AddRegistration(IContainerBuilder builder)
        {
            builder.Register<RecruitFacilityLogic>(Lifetime.Singleton).As<IRecruitFacilityLogic>()
                   .WithParameter<IRecruitFacilityView>(_view);
        }
    }
}
