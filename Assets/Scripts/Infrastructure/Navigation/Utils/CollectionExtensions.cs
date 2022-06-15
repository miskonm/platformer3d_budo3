using System;
using System.Collections.Generic;

namespace Platformer.Infrastructure.Navigation.Utils
{
    public static class CollectionExtensions
    {
        public static void Fill<TKey, TValue>(this Dictionary<TKey, TValue> dict, string tag, ICollection<TValue> array,
            Func<TValue, TKey> getKey, bool needClear = true)
        {
            if (needClear)
                dict.Clear();

            if (array == null)
                return;

            foreach (TValue value in array)
            {
                TKey key = getKey.Invoke(value);

                if (!dict.ContainsKey(key))
                    dict.Add(key, value);
                else
                    UnityEngine.Debug.LogError($"{tag}, {nameof(Fill)}: Duplicated settings with key '{key}'");
            }
        }
        
        public static void ForEach<T>(this ICollection<T> collection, Action<T> action)
        {
            foreach (T item in collection)
                action?.Invoke(item);
        }
    }
}