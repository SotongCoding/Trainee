using System;
using VContainer.Unity;

namespace SotongStudio.Trainee.Gameplay.Training.Screen
{
    public class TrainingCoordinator : IStartable, IDisposable
    {
        private readonly ITrainingFacilityController _controller;
        private readonly ITrainingFacilityPlayerAction _playerAction;

        private bool _disposedValue = false;

        public TrainingCoordinator(ITrainingFacilityController controller,
                                   ITrainingFacilityPlayerAction playerAction)
        {
            playerAction.OnCheckPredictStat.AddListener(controller.ShowPredictionStatIncrease);
            playerAction.OnDoTraining.AddListener(controller.TrainingProcess);

            _controller = controller;
            _playerAction = playerAction;
        }

        public void Start()
        {
            
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
