using NaughtyAttributes;
using SotongStudio.Trainee.Service.ExperienceCalculator;
using SotongStudio.Trainee.Service.PotencyGenerator;
using SotongStudio.Trainee.Shared.Adventure.Class;
using SotongStudio.Trainee.Shared.Adventure.Rank;
using SotongStudio.Trainee.Shared.Adventure.Status;
using SotongStudio.Trainee.Shared.Predifined.ClassConfig;
using UnityEngine;

namespace SotongStudio.Trainee
{
    public class TestingA : MonoBehaviour
    {
        [SerializeField] private ushort _currentLevel;
        [SerializeField] private ushort _currentExp;
        [SerializeField] private ushort _obtainedExp;

        [Header("Stat")]
        [SerializeField] private TestingStat _baseStat;

        [SerializeField] private ClassConfigCollection_SO _classConfigCollection;






        [Button]
        private void AddExperience()
        {
            var levelUpResult = ExperienceCalculator.CalculateExperience(_currentExp, _obtainedExp);

            _currentLevel += levelUpResult.LevelObtained;
            _currentExp = levelUpResult.NewCurrentExperience;
        }

        [Button]
        private void TestScaleStat()
        {
            for (int i = 1; i < 100; i++)
            {
                ushort level = (ushort)(i);

                var baseStat = new AdventureBaseStatus(_baseStat.Health,
                                                       _baseStat.PysAttack, _baseStat.PysDefense,
                                                       _baseStat.MgcAttack, _baseStat.MgcDefense,
                                                       _baseStat.Critical, _baseStat.Speed, _baseStat.Accuracy);
                var mainStat = new AdventureMainStatus(baseStat);
                mainStat.ChangeLevel(level);
                Debug.Log($"Level {level} Stat : " +
                                      $"Health {mainStat.Health} " +
                                      $"PysAttack {mainStat.PysAttack} PysDefense {mainStat.PysDefense} " +
                                      $"MgcAttack {mainStat.MgcAttack} MgcDefense {mainStat.MgcDefense} " +
                                      $"Critical {mainStat.Critical} Speed {mainStat.Speed} Accuracy {mainStat.Accuracy}");
            }
        }

        [Button]
        private void TestGeneratePotency()
        {
            var generator = new PotencyGeneratorService(_classConfigCollection);

            var potency = generator.GeneratePotency(AdventureRank.E_Class, AdventureClass.BladeMaster);

            Debug.Log($"Potency : " +
                      $"Health {potency.HealthPotency} " +
                      $"PysAttack {potency.PysAttackPotency} PysDefense {potency.PysDefensePotency} " +
                      $"MgcAttack {potency.MgcAttackPotency} MgcDefense {potency.MgcDefensePotency} " +
                      $"Critical {potency.CriticalPotency} Speed {potency.SpeedPotency} Accuracy {potency.AccuracyPotency}");
            var allPotency = potency.HealthPotency +
                             potency.PysAttackPotency + potency.PysDefensePotency +
                             potency.MgcAttackPotency + potency.MgcDefensePotency +
                             potency.AccuracyPotency + potency.CriticalPotency + potency.SpeedPotency;
            Debug.Log($"Total Potency : {allPotency}");
        }

        [System.Serializable]
        private class TestingStat : IAdventureStatus
        {
            [field: SerializeField] public ushort Health { get; set; }

            [field: SerializeField] public ushort PysAttack { get; set; }

            [field: SerializeField] public ushort PysDefense { get; set; }

            [field: SerializeField] public ushort MgcAttack { get; set; }

            [field: SerializeField] public ushort MgcDefense { get; set; }

            [field: SerializeField] public ushort Critical { get; set; }

            [field: SerializeField] public ushort Speed { get; set; }

            [field: SerializeField] public ushort Accuracy { get; set; }
        }
    }
}
