using System.Collections.Generic;
using System.Linq;
using SotongStudio.SharedData.PredefinedData;
using SotongStudio.Trainee.Shared.Adventure.Class;
using SotongStudio.Trainee.Shared.Adventure.Potency;
using SotongStudio.Trainee.Shared.Adventure.Rank;
using SotongStudio.Trainee.Shared.Adventure.Status;
using SotongStudio.Trainee.Shared.Predifined.ClassConfig;
using SotongStudio.Utilities.Enumerable;
using UnityEngine;
using UnityEngine.Pool;


namespace SotongStudio.Trainee.Service.PotencyGenerator
{
    public class PotencyGeneratorService
    {
        private readonly PredefinedCollection<ClassConfig_SO> _classConfigCollection;

        //TODO Make as decicated Data so it can be modified by designer
        private readonly Dictionary<AdventureRank, (int min, int max)> _potencyAmountMaps = new Dictionary<AdventureRank, (int min, int max)>
        {
            { AdventureRank.E_Class, (8, 10) },
            { AdventureRank.D_Class, (11, 13) },
            { AdventureRank.C_Class, (14, 16) },
            { AdventureRank.B_Class, (17, 19) },
            { AdventureRank.A_Class, (20, 22) },
            { AdventureRank.S_Class, (23, 25) },
            { AdventureRank.Yusha_Class, (30, 33) },
        };

        private readonly Dictionary<StatusCodex, ushort> _holdedPotencyNumber = new()
        {
            {StatusCodex.Health, 0 },

            {StatusCodex.PsyAttack, 0 },
            {StatusCodex.PsyDefense, 0 },

            {StatusCodex.MgcAttack, 0 },
            {StatusCodex.MgcDefense, 0 },

            {StatusCodex.Critical, 0 },
            {StatusCodex.Speed, 0 },
            {StatusCodex.Accuracy, 0 },
        };

        public PotencyGeneratorService(PredefinedCollection<ClassConfig_SO> classConfigCollection)
        {
            _classConfigCollection = classConfigCollection;
        }

        public AdventurePotency GeneratePotency(AdventureRank rank, AdventureClass adventureClass)
        {
            var potencyAmount = Random.Range(_potencyAmountMaps[rank].min, _potencyAmountMaps[rank].max + 1);

            _holdedPotencyNumber.ResetValuesOnly();

            for (int i = 0; i < potencyAmount; i++)
            {
                var getPotency = GetPotencyPoint(adventureClass);
                _holdedPotencyNumber[getPotency.Status]++;

            }

            return new AdventurePotency(_holdedPotencyNumber[StatusCodex.Health],

                                        _holdedPotencyNumber[StatusCodex.PsyAttack],
                                        _holdedPotencyNumber[StatusCodex.PsyDefense],

                                        _holdedPotencyNumber[StatusCodex.MgcAttack],
                                        _holdedPotencyNumber[StatusCodex.MgcDefense],

                                        _holdedPotencyNumber[StatusCodex.Critical],
                                        _holdedPotencyNumber[StatusCodex.Speed],
                                        _holdedPotencyNumber[StatusCodex.Accuracy]);
        }

        private PotencyWeightValue GetPotencyPoint(AdventureClass advClass)
        {
            using var _ = ListPool<PotencyWeightValue>.Get(out var potencyPossibilies);
            UpdatePossblePotencyList(potencyPossibilies, advClass);

            if (potencyPossibilies.Count == 0)
            {
                Debug.LogError("Failed Get Potency. No Possibility");
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

            // Fallback (seharusnya tidak terjadi)
            return potencyPossibilies[0];
        }

        private void UpdatePossblePotencyList(List<PotencyWeightValue> potencyPossibilies, AdventureClass advClass)
        {
            var selectedData = _classConfigCollection.GetItem(advClass.ToString());
            var potencyData = selectedData.PotencyWeight;

            potencyPossibilies.Clear();

            foreach (var potency in potencyData)
            {
                if (potency.Weight > 0 && _holdedPotencyNumber[potency.Status] < 4)
                {
                    potencyPossibilies.Add(potency);
                }
            }
        }
    }
}
