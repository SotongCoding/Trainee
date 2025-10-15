using SotongStudio.Trainee.Shared.Adventure.Class;
using SotongStudio.Trainee.Shared.Adventure.Efficiency;
using SotongStudio.Trainee.Shared.Adventure.Experience;
using SotongStudio.Trainee.Shared.Adventure.Potency;
using SotongStudio.Trainee.Shared.Adventure.Rank;

namespace SotongStudio.Trainee.Shared.Adventure.Data
{
    public interface IAdventureMetaData
    {
        AdventureRank Rank { get; }
        AdventureClass JobClass {get;}

        AdventureStatuses Statuses {get;}
        AdventurePotency Potency {get;}
        TrainingEfficiency TrainingEfficiency {get;}
        AdventureExperience Experience {get;}
    }
}
