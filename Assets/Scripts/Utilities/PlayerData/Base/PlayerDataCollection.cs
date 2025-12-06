#nullable enable

using Newtonsoft.Json;
using UnityEngine;

namespace SotongStudio.SharedData.PlayerCollection
{
    public interface IPlayerDataCollectionUpdate
    {
        void WritePlayerData<T>(T newData, string? dataIdentity = null) where T : IPlayerDataItem;
        void RemoveItem<T>(string? dataIdentity = null) where T : IPlayerDataItem;
    }

    public interface IPlayerDataCollection
    {
        T GetData<T>(string? dataIdentity = null) where T : IPlayerDataItem;
    }
    public class PlayerCollection : IPlayerDataCollection, IPlayerDataCollectionUpdate
    {
        private const string _dataNamePrefix = "Player";

        public T GetData<T>(string? dataIdentity = null) where T : IPlayerDataItem
        {
            var playerPrefKey = GetDataKey<T>(dataIdentity);

            var jsonString = PlayerPrefs.GetString(playerPrefKey, string.Empty);
            var dataResult = JsonConvert.DeserializeObject<T>(jsonString) ??
                             throw new System.InvalidOperationException($"Cannot Find Collection with Key : {playerPrefKey}");

            return dataResult;
        }

        public void RemoveItem<T>(string? dataIdentity = null) where T : IPlayerDataItem
        {
            var playerPrefKey = GetDataKey<T>(dataIdentity);

            PlayerPrefs.DeleteKey(playerPrefKey);
        }

        public void WritePlayerData<T>(T newData, string? dataIdentity = null) where T : IPlayerDataItem
        {
            var playerPrefKey = GetDataKey<T>(dataIdentity);
            var stringData = JsonConvert.SerializeObject(newData);

            PlayerPrefs.SetString(playerPrefKey, stringData);
        }


        private static string GetDataKey<T>(string? dataIdentity = null) where T : IPlayerDataItem
        {
            return !string.IsNullOrEmpty(dataIdentity) ?
                   string.Format("{0}_{1}_{2}", _dataNamePrefix, typeof(T).Name, dataIdentity) :
                   string.Format("{0}_{1}", _dataNamePrefix, typeof(T).Name);
        }
    }
}
