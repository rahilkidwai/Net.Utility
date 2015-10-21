using System;
using System.Collections.Generic;

namespace Rk.Net.Utility
{
    /// <summary>
    /// 
    /// </summary>
    public sealed class CacheManager
    {
        #region Fields
        private Dictionary<string, ICache> _manager; 
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="CacheManager"/> class.
        /// </summary>
        public CacheManager()
        {
            _manager = new Dictionary<string, ICache>();
        } 
        #endregion

        #region Methods
        /// <summary>
        /// Registers the cache with specified identifier.
        /// </summary>
        /// <param name="cacheID">The cache identifier.</param>
        /// <param name="cache">The cache.</param>
        public void Register<TKey, TValue>(string cacheID, ICache<TKey, TValue> cache)
        {
            if (cache == null) throw new ArgumentNullException("cache");
            cacheID = ValidateCacheID(cacheID);
            if (_manager.ContainsKey(cacheID)) throw new Exception("Cache with given ID already registered.");
            _manager.Add(cacheID, cache);
        }

        /// <summary>
        /// Gets the cache.
        /// </summary>
        /// <typeparam name="TKey">The type of the key.</typeparam>
        /// <typeparam name="TValue">The type of the value.</typeparam>
        /// <param name="cacheID">The cache identifier.</param>
        /// <returns></returns>
        public ICache<TKey, TValue> GetCache<TKey, TValue>(string cacheID)
        {
            ICache cache = null;
            cacheID = ValidateCacheID(cacheID);
            bool exists = _manager.TryGetValue(cacheID, out cache);
            return cache as ICache<TKey, TValue>;
        }

        /// <summary>
        /// Gets the cache.
        /// </summary>
        /// <param name="cacheID">The cache identifier.</param>
        /// <returns></returns>
        public ICache GetCache(string cacheID)
        {
            ICache cache = null;
            cacheID = ValidateCacheID(cacheID);
            _manager.TryGetValue(cacheID, out cache);
            return cache; //null if not found
        }

        /// <summary>
        /// Flushes the cache with given identifier and registration key.
        /// </summary>
        /// <param name="cacheID">The cache identifier.</param>
        /// <param name="registrationKey">The registration key.</param>
        /// <returns></returns>
        public int Flush<TKey, TValue>(string cacheID)
        {
            cacheID = ValidateCacheID(cacheID);
            ICache<TKey, TValue> cache = GetCache<TKey, TValue>(cacheID);
            return cache.Flush();
        }

        /// <summary>
        /// Flushes all the caches.
        /// </summary>
        /// <returns></returns>
        public int FlushAll()
        {
            int count = 0;
            ICache cache = null;
            foreach (string key in _manager.Keys)
            {
                cache = GetCache(key);
                if (cache != null)
                    count += cache.Flush();
            }
            return count;
        }

        private string ValidateCacheID(string cacheID)
        {
            if (string.IsNullOrWhiteSpace(cacheID)) throw new ArgumentException("Null or invalid value passed for cacheID");
            return cacheID.Trim().ToUpper();
        } 
        #endregion
    }
}