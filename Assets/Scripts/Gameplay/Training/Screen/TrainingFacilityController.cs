namespace SotongStudio.Trainee.Gameplay.Training.Screen
{
    public interface ITrainingFacilityController
    {
        void SetupTraining(string trainingId);

        void ShowPredictionStatIncrease();
        void TrainingProcess();

        void UpdateTrainingStatVisual();

    }
    public class TrainingFacilityController : ITrainingFacilityController
    {
        private readonly ITrainingFacilityDataUpdateService _dataUpdateService;
        private readonly ITrainingFacilityDataService _dataService;
        private readonly ITrainingService _trainingService;

        private readonly ITrainingFacilityLogic _trainingFacility;

        public TrainingFacilityController(ITrainingFacilityDataUpdateService dataUpdateService,
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
            
            UpdateTrainingStatVisual();
        }

        public void ShowPredictionStatIncrease()
        {
            _dataUpdateService.UpdatePredictionTraining();
            _trainingFacility.ShowPredictObtainStat();
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
            _trainingFacility.UpdateStatNumber();
            _trainingFacility.HidePredictObtainedStat();
        }
    }
}
