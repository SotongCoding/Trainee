using SotongStudio.Trainee.Shared.Adventure.Efficiency;
using SotongStudio.Trainee.Shared.Adventure.Status;
using UnityEngine;

namespace SotongStudio.Trainee.Service.TrainigCalculator
{
    public static class TrainingCalculator
    {
        public static ITrainingResult CalculateObtainedStat(IAdventureStatus incrementStat, ITrainingEfficiency currentTrainingEfficient,
                                                            ushort experience)
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
                                              critical, speed, accuracy,
                                              experience);
        }

        private static ushort CalculateSingleStat(ushort incrementStat, float currentEfficient)
        {
            var roundEfficient = Mathf.FloorToInt(currentEfficient);
            float bonusPercentage = (float)roundEfficient * 10 / 100;

            var obtainedStat = incrementStat + (incrementStat * bonusPercentage);
            if (currentEfficient <= 0) obtainedStat = 0;

            return (ushort)Mathf.CeilToInt(obtainedStat);
        }
    }
}
