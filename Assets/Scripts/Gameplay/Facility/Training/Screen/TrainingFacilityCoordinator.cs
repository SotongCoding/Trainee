using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using SotongStudio.Plugins.DI.LogicLoader;
using VContainer.Unity;

namespace SotongStudio.Trainee.Gameplay.Facility.Training.Screen
{
    public class TrainingFacilityCoordinator : IAsyncStartable, IDisposable
    {
        private readonly ITrainingFacilityController _controller;
        private readonly ILogicLoader<ITrainingFacilityLogic> _trainingFacilityLogic;
        private ITrainingFacilityPlayerAction _playerAction;

        private bool _disposedValue = false;
        private bool _isReady => _playerAction != null;

        public TrainingFacilityCoordinator(ITrainingFacilityController controller,
                                           ILogicLoader<ITrainingFacilityLogic> trainingFacilityLogic)
        {
            _controller = controller;
            _trainingFacilityLogic = trainingFacilityLogic;
        }

        public async UniTask StartAsync(CancellationToken cancellation = default)
        {
            if (!_isReady)
            {
                var logic = await _trainingFacilityLogic.LoadLogicAsync(cancellation);
                _playerAction = logic;
            }

            _playerAction.OnCheckPredictStat.AddListener(_controller.ShowPredictionStatIncrease);
            _playerAction.OnDoTraining.AddListener(_controller.TrainingProcess);

        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposedValue)
            {
                if (disposing)
                {
                    _playerAction.OnCheckPredictStat.RemoveListener(_controller.ShowPredictionStatIncrease);
                    _playerAction.OnDoTraining.RemoveListener(_controller.TrainingProcess);
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
