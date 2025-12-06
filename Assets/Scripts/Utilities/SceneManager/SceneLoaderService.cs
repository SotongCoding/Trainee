using System.Collections.Generic;
using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.Pool;
using UnityEngine.SceneManagement;

namespace SotongStudio.Utilities.SceneLoader
{
    public static class SceneLoaderService
    {
        private static Dictionary<string, AsyncOperation> _loadedScene = new();
        public static async UniTask<Scene> LoadSceneAsync(ConstSceneLoadConfig sceneConfig, CancellationToken cancellationToken)
        {
            if (_loadedScene.ContainsKey(sceneConfig.SceneName))
            {
                await UniTask.WaitUntil(() => _loadedScene[sceneConfig.SceneName].isDone);
                return GetLoadedScene(sceneConfig.SceneName);
            }
            else
            {
                var loadPorcess = SceneManager.LoadSceneAsync(sceneConfig.SceneName, LoadSceneMode.Additive);
                _loadedScene.Add(sceneConfig.SceneName, loadPorcess);
                
                if (loadPorcess.isDone) return GetLoadedScene(sceneConfig.SceneName);
                await UniTask.WaitUntil(() => loadPorcess.isDone);

                return GetLoadedScene(sceneConfig.SceneName);
            }
        }

        public static async UniTask UnloadSceneAsync(ConstSceneLoadConfig sceneConfig, CancellationToken cancellationToken)
        {
            Debug.Log($"Unload Scene {sceneConfig.SceneName}");
            var unloadPorcess = SceneManager.UnloadSceneAsync(sceneConfig.SceneName);

            if (unloadPorcess.isDone) await UniTask.CompletedTask;
            await UniTask.WaitUntil(() => unloadPorcess.isDone);

            _loadedScene.Remove(sceneConfig.SceneName);
        }

        private static Scene GetLoadedScene(string sceneName)
        {
            using var _ = ListPool<Scene>.Get(out var loadedScenes);
            // Iterate through all loaded scenes
            for (int i = 0; i < SceneManager.sceneCount; i++)
            {
                var scene = SceneManager.GetSceneAt(i);
                loadedScenes.Add(scene);
            }

            return loadedScenes.Find(x => x.name == sceneName);
        }
    }

}
