using StackExchange.Redis;

namespace Demo2.RedisTypesOperations
{
    internal class RedisSetOperations:RedisConnector
    {
        public void AddSet(string key, string value)
        {
            Database.SetAdd(key, value);
        }

        public RedisValue[] ReadSet(string key)
        {
            return Database.SetMembers(key);
        }

        public bool RemoveAValueFromKey(string key, string value)
        {
            return Database.SetRemove(key, value);
        }

        public bool IsMemebr(string key, string value)
        {
            return Database.SetContains(key, value);
        }
    }
}