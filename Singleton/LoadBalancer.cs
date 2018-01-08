namespace Singleton
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// The 'Singleton class'
    /// </summary>
    sealed class LoadBalancer
    {
        // Static members are eagerly initialized that is
        // immediately when class is load for the first time.
        // .Net guarantees thread safety for static initialization
        private static readonly LoadBalancer instance = new LoadBalancer();

        /// <summary>
        /// Type safe generic list of servers
        /// </summary>
        private List<Server> servers;
        private Random random = new Random();


        // Constructor is private
        private LoadBalancer()
        {
            // Load list of available servers
            servers = new List<Server>
            {
                new Server{ Name = "ServerI", IP = "120.14.220.18" },
                new Server{ Name = "ServerII", IP = "120.14.220.19" },
                new Server{ Name = "ServerIII", IP = "120.14.220.20" },
                new Server{ Name = "ServerIV", IP = "120.14.220.21" },
                new Server{ Name = "ServerV", IP = "120.14.220.22" },
            };
        }

        public static LoadBalancer GetLoadBalancer()
        {
            return instance;
        }

        // Simple, but effective random load balancer
        public Server NextServer
        {
            get
            {
                int r = random.Next(servers.Count);
                return servers[r];
            }
        }
    }
}
