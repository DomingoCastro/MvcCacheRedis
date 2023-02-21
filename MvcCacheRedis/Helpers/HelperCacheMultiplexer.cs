using StackExchange.Redis;

namespace MvcCacheRedis.Helpers
{
    public static class HelperCacheMultiplexer
    {
        private static Lazy<ConnectionMultiplexer> CreateConnection =
            new Lazy<ConnectionMultiplexer>(() =>
            {
                string cnn = "bbddproductoscachedcc.redis.cache.windows.net:6380,password=lAsIG6NktcEkW80MCADCbg2bOlqTfSlNvAzCaM1pmFs=,ssl=True,abortConnect=False";
                return ConnectionMultiplexer.Connect(cnn);
            });

        public static ConnectionMultiplexer GetConnection
        {
            get
            {
                return CreateConnection.Value;
            }
        }
    }
}
