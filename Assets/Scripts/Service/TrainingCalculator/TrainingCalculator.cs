using SotongStudio.Trainee.Shared.Adventure.Efficiency;
using SotongStudio.Trainee.Shared.Adventure.Status;
using UnityEngine;

namespace SotongStudio.Trainee.Service.TrainigCalculator
{
    public class TrainingCalculator
    {
        public IAdventureStatus CalculateObtainedStat(IAdventureStatus incrementStat, ITrainingEfficiency currentTrainingEfficient)
        {
            var health = CalculateSingleStat(incrementStat.Health, currentTrainingEfficient.HealthEfficiency);

            var psyAttack = CalculateSingleStat(incrementStat.PysAttack, currentTrainingEfficient.PysAttackEfficiency);
            var pysDefense = CalculateSingleStat(incrementStat.PysDefense, currentTrainingEfficient.PysDefenseEfficiency);

            var mgcAttack = CalculateSingleStat(incrementStat.MgcAttack, currentTrainingEfficient.MgcAttackEfficiency);
            var mgcDefense = CalculateSingleStat(incrementStat.MgcDefense, currentTrainingEfficient.MgcDefenseEfficiency);

            var critical = CalculateSingleStat(incrementStat.Critical, currentTrainingEfficient.CriticalEfficiency);
            var speed = CalculateSingleStat(incrementStat.Speed, currentTrainingEfficient.SpeedEfficiency);
            var accuracy = CalculateSingleStat(incrementStat.Accuracy, currentTrainingEfficient.AccuracyEfficiency);


            return new TrainingCalculateResult(health,
                                              psyAttack, pysDefense,
                                              mgcAttack, mgcDefense,
                                              critical, speed, accuracy);
        }

        private ushort CalculateSingleStat(ushort incrementStat, float currentEfficient)
        {
            var roundEfficient = Mathf.FloorToInt(currentEfficient);
            float bonusPercentage = (float)roundEfficient * 10 / 100;

            var obtainedStat = incrementStat + (incrementStat * bonusPercentage);

            return (ushort)Mathf.CeilToInt(obtainedStat);
        }
    }
}
