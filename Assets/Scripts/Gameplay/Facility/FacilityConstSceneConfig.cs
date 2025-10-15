using SotongStudio.Utilities.SceneLoader;

namespace SotongStudio.Trainee.Gameplay.Facility
{
    public static class FacilityConstSceneConfig
    {
        public static readonly ConstSceneLoadConfig Village_Scene = new(nameof(Village_Scene), SceneLoadType.Once);
        public static readonly ConstSceneLoadConfig Training_Scene = new(nameof(Training_Scene), SceneLoadType.Once);
        public static readonly ConstSceneLoadConfig Recruit_Scene =  new (nameof(Recruit_Scene), SceneLoadType.Once);
    }
}
