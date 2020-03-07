namespace Platform::Ranges::Tests
{
    TEST_CLASS(EnsureExtensions)
    {
        public: TEST_METHOD(MaximumArgumentIsGreaterOrEqualToMinimumExceptionTest) { Assert::ExpectException<ArgumentException>([&]()-> auto { return Platform::Ranges::EnsureExtensions::MaximumArgumentIsGreaterOrEqualToMinimum(Platform::Exceptions::Ensure::Always, 2, 1); }); }

        public: TEST_METHOD(ArgumentInRangeExceptionTest) { Assert::ExpectException<ArgumentOutOfRangeException>([&]()-> auto { return Platform::Ranges::EnsureExtensions::ArgumentInRange(Platform::Exceptions::Ensure::Always, 5, (6, 7)); }); }
    };
}
