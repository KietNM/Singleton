namespace Singleton
{
    using System;
    /// <summary>
    /// MainApp startup class for real world.
    /// Singleton Design Pattern
    /// </summary>
    class Program
    {
        /// <summary>
        /// Entry point into console application
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            LoadBalancer b1 = LoadBalancer.GetLoadBalancer();
            LoadBalancer b2 = LoadBalancer.GetLoadBalancer();
            LoadBalancer b3 = LoadBalancer.GetLoadBalancer();
            LoadBalancer b4 = LoadBalancer.GetLoadBalancer();

            // Same instance?
            if(b1 == b2 && b2==b3 && b3==b4)
            {
                Console.WriteLine("Same instance \n");
            }

            // Load balance 15 server requests
            LoadBalancer balancer = LoadBalancer.GetLoadBalancer();
            {
                for(int  i=0;i<15;i++)
                {
                    string serverName = balancer.NextServer.Name;
                    Console.WriteLine("Dispatch request to: " + serverName);
                }
            }

            // Wait for user
            Console.ReadKey();
        }
    }
}
