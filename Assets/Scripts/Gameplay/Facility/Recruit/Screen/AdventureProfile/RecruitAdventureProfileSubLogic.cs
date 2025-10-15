using System.Collections.Generic;
using SotongStudio.Trainee.Shared.Adventure.Data;

namespace SotongStudio.Trainee.Gameplay.Facility.Recruit.Screen
{
    public interface IRecruitAdventureProfileSubLogic
    {
        void SetupInfo(IAdventureMetaData adventureResult);
    }
    public class RecruitAdventureProfileSubLogic : IRecruitAdventureProfileSubLogic
    {
        private readonly ICharBasicInfoView _charInfo;
        private readonly IReadOnlyList<ICharStatInfoItemLogic> _statInfoItems;

        public RecruitAdventureProfileSubLogic(ICharBasicInfoView charInfo,
                                               IReadOnlyList<ICharStatInfoItemLogic> statInfoItems)
        {
            _charInfo = charInfo;
            _statInfoItems = statInfoItems;
        }

        public void SetupInfo(IAdventureMetaData adventureResult)
        {
            _charInfo.Setup(adventureResult.JobClass, adventureResult.Rank);
            foreach (var statInfo in _statInfoItems)
            {
                statInfo.Setup(adventureResult.Statuses.FinalStatus, adventureResult.Potency);
            }
        }
    }
}
