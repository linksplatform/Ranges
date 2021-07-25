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
        ASSERT_EQ("[1, 3]", Platform::Converters::To<std::string>(range));
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
}
