using System;
using System.Collections.Generic;

namespace LRUImproved
{
    class Program
    {
        static void Main(string[] args)
        {
            Random gen = new Random();
            var lrucache = new LRUCache<int, string>(5);

            lrucache.Put(1, "karan");
            lrucache.Put(2, "megan");
            lrucache.Put(3, "austin");
            lrucache.Put(4, "zanlin");
            lrucache.Put(5, "wailinn");

            for (int i = 0; i < 5; i++)
            {
                var num = gen.Next(1,lrucache.Count);
                Console.WriteLine($"Getting {num}: {lrucache.Get(num)}");
            }

        }
    }
}
