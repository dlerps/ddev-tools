using System.Collections;
using System.Collections.Generic;

namespace DDev.Tools.standard.Collections
{
    public class CompositeDictionary<K1Type, K2Type, VType> : IEnumerable<CompositeTriple<K1Type, K2Type, VType>>
    {
        private readonly char _devider;
        private IDictionary<string, VType> _dict;

        public CompositeDictionary()
        {
            _dict = new Dictionary<string, VType>();
            _devider = '|';
        }

        public CompositeDictionary(int initSize)
        {
            _dict = new Dictionary<string, VType>(initSize);
            _devider = '|';            
        }

        public CompositeDictionary(char devider)
        {
            _dict = new Dictionary<string, VType>();
            _devider = devider;
        }

        public CompositeDictionary(int initSize, char devider)
        {
            _dict = new Dictionary<string, VType>(initSize);
            _devider = devider;
        }

        public void Add(K1Type key1, K2Type key2, VType value)
        {
            string key = GetCompositeKey(key1, key2);

            if (!_dict.ContainsKey(key))
                _dict.Add(key, value);
        }

        public void Set(K1Type key1, K2Type key2, VType value)
        {
            string key = GetCompositeKey(key1, key2);

            if (_dict.ContainsKey(key))
                _dict[key] = value;
        }

        public VType GetType(K1Type key1, K2Type key2)
        {
            string key = GetCompositeKey(key1, key2);
            return _dict.ContainsKey(key) ? _dict[key] : default(VType);
        }

        public bool Contains(K1Type key1, K2Type key2)
        {
            string key = GetCompositeKey(key1, key2);
            return _dict.ContainsKey(key);            
        }

        protected virtual string GetCompositeKey(K1Type key1, K2Type key2)
        {
            return $"{key1.ToString()}{_devider}{key2.ToString()}";
        }

        protected virtual GetTriple(KeyValuePair<string, VType> pair)
        {
            
        }

        public IEnumerator<CompositeTriple<K1Type, K2Type, VType>> GetEnumerator()
        {
            throw new System.NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new System.NotImplementedException();
        }
    }

    public class CompositeTriple<K1Type, K2Type, VType>
    {
        public VType Value { get; set; }
        public K1Type Key1 { get; set; }
        public K2Type Key2 { get; set; }
    }
}