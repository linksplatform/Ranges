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
        public static void ArgumentInRangeExceptionTest() => Assert.Throws<ArgumentOutOfRangeException>(() => Ensure.Always.ArgumentInRange(5, (6, 7)));
    }
}
