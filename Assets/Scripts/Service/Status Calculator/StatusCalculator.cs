using SotongStudio.Trainee.Shared.Adventure.Status;

namespace SotongStudio.Trainee.Service.StatusCalculator
{
    public static class StatusCalculator
    {
        public static ScaleCalculateResult ScaleLevel(ushort level, IAdventureStatus baseStatus)
        {
            return ScaleCalculateResult.CreateNewScaleResult(baseStatus, level);
        }

        public static IAdventureStatus SumAdventureStatus(params IAdventureStatus[] statuses)
        {

            ushort health = 0;

            ushort pysAttack = 0;
            ushort psyDefense = 0;

            ushort mgcAttack = 0;
            ushort mgcDefense = 0;

            ushort critical = 0;
            ushort speed = 0;
            ushort accuracy = 0;

            foreach (var stat in statuses)
            {
                health += stat.Health;

                pysAttack += stat.PysAttack;
                psyDefense += stat.PysDefense;

                mgcAttack += stat.MgcAttack;
                mgcDefense += stat.MgcDefense;

                critical += stat.Critical;
                speed += stat.Speed;
                accuracy += stat.Accuracy;
            }

            return new SumStatus (health, pysAttack, psyDefense, mgcAttack, mgcDefense, critical, speed, accuracy); 
        }

        private class SumStatus : IAdventureStatus
        {
            public ushort Health { get; private set; }

            public ushort PysAttack { get; private set; }

            public ushort PysDefense { get; private set; }

            public ushort MgcAttack { get; private set; }

            public ushort MgcDefense { get; private set; }

            public ushort Critical { get; private set; }

            public ushort Speed { get; private set; }

            public ushort Accuracy { get; private set; }

            public SumStatus(ushort health,
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
}
