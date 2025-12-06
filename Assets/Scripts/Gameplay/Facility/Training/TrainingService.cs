using SotongStudio.SharedData.PredefinedData;
using SotongStudio.Trainee.Service.TrainigCalculator;
using SotongStudio.Trainee.Shared.Adventure.Data;
using SotongStudio.Trainee.Shared.Predifined.Training;
using UnityEngine;

namespace SotongStudio.Trainee.Gameplay.Facility.Training
{
    public interface ITrainingService
    {
        void TrainingAdventure(string trainingId);
        void RestAdvenuture();

        ITrainingResult PredictTrainingResult(string trainingId);
    }
    public class TrainingService : ITrainingService
    {
        private readonly PredefinedCollection<TrainingConfig_SO> _trainingCollection;
        private readonly IAdventureMetaDataProvider _adventureMetaData;

        public TrainingService(PredefinedCollection<TrainingConfig_SO> trainingCollection,
                               IAdventureMetaDataProvider adventureMetaData)
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
            var reduceEfficient = trainingConfig.EfficiencyReducement;

            var trainingResult = PredictTrainingResult(trainingId);

            adventure.AddTrainingStatus(trainingResult);
            adventure.DecreaseEfficiency(reduceEfficient);
            adventure.AddExperience(trainingResult.Experience);
        }
        
        public ITrainingResult PredictTrainingResult(string trainingId)
        {
            var adventure = _adventureMetaData.GetAdventureMetaData();

            var trainingConfig = _trainingCollection.GetItem(trainingId);
            var increment = trainingConfig.IncrementStat;

            var trainingResult = TrainingCalculator.CalculateObtainedStat(increment, adventure.TrainingEfficiency, 
                                                                          trainingConfig.Experience);
            
            return trainingResult;
        }
    }
}
