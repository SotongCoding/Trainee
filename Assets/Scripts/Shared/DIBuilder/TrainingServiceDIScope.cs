using VContainer;

namespace SotongStudio.Trainee.Gameplay.Facility.Training
{
    public static class TrainingServiceDIScope 
    {
        public static void  RegisterTrainingServiceDI(this IContainerBuilder builder)
        {
            builder.Register<TrainingService>(Lifetime.Singleton).As<ITrainingService>();
        }
    }
}
