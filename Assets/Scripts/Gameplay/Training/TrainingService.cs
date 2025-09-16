using SotongStudio.SharedData.PredefinedData;
using SotongStudio.Trainee.Service.TrainigCalculator;
using SotongStudio.Trainee.Shared.Adventure.Data;
using SotongStudio.Trainee.Shared.Predifined.Training;
using UnityEngine;

namespace SotongStudio.Trainee.Gameplay.Training
{
    public interface ITrainingService
    {
        void TrainingAdventure(string trainingId);
        void RestAdvenuture();
    }
    public class TrainingService : ITrainingService
    {
        private readonly PredefinedCollection<TrainingConfig_SO> _trainingCollection;
        private readonly IAdventureMetaDataService _adventureMetaData;

        public TrainingService(PredefinedCollection<TrainingConfig_SO> trainingCollection,
                               IAdventureMetaDataService adventureMetaData)
        {
            _trainingCollection = trainingCollection;
            _adventureMetaData = adventureMetaData;
        }

        public void RestAdvenuture()
        {
            var adventure = _adventureMetaData.GetAdventureMetaData();
            var increasedEfficiency = Random.Range(0.5f, 0.8f);
            adventure.IncreaseEfficiency(increasedEfficiency);
        }

        public void TrainingAdventure(string trainingId)
        {
            var adventure = _adventureMetaData.GetAdventureMetaData();
            var trainingConfig = _trainingCollection.GetItem(trainingId);

            var increment = trainingConfig.IncrementStat;
            var reduceEfficient = trainingConfig.EfficiencyReducement;

            var trainingResult = TrainingCalculator.CalculateObtainedStat(increment, adventure.TrainingEfficiency);

            adventure.AddTrainingStatus(trainingResult);
            adventure.DecreaseEfficiency(reduceEfficient);
        }
    }
}
