using UnityEngine.Events;
using UnityEngine;
using UnityEngine.UI;


namespace SotongStudio.Trainee.Gameplay.Facility.Recruit.Screen
{
    public interface IRecruitFacilityView
    {
        UnityEvent OnKeepAdventure { get; }
        UnityEvent OnRecruitAdventure { get; }
        UnityEvent OnExit {  get; }


        void Show();
        void Hide();
    }

    public class RecruitFacilityView : MonoBehaviour, IRecruitFacilityView
    {
        [SerializeField] private CanvasGroup _mainHUDCanvas;

        [SerializeField] private Button RecruitButton; 
        [SerializeField] private Button KeepRecruitButton;
        [SerializeField] private Button ExitButton;

        public UnityEvent OnRecruitAdventure => RecruitButton.onClick;
        public UnityEvent OnKeepAdventure => KeepRecruitButton.onClick;
        public UnityEvent OnExit => ExitButton.onClick;



        public void Show()
        {
            _mainHUDCanvas.Show();
        }

        public void Hide()
        {
            _mainHUDCanvas.Hide();
        }
    }
}