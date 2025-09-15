using SotongStudio.Trainee.Service.TrainigCalculator;

namespace SotongStudio.Trainee.Shared.Adventure.Status
{
    public class AdventureTrainingStatus : IAdventureStatus
    {
        public ushort Health { get; private set; }

        public ushort PysAttack { get; private set; }

        public ushort PysDefense { get; private set; }

        public ushort MgcAttack { get; private set; }

        public ushort MgcDefense { get; private set; }

        public ushort Critical { get; private set; }

        public ushort Speed { get; private set; }

        public ushort Accuracy { get; private set; }

        public AdventureTrainingStatus(ushort health,

                                   ushort pysAttack, ushort pysDefense,
                                   ushort mgcAttack, ushort mgcDefense,

                                   ushort critical, ushort speed, ushort accuracy)
        {
            Health = health;
            PysAttack = pysAttack;
            PysDefense = pysDefense;
            MgcAttack = mgcAttack;
            MgcDefense = mgcDefense;
            Critical = critical;
            Speed = speed;
            Accuracy = accuracy;
        }

        public AdventureTrainingStatus() : this(0, 0, 0, 0, 0, 0, 0, 0)
        {

        }

        public void AddStatus(ITrainingResult trainingResult)
        {
            Health += trainingResult.Health;

            PysAttack += trainingResult.PysAttack;
            PysDefense += trainingResult.PysDefense;

            MgcAttack += trainingResult.MgcAttack;
            MgcDefense += trainingResult.MgcDefense;

            Accuracy += trainingResult.Accuracy;
            Speed += trainingResult.Speed;
            Critical += trainingResult.Critical;
        }
    }
}
