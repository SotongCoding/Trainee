using SotongStudio.Plugins.DI.LogicLoader;
using SotongStudio.Trainee.Gameplay.Facility.Training.Screen;
using SotongStudio.Utilities.SceneLoader;

namespace SotongStudio.Trainee.Gameplay.Facility.Training.DI
{
    public class TrainingFacilityLogicLoader : LogicLoader<ITrainingFacilityLogic>
    {
        protected override ConstSceneLoadConfig Scene => FacilityConstSceneConfig.Training_Scene;
    }
}
