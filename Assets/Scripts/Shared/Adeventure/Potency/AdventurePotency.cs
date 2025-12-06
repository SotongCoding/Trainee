namespace SotongStudio.Trainee.Shared.Adventure.Potency
{
    public interface IAdventurePotency
    {
        ushort HealthPotency { get; }
        ushort PysAttackPotency { get; }
        ushort PysDefensePotency { get; }
        ushort MgcAttackPotency { get; }
        ushort MgcDefensePotency { get; }
        ushort CriticalPotency { get; }
        ushort SpeedPotency { get; }
        ushort AccuracyPotency { get; }
    }
    public class AdventurePotency : IAdventurePotency
    {
        public ushort HealthPotency { get; private set; }

        public ushort PysAttackPotency { get; private set; }
        public ushort PysDefensePotency { get; private set; }

        public ushort MgcAttackPotency { get; private set; }
        public ushort MgcDefensePotency { get; private set; }

        public ushort CriticalPotency { get; private set; }
        public ushort SpeedPotency { get; private set; }
        public ushort AccuracyPotency { get; private set; }

        public AdventurePotency(ushort healthPotency,
                               ushort pysAttackPotency, ushort pysDefensePotency,
                               ushort mgcAttackPotency, ushort mgcDefensePotency,
                               ushort criticalPotency, ushort speedPotency, ushort accuracyPotency)
        {
            HealthPotency = healthPotency;
            PysAttackPotency = pysAttackPotency;
            PysDefensePotency = pysDefensePotency;
            MgcAttackPotency = mgcAttackPotency;
            MgcDefensePotency = mgcDefensePotency;
            CriticalPotency = criticalPotency;
            SpeedPotency = speedPotency;
            AccuracyPotency = accuracyPotency;
        }
    }
}
