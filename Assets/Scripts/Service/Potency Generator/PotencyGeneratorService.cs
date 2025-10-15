using System.Collections.Generic;
using System.Linq;
using SotongStudio.SharedData.PredefinedData;
using SotongStudio.Trainee.Shared.Adventure.Class;
using SotongStudio.Trainee.Shared.Adventure.Potency;
using SotongStudio.Trainee.Shared.Adventure.Rank;
using SotongStudio.Trainee.Shared.Adventure.Status;
using SotongStudio.Trainee.Shared.Predifined.ClassConfig;
using SotongStudio.Trainee.Shared.Predifined.Rank.Potency;
using UnityEngine;
using UnityEngine.Pool;


namespace SotongStudio.Trainee.Service.PotencyGenerator
{
    public class PotencyGeneratorService
    {
        private readonly PredefinedCollection<ClassConfig_SO> _classConfigCollection;
        private readonly IRankPotencyConfig _rankPotencyConfig;

        public PotencyGeneratorService(PredefinedCollection<ClassConfig_SO> classConfigCollection,
                                       IRankPotencyConfig rankPotencyConfig)
        {
            _classConfigCollection = classConfigCollection;
            _rankPotencyConfig = rankPotencyConfig;
        }

        public AdventurePotency GeneratePotency(AdventureRank rank, AdventureClass adventureClass)
        {
            var potencyAmount = Random.Range(_rankPotencyConfig[rank].MinValue, _rankPotencyConfig[rank].MaxValue + 1);

            Dictionary<StatusCodex, ushort> holdedPotencyNumber = new()
        {
                {StatusCodex.Health, 0 },

                {StatusCodex.PsyAttack, 0 },
                {StatusCodex.PsyDefense, 0 },

                {StatusCodex.MgcAttack, 0 },
                {StatusCodex.MgcDefense, 0 },

                {StatusCodex.Critical, 0 },
                {StatusCodex.Speed, 0 },
                {StatusCodex.Accuracy, 0 }};

            for (int i = 0; i < potencyAmount; i++)
            {
                var getPotency = GetPotencyPoint(adventureClass, holdedPotencyNumber);
                if (getPotency ==null)
                {
                    continue;
                }
                holdedPotencyNumber[getPotency.Status]++;

            }

            return new AdventurePotency(holdedPotencyNumber[StatusCodex.Health],

                                        holdedPotencyNumber[StatusCodex.PsyAttack],
                                        holdedPotencyNumber[StatusCodex.PsyDefense],

                                        holdedPotencyNumber[StatusCodex.MgcAttack],
                                        holdedPotencyNumber[StatusCodex.MgcDefense],

                                        holdedPotencyNumber[StatusCodex.Critical],
                                        holdedPotencyNumber[StatusCodex.Speed],
                                        holdedPotencyNumber[StatusCodex.Accuracy]);
        }

        private PotencyWeightValue? GetPotencyPoint(AdventureClass advClass, Dictionary<StatusCodex, ushort> holdedPotencyNumber)
        {
            using var _ = ListPool<PotencyWeightValue>.Get(out var potencyPossibilies);
            UpdatePossblePotencyList(potencyPossibilies, holdedPotencyNumber, advClass);

            if (potencyPossibilies.Count == 0)
            {
                return null;
            }

            int totalWeight = potencyPossibilies.Sum(data => data.Weight);
            int randomValue = Random.Range(1, totalWeight + 1);
            int cumulativeWeight = 0;

            foreach (var potency in potencyPossibilies)
            {
                cumulativeWeight += potency.Weight;
                if (randomValue <= cumulativeWeight)
                {
                    return potency;
                }
            }

            return null;
        }

        private void UpdatePossblePotencyList(List<PotencyWeightValue> potencyPossibilities, Dictionary<StatusCodex, ushort> holdedPotencyNumber, AdventureClass advClass)
        {
            potencyPossibilities.Clear();

            var selectedData = _classConfigCollection.GetItem(advClass.ToString());
            var potencyData = selectedData.PotencyWeight;


            foreach (var potency in potencyData)
            {
                if (potency.Weight > 0)
                {
                    potencyPossibilities.Add(potency);
                }
            }

            foreach (var currentPoint in holdedPotencyNumber)
            {
                if (currentPoint.Value > 3)
                {
                    var data = potencyPossibilities.Find(x => x.Status == currentPoint.Key);
                    potencyPossibilities.Remove(data);
                }
            }
        }
    }
}
