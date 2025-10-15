#nullable enable

using SotongStudio.Trainee.Service.TrainigCalculator;
using SotongStudio.Trainee.Shared.Adventure.Data;
using SotongStudio.Trainee.Shared.Adventure.Efficiency;
using SotongStudio.Trainee.Shared.Adventure.Status;


namespace SotongStudio.Trainee.Gameplay.Facility.Training.Screen
{
    public interface ITrainingFacilityDataUpdateService
    {
        void SetCurrentTraining(string trainingId);
        void UpdatePredictionTraining();
    }
    public interface ITrainingFacilityDataService
    {
        bool IsTrainingSetupDone { get; }
        string? CurrentTrainingId { get; }

        ushort GetAdventurePotency(StatusCodex handledStatus);
        float GetCurrentEfficiency(StatusCodex handledStatus);
        ushort GetCurrentStat(StatusCodex handledStat);
        ushort GetIncrement(StatusCodex handledStat);
    }
    public class CharacterTrainingDataService : ITrainingFacilityDataService, ITrainingFacilityDataUpdateService
    {
        private readonly IAdventureMetaDataProvider _adventureMetaDataService;
        private readonly ITrainingService _trainingService;

        private ITrainingResult? _currentPredictedResult;
        public string? CurrentTrainingId { get; private set; } = null;
        public bool IsTrainingSetupDone
        {
            get
            {
                return CurrentTrainingId != null;
            }
        }

        public CharacterTrainingDataService(IAdventureMetaDataProvider adventureMetaDataService,
                                            ITrainingService trainingService)
        {
            _adventureMetaDataService = adventureMetaDataService;
            _trainingService = trainingService;
        }

        public void SetCurrentTraining(string trainingId)
        {
            CurrentTrainingId = trainingId;

        }
        public void UpdatePredictionTraining()
        {
            _currentPredictedResult = _trainingService.PredictTrainingResult(CurrentTrainingId);
        }

        public ushort GetCurrentStat(StatusCodex handledStat)
        {
            var metaData = _adventureMetaDataService.GetAdventureMetaData();
            return metaData.Statuses.FinalStatus.StatOf(handledStat);
        }

        public ushort GetIncrement(StatusCodex handledStat)
        {
            if (_currentPredictedResult != null)
            {
                return _currentPredictedResult.StatOf(handledStat);
            }

            throw new System.InvalidOperationException("Cannot get Increment while prediction not Calculated First");
        }
        public float GetCurrentEfficiency(StatusCodex handledStatus)
        {
            var metaData = _adventureMetaDataService.GetAdventureMetaData();
            var efficientData = metaData.TrainingEfficiency;
            if (efficientData != null)
            {
                return efficientData.StatOf(handledStatus) / metaData.Potency.StatOf(handledStatus);
            }
            throw new System.InvalidOperationException($"Cannot Get Efficiency from {metaData} of {handledStatus} ");
        }

        public ushort GetAdventurePotency(StatusCodex handledStatus)
        {
            var metaData = _adventureMetaDataService.GetAdventureMetaData();
            return metaData.Potency.StatOf(handledStatus);
        }
    }
}
