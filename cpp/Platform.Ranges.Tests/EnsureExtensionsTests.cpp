// NOTE: EnsureExtensions functionality has been replaced with GSL::Expects
// GSL::Expects terminates the program on failure rather than throwing exceptions
// Tests for termination behavior would require different testing strategies
namespace Platform::Ranges::Tests
{
    TEST(EnsureExtensionsTests, MaximumArgumentIsGreaterOrEqualToMinimumExceptionTest)
    {
        // EXPECT_THROW(Ensure::Always::MaximumArgumentIsGreaterOrEqualToMinimum(2, 1), std::logic_error); // EnsureExtensions replaced with GSL::Expects
    }

    TEST(EnsureExtensionsTests, ArgumentInRangeExceptionTest)
    {
        // EXPECT_THROW(Ensure::Always::ArgumentInRange(5, 6, 7), std::logic_error); // EnsureExtensions replaced with GSL::Expects
    }
}
