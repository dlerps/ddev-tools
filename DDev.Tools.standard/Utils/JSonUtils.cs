using System;
using System.Collections.Generic;

namespace DDev.Tools.Utils
{   
    /// <summary>
    /// Static class with some utilities for Json handling.
    /// </summary>
    public static class JsonUtils
    {
        /// <summary>
        /// Parses a generic value from a Dictionary. If the value does not exist, the 
        /// defualt value of the type is returned.
        /// </summary>
        /// <param name="vals"></param>
        /// <param name="key"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        [Obsolete("Use the CollectionUtils instead")]
        public static PType ParseValue<PType>(IDictionary<string, object> vals, string key, PType defaultVal = default(PType))
        {
            if(vals.ContainsKey(key) && vals[key] is PType)
                return (PType) vals[key];

            return defaultVal;
        }

        /// <summary>
        /// Prints the contents of a JSon Dictionary on the StdOut console.
        /// </summary>
        /// <param name="IDictionary<string"></param>
        /// <param name="vals"></param>
        [Obsolete("Use the CollectionUtils instead")]
        public static void PrintDictionary(IDictionary<string, object> vals)
        {
            foreach(var pair in vals)
            {
                Console.WriteLine(String.Format("{0} -> {1}", pair.Key, pair.Value));
            }
        }
    }
}