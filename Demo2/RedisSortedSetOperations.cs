using System.Collections.Generic;
using System.Linq;
using StackExchange.Redis;

namespace Demo2
{
    internal class RedisSortedSetOperations: RedisConnector
    {
        public void Add(string key, string value, double score)
        {
            Database.SortedSetAdd(key, value, score);
        }

        public void Add(string key, string[] values)
        {
            var sortedSetValues = new List<SortedSetEntry>();
            for (var i = 0; i < values.Length; i++)
            {
                sortedSetValues.Add(new SortedSetEntry(values[i], (i+1) *100));
            }

            Database.SortedSetAdd(key, sortedSetValues.ToArray());
        }
    }
}