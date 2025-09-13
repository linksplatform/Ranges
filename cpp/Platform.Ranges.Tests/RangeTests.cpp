namespace Platform::Ranges::Tests
{
    TEST(RangesTests, ConstructorsTest)
    {
        auto range1 = Range(1, 3);
        ASSERT_EQ(1, range1.Minimum);
        ASSERT_EQ(3, range1.Maximum);
        EXPECT_THROW(Range(2, 1), std::invalid_argument);
        auto range2 = Range(5);
        ASSERT_EQ(5, range2.Minimum);
        ASSERT_EQ(5, range2.Maximum);
    }

    TEST(RangesTests, ContainsTest)
    {
        auto range = Range(1, 3);
        ASSERT_TRUE(range.Contains(1));
        ASSERT_TRUE(range.Contains(2));
        ASSERT_TRUE(range.Contains(3));
        ASSERT_TRUE(range.Contains({2, 3}));
        ASSERT_FALSE(range.Contains({3, 4}));
    }

    TEST(RangesTests, DifferenceTest)
    {
        auto range = Range(1, 3);
        ASSERT_EQ(2, Platform::Ranges::Difference(range));
    }

    TEST(RangesTests, ToStringTest)
    {
        auto range = Range(1, 3);
        ASSERT_EQ("[1..3]", Platform::Converters::To<std::string>(range));
    }

    TEST(RangesTests, EqualityTest)
    {
        auto range1 = Range(1, 3);
        auto range1Duplicate = Range(1, 3);
        auto range2 = Range(2, 5);
        ASSERT_TRUE(range1 == range1Duplicate);
        ASSERT_EQ(range1, range1Duplicate);
        ASSERT_TRUE(range1 != range2);
        ASSERT_NE(range1, range2);
    }

    TEST(RangesExtensionsTests, ExplicitCasts)
    {
        Range<int> range = Range{1, 2};
        Range<int> one_case = Range<std::uint8_t>{1, 2};
        Range<std::uint8_t> two_case = Range<int>{1, 2};

        ASSERT_EQ(range, one_case);
        ASSERT_EQ(range, two_case);
        ASSERT_EQ(one_case, two_case);
    }

    TEST(RangesExtensionsTests, AnyOrderingType)
    {
        {
            using namespace std::string_literals;

            auto range = Range{ "abc"s, "def" };
            static_assert(std::same_as<decltype(range.Minimum), const std::string>);
            static_assert(std::same_as<decltype(range.Maximum), const std::string>);

            ASSERT_TRUE(range.Contains("abcd"));
            ASSERT_TRUE(range.Contains("abcd"s));
            ASSERT_FALSE(range.Contains("ab"));
            ASSERT_FALSE(range.Contains("ab"s));
        }

        {
            int array[]{1, 2, 3, 4, 5, 6, 7, 8, 9, 10};
            auto third = Range{std::begin(array), std::begin(array) + std::size(array) / 3};

            ASSERT_TRUE(third.Contains(&array[0]));
            ASSERT_TRUE(third.Contains(&array[1]));
            ASSERT_TRUE(third.Contains(&array[2]));
            ASSERT_FALSE(third.Contains(&array[9]));
            ASSERT_FALSE(third.Contains(&array[8]));
            ASSERT_FALSE(third.Contains(&array[7]));
        }
    }

    TEST(RangesTests, StaticConstantsTest)
    {
        ASSERT_EQ(std::numeric_limits<std::int8_t>::lowest(), SByte.Minimum);
        ASSERT_EQ(std::numeric_limits<std::int8_t>::max(), SByte.Maximum);

        ASSERT_EQ(std::numeric_limits<std::int16_t>::lowest(), Int16.Minimum);
        ASSERT_EQ(std::numeric_limits<std::int16_t>::max(), Int16.Maximum);

        ASSERT_EQ(std::numeric_limits<std::int32_t>::lowest(), Int32.Minimum);
        ASSERT_EQ(std::numeric_limits<std::int32_t>::max(), Int32.Maximum);

        ASSERT_EQ(std::numeric_limits<std::int64_t>::lowest(), Int64.Minimum);
        ASSERT_EQ(std::numeric_limits<std::int64_t>::max(), Int64.Maximum);

        ASSERT_EQ(std::numeric_limits<std::uint8_t>::lowest(), Byte.Minimum);
        ASSERT_EQ(std::numeric_limits<std::uint8_t>::max(), Byte.Maximum);

        ASSERT_EQ(std::numeric_limits<std::uint16_t>::lowest(), UInt16.Minimum);
        ASSERT_EQ(std::numeric_limits<std::uint16_t>::max(), UInt16.Maximum);

        ASSERT_EQ(std::numeric_limits<std::uint32_t>::lowest(), UInt32.Minimum);
        ASSERT_EQ(std::numeric_limits<std::uint32_t>::max(), UInt32.Maximum);

        ASSERT_EQ(std::numeric_limits<std::uint64_t>::lowest(), UInt64.Minimum);
        ASSERT_EQ(std::numeric_limits<std::uint64_t>::max(), UInt64.Maximum);

        ASSERT_EQ(std::numeric_limits<std::float_t>::lowest(), Single.Minimum);
        ASSERT_EQ(std::numeric_limits<std::float_t>::max(), Single.Maximum);

        ASSERT_EQ(std::numeric_limits<std::double_t>::lowest(), Double.Minimum);
        ASSERT_EQ(std::numeric_limits<std::double_t>::max(), Double.Maximum);
    }

    TEST(RangesTests, HashTest)
    {
        auto range1 = Range(1, 3);
        auto range1Duplicate = Range(1, 3);
        auto range2 = Range(2, 5);

        std::hash<Range<int>> hasher;
        ASSERT_EQ(hasher(range1), hasher(range1Duplicate));
        ASSERT_NE(hasher(range1), hasher(range2));
    }

    TEST(RangesTests, TupleConversionTest)
    {
        auto range = Range(1, 3);
        std::tuple<int, int> tuple = range;
        ASSERT_EQ(1, std::get<0>(tuple));
        ASSERT_EQ(3, std::get<1>(tuple));

        Range<int> rangeFromTuple{std::make_tuple(5, 7)};
        ASSERT_EQ(5, rangeFromTuple.Minimum);
        ASSERT_EQ(7, rangeFromTuple.Maximum);
    }

    TEST(RangesTests, StreamOperatorTest)
    {
        auto range = Range(1, 3);
        std::stringstream ss;
        ss << range;
        ASSERT_EQ("[1..3]", ss.str());
    }

    TEST(RangesTests, ContainsRangeEdgeCasesTest)
    {
        auto range = Range(1, 10);
        
        ASSERT_TRUE(range.Contains(Range(1, 10)));
        ASSERT_TRUE(range.Contains(Range(2, 9)));
        ASSERT_TRUE(range.Contains(Range(1, 1)));
        ASSERT_TRUE(range.Contains(Range(10, 10)));
        
        ASSERT_FALSE(range.Contains(Range(0, 10)));
        ASSERT_FALSE(range.Contains(Range(1, 11)));
        ASSERT_FALSE(range.Contains(Range(0, 11)));
    }

    TEST(RangesTests, DifferentNumericTypesTest)
    {
        auto byteRange = Range<std::uint8_t>(1, 3);
        ASSERT_EQ(1, byteRange.Minimum);
        ASSERT_EQ(3, byteRange.Maximum);

        auto longRange = Range<std::int64_t>(100L, 300L);
        ASSERT_EQ(100L, longRange.Minimum);
        ASSERT_EQ(300L, longRange.Maximum);

        auto floatRange = Range<float>(1.5f, 3.5f);
        ASSERT_FLOAT_EQ(1.5f, floatRange.Minimum);
        ASSERT_FLOAT_EQ(3.5f, floatRange.Maximum);

        auto doubleRange = Range<double>(1.5, 3.5);
        ASSERT_DOUBLE_EQ(1.5, doubleRange.Minimum);
        ASSERT_DOUBLE_EQ(3.5, doubleRange.Maximum);
    }
}
