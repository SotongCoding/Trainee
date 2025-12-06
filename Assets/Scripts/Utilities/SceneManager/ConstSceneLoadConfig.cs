using UnityEngine;

namespace SotongStudio.Utilities.SceneLoader
{
    public class ConstSceneLoadConfig
    {
        public string SceneName;
        public SceneLoadType SceneLoadType;

        public ConstSceneLoadConfig(string sceneName, SceneLoadType sceneLoadType)
        {
            SceneName = sceneName;
            SceneLoadType = sceneLoadType;
        }
    }

    public enum SceneLoadType
    {
        AON,
        Once
    }
}


