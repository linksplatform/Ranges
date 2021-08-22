using System;
using Xunit;

namespace Platform.Ranges.Tests
{
    /// <summary>
    /// <para>
    /// Represents the range tests.
    /// </para>
    /// <para></para>
    /// </summary>
    public static class RangeTests
    {
        /// <summary>
        /// <para>
        /// Tests that constructors test.
        /// </para>
        /// <para></para>
        /// </summary>
        [Fact]
        public static void ConstructorsTest()
        {
            var range1 = new Range<int>(1, 3);
            Assert.Equal(1, range1.Minimum);
            Assert.Equal(3, range1.Maximum);
            Assert.Throws<ArgumentException>(() => new Range<int>(2, 1));
            var range2 = new Range<int>(5);
            Assert.Equal(5, range2.Minimum);
            Assert.Equal(5, range2.Maximum);
        }

        /// <summary>
        /// <para>
        /// Tests that contains test.
        /// </para>
        /// <para></para>
        /// </summary>
        [Fact]
        public static void ContainsTest()
        {
            var range = new Range<int>(1, 3);
            Assert.True(range.Contains(1));
            Assert.True(range.Contains(2));
            Assert.True(range.Contains(3));
            Assert.True(range.Contains((2, 3)));
            Assert.False(range.Contains((3, 4)));
        }

        /// <summary>
        /// <para>
        /// Tests that difference test.
        /// </para>
        /// <para></para>
        /// </summary>
        [Fact]
        public static void DifferenceTest()
        {
            var range = new Range<int>(1, 3);
            Assert.Equal(2, range.Difference());
        }

        /// <summary>
        /// <para>
        /// Tests that to string test.
        /// </para>
        /// <para></para>
        /// </summary>
        [Fact]
        public static void ToStringTest()
        {
            var range = new Range<int>(1, 3);
            Assert.Equal("[1..3]", range.ToString());
        }

        /// <summary>
        /// <para>
        /// Tests that equality test.
        /// </para>
        /// <para></para>
        /// </summary>
        [Fact]
        public static void EqualityTest()
        {
            var range1 = new Range<int>(1, 3);
            var range1Duplicate = new Range<int>(1, 3);
            var range2 = new Range<int>(2, 5);
            Assert.True(range1 == range1Duplicate);
            Assert.Equal(range1, range1Duplicate);
            Assert.True(range1 != range2);
            Assert.NotEqual(range1, range2);
        }
    }
}
