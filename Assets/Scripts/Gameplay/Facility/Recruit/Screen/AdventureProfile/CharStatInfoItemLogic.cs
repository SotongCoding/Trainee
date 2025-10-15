using SotongStudio.Trainee.Gameplay.Facility.Training.Screen;
using SotongStudio.Trainee.Shared.Adventure.Potency;
using SotongStudio.Trainee.Shared.Adventure.Status;
using TMPro;
using UnityEngine;

namespace SotongStudio.Trainee.Gameplay.Facility.Recruit.Screen
{
    public interface ICharStatInfoItemLogic
    {
        void Setup(AdventureFinalStatus finalStatus, AdventurePotency potency);
    }
    public class CharStatInfoItemLogic : MonoBehaviour, ICharStatInfoItemLogic
    {
        [SerializeField] private CharStatHandledData _handledData;
        [SerializeField] private CharStatNumberView _numberView;
        [SerializeField] private CharPotencyView _potencyView;

        public void Setup(AdventureFinalStatus finalStatus, AdventurePotency potency)
        {
            var statNumber = finalStatus.StatOf(_handledData.HandledStatus);
            var potencyAmount = potency.StatOf(_handledData.HandledStatus);

            _numberView.SetCurrentNumber(statNumber);
            _potencyView.SetEfficiencyAmount(potencyAmount);
        }
    }
}
