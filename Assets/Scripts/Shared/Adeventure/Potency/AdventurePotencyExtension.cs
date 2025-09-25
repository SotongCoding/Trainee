using SotongStudio.Trainee.Shared.Adventure.Potency;
using SotongStudio.Trainee.Shared.Adventure.Status;

namespace SotongStudio.Trainee
{
    public static class AdventurePotencyExtension
    {
        public static ushort StatOf(this IAdventurePotency potency, StatusCodex status)
        {
            return status switch
            {
                StatusCodex.Health => potency.HealthPotency,
                StatusCodex.PsyAttack => potency.PysAttackPotency,
                StatusCodex.PsyDefense => potency.PysDefensePotency,
                StatusCodex.MgcAttack => potency.MgcAttackPotency,
                StatusCodex.MgcDefense => potency.MgcDefensePotency,
                StatusCodex.Critical => potency.CriticalPotency,
                StatusCodex.Speed => potency.SpeedPotency,
                StatusCodex.Accuracy => potency.AccuracyPotency,
                _ => throw new System.InvalidOperationException($"Cannot find Potency of {status}"),
            };
        }
    }
}
