using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using SotongStudio.Plugins.DI.LogicLoader;
using UnityEngine;

namespace SotongStudio.Trainee.Gameplay.Facility.Training.Screen
{
    public interface ITrainingFacilityController
    {
        UniTask OpenFacilityAsync(CancellationToken cancellationToken);
        UniTask SetupTrainingAsync(string trainingId, CancellationToken cancellationToken);

        void ShowPredictionStatIncrease();
        void TrainingProcess();

        void UpdateTrainingStatVisual();

    }
    public class TrainingFacilityController : ITrainingFacilityController, IDisposable
    {
        private readonly ITrainingFacilityDataUpdateService _dataUpdateService;
        private readonly ITrainingFacilityDataService _dataService;
        private readonly ITrainingService _trainingService;
        private readonly ILogicLoader<ITrainingFacilityLogic> _facilityLogicLoader;

        private ITrainingFacilityLogic _trainingFacilityLogic;

        private bool _disposedValue;
        private readonly CancellationTokenSource _cts = new();

        public TrainingFacilityController(ITrainingFacilityDataUpdateService dataUpdateService,
                                          ITrainingFacilityDataService dataService,

                                          ITrainingService trainingService,
                                          ILogicLoader<ITrainingFacilityLogic> facilityLogicLoader)
        {
            _dataUpdateService = dataUpdateService;
            _dataService = dataService;
            _trainingService = trainingService;


            _facilityLogicLoader = facilityLogicLoader;
        }

        public void SetupTrainingAsync(string trainingId)
        {
            SetupTrainingAsync(trainingId, _cts.Token).Forget();
        }
        public async UniTask SetupTrainingAsync(string trainingId, CancellationToken cancellationToken)
        {
            _trainingFacilityLogic = await _facilityLogicLoader.LoadLogicAsync(cancellationToken);

            _dataUpdateService.SetCurrentTraining(trainingId);
            _dataUpdateService.UpdatePredictionTraining();

            UpdateTrainingStatVisual();
        }

        public UniTask OpenFacilityAsync(CancellationToken cancellationToken)
        {
            _trainingFacilityLogic.Show();
            return UniTask.CompletedTask;
        }

        public void ShowPredictionStatIncrease()
        {
            _trainingFacilityLogic.ShowPredictObtainStat();
        }
        public void TrainingProcess()
        {
            if (!_dataService.IsTrainingSetupDone)
            {
                return;
            }

            _trainingService.TrainingAdventure(_dataService.CurrentTrainingId);
            
            UpdateTrainingStatVisual();
        }

        public void UpdateTrainingStatVisual()
        {
            _trainingFacilityLogic.UpdateStatNumber();
            _trainingFacilityLogic.HidePredictObtainedStat();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposedValue)
            {
                if (disposing)
                {
                    _cts.Cancel();
                    _cts.Dispose();
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
