using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using SotongStudio.Utilities.SceneLoader;

namespace SotongStudio.Trainee.Gameplay.Facility
{
    public interface IFacility
    {
        UniTask OpenFacilityAsync(CancellationToken cancellationToken);
    }
    public abstract class BaseFacilityLogic : IFacility, IDisposable
    {
        protected CancellationTokenSource Cts = new();
        private bool _disposedValue;
        protected abstract ConstSceneLoadConfig SceneConfig { get; }

        protected BaseFacilityLogic()
        { 
        }

        public virtual UniTask OpenFacilityAsync(CancellationToken cancellationToken)
        {
            return SceneLoaderService.LoadSceneAsync(SceneConfig, cancellationToken);
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
