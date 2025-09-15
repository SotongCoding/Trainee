using SotongStudio.Trainee.Shared.Adventure.Potency;

namespace SotongStudio.Trainee.Shared.Adventure.Efficiency
{
    public interface ITrainingEfficiency
    {
        float HealthEfficiency { get; }
        float PysAttackEfficiency { get; }
        float PysDefenseEfficiency { get; }
        float MgcAttackEfficiency { get; }
        float MgcDefenseEfficiency { get; }
        float CriticalEfficiency { get; }
        float SpeedEfficiency { get; }
        float AccuracyEfficiency { get; }
    }
    public class TrainingEfficiency : ITrainingEfficiency
    {
        public float HealthEfficiency { get; private set; }

        public float PysAttackEfficiency {get; private set;}

        public float PysDefenseEfficiency {get; private set;}

        public float MgcAttackEfficiency {get; private set;}

        public float MgcDefenseEfficiency {get; private set;}

        public float CriticalEfficiency {get; private set;}

        public float SpeedEfficiency {get; private set;}

        public float AccuracyEfficiency {get; private set;}

        public TrainingEfficiency(ushort healthEfficiency, 
                                  ushort pysAttackEfficiency, ushort pysDefenseEfficiency, 
                                  ushort mgcAttackEfficiency, ushort mgcDefenseEfficiency, 
                                  ushort criticalEfficiency, ushort speedEfficiency, ushort accuracyEfficiency)
        {
            HealthEfficiency = healthEfficiency;
            PysAttackEfficiency = pysAttackEfficiency;
            PysDefenseEfficiency = pysDefenseEfficiency;
            MgcAttackEfficiency = mgcAttackEfficiency;
            MgcDefenseEfficiency = mgcDefenseEfficiency;
            CriticalEfficiency = criticalEfficiency;
            SpeedEfficiency = speedEfficiency;
            AccuracyEfficiency = accuracyEfficiency;
        }

        public TrainingEfficiency(IAdventurePotency potency) : 
                                 this(potency.HealthPotency,
                                      potency.PysAttackPotency, potency.PysDefensePotency,
                                      potency.MgcAttackPotency, potency.MgcDefensePotency,
                                      potency.CriticalPotency, potency.SpeedPotency, potency.AccuracyPotency)
        {

        }
    }
}
