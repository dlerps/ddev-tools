using System;
using System.Collections.Generic;
using System.Text;

namespace DDev.Tools
{
    public class GenericDictionary<KEY> 
        :Dictionary<KEY, object>, IDictionary<KEY, object>
    {
        #region Constructors

        /// <summary>
        /// Default cunstructor
        /// </summary>
        public GenericDictionary() :base() { }

        /// <summary>
        /// Constructor with inital internal dictionary size.
        /// </summary>
        /// <param name="initSize"></param>
        public GenericDictionary(int initSize) :base(initSize) { }

        #endregion

        #region Public Methods

        /// <summary>
        /// Gets a value of a generic type from the dictionary. 
        /// </summary>
        /// <typeparam name="VAL"></typeparam>
        /// <param name="key"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        public VAL Get<VAL>(KEY key, VAL defaultVal = default(VAL))
        {
            if (ContainsKey(key) && this[key] is VAL)
                return (VAL) this[key];

            return defaultVal;
        }
        
        #endregion
        
    }
}
