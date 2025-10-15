using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Cysharp.Threading.Tasks;
using SotongStudio.Utilities.SceneLoader;
using UnityEngine;
using UnityEngine.Pool;
using UnityEngine.SceneManagement;
using VContainer;
using VContainer.Unity;

#nullable enable

namespace SotongStudio.Plugins.DI.LogicLoader
{
    public interface ILogicLoader<TLogic> where TLogic : ISceneLogic
    {
        UniTask<TLogic> LoadLogicAsync(CancellationToken cancellationToken);
        void Unload();
    }
    public abstract class LogicLoader<TLogic> : ILogicLoader<TLogic>, IDisposable where TLogic : ISceneLogic
    {
        protected abstract ConstSceneLoadConfig Scene { get; }
        private TLogic? _cachedLogic = default;
        private bool _disposedValue;

        protected CancellationTokenSource Cts { get; } = new();

        protected LogicLoader()
        {

        }

        public async UniTask<TLogic> LoadLogicAsync(CancellationToken cancellationToken)
        {
            if (_cachedLogic == null ||
                !IsSceneLoaded(Scene.SceneName))
            {
                var targetScene = await SceneLoaderService.LoadSceneAsync(Scene, cancellationToken);
                var sceneScope = LifetimeScope.Find<SceneScope>(targetScene);
                sceneScope.Build();
                _cachedLogic = sceneScope.Container.Resolve<TLogic>();
            }

            return _cachedLogic!;
        }

        public void Unload()
        {
            UnloadAsync(Cts.Token).Forget();
        }
        private async UniTaskVoid UnloadAsync(CancellationToken cancellationToken)
        {
            await SceneLoaderService.UnloadSceneAsync(Scene, cancellationToken);
            _cachedLogic = default;
        }

        private static bool IsSceneLoaded(string sceneName)
        {
            using var _ = ListPool<Scene>.Get(out var loadedScenes);

            // Iterate through all loaded scenes
            for (int i = 0; i < SceneManager.sceneCount; i++)
            {
                var scene = SceneManager.GetSceneAt(i);
                loadedScenes.Add(scene);
            }

            return loadedScenes.Any(x => x.name == sceneName);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposedValue)
            {
                if (disposing)
                {
                    Cts.Cancel();
                    Cts.Dispose();
                }
                _disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
