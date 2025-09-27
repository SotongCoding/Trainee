using System.Collections.Generic;
using UnityEngine.Events;

namespace SotongStudio.Trainee.Gameplay.Training.Screen
{
    public interface ITrainingFacilityLogic
    {
        void Show();

        void UpdateStatNumber();
        void ShowPredictObtainStat();
        void Hide();
        void HidePredictObtainedStat();
    }

    public interface ITrainingFacilityPlayerAction
    {
        UnityEvent OnCheckPredictStat { get; }
        UnityEvent OnDoTraining { get; }
    }
    public class TrainingFacilityLogic : ITrainingFacilityLogic, ITrainingFacilityPlayerAction
    {
        private readonly IReadOnlyList<ICharacterStatItemLogic> _charStats;
        private readonly ITrainingFacilityView _view;

        public UnityEvent OnCheckPredictStat { get; private set; } = new();
        public UnityEvent OnDoTraining { get;  private set;} = new();  

        private int _currentPressNumber = 0;

        public TrainingFacilityLogic(IReadOnlyList<ICharacterStatItemLogic> charStats,
                                     ITrainingFacilityView view)
        {
            _charStats = charStats;
            _view = view;

            _view.OnTrainButtonSelect.AddListener(TrainButtonLogicProcess);
        }



        public void Show()
        {
            _view.Show();
        }

        private void TrainButtonLogicProcess()
        {
            if (_currentPressNumber == 0)
            {
                OnCheckPredictStat.Invoke();
                _currentPressNumber++;
            }
            else
            {
                OnDoTraining.Invoke();
                _currentPressNumber = 0;
            }
        }

        public void ShowPredictObtainStat()
        {
            foreach (var stat in _charStats)
            {
                stat.ShowPredictedIncrement();
            }
        }
        public void HidePredictObtainedStat()
        {
            foreach (var stat in _charStats)
            {
                stat.HidePredictedIncrement();
            }
        }

        public void UpdateStatNumber()
        {
            foreach (var stat in _charStats)
            {
                //Just testing
                stat.Setup();


                stat.UpdateCurrentNumber();
                stat.UpdateEfficiency();
                
            }
        }

        public void Hide()
        {
            _view.Hide();
        }
    }
}
