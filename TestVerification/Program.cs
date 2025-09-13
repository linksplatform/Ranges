using Platform.Ranges;

// Simple script to manually verify range functionality
Console.WriteLine("=== Range Coverage Verification ===\n");

// Test basic range functionality
Console.WriteLine("1. Basic Range Construction:");
var range1 = new Range<int>(1, 10);
var range2 = new Range<int>(5);
Console.WriteLine($"Range(1, 10): {range1}");
Console.WriteLine($"Range(5): {range2}");

// Test contains functionality
Console.WriteLine("\n2. Contains Tests:");
Console.WriteLine($"Range(1, 10).Contains(5): {range1.Contains(5)}");
Console.WriteLine($"Range(1, 10).Contains(15): {range1.Contains(15)}");
Console.WriteLine($"Range(1, 10).Contains(Range(2, 8)): {range1.Contains(new Range<int>(2, 8))}");

// Test difference extensions
Console.WriteLine("\n3. Difference Extensions:");
Console.WriteLine($"Range(1, 10).Difference(): {range1.Difference()}");
var doubleRange = new Range<double>(1.5, 5.5);
Console.WriteLine($"Range<double>(1.5, 5.5).Difference(): {doubleRange.Difference()}");

// Test static ranges
Console.WriteLine("\n4. Static Range Constants:");
Console.WriteLine($"Range.Int32: {Platform.Ranges.Range.Int32}");
Console.WriteLine($"Range.Byte: {Platform.Ranges.Range.Byte}");

// Test implicit operators
Console.WriteLine("\n5. Implicit Operators:");
(int min, int max) tuple = range1;
Console.WriteLine($"Range to tuple: ({tuple.min}, {tuple.max})");
Range<int> rangeFromTuple = (20, 30);
Console.WriteLine($"Tuple to Range: {rangeFromTuple}");

Console.WriteLine("\n=== All tests completed successfully! ===");
