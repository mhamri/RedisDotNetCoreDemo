using System;

namespace Demo2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Stared");

            new RedisDemo().Run().Wait();

            Console.WriteLine("Fin!");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Press any key to exit!");
            Console.ReadKey();
        }

        
    }
}
