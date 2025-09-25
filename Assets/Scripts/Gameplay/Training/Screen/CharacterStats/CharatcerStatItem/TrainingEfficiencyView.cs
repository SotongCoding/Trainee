using UnityEngine;
using UnityEngine.UI;

namespace SotongStudio.Trainee.Gameplay.Training.Screen
{
    public interface ITrainingEfficiencyView
    {
        void SetEfficiencyAmount(int amount);
        void UpdateEfficiencyValue(float value);
    }
    public class TrainingEfficiencyView : MonoBehaviour, ITrainingEfficiencyView
    {
        [SerializeField]
        private GameObject[] _efficiencyBar;
        [SerializeField]
        private Image _efficiencyFillImage;

        public void SetEfficiencyAmount(int amount)
        {
            int i = 0;
            for (; i < amount; i++)
            {
                _efficiencyBar[i].SetActive(true);
            }
            for (; i < _efficiencyBar.Length; i++)
            {
                _efficiencyBar[i].SetActive(false);
            }
        }

        public void UpdateEfficiencyValue(float value)
        {
            _efficiencyFillImage.fillAmount = value;
        }
    }
}
