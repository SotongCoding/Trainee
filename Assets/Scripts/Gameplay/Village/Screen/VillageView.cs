using UnityEngine;

namespace SotongStudio.Trainee.Gameplay.Village.Screen
{
    public interface IVillageView
    {
        void Show();
        void Hide();
    }

    public class VillageView : MonoBehaviour, IVillageView
    {
        [SerializeField] private CanvasGroup _mainCanvasGroup;

        public void Show()
        {
            _mainCanvasGroup.Show();
        }
        public void Hide()
        {
            _mainCanvasGroup.Hide();
        }

    }
}
