using System.Threading;
using SotongStudio.Trainee.Service.PotencyGenerator;
using SotongStudio.Trainee.Shared.Adventure.Class;
using SotongStudio.Trainee.Shared.Adventure.Data;
using SotongStudio.Trainee.Shared.Adventure.Efficiency;
using SotongStudio.Trainee.Shared.Adventure.Rank;
using SotongStudio.Trainee.Shared.Adventure.Status;
using SotongStudio.Trainee.Shared.Predifined.Rank.RandomStatus;
using UnityEngine;

namespace SotongStudio.Trainee.Service.AdventureGenerator
{
    public class AdventureGenerator
    {
        private readonly PotencyGeneratorService _potencyGenerator;

        private readonly RankRandomStatusConfig_SO _randomStatusConfig;

        public AdventureGenerator(PotencyGeneratorService potencyGenerator,
                                  RankRandomStatusConfig_SO randomStatusConfig)
        {
            _potencyGenerator = potencyGenerator;
            _randomStatusConfig = randomStatusConfig;
        }

        public AdventureMetaData CreateAdventureMetaData()
        {
            var rank = GetAdventureRank(AdventureRank.E_Class, AdventureRank.Yuusha_Class);
            var selectedClass = GetAdventureClass();
            var potencyData = _potencyGenerator.GeneratePotency(rank, selectedClass);
            var efficiency = new TrainingEfficiency(potencyData);


            var baseHealth = _randomStatusConfig.GetStat(potencyData.HealthPotency);

            var basePysAttack = _randomStatusConfig.GetStat(potencyData.PysAttackPotency);
            var basePysDefense = _randomStatusConfig.GetStat(potencyData.PysDefensePotency);

            var baseMgcAttack = _randomStatusConfig.GetStat(potencyData.MgcAttackPotency);
            var baseMgcDefense = _randomStatusConfig.GetStat(potencyData.MgcDefensePotency);

            var baseCritical = _randomStatusConfig.GetStat(potencyData.CriticalPotency);
            var baseAccuracy = _randomStatusConfig.GetStat(potencyData.AccuracyPotency);
            var baseSpeed = _randomStatusConfig.GetStat(potencyData.SpeedPotency);


            var baseStat = new AdventureBaseStatus(baseHealth, basePysAttack, basePysDefense,
                                                   baseMgcAttack, baseMgcDefense,
                                                   baseCritical, baseSpeed, baseAccuracy);

            return new(rank, selectedClass,
                       baseStat, potencyData, efficiency);
        }

        private static AdventureRank GetAdventureRank(AdventureRank min, AdventureRank max)
        {
            var rank = Random.Range((int)min, (int)max + 1);

            return (AdventureRank)rank;
        }

        private static AdventureClass GetAdventureClass(params AdventureClass[] possibleClasses)
        {
            if (possibleClasses.Length == 0)
            {
                var selectedClass = Random.Range((int)AdventureClass.BladeMaster, (int)AdventureClass.Enchanter + 1);
                return (AdventureClass)selectedClass;
            }

            var randIndex = Random.Range(0, possibleClasses.Length);

            return possibleClasses[randIndex];
        }
    }
}
