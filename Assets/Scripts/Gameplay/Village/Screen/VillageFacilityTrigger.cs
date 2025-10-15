using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

#nullable enable
namespace SotongStudio.Trainee.Gameplay.Village.Screen
{
    public interface IVillageFacilityTrigger
    {
        UnityEvent<VillageFacility, string?> OnSelectFacility { get; }
    }
    public class VillageFacilityTrigger : MonoBehaviour, IVillageFacilityTrigger
    {
        [SerializeField] private VillageFacility _facility;
        [SerializeField] private string facilityId;

        [SerializeField] private Button _selectButton;
        public UnityEvent<VillageFacility, string?> OnSelectFacility { get; private set; } = new();

        private void Awake()
        {
            _selectButton.onClick.AddListener(SelectFacility);
        }

        private void OnDestroy()
        {
            _selectButton?.onClick.RemoveListener(SelectFacility);
        }

        private void SelectFacility()
        {
            OnSelectFacility.Invoke(_facility, facilityId);
        }
    }
}
