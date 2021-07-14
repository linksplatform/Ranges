namespace Platform::Ranges::Tests
{
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
        using namespace std::string_literals;

        auto range = Range{"abc"s, "def"};
        static_assert(std::same_as<decltype(range.Minimum), const std::string>);
        static_assert(std::same_as<decltype(range.Maximum), const std::string>);

        ASSERT_TRUE(range.Contains("abcd"));
        ASSERT_FALSE(range.Contains("ab"));
    }
}
