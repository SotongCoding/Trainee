using System.Collections.Generic;
using System.Linq;

namespace SotongStudio.Utilities.Enumerable
{
    public static class DictionaryExtension
    {
        public static Dictionary<K, V> ResetValuesOnly<K, V>(this Dictionary<K, V> dic, V value = default)
        {
            dic.Keys.ToList().ForEach(x => dic[x] = value);
            return dic;
        }

        public static Dictionary<K, V> ResetValuesOnlyAsNewDictionary<K, V>(this Dictionary<K, V> dic)
        {
            return dic.ToDictionary(x => x.Key, x => default(V), dic.Comparer);
        }

    }

}
