using System.Threading.Tasks;

namespace Demo2.RedisTypesOperations
{
    class RedisStringOperations : RedisConnector
    {
        public Task<bool> AddString(string key, string value)
        {
            return Database.StringSetAsync(key, value);
        }

        public async Task<string> GetKey(string key)
        {
            var value= await Database.StringGetAsync(key);
            
            return value.ToString();
        }

        public Task<bool> DeleteKey(string key)
        {
            return Database.KeyDeleteAsync(key);
        }
    }
}
