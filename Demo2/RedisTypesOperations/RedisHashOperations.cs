using System.Collections.Generic;
using System.Linq;
using StackExchange.Redis;

namespace Demo2.RedisTypesOperations
{
    internal class RedisHashOperations:RedisConnector
    {
        public void AddHash(string hashKey, string valueKey, string valueValue)
        {
            Database.HashSet(hashKey, valueKey, valueValue);
        }

        public void AddHash(string hashKey, Dictionary<string , string> values)
        {
            Database.HashSet(hashKey, values.Select(x=> new HashEntry(x.Key, x.Value)).ToArray());
        }
    }
}