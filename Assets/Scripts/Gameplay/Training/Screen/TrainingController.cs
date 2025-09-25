using UnityEngine;

namespace SotongStudio.Trainee.Gameplay.Training.Screen
{
    public interface ITrainingController
    {
        void SetupTraining(string trainingId);

        void ShowPredictionStatIncrease();
        void TrainingProcess();

        void UpdateTrainingStatVisual();

    }
    public class TrainingController : ITrainingController
    {
        private readonly ITrainingFacilityDataUpdateService _dataUpdateService;
        private readonly ITrainingFacilityDataService _dataService;
        private readonly ITrainingService _trainingService;

        private readonly ITrainingFacilityLogic _trainingFacility;

        public TrainingController(ITrainingFacilityDataUpdateService dataUpdateService,
                                  ITrainingFacilityDataService dataService,
                                  ITrainingService trainingService,
                                  ITrainingFacilityLogic trainingFacility)
        {
            _dataUpdateService = dataUpdateService;
            _dataService = dataService;
            _trainingService = trainingService;
            _trainingFacility = trainingFacility;
        }

        public void SetupTraining(string trainingId)
        {
            _dataUpdateService.SetCurrentTraining(trainingId);
        }

        public void ShowPredictionStatIncrease()
        {
            _dataUpdateService.UpdatePredictionTraining();
            Debug.Log("Do Predict Stat");
            _trainingFacility.ShowPredictObtainStat();
        }
        public void TrainingProcess()
        {
            if (_dataService.IsTrainingSetupDone)
            {
                Debug.Log("Do Training");
                _trainingService.TrainingAdventure(_dataService.CurrentTrainingId);
            }

            UpdateTrainingStatVisual();
        }

        public void UpdateTrainingStatVisual()
        {
            _trainingFacility.UpdateStatNumber();
        }
    }
}
