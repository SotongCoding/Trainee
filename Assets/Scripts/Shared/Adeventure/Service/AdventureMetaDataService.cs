using UnityEngine;

namespace SotongStudio.Trainee.Shared.Adventure.Data
{
    public interface IAdventureMetaDataService
    {
        void SetAdventureData(AdventureMetaData metaData);
        AdventureMetaData GetAdventureMetaData();
    }
    public class AdventureMetaDataService : IAdventureMetaDataService
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
