using System;
using System.Collections.Generic;
using System.Text;

namespace LRUImproved
{
    // created our own kvp class because default key/value are get only
    public class KeyValuePair<TKey, TValue>
    {
        public TKey Key { get; set; }
        public TValue Value { get; set; }

        public KeyValuePair(TKey key, TValue val)
        {
            Key = key;
            Value = val;
        }

        public override string ToString()
        {
            return $"Key: {Key}, Value: {Value}";
        }
    }


    public class LRUCache<Tkey, TValue> : ICache<Tkey, TValue>
    {
        // list that will store kvp of items added to cache
        LinkedList<KeyValuePair<Tkey, TValue>> list;
        
        // dictionary that will hold nodes for constant time lookup
        Dictionary<Tkey, LinkedListNode<KeyValuePair<Tkey, TValue>>> cache;
        
        // property used to enforce lru 
        int capacity;

        // count of total items in cache
        public int Count { get; private set; }
        public LRUCache(int cap = 4)
        {
            capacity = cap;
            Count = 0;
            list = new LinkedList<KeyValuePair<Tkey, TValue>>();
            cache = new Dictionary<Tkey, LinkedListNode<KeyValuePair<Tkey, TValue>>>();
        }

        public void Put(Tkey key, TValue value)
        {
            // if cache contains key, get the node for the key, remove it from list, set new value and add it to top
            if (cache.ContainsKey(key))
            {
                var existingNode = cache[key];

                list.Remove(existingNode);

                // modify the value contained node
                existingNode.Value.Value = value;

                list.AddFirst(existingNode);
            }

            // check if cache is full
            if (Count == capacity)
            {
                // drop the tail (least recently used item), and also remove it from the cache
                var lruNode = list.Last;
                list.RemoveLast();
                cache.Remove(lruNode.Value.Key);
                Count--;
            }

            // add the new node to the front of the list
            var newNode = new KeyValuePair<Tkey, TValue>(key, value);
            list.AddFirst(newNode);
            cache[key] = list.First;
            Count++;

        }

        public TValue Get(Tkey key)
        {
            // if in the cache, get the node, remove node from its position and then move it to head, return it
            if (cache.ContainsKey(key))
            {
                // get the node containing the key value pair and return kvp's value
                var node = cache[key];

                list.Remove(node);

                list.AddFirst(node);

                return node.Value.Value;
            }

            // key not found
            return default(TValue);
        }
    }
}
