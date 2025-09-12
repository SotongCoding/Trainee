namespace SotongStudio.Trainee.Shared.Adventure.Status
{
    public class AdventureFinalStatus : IAdventureStatus
    {
        public ushort Health { get; private set; }

        public ushort PysAttack { get; private set; }

        public ushort PysDefense { get; private set; }

        public ushort MgcAttack { get; private set; }

        public ushort MgcDefense { get; private set; }

        public ushort Critical { get; private set; }

        public ushort Speed { get; private set; }

        public ushort Accuracy { get; private set; }

        public AdventureFinalStatus(ushort health,

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

        public AdventureFinalStatus(IAdventureStatus adventureStatus)
        {
            Health = adventureStatus.Health;
            
            PysAttack = adventureStatus.PysAttack;
            PysDefense = adventureStatus.PysDefense;

            MgcAttack = adventureStatus.MgcAttack;
            MgcDefense = adventureStatus.MgcDefense;

            Critical = adventureStatus.Critical;
            Speed = adventureStatus.Speed;
            Accuracy = adventureStatus.Accuracy;
        }
    }
}
