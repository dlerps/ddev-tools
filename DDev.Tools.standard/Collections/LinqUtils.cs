﻿using System.Linq;
using System;
using System.Collections.Generic;

namespace DDev.Tools
{
    public static class LinqUtils
    {
        /// <summary>
        /// Transforms an enumerable to a clustered dictionary.
        /// Uses a function to determine by which key to cluster the collection.
        /// </summary>
        /// <typeparam name="K"></typeparam>
        /// <typeparam name="V"></typeparam>
        /// <param name="src"></param>
        /// <param name="keySelector"></param>
        /// <param name="fillupKeys"></param>
        /// <returns></returns>
        public static IDictionary<K, List<V>> ToClusteredDictionary<K, V>(
            this IEnumerable<V> src, 
            Func<V, K> keySelector,
            List<K> fillupKeys)
            where V : new()
        {
            IDictionary<K, List<V>> dict = new Dictionary<K, List<V>>();

            if (src == null)
                return dict;
            
            // iterate through all values an add it to a key set
            foreach (V value in src)
            {
                K key = keySelector(value);

                if (!dict.ContainsKey(key))
                    dict[key] = new List<V>();

                dict[key].Add(value);
                
            }
            
            // the fillupKeys list is used to add empty sets for keys that have not come up yet
            if (fillupKeys != null && fillupKeys.Any())
            {
                foreach (K k in fillupKeys)
                {
                    if (!dict.ContainsKey(k))
                        dict[k] = new List<V>();
                }
            }

            return dict;
        }
    }
}