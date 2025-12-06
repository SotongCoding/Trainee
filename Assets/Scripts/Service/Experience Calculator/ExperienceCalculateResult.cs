
namespace SotongStudio.Trainee.Service.ExperienceCalculator
{
    public interface IExperienceCalculateResult
    {
        ushort LevelObtained { get; }
        ushort NewCurrentExperience { get; }
    }
    public class ExperienceCalculateResult : IExperienceCalculateResult
    {
        public ushort LevelObtained { get; private set; }
        public ushort NewCurrentExperience { get; private set; }

        public ExperienceCalculateResult(ushort levelObtained, ushort newCurrentExperience)
        {
            LevelObtained = levelObtained;
            NewCurrentExperience = newCurrentExperience;
        }
    }
}

