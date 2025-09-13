using System;
using Xunit;
using Platform.Exceptions;

namespace Platform.Ranges.Tests
{
    public static class EnsureExtensionsTests
    {
        [Fact]
        public static void MaximumArgumentIsGreaterOrEqualToMinimumExceptionTest() => Assert.Throws<ArgumentException>(() => Ensure.Always.MaximumArgumentIsGreaterOrEqualToMinimum(2, 1));

        [Fact]
        public static void MaximumArgumentIsGreaterOrEqualToMinimumValidTest()
        {
            Ensure.Always.MaximumArgumentIsGreaterOrEqualToMinimum(1, 2);
            Ensure.Always.MaximumArgumentIsGreaterOrEqualToMinimum(5, 5);
            Ensure.Always.MaximumArgumentIsGreaterOrEqualToMinimum(1, 2, "testParam");
            Ensure.Always.MaximumArgumentIsGreaterOrEqualToMinimum(1, 2, "testParam", "Test message");
        }

        [Fact]
        public static void MaximumArgumentIsGreaterOrEqualToMinimumWithCustomMessageTest()
        {
            var exception = Assert.Throws<ArgumentException>(() => 
                Ensure.Always.MaximumArgumentIsGreaterOrEqualToMinimum(5, 3, "maxParam", "Custom error message"));
            Assert.Contains("Custom error message", exception.Message);
            Assert.Equal("maxParam", exception.ParamName);
        }

        [Fact]
        public static void MaximumArgumentIsGreaterOrEqualToMinimumWithMessageBuilderTest()
        {
            var exception = Assert.Throws<ArgumentException>(() => 
                Ensure.Always.MaximumArgumentIsGreaterOrEqualToMinimum(5, 3, "maxParam", () => "Lambda message"));
            Assert.Contains("Lambda message", exception.Message);
        }

        [Fact]
        public static void ArgumentInRangeExceptionTest() => Assert.Throws<ArgumentOutOfRangeException>(() => Ensure.Always.ArgumentInRange(5, (6, 7)));

        [Fact]
        public static void ArgumentInRangeValidTest()
        {
            Ensure.Always.ArgumentInRange(5, new Range<int>(1, 10));
            Ensure.Always.ArgumentInRange(5, new Range<int>(5, 5));
            Ensure.Always.ArgumentInRange(1, new Range<int>(1, 10));
            Ensure.Always.ArgumentInRange(10, new Range<int>(1, 10));
        }

        [Fact]
        public static void ArgumentInRangeWithArgumentNameTest()
        {
            var exception = Assert.Throws<ArgumentOutOfRangeException>(() => 
                Ensure.Always.ArgumentInRange(15, new Range<int>(1, 10), "testParam"));
            Assert.Equal("testParam", exception.ParamName);
            Assert.Equal(15, exception.ActualValue);
        }

        [Fact]
        public static void ArgumentInRangeWithCustomMessageTest()
        {
            var exception = Assert.Throws<ArgumentOutOfRangeException>(() => 
                Ensure.Always.ArgumentInRange(15, new Range<int>(1, 10), "testParam", "Custom range message"));
            Assert.Contains("Custom range message", exception.Message);
        }

        [Fact]
        public static void ArgumentInRangeWithMessageBuilderTest()
        {
            var exception = Assert.Throws<ArgumentOutOfRangeException>(() => 
                Ensure.Always.ArgumentInRange(15, new Range<int>(1, 10), "testParam", () => "Lambda range message"));
            Assert.Contains("Lambda range message", exception.Message);
        }

        [Fact]
        public static void ArgumentInRangeWithMinMaxTest()
        {
            Ensure.Always.ArgumentInRange(5, 1, 10);
            Ensure.Always.ArgumentInRange(5, 1, 10, "testParam");
            
            var exception = Assert.Throws<ArgumentOutOfRangeException>(() => 
                Ensure.Always.ArgumentInRange(15, 1, 10, "testParam"));
            Assert.Equal("testParam", exception.ParamName);
        }

        [Fact]
        public static void ArgumentInRangeDifferentTypesTest()
        {
            Ensure.Always.ArgumentInRange(5.5, new Range<double>(1.0, 10.0));
            Ensure.Always.ArgumentInRange(5.5f, new Range<float>(1.0f, 10.0f));
            Ensure.Always.ArgumentInRange(5m, new Range<decimal>(1m, 10m));
            Ensure.Always.ArgumentInRange((byte)5, new Range<byte>(1, 10));
            Ensure.Always.ArgumentInRange((long)5, new Range<long>(1L, 10L));
            
            Assert.Throws<ArgumentOutOfRangeException>(() => Ensure.Always.ArgumentInRange(15.5, new Range<double>(1.0, 10.0)));
            Assert.Throws<ArgumentOutOfRangeException>(() => Ensure.Always.ArgumentInRange(15.5f, new Range<float>(1.0f, 10.0f)));
            Assert.Throws<ArgumentOutOfRangeException>(() => Ensure.Always.ArgumentInRange(15m, new Range<decimal>(1m, 10m)));
            Assert.Throws<ArgumentOutOfRangeException>(() => Ensure.Always.ArgumentInRange((byte)15, new Range<byte>(1, 10)));
            Assert.Throws<ArgumentOutOfRangeException>(() => Ensure.Always.ArgumentInRange(15L, new Range<long>(1L, 10L)));
        }

        [Fact]
        public static void OnDebugMethodsTest()
        {
            Ensure.OnDebug.MaximumArgumentIsGreaterOrEqualToMinimum(1, 2);
            Ensure.OnDebug.MaximumArgumentIsGreaterOrEqualToMinimum(1, 2, "testParam");
            Ensure.OnDebug.MaximumArgumentIsGreaterOrEqualToMinimum(1, 2, "testParam", "Test message");
            Ensure.OnDebug.MaximumArgumentIsGreaterOrEqualToMinimum(1, 2, "testParam", () => "Lambda message");

            Ensure.OnDebug.ArgumentInRange(5, new Range<int>(1, 10));
            Ensure.OnDebug.ArgumentInRange(5, new Range<int>(1, 10), "testParam");
            Ensure.OnDebug.ArgumentInRange(5, new Range<int>(1, 10), "testParam", "Test message");
            Ensure.OnDebug.ArgumentInRange(5, new Range<int>(1, 10), "testParam", () => "Lambda message");
            Ensure.OnDebug.ArgumentInRange(5, 1, 10);
            Ensure.OnDebug.ArgumentInRange(5, 1, 10, "testParam");
        }
    }
}
