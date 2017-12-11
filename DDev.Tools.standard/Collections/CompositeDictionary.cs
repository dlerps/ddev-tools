using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace DDev.Tools
{
    public class CompositeDictionary<K1Type, K2Type, VType> : IEnumerable<CompositeTriple<K1Type, K2Type, VType>>
    {
        private IDictionary<KeyValuePair<K1Type, K2Type>, VType> _dict;

        public CompositeDictionary()
        {
            _dict = new Dictionary<KeyValuePair<K1Type, K2Type>, VType>();
        }

        public CompositeDictionary(int initSize)
        {
            _dict = new Dictionary<KeyValuePair<K1Type, K2Type>, VType>(initSize);
        }

        #region Properties

        /// <summary>
        /// The internal collection of values.
        /// </summary>
        /// <returns></returns>
        public ICollection<VType> Values
        {
            get 
            {
                return _dict.Values;
            }
        }

        /// <summary>
        /// The internal collection of composite keys.
        /// </summary>
        /// <returns></returns>
        public ICollection<KeyValuePair<K1Type, K2Type>> Keys
        {
            get 
            {
                return _dict.Keys;
            }
        }

        /// <summary>
        /// The internal collection of primary keys.
        /// </summary>
        /// <returns></returns>
        public ICollection<K1Type> PrimaryKeys
        {
            get 
            {
                return _dict.Keys.Select(k => k.Key).ToList();
            }
        }

        /// <summary>
        /// The internal collection of primary keys.
        /// </summary>
        /// <returns></returns>
        public ICollection<K2Type> SecondaryKeys
        {
            get 
            {
                return _dict.Keys.Select(k => k.Value).ToList();
            }
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Adds a value to the dictionary.
        /// </summary>
        /// <param name="key1"></param>
        /// <param name="key2"></param>
        /// <param name="value"></param>
        public void Add(K1Type key1, K2Type key2, VType value)
        {
            KeyValuePair<K1Type, K2Type> key = GetCompositeKey(key1, key2);

            if (!_dict.ContainsKey(key))
                _dict.Add(key, value);
        }

        /// <summary>
        /// Sets a value in the dictionary.
        /// </summary>
        /// <param name="key1"></param>
        /// <param name="key2"></param>
        /// <param name="value"></param>
        public void Set(K1Type key1, K2Type key2, VType value)
        {
            KeyValuePair<K1Type, K2Type> key = GetCompositeKey(key1, key2);

            if (_dict.ContainsKey(key))
                _dict[key] = value;
        }

        /// <summary>
        /// Gets a value from the dictionary.
        /// </summary>
        /// <param name="key1"></param>
        /// <param name="key2"></param>
        /// <returns></returns>
        public VType Get(K1Type key1, K2Type key2)
        {
            KeyValuePair<K1Type, K2Type> key = GetCompositeKey(key1, key2);
            return _dict.ContainsKey(key) ? _dict[key] : default(VType);
        }

        /// <summary>
        /// Checks if a xomposite key is in the dictionary
        /// </summary>
        /// <param name="key1"></param>
        /// <param name="key2"></param>
        /// <returns></returns>
        public bool ContainsKeys(K1Type key1, K2Type key2)
        {
            KeyValuePair<K1Type, K2Type> key = GetCompositeKey(key1, key2);
            return _dict.ContainsKey(key);            
        }

        /// <summary>
        /// Removes a value from the dictionary.
        /// </summary>
        /// <param name="key1"></param>
        /// <param name="key2"></param>
        /// <returns></returns>
        public bool Remove(K1Type key1, K2Type key2)
        {
            KeyValuePair<K1Type, K2Type> key = GetCompositeKey(key1, key2);
            return _dict.Remove(key);            
        }

        /// <summary>
        /// The number of items in the dictionary.
        /// </summary>
        /// <returns></returns>
        public int Count()
        {
            return _dict.Count;
        }

        #endregion

        #region IEnumerable

        /// <inheritdoc />
        public IEnumerator<CompositeTriple<K1Type, K2Type, VType>> GetEnumerator()
        {
            return _dict.Select(i => GetTriple(i)).GetEnumerator();
        }

        /// <inheritdoc />
        IEnumerator IEnumerable.GetEnumerator()
        {
            return _dict.Select(i => GetTriple(i)).GetEnumerator();
        }

        #endregion

        private CompositeTriple<K1Type, K2Type, VType> GetTriple(KeyValuePair<KeyValuePair<K1Type, K2Type>, VType> pair)
        {
            return new CompositeTriple<K1Type, K2Type, VType>()
            {
                Value = pair.Value,
                Key1 = pair.Key.Key,
                Key2 = pair.Key.Value
            };
        }

        private KeyValuePair<K1Type, K2Type> GetCompositeKey(K1Type key1, K2Type key2)
        {
            return new KeyValuePair<K1Type, K2Type>(key1, key2);
        }
    }

    public class CompositeTriple<K1Type, K2Type, VType>
    {
        public VType Value { get; set; }
        public K1Type Key1 { get; set; }
        public K2Type Key2 { get; set; }
    }
}