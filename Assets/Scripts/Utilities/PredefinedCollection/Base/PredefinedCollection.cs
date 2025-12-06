using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;

namespace SotongStudio.SharedData.PredefinedData
{
    public interface IPredefinedCollection<TValue> where TValue : IPredefinedItem
    {
        TValue GetItem(string itemId);
        IEnumerable<TValue> GetAllItems();
    }
    public abstract class PredefinedCollection<TValue> : ScriptableObject, IPredefinedCollection<TValue>
                                                         where TValue : ScriptableObject, IPredefinedItem
    {

        [SerializeField] private List<TValue> _itemList = new List<TValue>();

        public TValue GetItem(string itemId)
        {
            var targetObject = _itemList.Find(data => data.ItemId == itemId);
            return targetObject;
        }

        public IEnumerable<TValue> GetAllItems()
        {
            return _itemList;
        }

        #region Get Data Helper
#if UNITY_EDITOR
        [Button]
        private void SearchItems()
        {
            var rawFilePath = UnityEditor.AssetDatabase.GetAssetPath(this).Split('/');
            string filePath = string.Empty;

            for (int i = 0; i < rawFilePath.Length - 1; i++)
            {
                filePath += rawFilePath[i] + "/";
            }
            string[] files = System.IO.Directory.GetFiles(filePath + "/", "*.asset", System.IO.SearchOption.AllDirectories);

            _itemList.Clear();
            foreach (var file in files)
            {
                Debug.Log($"Found Asset :{file}");
                var asset = UnityEditor.AssetDatabase.LoadAssetAtPath<TValue>(file);

                if (asset != null)
                    _itemList.Add(asset);

            }
        }
#endif


        #endregion
    }
}
