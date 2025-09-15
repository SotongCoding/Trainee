using System.Collections.Generic;
using SotongStudio.SharedData.PredefinedData;
using SotongStudio.Trainee.Shared.Adventure.Class;
using SotongStudio.Trainee.Shared.Adventure.Status;
using UnityEngine;

namespace SotongStudio.Trainee.Shared.Predifined.ClassConfig
{
    [CreateAssetMenu(fileName = "CLS_Name", menuName = "Predefined Data/Class Config/Item", order = 1)]
    public class ClassConfig_SO : PredefinedItem
    {
        public override string ItemId => Class.ToString();
        public AdventureClass Class;

        [SerializeField]
        private PotencyWeghtSetting _potencyWeight;

        public IEnumerable<PotencyWeightValue> PotencyWeight => _potencyWeight.AllValues();

    }

    [System.Serializable]
    public class PotencyWeghtSetting
    {
        private List<PotencyWeightValue> _weight = new();

        public PotencyWeightValue Health;

        public PotencyWeightValue PysAttack;
        public PotencyWeightValue PysDefense;

        public PotencyWeightValue MgcAttack;
        public PotencyWeightValue MgcDefense;

        public PotencyWeightValue Speed;
        public PotencyWeightValue Critical;
        public PotencyWeightValue Accuracy;

        public IEnumerable<PotencyWeightValue> AllValues()
        {
            if (_weight.Count == 0)
            {
                _weight.Add(Health);

                _weight.Add(PysAttack);
                _weight.Add(PysDefense);

                _weight.Add(MgcAttack);
                _weight.Add(MgcDefense);

                _weight.Add(Speed);
                _weight.Add(Critical);
                _weight.Add(Accuracy);
            }

            return _weight;
        }
    }

    [System.Serializable]
    public class PotencyWeightValue
    {
        public StatusCodex Status;
        public short Weight;
    }
}
