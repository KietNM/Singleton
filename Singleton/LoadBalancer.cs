namespace Singleton
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// The 'Singleton class'
    /// </summary>
    class LoadBalancer
    {
        private static LoadBalancer instance;
        private List<string> servers = new List<string>();
        private Random random = new Random();

        // Lock synchronization object
        private static object syncLock = new object();

        // Constructor 
        protected LoadBalancer ()
        {
            // List of available servers
            servers.Add("ServerI");
            servers.Add("ServerII");
            servers.Add("ServerIII");
            servers.Add("ServerIV");
            servers.Add("ServerV");
        }

        public static LoadBalancer GetLoadBalancer()
        {
            // Support multithreaded application through
            // Double checked locking  pattern which once the instance exists
            // Avoids locking each time method is invoked.
            if(instance == null)
            {
                lock(syncLock)
                {
                    if (instance == null)
                        instance = new LoadBalancer();
                }
            }
            return instance;
        }

        // Simple, but effective random load balancer
        public string Server
        {
            get
            {
                int r = random.Next(servers.Count);
                return servers[r].ToString();
            }
        }
    }
}
