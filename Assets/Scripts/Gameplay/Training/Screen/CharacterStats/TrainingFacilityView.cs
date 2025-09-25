using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace SotongStudio.Trainee.Gameplay.Training.Screen
{
    public interface ITrainingFacilityView
    {
        void Show();
        void Hide();

        UnityEvent OnTrainButtonSelect { get; }
    }
    public class TrainingFacilityView : MonoBehaviour, ITrainingFacilityView
    {
        [SerializeField] private CanvasGroup _mainCanvasGroup;
        [SerializeField] private Button _trainButton;
        public UnityEvent OnTrainButtonSelect => _trainButton.onClick;

        public void Hide()
        {
            _mainCanvasGroup.Hide();
        }

        public void Show()
        {
            _mainCanvasGroup.Show();
        }
    }
}
