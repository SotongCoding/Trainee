using SotongStudio.SharedData.PredefinedData;
using SotongStudio.Trainee.Shared.Adventure.Efficiency;
using SotongStudio.Trainee.Shared.Adventure.Status;
using UnityEngine;

namespace SotongStudio.Trainee.Shared.Predifined.Training
{
    [CreateAssetMenu(fileName = "TRN_XX", menuName = "Predefined Data/Training Config/Item", order = 1)]
    public class TrainingConfig_SO : PredefinedItem
    {
        [SerializeField]
        private string TrainingId;
        public IncrementStat IncrementStat;
        public ReduceEfficiency EfficiencyReducement;
        public ushort Experience;

        public override string ItemId => TrainingId;    
    }

    [System.Serializable]
    public class IncrementStat : IAdventureStatus
    {
        [field:SerializeField]
        public ushort Health { get; private set; }
        [field: SerializeField]
        public ushort PysAttack { get; private set; }
        [field: SerializeField]
        public ushort PysDefense { get; private set; }
        [field: SerializeField]
        public ushort MgcAttack { get; private set; }
        [field: SerializeField]
        public ushort MgcDefense { get; private set; }
        [field: SerializeField]
        public ushort Critical { get; private set; }
        [field: SerializeField]
        public ushort Speed { get; private set; }
        [field: SerializeField]
        public ushort Accuracy { get; private set; }
    }

    [System.Serializable]
    public class ReduceEfficiency : ITrainingEfficiency
    {
        [field: SerializeField]
        public float HealthEfficiency { get; private set; }
        [field: SerializeField]
        public float PysAttackEfficiency { get; private set; }
        [field: SerializeField]
        public float PysDefenseEfficiency { get; private set; }
        [field: SerializeField]
        public float MgcAttackEfficiency { get; private set; }
        [field: SerializeField]
        public float MgcDefenseEfficiency { get; private set; }
        [field: SerializeField]
        public float CriticalEfficiency { get; private set; }
        [field: SerializeField]
        public float SpeedEfficiency { get; private set; }
        [field: SerializeField]
        public float AccuracyEfficiency { get; private set; }
    }
}
