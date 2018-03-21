using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StackExchange.Redis;

namespace Demo2.RedisTypesOperations
{
    internal class RedisListOperations: RedisConnector
    {

        public Task AddOneValueToList(string key, string values)
        {
            return Database.ListLeftPushAsync(key, values);
        }

        public RedisValue ReadoneValueFromTop(string key)
        {
            return Database.ListLeftPop(key);
        }

        public RedisValue ReadoneValueFromBottom(string key)
        {
            return Database.ListRightPop(key);
        }

        public void AddValuesToTop(string key, string[] inputs)
        {

            Database.ListLeftPush(key, Array.ConvertAll(inputs, input => (RedisValue)input));
        }

        public void AddValuesToBottom(string key, string[] inputs)
        {

            Database.ListRightPush(key, inputs.Select(x=> (RedisValue)x).ToArray());
        }
    }
}