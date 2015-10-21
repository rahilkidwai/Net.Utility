using System.Collections.Generic;

namespace Rk.Net.Utility
{
    /// <summary>
    /// 
    /// </summary>
    public interface ICache
    {
        /// <summary>
        /// Gets the count of items in cache.
        /// </summary>
        int Count { get; }

        /// <summary>
        /// Flushes the cache.
        /// </summary>
        /// <returns></returns>
        int Flush();
    }

    /// <summary>
    /// 
    /// </summary>
    public interface ICache<TKey, TValue> : ICache
    {
        /// <summary>
        /// Determines whether cahce contains the element with specified key.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        bool Contains(TKey key);
        
        /// <summary>
        /// Gets the item with given key.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        TValue Get(TKey key);

        /// <summary>
        /// Adds item with given key in cache.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="item">The item.</param>
        /// <returns></returns>
        bool Add(TKey key, TValue item);

        /// <summary>
        /// Removes the item from cache with given key.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        bool Remove(TKey key);

        /// <summary>
        /// Returns the list of values in cache.
        /// </summary>
        /// <returns></returns>
        List<TValue> ToList();
    }
}