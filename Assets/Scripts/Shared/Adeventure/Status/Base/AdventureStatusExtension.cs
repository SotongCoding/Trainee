using UnityEngine;

namespace SotongStudio.Trainee.Shared.Adventure.Status
{
    public static class AdventureStatusExtension
    {
        public static ushort StatOf(this IAdventureStatus charStatus, StatusCodex status)
        {
            return status switch
            {
                StatusCodex.Health => charStatus.Health,
                StatusCodex.PsyAttack => charStatus.PysAttack,
                StatusCodex.PsyDefense => charStatus.PysDefense,
                StatusCodex.MgcAttack => charStatus.MgcAttack,
                StatusCodex.MgcDefense => charStatus.MgcDefense,
                StatusCodex.Critical => charStatus.Critical,
                StatusCodex.Speed => charStatus.Speed,
                StatusCodex.Accuracy => charStatus.Accuracy,
                _ => throw new System.InvalidOperationException($"Cannot find Status of {status}"),
            };
        }
    }
}
