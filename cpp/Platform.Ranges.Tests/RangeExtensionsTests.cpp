namespace Platform::Ranges::Tests
{
    TEST(RangeExtensionsTests, DifferenceIntTest)
    {
        auto range = Range(1, 5);
        ASSERT_EQ(4, Difference(range));

        auto zeroRange = Range(10, 10);
        ASSERT_EQ(0, Difference(zeroRange));

        auto negativeRange = Range(-10, -5);
        ASSERT_EQ(5, Difference(negativeRange));

        auto crossZeroRange = Range(-5, 5);
        ASSERT_EQ(10, Difference(crossZeroRange));
    }

    TEST(RangeExtensionsTests, DifferenceUnsignedTypesTest)
    {
        auto byteRange = Range<std::uint8_t>(1, 5);
        ASSERT_EQ(4, Difference(byteRange));

        auto ushortRange = Range<std::uint16_t>(1, 5);
        ASSERT_EQ(4, Difference(ushortRange));

        auto uintRange = Range<std::uint32_t>(1, 5);
        ASSERT_EQ(4U, Difference(uintRange));

        auto ulongRange = Range<std::uint64_t>(1, 5);
        ASSERT_EQ(4UL, Difference(ulongRange));

        // Test with maximum ranges
        auto maxByteRange = Range<std::uint8_t>(std::numeric_limits<std::uint8_t>::min(), std::numeric_limits<std::uint8_t>::max());
        ASSERT_EQ(255, Difference(maxByteRange));

        auto maxUshortRange = Range<std::uint16_t>(std::numeric_limits<std::uint16_t>::min(), std::numeric_limits<std::uint16_t>::max());
        ASSERT_EQ(65535, Difference(maxUshortRange));
    }

    TEST(RangeExtensionsTests, DifferenceSignedTypesTest)
    {
        auto sbyteRange = Range<std::int8_t>(1, 5);
        ASSERT_EQ(4, Difference(sbyteRange));

        auto shortRange = Range<std::int16_t>(1, 5);
        ASSERT_EQ(4, Difference(shortRange));

        auto intRange = Range<std::int32_t>(1, 5);
        ASSERT_EQ(4, Difference(intRange));

        auto longRange = Range<std::int64_t>(1, 5);
        ASSERT_EQ(4L, Difference(longRange));

        // Test with negative values
        auto negativeSbyteRange = Range<std::int8_t>(-10, -5);
        ASSERT_EQ(5, Difference(negativeSbyteRange));

        auto negativeShortRange = Range<std::int16_t>(-100, -50);
        ASSERT_EQ(50, Difference(negativeShortRange));

        auto negativeIntRange = Range<std::int32_t>(-1000, -500);
        ASSERT_EQ(500, Difference(negativeIntRange));

        auto negativeLongRange = Range<std::int64_t>(-10000L, -5000L);
        ASSERT_EQ(5000L, Difference(negativeLongRange));
    }

    TEST(RangeExtensionsTests, DifferenceFloatingPointTest)
    {
        auto floatRange = Range<float>(1.0f, 5.0f);
        ASSERT_FLOAT_EQ(4.0f, Difference(floatRange));

        auto doubleRange = Range<double>(1.0, 5.0);
        ASSERT_DOUBLE_EQ(4.0, Difference(doubleRange));

        auto zeroFloatRange = Range<float>(10.5f, 10.5f);
        ASSERT_FLOAT_EQ(0.0f, Difference(zeroFloatRange));

        auto zeroDoubleRange = Range<double>(10.5, 10.5);
        ASSERT_DOUBLE_EQ(0.0, Difference(zeroDoubleRange));

        auto negativeFloatRange = Range<float>(-10.5f, -5.5f);
        ASSERT_FLOAT_EQ(5.0f, Difference(negativeFloatRange));

        auto negativeDoubleRange = Range<double>(-10.5, -5.5);
        ASSERT_DOUBLE_EQ(5.0, Difference(negativeDoubleRange));

        auto decimalFloatRange = Range<float>(1.25f, 3.75f);
        ASSERT_FLOAT_EQ(2.5f, Difference(decimalFloatRange));

        auto decimalDoubleRange = Range<double>(1.25, 3.75);
        ASSERT_DOUBLE_EQ(2.5, Difference(decimalDoubleRange));
    }

    TEST(RangeExtensionsTests, DifferenceEdgeCasesTest)
    {
        // Zero-width ranges
        auto zeroIntRange = Range(42, 42);
        ASSERT_EQ(0, Difference(zeroIntRange));

        auto zeroFloatRange = Range(3.14f, 3.14f);
        ASSERT_FLOAT_EQ(0.0f, Difference(zeroFloatRange));

        auto zeroDoubleRange = Range(2.718, 2.718);
        ASSERT_DOUBLE_EQ(0.0, Difference(zeroDoubleRange));

        // Large ranges
        auto largeIntRange = Range(std::numeric_limits<int>::min() / 2, std::numeric_limits<int>::max() / 2);
        auto expectedDiff = static_cast<long long>(std::numeric_limits<int>::max() / 2) - static_cast<long long>(std::numeric_limits<int>::min() / 2);
        ASSERT_EQ(expectedDiff, Difference(largeIntRange));
    }
}