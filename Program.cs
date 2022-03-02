using System;
using StackExchange.Redis;

namespace azure_cache_for_redis
{
    public class Program
    {
        // connection string to your Redis Cache    
        static string connectionString = "balduinoman.redis.cache.windows.net:6380,password=3DEn6zuyINg4KBhxwED3Zr0C00dfQqSuZAzCaLvWBlo=,ssl=True,abortConnect=False";

        static void Main(string[] args)
        {
            // The connection to the Azure Cache for Redis is managed by the ConnectionMultiplexer class.
            using (var cache = ConnectionMultiplexer.Connect(connectionString))
            {
                IDatabase db = cache.GetDatabase();

                // Snippet below executes a PING to test the server connection
                var result = db.Execute("ping");
                Console.WriteLine($"PING = {result.Type} : {result}");

                // Call StringSetAsync on the IDatabase object to set the key "test:key" to the value "100"
                bool setValue = db.StringSet("test:key", "100");
                Console.WriteLine($"SET: {setValue}");

                // StringGetAsync takes the key to retrieve and return the value
                string getValue = db.StringGet("test:key");
                Console.WriteLine($"GET: {getValue}");
            }
        }
    }
}
