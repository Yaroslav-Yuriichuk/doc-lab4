using Newtonsoft.Json;
using StackExchange.Redis;

namespace Lab4.Output;

internal sealed class RedisOutputStrategy : IOutputStrategy
{
    private readonly IConnectionMultiplexer _connectionMultiplexer;
    private readonly long _cacheExpirySeconds;

    public RedisOutputStrategy(string connectionString, long cacheExpirySeconds)
    {
        _connectionMultiplexer = ConnectionMultiplexer.Connect(connectionString);
        _cacheExpirySeconds = cacheExpirySeconds;
    }

    public async Task OutputData<T>(T[]? models)
    {
        if (models is null)
        {
            return;
        }

        string json = JsonConvert.SerializeObject(models);
        string key = $"Lab4Output_{DateTime.Now.ToFileTime()}";

        IDatabase db = _connectionMultiplexer.GetDatabase();
        await db.StringSetAsync(key, json, TimeSpan.FromSeconds(_cacheExpirySeconds));
    }
}