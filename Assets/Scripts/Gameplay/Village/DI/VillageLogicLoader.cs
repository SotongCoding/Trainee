using SotongStudio.Plugins.DI.LogicLoader;
using SotongStudio.Trainee.Gameplay.Facility;
using SotongStudio.Utilities.SceneLoader;

namespace SotongStudio.Trainee.Gameplay.Village.Screen
{
    public class VillageLogicLoader : LogicLoader<IVillageLogic>
    {
        public VillageLogicLoader()
        {
        }

        protected override ConstSceneLoadConfig Scene => FacilityConstSceneConfig.Village_Scene;
    }
}
