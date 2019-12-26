using System;
using BenchmarkDotNet.Running;

namespace CatalogManager.Benchmark
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("__Benchmark Started__");

            BenchmarkRunner.Run<BenchmarkRESTClient>();
            Console.ReadKey();
        }
    }
}
