using System;
using System.Collections.Generic;
using System.Text;

namespace DDev.Tools
{
    public static class CollectionUtils
    {
        /// <summary>
        /// Parses a generic value from a Dictionary. If the value does not exist, the 
        /// defualt value of the type is returned.
        /// </summary>
        /// <param name="vals"></param>
        /// <param name="key"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        public static PType ParseValue<K, PType>(this IDictionary<K, object> vals, K key, PType defaultVal = default(PType))
        {
            if (vals.ContainsKey(key) && vals[key] is PType)
                return (PType) vals[key];

            return defaultVal;
        }

        /// <summary>
        /// Parses a generic value from a Dictionary. If the value does not exist, the 
        /// defualt value of the type is returned.
        /// </summary>
        /// <param name="vals"></param>
        /// <param name="key"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        public static PType ParseValue<PType>(this IDictionary<string, object> vals, string key, PType defaultVal = default(PType))
        {
            return ParseValue<string, PType>(vals, key, defaultVal);
        }

        // <summary>
        /// Prints the contents of a JSon Dictionary on the StdOut console.
        /// </summary>
        /// <param name="IDictionary<string"></param>
        /// <param name="vals"></param>
        public static void PrintDictionary<K>(this IDictionary<K, object> vals)
        {
            foreach (KeyValuePair<K, object> pair in vals)
            {
                Console.WriteLine(String.Format("{0} -> {1}", pair.Key, pair.Value));
            }
        }

    }
}