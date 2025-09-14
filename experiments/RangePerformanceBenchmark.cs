using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Platform.Ranges;

namespace Platform.Ranges.Experiments
{
    /// <summary>
    /// Benchmark to compare performance of static readonly fields vs static properties with aggressive inlining
    /// for Range constant access patterns.
    /// </summary>
    public static class RangePerformanceBenchmark
    {
        // Simulating the OLD approach (static readonly fields)
        public static class OldRangeConstants
        {
            public static readonly Range<int> Int32 = new Range<int>(int.MinValue, int.MaxValue);
            public static readonly Range<long> Int64 = new Range<long>(long.MinValue, long.MaxValue);
            public static readonly Range<double> Double = new Range<double>(double.MinValue, double.MaxValue);
        }

        // Simulating the NEW approach (static properties with aggressive inlining)
        public static class NewRangeConstants
        {
            public static Range<int> Int32
            {
                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                get => new Range<int>(int.MinValue, int.MaxValue);
            }
            
            public static Range<long> Int64
            {
                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                get => new Range<long>(long.MinValue, long.MaxValue);
            }
            
            public static Range<double> Double
            {
                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                get => new Range<double>(double.MinValue, double.MaxValue);
            }
        }

        public static void RunBenchmark()
        {
            const int iterations = 10_000_000;
            
            Console.WriteLine("Range Performance Benchmark");
            Console.WriteLine("===========================");
            Console.WriteLine($"Iterations: {iterations:N0}");
            Console.WriteLine();

            // Warmup
            Console.WriteLine("Warming up...");
            BenchmarkOldApproach(iterations / 100);
            BenchmarkNewApproach(iterations / 100);
            BenchmarkCurrentImplementation(iterations / 100);

            Console.WriteLine("\nStarting benchmarks...");
            
            // Benchmark OLD approach (static readonly fields)
            var oldTime = BenchmarkOldApproach(iterations);
            Console.WriteLine($"Old approach (static readonly fields): {oldTime:F2} ms");

            // Benchmark NEW approach (static properties with aggressive inlining)
            var newTime = BenchmarkNewApproach(iterations);
            Console.WriteLine($"New approach (static properties): {newTime:F2} ms");

            // Benchmark current implementation in Range class
            var currentTime = BenchmarkCurrentImplementation(iterations);
            Console.WriteLine($"Current implementation: {currentTime:F2} ms");

            Console.WriteLine();
            Console.WriteLine("Performance Analysis:");
            Console.WriteLine($"New vs Old: {(newTime / oldTime * 100):F1}% ({(newTime > oldTime ? "slower" : "faster")})");
            Console.WriteLine($"Current vs Old: {(currentTime / oldTime * 100):F1}% ({(currentTime > oldTime ? "slower" : "faster")})");
            
            if (Math.Abs(newTime - currentTime) < 0.01)
            {
                Console.WriteLine("✓ Current implementation performs similarly to new approach");
            }
        }

        private static double BenchmarkOldApproach(int iterations)
        {
            var stopwatch = Stopwatch.StartNew();
            
            var sum = 0L;
            for (int i = 0; i < iterations; i++)
            {
                // Access the constants multiple times to simulate real usage
                var intRange = OldRangeConstants.Int32;
                var longRange = OldRangeConstants.Int64;
                var doubleRange = OldRangeConstants.Double;
                
                // Use the ranges to prevent optimizations
                sum += intRange.Minimum + longRange.Minimum + (long)doubleRange.Minimum;
            }
            
            stopwatch.Stop();
            
            // Prevent dead code elimination
            if (sum == 0) Console.WriteLine("Unexpected result");
            
            return stopwatch.Elapsed.TotalMilliseconds;
        }

        private static double BenchmarkNewApproach(int iterations)
        {
            var stopwatch = Stopwatch.StartNew();
            
            var sum = 0L;
            for (int i = 0; i < iterations; i++)
            {
                // Access the properties multiple times to simulate real usage
                var intRange = NewRangeConstants.Int32;
                var longRange = NewRangeConstants.Int64;
                var doubleRange = NewRangeConstants.Double;
                
                // Use the ranges to prevent optimizations
                sum += intRange.Minimum + longRange.Minimum + (long)doubleRange.Minimum;
            }
            
            stopwatch.Stop();
            
            // Prevent dead code elimination
            if (sum == 0) Console.WriteLine("Unexpected result");
            
            return stopwatch.Elapsed.TotalMilliseconds;
        }

        private static double BenchmarkCurrentImplementation(int iterations)
        {
            var stopwatch = Stopwatch.StartNew();
            
            var sum = 0L;
            for (int i = 0; i < iterations; i++)
            {
                // Access the current implementation multiple times
                var intRange = Range.Int32;
                var longRange = Range.Int64;
                var doubleRange = Range.Double;
                
                // Use the ranges to prevent optimizations
                sum += intRange.Minimum + longRange.Minimum + (long)doubleRange.Minimum;
            }
            
            stopwatch.Stop();
            
            // Prevent dead code elimination
            if (sum == 0) Console.WriteLine("Unexpected result");
            
            return stopwatch.Elapsed.TotalMilliseconds;
        }
    }
}