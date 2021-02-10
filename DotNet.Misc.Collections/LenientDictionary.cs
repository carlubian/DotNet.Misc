namespace System.Collections.Generic
{
    public class LenientDictionary<TKey, TValue> : IDictionary<TKey, TValue>,
        ICollection<KeyValuePair<TKey, TValue>>,
        IEnumerable<KeyValuePair<TKey, TValue>>
    {
        private readonly IDictionary<TKey, TValue> source;

        public LenientDictionary()
        {
            source = new Dictionary<TKey, TValue>();
        }

        public TValue this[TKey key]
        {
            get
            {
                if (source.TryGetValue(key, out var value))
                    return value;

                return default;
            }
            set => source[key] = value;
        }

        public ICollection<TKey> Keys => source.Keys;

        public ICollection<TValue> Values => source.Values;

        public int Count => source.Count;

        public bool IsReadOnly => source.IsReadOnly;

        public void Add(TKey key, TValue value)
        {
            if (source.ContainsKey(key))
                source[key] = value;
            else
                source.Add(key, value);
        }

        public void Add(KeyValuePair<TKey, TValue> item)
        {
            if (source.ContainsKey(item.Key))
                source[item.Key] = item.Value;
            else
                source.Add(item);
        }

        public void Clear() => source.Clear();

        public bool Contains(KeyValuePair<TKey, TValue> item) => source.Contains(item);

        public bool ContainsKey(TKey key) => source.ContainsKey(key);

        public void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex) => source.CopyTo(array, arrayIndex);

        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator() => source.GetEnumerator();

        public bool Remove(TKey key) => source.Remove(key);

        public bool Remove(KeyValuePair<TKey, TValue> item) => source.Remove(item);

        public bool TryGetValue(TKey key, out TValue value) => source.TryGetValue(key, out value);

        IEnumerator IEnumerable.GetEnumerator() => source.GetEnumerator();
    }
}
