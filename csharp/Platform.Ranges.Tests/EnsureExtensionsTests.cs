using System;
using Xunit;
using Platform.Exceptions;

namespace Platform.Ranges.Tests
{
    /// <summary>
    /// <para>
    /// Represents the ensure extensions tests.
    /// </para>
    /// <para></para>
    /// </summary>
    public static class EnsureExtensionsTests
    {
        /// <summary>
        /// <para>
        /// Tests that maximum argument is greater or equal to minimum exception test.
        /// </para>
        /// <para></para>
        /// </summary>
        [Fact]
        public static void MaximumArgumentIsGreaterOrEqualToMinimumExceptionTest() => Assert.Throws<ArgumentException>(() => Ensure.Always.MaximumArgumentIsGreaterOrEqualToMinimum(2, 1));

        /// <summary>
        /// <para>
        /// Tests that argument in range exception test.
        /// </para>
        /// <para></para>
        /// </summary>
        [Fact]
        public static void ArgumentInRangeExceptionTest() => Assert.Throws<ArgumentOutOfRangeException>(() => Ensure.Always.ArgumentInRange(5, (6, 7)));
    }
}
