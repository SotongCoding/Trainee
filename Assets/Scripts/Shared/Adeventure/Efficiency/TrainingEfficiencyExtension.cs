using SotongStudio.Trainee.Shared.Adventure.Status;

namespace SotongStudio.Trainee.Shared.Adventure.Efficiency
{
    public static class TrainingEfficiencyExtension
    {
        public static float StatOf(this ITrainingEfficiency efficiency, StatusCodex status)
        {
            return status switch
            {
                StatusCodex.Health => efficiency.HealthEfficiency,
                StatusCodex.PsyAttack => efficiency.PysAttackEfficiency,
                StatusCodex.PsyDefense => efficiency.PysDefenseEfficiency,
                StatusCodex.MgcAttack => efficiency.MgcAttackEfficiency,
                StatusCodex.MgcDefense => efficiency.MgcDefenseEfficiency,
                StatusCodex.Critical => efficiency.CriticalEfficiency,
                StatusCodex.Speed => efficiency.SpeedEfficiency,
                StatusCodex.Accuracy => efficiency.AccuracyEfficiency,
                _ => throw new System.InvalidOperationException($"Cannot find Efficiency of {status}"),
            };
        }
    }
}
