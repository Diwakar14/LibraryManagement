using Newtonsoft.Json;
using StackExchange.Redis;

namespace LibraryManagement.Redis
{
    public class RedisService : IRedisService
    {
        private readonly IConnectionMultiplexer connectionMultiplexer;
        private IDatabase _db;

        public RedisService(IConnectionMultiplexer connectionMultiplexer)
        {
            this.connectionMultiplexer = connectionMultiplexer;
            _db = this.connectionMultiplexer.GetDatabase();
        }

        public async Task<T> GetKeyAsync<T>(string key)
        {
            RedisValue redisValue = await _db.StringGetAsync(key);
            var obj = JsonConvert.DeserializeObject<T>(redisValue.ToString());
            return obj;
        }

        public async Task SetKeyAsync<T>(string key, T value, TimeSpan timeout)
        {
            var json = JsonConvert.SerializeObject(value);
            await _db.StringSetAsync(key, json, timeout);
        }
    }
}
