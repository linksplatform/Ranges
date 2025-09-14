using System;
using Platform.Ranges.Experiments;

namespace Platform.Ranges.Experiments
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Platform.Ranges Performance Analysis");
            Console.WriteLine("====================================");
            Console.WriteLine();
            
            RangePerformanceBenchmark.RunBenchmark();
            
            Console.WriteLine();
            Console.WriteLine("Benchmark completed!");
        }
    }
}