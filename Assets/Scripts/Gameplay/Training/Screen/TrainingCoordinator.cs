using VContainer.Unity;

namespace SotongStudio.Trainee.Gameplay.Training.Screen
{
    public class TrainingCoordinator : IStartable
    {
        public TrainingCoordinator(ITrainingController controller,
                                   ITrainingFacilityPlayerAction playerAction)
        {
            playerAction.OnCheckPredictStat.AddListener(controller.ShowPredictionStatIncrease);
            playerAction.OnDoTraining.AddListener(controller.TrainingProcess);
        }

        public void Start()
        {
            
        }
    }
}
