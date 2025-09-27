using SotongStudio.Trainee.Service.ExperienceCalculator;
using SotongStudio.Trainee.Service.TrainigCalculator;
using SotongStudio.Trainee.Shared.Adventure.Data;
using SotongStudio.Trainee.Shared.Adventure.Efficiency;

namespace SotongStudio.Trainee
{
    public static class AdventureMetaDataUpdateServiceExtension
    {
        public static void AddTrainingStatus(this AdventureMetaData metaData, ITrainingResult trainingResult)
        {
            metaData.Statuses.TrainingStatus.AddStatus(trainingResult);
        }

        public static void DecreaseEfficiency(this AdventureMetaData metaData, ITrainingEfficiency decrementEfficient)
        {
            metaData.TrainingEfficiency.ReduceEfficient(decrementEfficient);
        }
        public static void IncreaseEfficiency(this AdventureMetaData metaData, float incrementEfficient)
        {
            metaData.TrainingEfficiency.IncreaseEfficient(incrementEfficient);
        }

        public static void AddExperience(this AdventureMetaData metaData, ushort obtainedExp)
        {
            var experienceResult = ExperienceCalculator.CalculateExperience(metaData.Experience.ExpPoint, obtainedExp);

            metaData.Experience.ChangeCurrentExperience(experienceResult.NewCurrentExperience);

            var newLevel = metaData.Experience.Level + experienceResult.LevelObtained;
            metaData.Experience.ChangeCurrentLevel((ushort)newLevel);
        }
    }
}
