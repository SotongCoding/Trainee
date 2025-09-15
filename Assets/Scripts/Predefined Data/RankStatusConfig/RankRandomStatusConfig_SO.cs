using System.Collections.Generic;
using SotongStudio.VContainer;
using UnityEngine;

namespace SotongStudio.Trainee.Shared.Predifined.Rank.RandomStatus
{
    [CreateAssetMenu(fileName = "Random Stat Config", menuName = "Config/Random Status")]
    [RegisterAs(typeof(RankRandomStatusConfig_SO))]
    public class RankRandomStatusConfig_SO : ScriptableObject
    {
        [SerializeField] private List<RankStatusRangeData> _randomStatList;

        private readonly Dictionary<int, RankStatusRangeData> _randomStatMap = new();
        public ushort GetStat(ushort potency)
        {
            if (_randomStatMap.Count <= 0)
            {
                foreach (var data in _randomStatList)
                {
                    _randomStatMap.Add(data.PotencyNumber, data);
                }
            }

            var selectedData = _randomStatMap[potency];
            return (ushort)Random.Range(selectedData.MinValue, selectedData.MaxValue + 1);
        }

        [System.Serializable]
        public class RankStatusRangeData
        {
            public int PotencyNumber;
            [Space]
            public int MinValue;
            public int MaxValue;

            public RankStatusRangeData(int potencyNumber, int minValue, int maxValue)
            {
                PotencyNumber = potencyNumber;
                MinValue = minValue;
                MaxValue = maxValue;
            }
        }
    }
}
