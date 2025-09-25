using TMPro;
using UnityEngine;

namespace SotongStudio.Trainee.Gameplay.Training.Screen
{
    public interface ICharStatNumberView
    {
        void SetCurrentNumber(ushort value);
        
        void ShowIncrement();
        void SetIncrementNumber(ushort value);
        void HideIncrement();
    }

    public class CharStatNumberView : MonoBehaviour, ICharStatNumberView
    {
        [SerializeField] private TMP_Text _currentNumber;
        
        [Space]
        [SerializeField] private TMP_Text _incrementNumber;
        [SerializeField] private CanvasGroup _incrementCanvas;


        public void SetCurrentNumber(ushort value)
        {
            _currentNumber.text = value.ToString();
        }

        public void ShowIncrement()
        {
            _incrementCanvas.Show();
        }
        public void SetIncrementNumber(ushort value)
        {
            _incrementNumber.text = $"+{value}";
        }
        public void HideIncrement()
        {
            _incrementCanvas.Hide();
        }
    }
}
