using UnityEngine;

namespace SotongStudio.Trainee.Shared.Adventure.Status
{
    public class AdventurePathBoardStatus : IAdventureStatus
    {
        public ushort Health { get; private set; }

        public ushort PysAttack { get; private set; }

        public ushort PysDefense { get; private set; }

        public ushort MgcAttack { get; private set; }

        public ushort MgcDefense { get; private set; }

        public ushort Critical { get; private set; }

        public ushort Speed { get; private set; }

        public ushort Accuracy { get; private set; }

        public AdventurePathBoardStatus(ushort health,

                                   ushort pysAttack, ushort pysDefense,
                                   ushort mgcAttack, ushort mgcDefense,

                                   ushort critical, ushort speed, ushort accuracy)
        {
            Health = health;
            PysAttack = pysAttack;
            PysDefense = pysDefense;
            MgcAttack = mgcAttack;
            MgcDefense = mgcDefense;
            Critical = critical;
            Speed = speed;
            Accuracy = accuracy;
        }
    }
}
