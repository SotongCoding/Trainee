using SotongStudio.Trainee.Shared.Adventure.Potency;
using UnityEngine;

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
        private readonly IAdventurePotency _adventurePotency;

        public float HealthEfficiency { get; private set; }

        public float PysAttackEfficiency { get; private set; }

        public float PysDefenseEfficiency { get; private set; }

        public float MgcAttackEfficiency { get; private set; }

        public float MgcDefenseEfficiency { get; private set; }

        public float CriticalEfficiency { get; private set; }

        public float SpeedEfficiency { get; private set; }

        public float AccuracyEfficiency { get; private set; }

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
            _adventurePotency = potency;
        }

        public void ReduceEfficient(ITrainingEfficiency decrementEfficient)
        {
            HealthEfficiency = Mathf.Clamp(HealthEfficiency - decrementEfficient.HealthEfficiency, 0, _adventurePotency.HealthPotency);

            PysAttackEfficiency = Mathf.Clamp(PysAttackEfficiency - decrementEfficient.PysAttackEfficiency, 0, _adventurePotency.PysAttackPotency);
            PysDefenseEfficiency = Mathf.Clamp(PysDefenseEfficiency - decrementEfficient.PysDefenseEfficiency, 0, _adventurePotency.PysDefensePotency);

            MgcAttackEfficiency = Mathf.Clamp(MgcAttackEfficiency - decrementEfficient.MgcAttackEfficiency, 0, _adventurePotency.MgcAttackPotency);
            MgcDefenseEfficiency = Mathf.Clamp(MgcDefenseEfficiency - decrementEfficient.MgcDefenseEfficiency, 0, _adventurePotency.MgcDefensePotency);

            AccuracyEfficiency = Mathf.Clamp(AccuracyEfficiency - decrementEfficient.AccuracyEfficiency, 0, _adventurePotency.AccuracyPotency);
            SpeedEfficiency = Mathf.Clamp(SpeedEfficiency - decrementEfficient.SpeedEfficiency, 0, _adventurePotency.SpeedPotency);
            CriticalEfficiency = Mathf.Clamp(CriticalEfficiency - decrementEfficient.CriticalEfficiency, 0, _adventurePotency.CriticalPotency);
        }

        public void IncreaseEfficient(float incrementEfficient)
        {
            HealthEfficiency = Mathf.Clamp(HealthEfficiency + incrementEfficient, 0, _adventurePotency.HealthPotency);

            PysAttackEfficiency = Mathf.Clamp(PysAttackEfficiency + incrementEfficient, 0, _adventurePotency.PysAttackPotency);
            PysDefenseEfficiency = Mathf.Clamp(PysDefenseEfficiency + incrementEfficient, 0, _adventurePotency.PysDefensePotency);

            MgcAttackEfficiency = Mathf.Clamp(MgcAttackEfficiency + incrementEfficient, 0, _adventurePotency.MgcAttackPotency);
            MgcDefenseEfficiency = Mathf.Clamp(MgcDefenseEfficiency + incrementEfficient, 0, _adventurePotency.MgcDefensePotency);

            AccuracyEfficiency = Mathf.Clamp(AccuracyEfficiency + incrementEfficient, 0, _adventurePotency.AccuracyPotency);
            SpeedEfficiency = Mathf.Clamp(SpeedEfficiency + incrementEfficient, 0, _adventurePotency.SpeedPotency);
            CriticalEfficiency = Mathf.Clamp(CriticalEfficiency + incrementEfficient, 0, _adventurePotency.CriticalPotency);
        }
    }
}
