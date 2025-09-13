#nullable enable

using UnityEngine;

namespace SotongStudio.SharedData.PredefinedData
{
    public interface IPredefinedItem
    {
        string ItemId { get; }
    }

    public abstract class PredefinedItem : ScriptableObject, IPredefinedItem
    {
        public abstract string ItemId { get; }
    }
}
