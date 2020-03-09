using System;

namespace LRUImproved
{
    class Program
    {
        static void Main(string[] args)
        {
            var lrucache = new LRUCache<int, string>();

            lrucache.Put(1, "karan");
            lrucache.Put(2, "megan");
            lrucache.Put(3, "austin");
            lrucache.Put(4, "zanlin");
            lrucache.Put(5, "wailinn");

            Console.WriteLine(lrucache.Get(2));

        }
    }
}
