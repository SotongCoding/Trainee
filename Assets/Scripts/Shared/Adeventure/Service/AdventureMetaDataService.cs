using SotongStudio.Trainee.Service.AdventureGenerator;

#nullable enable

namespace SotongStudio.Trainee.Shared.Adventure.Data
{
    public interface IAdventureMetaDatUpdateService
    {
        
    }

    public interface IAdventureMetaDataProvider
    {
        bool CreateNewAdventure(out IAdventureMetaData? adventure);
        IAdventureMetaData GetAdventureMetaData();
        void KeepLastRecruitedAdventure();


    }
    public class AdventureMetaDataService : IAdventureMetaDataProvider, IAdventureMetaDatUpdateService
    {
        private readonly AdventureGenerator _adventureGenerator;

        private AdventureMetaData? _currentAdventure;
        private IAdventureMetaData? _lastRecruitAdventure;

        public AdventureMetaDataService(AdventureGenerator adventureGenerator)
        {
            _adventureGenerator = adventureGenerator;
        }

        public bool CreateNewAdventure(out IAdventureMetaData? adventure)
        {
            adventure = _lastRecruitAdventure;
            if (_currentAdventure is not null) { return false; }
            
            _lastRecruitAdventure = _adventureGenerator.CreateAdventure();
            adventure = _lastRecruitAdventure;

            return true;

        }

        public IAdventureMetaData GetAdventureMetaData()
        {
            if (_currentAdventure is null)
            {
                throw new System.InvalidOperationException("Cannot get Adventure data since its NULL");
            }
            return _currentAdventure;
        }

        public void KeepLastRecruitedAdventure()
        {
            if (_lastRecruitAdventure is null)
            {
                throw new System.InvalidOperationException("Cannot get last recruited Adventure data");
            }

            _currentAdventure = new(_lastRecruitAdventure.Rank, _lastRecruitAdventure.JobClass,
                                    _lastRecruitAdventure.Statuses.BaseStatus, _lastRecruitAdventure.Potency, _lastRecruitAdventure.TrainingEfficiency);
            _lastRecruitAdventure = null;
        }
    }
}
