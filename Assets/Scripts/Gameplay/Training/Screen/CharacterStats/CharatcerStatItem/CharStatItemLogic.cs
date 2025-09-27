using UnityEngine;
using VContainer;

namespace SotongStudio.Trainee.Gameplay.Training.Screen
{
    public interface ICharacterStatItemLogic
    {
        void Setup();

        void ShowPredictedIncrement();
        void HidePredictedIncrement();

        void UpdateCurrentNumber();
        void UpdateEfficiency();
    }

    public class CharStatItemLogic : MonoBehaviour, ICharacterStatItemLogic
    {
        [SerializeField] private CharStatHandledData _handledData;
        [SerializeField] private CharStatNumberView _numberView;
        [SerializeField] private TrainingEfficiencyView _efficiencyView;

        private ITrainingFacilityDataService _dataService;

        [Inject]
        private void Inject(ITrainingFacilityDataService dataService)
        {
            _dataService = dataService;
        }

        public void Setup()
        {
            var amountPotency = _dataService.GetAdventurePotency(_handledData.HandledStatus);
            _efficiencyView.SetEfficiencyAmount(amountPotency);
        }
        public void ShowPredictedIncrement()
        {
            var incrementNumber = _dataService.GetIncrement(_handledData.HandledStatus);
            _numberView.SetIncrementNumber(incrementNumber);

            _numberView.ShowIncrement();
        }
        public void HidePredictedIncrement()
        {
            _numberView.HideIncrement();
        }

        public void UpdateCurrentNumber()
        {
            var currentStatNumber = _dataService.GetCurrentStat(_handledData.HandledStatus);
            _numberView.SetCurrentNumber(currentStatNumber);
        }
        public void UpdateEfficiency()
        {
            var currentEfficiency = _dataService.GetCurrentEfficiency(_handledData.HandledStatus);
            _efficiencyView.UpdateEfficiencyValue(currentEfficiency);
        }
    }
}