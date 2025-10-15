using Newtonsoft.Json;
using SotongStudio.Trainee.Shared.Adventure.Class;
using SotongStudio.Trainee.Shared.Adventure.Efficiency;
using SotongStudio.Trainee.Shared.Adventure.Experience;
using SotongStudio.Trainee.Shared.Adventure.Potency;
using SotongStudio.Trainee.Shared.Adventure.Rank;
using SotongStudio.Trainee.Shared.Adventure.Status;

namespace SotongStudio.Trainee.Shared.Adventure.Data
{
    public class AdventureMetaData : IAdventureMetaData
    {
        public AdventureRank Rank { get; private set; }
        public AdventureClass JobClass {get; private set;}

        public AdventureStatuses Statuses {get; private set;}
        public AdventurePotency Potency {get; private set;}
        public TrainingEfficiency TrainingEfficiency {get; private set;}
        public AdventureExperience Experience {get; private set;}

        public AdventureMetaData(AdventureRank rank,
                                 AdventureClass jobClass,
                                 AdventureBaseStatus baseStatus,
                                 AdventurePotency potency,
                                 TrainingEfficiency trainingEfficiency)
        {
            Rank = rank;
            JobClass = jobClass;

            Experience = new();

            Potency = potency;
            TrainingEfficiency = trainingEfficiency;

            Statuses = new(baseStatus, Experience);
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


        public AdventureStatuses(AdventureBaseStatus baseStatus, AdventureExperience experience)
        {
            BaseStatus = baseStatus;

            MainStatus = new(baseStatus, experience);
            TrainingStatus = new();
            FinalStatus = new(MainStatus, TrainingStatus);
        }
    }
}
