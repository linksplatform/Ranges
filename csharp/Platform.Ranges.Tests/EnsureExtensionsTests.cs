using System;
using Xunit;
using Platform.Exceptions;
using Platform.Ranges.Resources;

namespace Platform.Ranges.Tests
{
    public static class EnsureExtensionsTests
    {
        [Fact]
        public static void MaximumArgumentIsGreaterOrEqualToMinimumExceptionTest() => Assert.Throws<ArgumentException>(() => Ensure.Always.MaximumArgumentIsGreaterOrEqualToMinimum(2, 1));

        [Fact]
        public static void ArgumentInRangeExceptionTest() => Assert.Throws<ArgumentOutOfRangeException>(() => Ensure.Always.ArgumentInRange(5, (6, 7)));

        [Fact]
        public static void MaximumArgumentIsGreaterOrEqualToMinimumMessageTest()
        {
            var exception = Assert.Throws<ArgumentException>(() => Ensure.Always.MaximumArgumentIsGreaterOrEqualToMinimum(5, 3));
            Assert.Contains(ExceptionMessages.MaximumShouldBeGreaterOrEqualToMinimum, exception.Message);
        }

        [Fact]
        public static void ArgumentInRangeMessageTest()
        {
            var exception = Assert.Throws<ArgumentOutOfRangeException>(() => Ensure.Always.ArgumentInRange(10, (1, 5), "testArgument"));
            var expectedMessage = string.Format(ExceptionMessages.ArgumentOutOfRange, 10, new Range<int>(1, 5));
            Assert.Contains(expectedMessage, exception.Message);
        }

        [Fact]
        public static void ExceptionMessagesResourcesTest()
        {
            Assert.Equal("Maximum should be greater or equal to minimum.", ExceptionMessages.MaximumShouldBeGreaterOrEqualToMinimum);
            Assert.Equal("Argument value [{0}] is out of range {1}.", ExceptionMessages.ArgumentOutOfRange);
        }
    }
}
