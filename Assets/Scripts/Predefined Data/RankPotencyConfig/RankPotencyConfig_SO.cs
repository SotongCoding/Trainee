using System.Collections.Generic;
using SotongStudio.Trainee.Shared.Adventure.Rank;
using SotongStudio.VContainer;
using UnityEngine;

namespace SotongStudio.Trainee.Shared.Predifined.Rank.Potency
{
    public interface IRankPotencyConfig
    {
        RankPotencyRangeData this[AdventureRank rank] {  get; }
    }

    [CreateAssetMenu(fileName = "Rank Config", menuName = "Config/Rank")]
    [RegisterAs(typeof(IRankPotencyConfig))]
    public class RankPotencyConfig_SO : ScriptableObject, IRankPotencyConfig
    {
        [SerializeField] private RankPotencyRangeData EClass = new(AdventureRank.E_Class, 8, 10);
        [SerializeField] private RankPotencyRangeData DClass = new(AdventureRank.D_Class, 11, 13);
        [SerializeField] private RankPotencyRangeData CClass = new(AdventureRank.C_Class, 14, 16);
        [SerializeField] private RankPotencyRangeData BClass = new(AdventureRank.B_Class, 17, 19);
        [SerializeField] private RankPotencyRangeData AClass = new(AdventureRank.A_Class, 20, 22);
        [SerializeField] private RankPotencyRangeData SClass = new(AdventureRank.S_Class, 23, 25);
        [SerializeField] private RankPotencyRangeData YuushaClass = new(AdventureRank.Yuusha_Class, 30, 33);

        public RankPotencyRangeData this[AdventureRank rank] => GetData(rank);

        private readonly Dictionary<AdventureRank, RankPotencyRangeData> _potencyCollection = new();

        private RankPotencyRangeData GetData(AdventureRank rank)
        {
            if (_potencyCollection.Count <= 0)
            {
                _potencyCollection.Add(EClass.Rank, EClass);
                _potencyCollection.Add(DClass.Rank, DClass);
                _potencyCollection.Add(CClass.Rank, CClass);
                _potencyCollection.Add(BClass.Rank, BClass);
                _potencyCollection.Add(AClass.Rank, AClass);
                _potencyCollection.Add(SClass.Rank, SClass);
                _potencyCollection.Add(YuushaClass.Rank, YuushaClass);
            }

            return _potencyCollection[rank];
        }
    }

    [System.Serializable]
    public class RankPotencyRangeData
    {
        public AdventureRank Rank;
        public int MinValue;
        public int MaxValue;

        public RankPotencyRangeData(AdventureRank rank, int minValue, int maxValue)
        {
            Rank = rank;
            MinValue = minValue;
            MaxValue = maxValue;
        }
    }
}


