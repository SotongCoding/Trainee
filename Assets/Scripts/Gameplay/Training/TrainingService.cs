using SotongStudio.SharedData.PredefinedData;
using SotongStudio.Trainee.Service.TrainigCalculator;
using SotongStudio.Trainee.Shared.Adventure.Data;
using SotongStudio.Trainee.Shared.Predifined.Training;

namespace SotongStudio.Trainee.Gameplay.Training
{
    public interface ITrainingService
    {
        void DoTraining(AdventureMetaData adventure, string trainingId);
    }
    public class TrainingService : ITrainingService
    {
        private readonly PredefinedCollection<TrainingConfig_SO> _trainingCollection;

        public TrainingService(PredefinedCollection<TrainingConfig_SO> trainingCollection)
        {
            _trainingCollection = trainingCollection;
        }

        public void DoTraining(AdventureMetaData adventure, string trainingId)
        {
            var trainingConfig = _trainingCollection.GetItem(trainingId);

            var increment = trainingConfig.IncrementStat;
            var reduceEfficient = trainingConfig.EfficiencyReducement;

            var trainingResult = TrainingCalculator.CalculateObtainedStat(increment, adventure.TrainingEfficiency);

            adventure.AddTrainingStatus(trainingResult);
            adventure.DecreaseEfficiency(reduceEfficient);
        }
    }
}
