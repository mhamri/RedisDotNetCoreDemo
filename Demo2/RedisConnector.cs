using System.Linq;
using StackExchange.Redis;

namespace Demo2
{
    public abstract class RedisConnector
    {
        private static ConnectionMultiplexer _multiplexer = null;
        private static readonly object Padlock = new object();
        
        protected IDatabase Database => Multiplexer.GetDatabase();

        public static ConnectionMultiplexer Multiplexer
        {
            get
            {
                lock (Padlock)
                {
                    return _multiplexer ?? (_multiplexer = ConnectionMultiplexer.Connect("localhost:6379"));
                }
            }
        }

        public void CleanUp()
        {
            foreach (var endPoint in Multiplexer.GetEndPoints())
            {
                var x = Multiplexer.GetServer(endPoint);
                x.FlushDatabase(Database.Database);
            }
        }


    }
}
