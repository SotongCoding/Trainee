using SotongStudio.Trainee.Service.StatusCalculator;

namespace SotongStudio.Trainee.Shared.Adventure.Status
{
    public class AdventureFinalStatus : IAdventureStatus
    {
        private readonly AdventureMainStatus _mainStatus;
        private readonly AdventureTrainingStatus _trainingStatus;


        public ushort Health => StatusCalculator.SumAdventureStatus(_mainStatus, _trainingStatus).Health;
        public ushort PysAttack => StatusCalculator.SumAdventureStatus(_mainStatus, _trainingStatus).PysAttack;
        public ushort PysDefense => StatusCalculator.SumAdventureStatus(_mainStatus, _trainingStatus).PysDefense;
        public ushort MgcAttack => StatusCalculator.SumAdventureStatus(_mainStatus, _trainingStatus).MgcAttack;
        public ushort MgcDefense => StatusCalculator.SumAdventureStatus(_mainStatus, _trainingStatus).MgcDefense;
        public ushort Critical => StatusCalculator.SumAdventureStatus(_mainStatus, _trainingStatus).Critical;
        public ushort Speed => StatusCalculator.SumAdventureStatus(_mainStatus, _trainingStatus).Speed;
        public ushort Accuracy => StatusCalculator.SumAdventureStatus(_mainStatus, _trainingStatus).Accuracy;

        public AdventureFinalStatus(AdventureMainStatus mainStatus, 
                                    AdventureTrainingStatus trainingStatus)
        {
            _mainStatus = mainStatus;
            _trainingStatus = trainingStatus;
        }
    }
}
