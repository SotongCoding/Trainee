using TMPro;
using UnityEngine;

namespace SotongStudio.Trainee
{
    public interface IIncrementNumberView
    {
        void ShowIncrement();
        void SetIncrementNumber(ushort value);
        void HideIncrement();
    }
    public class IncrementNumberView : MonoBehaviour, IIncrementNumberView
    {
        [SerializeField] private CanvasGroup _incrementCanvas;
        [SerializeField] private TMP_Text _incrementNumber;

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
