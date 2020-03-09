using System;
using System.Collections.Generic;
using System.Text;

namespace LRUImproved
{
    public interface ICache<TKey, TValue>
    {
        TValue Get(TKey key);
        void Put(TKey key, TValue value);

    }
}
