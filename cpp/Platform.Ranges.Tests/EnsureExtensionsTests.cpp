namespace Platform::Ranges::Tests
{
    TEST_CLASS(EnsureExtensionsTests)
    {
        public: TEST_METHOD(MaximumArgumentIsGreaterOrEqualToMinimumExceptionTest) { Assert::ExpectException<std::invalid_argument>([&]()-> auto { return Platform::Ranges::EnsureExtensions::MaximumArgumentIsGreaterOrEqualToMinimum(Platform::Exceptions::Ensure::Always, 2, 1); }); }

        public: TEST_METHOD(ArgumentInRangeExceptionTest) { Assert::ExpectException<std::invalid_argument>([&]()-> auto { return Platform::Ranges::EnsureExtensions::ArgumentInRange(Platform::Exceptions::Ensure::Always, 5, {6, 7}); }); }
    };
}
