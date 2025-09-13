using System;
using Xunit;

namespace Platform.Ranges.Tests
{
    public static class RangeExtensionsTests
    {
        [Fact]
        public static void DifferenceULongTest()
        {
            var range = new Range<ulong>(1, 5);
            Assert.Equal(4UL, range.Difference());

            var zeroRange = new Range<ulong>(10, 10);
            Assert.Equal(0UL, zeroRange.Difference());

            var maxRange = new Range<ulong>(ulong.MinValue, ulong.MaxValue);
            Assert.Equal(ulong.MaxValue, maxRange.Difference());
        }

        [Fact]
        public static void DifferenceUIntTest()
        {
            var range = new Range<uint>(1, 5);
            Assert.Equal(4U, range.Difference());

            var zeroRange = new Range<uint>(10, 10);
            Assert.Equal(0U, zeroRange.Difference());

            var maxRange = new Range<uint>(uint.MinValue, uint.MaxValue);
            Assert.Equal(uint.MaxValue, maxRange.Difference());
        }

        [Fact]
        public static void DifferenceUShortTest()
        {
            var range = new Range<ushort>(1, 5);
            Assert.Equal((ushort)4, range.Difference());

            var zeroRange = new Range<ushort>(10, 10);
            Assert.Equal((ushort)0, zeroRange.Difference());

            var maxRange = new Range<ushort>(ushort.MinValue, ushort.MaxValue);
            Assert.Equal(ushort.MaxValue, maxRange.Difference());
        }

        [Fact]
        public static void DifferenceByteTest()
        {
            var range = new Range<byte>(1, 5);
            Assert.Equal((byte)4, range.Difference());

            var zeroRange = new Range<byte>(10, 10);
            Assert.Equal((byte)0, zeroRange.Difference());

            var maxRange = new Range<byte>(byte.MinValue, byte.MaxValue);
            Assert.Equal((byte)255, maxRange.Difference());
        }

        [Fact]
        public static void DifferenceLongTest()
        {
            var range = new Range<long>(1, 5);
            Assert.Equal(4L, range.Difference());

            var zeroRange = new Range<long>(10, 10);
            Assert.Equal(0L, zeroRange.Difference());

            var negativeRange = new Range<long>(-10, -5);
            Assert.Equal(5L, negativeRange.Difference());

            var crossZeroRange = new Range<long>(-5, 5);
            Assert.Equal(10L, crossZeroRange.Difference());
        }

        [Fact]
        public static void DifferenceIntTest()
        {
            var range = new Range<int>(1, 5);
            Assert.Equal(4, range.Difference());

            var zeroRange = new Range<int>(10, 10);
            Assert.Equal(0, zeroRange.Difference());

            var negativeRange = new Range<int>(-10, -5);
            Assert.Equal(5, negativeRange.Difference());

            var crossZeroRange = new Range<int>(-5, 5);
            Assert.Equal(10, crossZeroRange.Difference());
        }

        [Fact]
        public static void DifferenceShortTest()
        {
            var range = new Range<short>(1, 5);
            Assert.Equal((short)4, range.Difference());

            var zeroRange = new Range<short>(10, 10);
            Assert.Equal((short)0, zeroRange.Difference());

            var negativeRange = new Range<short>(-10, -5);
            Assert.Equal((short)5, negativeRange.Difference());

            var crossZeroRange = new Range<short>(-5, 5);
            Assert.Equal((short)10, crossZeroRange.Difference());
        }

        [Fact]
        public static void DifferenceSByteTest()
        {
            var range = new Range<sbyte>(1, 5);
            Assert.Equal((sbyte)4, range.Difference());

            var zeroRange = new Range<sbyte>(10, 10);
            Assert.Equal((sbyte)0, zeroRange.Difference());

            var negativeRange = new Range<sbyte>(-10, -5);
            Assert.Equal((sbyte)5, negativeRange.Difference());

            var crossZeroRange = new Range<sbyte>(-5, 5);
            Assert.Equal((sbyte)10, crossZeroRange.Difference());
        }

        [Fact]
        public static void DifferenceDoubleTest()
        {
            var range = new Range<double>(1.0, 5.0);
            Assert.Equal(4.0, range.Difference(), 15);

            var zeroRange = new Range<double>(10.5, 10.5);
            Assert.Equal(0.0, zeroRange.Difference(), 15);

            var negativeRange = new Range<double>(-10.5, -5.5);
            Assert.Equal(5.0, negativeRange.Difference(), 15);

            var decimalRange = new Range<double>(1.25, 3.75);
            Assert.Equal(2.5, decimalRange.Difference(), 15);
        }

        [Fact]
        public static void DifferenceFloatTest()
        {
            var range = new Range<float>(1.0f, 5.0f);
            Assert.Equal(4.0f, range.Difference(), 6);

            var zeroRange = new Range<float>(10.5f, 10.5f);
            Assert.Equal(0.0f, zeroRange.Difference(), 6);

            var negativeRange = new Range<float>(-10.5f, -5.5f);
            Assert.Equal(5.0f, negativeRange.Difference(), 6);

            var decimalRange = new Range<float>(1.25f, 3.75f);
            Assert.Equal(2.5f, decimalRange.Difference(), 6);
        }

        [Fact]
        public static void DifferenceDecimalTest()
        {
            var range = new Range<decimal>(1.0m, 5.0m);
            Assert.Equal(4.0m, range.Difference());

            var zeroRange = new Range<decimal>(10.5m, 10.5m);
            Assert.Equal(0.0m, zeroRange.Difference());

            var negativeRange = new Range<decimal>(-10.5m, -5.5m);
            Assert.Equal(5.0m, negativeRange.Difference());

            var preciseRange = new Range<decimal>(1.123456789m, 3.987654321m);
            Assert.Equal(2.864197532m, preciseRange.Difference());
        }
    }
}