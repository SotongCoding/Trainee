using SotongStudio.Plugins.DI.LogicLoader;
using SotongStudio.Trainee.Gameplay.Facility;
using SotongStudio.Trainee.Gameplay.Facility.Recruit.Screen;
using SotongStudio.Utilities.SceneLoader;
using UnityEngine;

namespace SotongStudio.Trainee
{
    public class RecruitLogicLoader : LogicLoader<IRecruitFacilityLogic>
    {
        protected override ConstSceneLoadConfig Scene => FacilityConstSceneConfig.Recruit_Scene;
    }
}
