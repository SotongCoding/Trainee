using UnityEngine;

namespace SotongStudio.Trainee.Shared.Adventure.Status
{
    public interface IAdventureStatus
    {
        ushort Health { get; }

        ushort PysAttack { get; }
        ushort PysDefense { get; }

        ushort MgcAttack { get; }
        ushort MgcDefense { get; }

        ushort Critical { get; }
        ushort Speed { get; }
        ushort Accuracy { get; }
    }
}
