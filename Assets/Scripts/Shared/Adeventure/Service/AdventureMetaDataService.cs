using UnityEngine;

namespace SotongStudio.Trainee.Shared.Adventure.Data
{
    public interface IAdventureMetaDatUpdateService
    {
        void SetAdventureData(AdventureMetaData metaData);
    }

    public interface IAdventureMetaDataService
    {
        AdventureMetaData GetAdventureMetaData();
    }
    public class AdventureMetaDataService : IAdventureMetaDataService, IAdventureMetaDatUpdateService
    {
        private AdventureMetaData _currentAdventure;

        public AdventureMetaData GetAdventureMetaData()
        {
            return _currentAdventure;
        }

        public void SetAdventureData(AdventureMetaData metaData)
        {
            _currentAdventure = metaData;
        }
    }
}
