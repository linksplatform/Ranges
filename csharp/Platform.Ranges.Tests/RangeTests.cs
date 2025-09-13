using System;
using Xunit;

namespace Platform.Ranges.Tests
{
    public static class RangeTests
    {
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

        [Fact]
        public static void DifferenceTest()
        {
            var range = new Range<int>(1, 3);
            Assert.Equal(2, range.Difference());
        }

        [Fact]
        public static void ToStringTest()
        {
            var range = new Range<int>(1, 3);
            Assert.Equal("[1..3]", range.ToString());
        }

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

        [Fact]
        public static void EqualsObjectTest()
        {
            var range = new Range<int>(1, 3);
            var rangeAsObject = (object)new Range<int>(1, 3);
            var differentRange = (object)new Range<int>(2, 5);
            var nullObject = (object)null;
            var stringObject = (object)"test";

            Assert.True(range.Equals(rangeAsObject));
            Assert.False(range.Equals(differentRange));
            Assert.False(range.Equals(nullObject));
            Assert.False(range.Equals(stringObject));
        }

        [Fact]
        public static void GetHashCodeTest()
        {
            var range1 = new Range<int>(1, 3);
            var range1Duplicate = new Range<int>(1, 3);
            var range2 = new Range<int>(2, 5);

            Assert.Equal(range1.GetHashCode(), range1Duplicate.GetHashCode());
            Assert.NotEqual(range1.GetHashCode(), range2.GetHashCode());
        }

        [Fact]
        public static void ImplicitOperatorTest()
        {
            var range = new Range<int>(1, 3);
            (int min, int max) tuple = range;
            Assert.Equal(1, tuple.min);
            Assert.Equal(3, tuple.max);

            Range<int> rangeFromTuple = (1, 3);
            Assert.Equal(1, rangeFromTuple.Minimum);
            Assert.Equal(3, rangeFromTuple.Maximum);
        }

        [Fact]
        public static void ContainsRangeEdgeCasesTest()
        {
            var range = new Range<int>(1, 10);
            
            Assert.True(range.Contains(new Range<int>(1, 10)));
            Assert.True(range.Contains(new Range<int>(2, 9)));
            Assert.True(range.Contains(new Range<int>(1, 1)));
            Assert.True(range.Contains(new Range<int>(10, 10)));
            
            Assert.False(range.Contains(new Range<int>(0, 10)));
            Assert.False(range.Contains(new Range<int>(1, 11)));
            Assert.False(range.Contains(new Range<int>(0, 11)));
        }

        [Fact]
        public static void DifferentNumericTypesTest()
        {
            var byteRange = new Range<byte>(1, 3);
            Assert.Equal((byte)1, byteRange.Minimum);
            Assert.Equal((byte)3, byteRange.Maximum);

            var longRange = new Range<long>(100L, 300L);
            Assert.Equal(100L, longRange.Minimum);
            Assert.Equal(300L, longRange.Maximum);

            var floatRange = new Range<float>(1.5f, 3.5f);
            Assert.Equal(1.5f, floatRange.Minimum);
            Assert.Equal(3.5f, floatRange.Maximum);

            var doubleRange = new Range<double>(1.5, 3.5);
            Assert.Equal(1.5, doubleRange.Minimum);
            Assert.Equal(3.5, doubleRange.Maximum);

            var decimalRange = new Range<decimal>(1.5m, 3.5m);
            Assert.Equal(1.5m, decimalRange.Minimum);
            Assert.Equal(3.5m, decimalRange.Maximum);
        }

        [Fact]
        public static void StaticRangeConstantsTest()
        {
            Assert.Equal(sbyte.MinValue, Range.SByte.Minimum);
            Assert.Equal(sbyte.MaxValue, Range.SByte.Maximum);

            Assert.Equal(short.MinValue, Range.Int16.Minimum);
            Assert.Equal(short.MaxValue, Range.Int16.Maximum);

            Assert.Equal(int.MinValue, Range.Int32.Minimum);
            Assert.Equal(int.MaxValue, Range.Int32.Maximum);

            Assert.Equal(long.MinValue, Range.Int64.Minimum);
            Assert.Equal(long.MaxValue, Range.Int64.Maximum);

            Assert.Equal(byte.MinValue, Range.Byte.Minimum);
            Assert.Equal(byte.MaxValue, Range.Byte.Maximum);

            Assert.Equal(ushort.MinValue, Range.UInt16.Minimum);
            Assert.Equal(ushort.MaxValue, Range.UInt16.Maximum);

            Assert.Equal(uint.MinValue, Range.UInt32.Minimum);
            Assert.Equal(uint.MaxValue, Range.UInt32.Maximum);

            Assert.Equal(ulong.MinValue, Range.UInt64.Minimum);
            Assert.Equal(ulong.MaxValue, Range.UInt64.Maximum);

            Assert.Equal(float.MinValue, Range.Single.Minimum);
            Assert.Equal(float.MaxValue, Range.Single.Maximum);

            Assert.Equal(double.MinValue, Range.Double.Minimum);
            Assert.Equal(double.MaxValue, Range.Double.Maximum);

            Assert.Equal(decimal.MinValue, Range.Decimal.Minimum);
            Assert.Equal(decimal.MaxValue, Range.Decimal.Maximum);
        }
    }
}
