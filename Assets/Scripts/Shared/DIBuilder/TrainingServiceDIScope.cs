using SotongStudio.Trainee.Gameplay.Training;
using VContainer;

namespace SotongStudio.Trainee
{
    public static class TrainingServiceDIScope 
    {
        public static void  RegisterTrainingServiceDI(this IContainerBuilder builder)
        {
            builder.Register<TrainingService>(Lifetime.Singleton).As<ITrainingService>();
        }
    }
}
