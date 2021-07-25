namespace Platform::Ranges::Tests
{
    TEST(EnsureExtensionsTests, MaximumArgumentIsGreaterOrEqualToMinimumExceptionTest)
    {
        //EXPECT_THROW(Ensure::Always::MaximumArgumentIsGreaterOrEqualToMinimum(2, 1), std::logic_error);
    }

    TEST(EnsureExtensionsTests, ArgumentInRangeExceptionTest)
    {
        EXPECT_THROW(Ensure::Always::ArgumentInRange(5, 6, 7, ""), std::logic_error);
    }
}
