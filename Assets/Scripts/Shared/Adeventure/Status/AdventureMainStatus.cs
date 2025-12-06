using SotongStudio.Trainee.Service.StatusCalculator;
using SotongStudio.Trainee.Shared.Adventure.Experience;

namespace SotongStudio.Trainee.Shared.Adventure.Status
{
    public class AdventureMainStatus : IAdventureStatus
    {
        private readonly AdventureBaseStatus _baseStatus;
        private readonly IAdventureExperience _experience;


        public ushort Health => StatusCalculator.ScaleLevel(_experience.Level, _baseStatus).Health;

        public ushort PysAttack => StatusCalculator.ScaleLevel(_experience.Level, _baseStatus).PysAttack;

        public ushort PysDefense => StatusCalculator.ScaleLevel(_experience.Level, _baseStatus).PysDefense;

        public ushort MgcAttack => StatusCalculator.ScaleLevel(_experience.Level, _baseStatus).MgcAttack;

        public ushort MgcDefense => StatusCalculator.ScaleLevel(_experience.Level, _baseStatus).MgcDefense;

        public ushort Critical => StatusCalculator.ScaleLevel(_experience.Level, _baseStatus).Critical;

        public ushort Speed => StatusCalculator.ScaleLevel(_experience.Level, _baseStatus).Speed;

        public ushort Accuracy => StatusCalculator.ScaleLevel(_experience.Level, _baseStatus).Accuracy;

        public AdventureMainStatus(AdventureBaseStatus baseStatus, IAdventureExperience experience)
        {
            _baseStatus = baseStatus;
            _experience = experience;
        }
    }
}
