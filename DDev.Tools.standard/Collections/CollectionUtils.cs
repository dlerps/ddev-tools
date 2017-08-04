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
        public static PType ParseValue<PType>(this IDictionary<string, object> vals, string key, PType defaultVal = default(PType))
        {
            if (vals.ContainsKey(key) && vals[key] is PType)
                return (PType)vals[key];

            return defaultVal;
        }

    }
}
