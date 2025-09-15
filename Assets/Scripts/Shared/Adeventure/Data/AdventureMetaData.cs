using Newtonsoft.Json;
using SotongStudio.Trainee.Shared.Adventure.Class;
using SotongStudio.Trainee.Shared.Adventure.Efficiency;
using SotongStudio.Trainee.Shared.Adventure.Potency;
using SotongStudio.Trainee.Shared.Adventure.Rank;
using SotongStudio.Trainee.Shared.Adventure.Status;

namespace SotongStudio.Trainee.Shared.Adventure.Data
{
    public class AdventureMetaData
    {
        public AdventureRank Rank;
        public AdventureClass JobClass;

        public AdventureStatuses Statuses;
        public AdventurePotency Potency;
        public TrainingEfficiency TrainingEfficiency;

        public AdventureMetaData(
                                 AdventureRank rank,
                                 AdventureClass jobClass,
                                 AdventureBaseStatus baseStatus,
                                 AdventurePotency potency,
                                 TrainingEfficiency trainingEfficiency)
        {
            Rank = rank;
            JobClass = jobClass;

            Statuses = new(baseStatus);
            Potency = potency;
            TrainingEfficiency = trainingEfficiency;
        }
    }

    public class AdventureStatuses
    {
        public AdventureFinalStatus FinalStatus;

        public AdventureBaseStatus BaseStatus;
        public AdventureMainStatus MainStatus;
        public AdventureTrainingStatus TrainingStatus;

        [JsonConstructor]
        public AdventureStatuses(AdventureFinalStatus finalStatus,
                                 AdventureBaseStatus baseStatus, 
                                 AdventureMainStatus mainStatus, 
                                 AdventureTrainingStatus trainingStatus)
        {
            FinalStatus = finalStatus;
            BaseStatus = baseStatus;
            MainStatus = mainStatus;
            TrainingStatus = trainingStatus;
        }

        
        public AdventureStatuses(AdventureBaseStatus baseStatus)
        {
            BaseStatus = baseStatus;

            MainStatus = new(baseStatus);
            TrainingStatus = new();
            FinalStatus = new(MainStatus, TrainingStatus);
        }
    }
}
