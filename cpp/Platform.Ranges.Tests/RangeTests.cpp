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
}
