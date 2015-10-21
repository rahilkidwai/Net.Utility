using System;
using System.Collections.Generic;
using System.Linq;

namespace Rk.Net.Utility
{
    /// <summary>
    /// 
    /// </summary>
    public sealed class Cache<TKey, TValue> : ICache<TKey, TValue>
    {
        #region Fields
        private Dictionary<TKey, TValue> _cache = null; 
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="Cache{TKey, TValue}"/> class.
        /// </summary>
        public Cache()
        {
            _cache = new Dictionary<TKey, TValue>();
        } 
        #endregion

        #region Properties
        /// <summary>
        /// Gets the count of items in cache.
        /// </summary>
        public int Count { get { return _cache.Count; } } 
        #endregion

        #region Methods
        /// <summary>
        /// Determines whether cahce contains the element with specified key.
        /// </summary>
        /// <typeparam name="TKey">The type of the key.</typeparam>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        public bool Contains(TKey key)
        {
            return _cache.ContainsKey(key);
        }

        /// <summary>
        /// Flushes the cache.
        /// </summary>
        /// <returns></returns>
        public int Flush()
        {
            int count = _cache.Count;
            _cache.Clear();
            return count;
        }

        /// <summary>
        /// Gets the item with given key.
        /// </summary>
        /// <typeparam name="TKey">The type of the key.</typeparam>
        /// <typeparam name="TValue">The type of the value.</typeparam>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        public TValue Get(TKey key)
        {
            if (key == null) throw new ArgumentNullException("key");
            if (!_cache.ContainsKey(key)) throw new KeyNotFoundException();
            return _cache[key];
        }

        /// <summary>
        /// Adds item with given key in cache.
        /// </summary>
        /// <typeparam name="TKey">The type of the key.</typeparam>
        /// <typeparam name="TValue">The type of the value.</typeparam>
        /// <param name="key">The key.</param>
        /// <param name="item">The item.</param>
        /// <returns></returns>
        public bool Add(TKey key, TValue item)
        {
            if (key == null) throw new ArgumentNullException("key");
            if (_cache.ContainsKey(key)) throw new Exception("Cache already contains item with given key");
            _cache.Add(key, item);
            return true;
        }

        /// <summary>
        /// Removes the item from cache with given key.
        /// </summary>
        /// <typeparam name="TKey">The type of the key.</typeparam>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        public bool Remove(TKey key)
        {
            if (key == null) throw new ArgumentNullException("key");
            return _cache.Remove(key);
        }

        /// <summary>
        /// Returns the list of values in cache.
        /// </summary>
        /// <returns></returns>
        public List<TValue> ToList()
        {
            return _cache.Values.ToList();
        } 
        #endregion
    }
}