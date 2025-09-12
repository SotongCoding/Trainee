using SotongStudio.Trainee.Service.StatusCalculator;

namespace SotongStudio.Trainee.Shared.Adventure.Status
{
    public class AdventureMainStatus : IAdventureStatus
    {
        public ushort Level { get; private set; }
        private readonly AdventureBaseStatus _baseStatus;


        public ushort Health => StatusCalculator.ScaleLevel(Level, _baseStatus).Health;

        public ushort PysAttack => StatusCalculator.ScaleLevel(Level, _baseStatus).PysAttack;

        public ushort PysDefense => StatusCalculator.ScaleLevel(Level, _baseStatus).PysDefense;

        public ushort MgcAttack => StatusCalculator.ScaleLevel(Level, _baseStatus).MgcAttack;

        public ushort MgcDefense => StatusCalculator.ScaleLevel(Level, _baseStatus).MgcDefense;

        public ushort Critical => StatusCalculator.ScaleLevel(Level, _baseStatus).Critical;

        public ushort Speed => StatusCalculator.ScaleLevel(Level, _baseStatus).Speed;

        public ushort Accuracy => StatusCalculator.ScaleLevel(Level, _baseStatus).Accuracy;

        public AdventureMainStatus(AdventureBaseStatus baseStatus)
        {
            _baseStatus = baseStatus;
        }

        public void ChangeLevel(ushort level)
        {
            Level = level;
        }
    }
}
