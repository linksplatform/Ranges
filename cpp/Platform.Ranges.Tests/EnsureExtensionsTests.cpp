namespace Platform::Ranges::Tests
{
    TEST(EnsureExtensionsTests, MaximumArgumentIsGreaterOrEqualToMinimumExceptionTest)
    {
        EXPECT_THROW(Ensure::Always::MaximumArgumentIsGreaterOrEqualToMinimum(2, 1), std::invalid_argument);
    }

    TEST(EnsureExtensionsTests, MaximumArgumentIsGreaterOrEqualToMinimumValidTest)
    {
        EXPECT_NO_THROW(Ensure::Always::MaximumArgumentIsGreaterOrEqualToMinimum(1, 2));
        EXPECT_NO_THROW(Ensure::Always::MaximumArgumentIsGreaterOrEqualToMinimum(5, 5));
        EXPECT_NO_THROW(Ensure::Always::MaximumArgumentIsGreaterOrEqualToMinimum(1, 2, "testParam"));
        EXPECT_NO_THROW(Ensure::Always::MaximumArgumentIsGreaterOrEqualToMinimum(1, 2, "testParam", "Test message"));
    }

    TEST(EnsureExtensionsTests, MaximumArgumentIsGreaterOrEqualToMinimumWithCustomMessageTest)
    {
        try 
        {
            Ensure::Always::MaximumArgumentIsGreaterOrEqualToMinimum(5, 3, "maxParam", "Custom error message");
            FAIL() << "Expected std::invalid_argument";
        }
        catch (const std::invalid_argument& e) 
        {
            std::string message(e.what());
            EXPECT_TRUE(message.find("Custom error message") != std::string::npos);
            EXPECT_TRUE(message.find("maxParam") != std::string::npos);
        }
    }

    TEST(EnsureExtensionsTests, MaximumArgumentIsGreaterOrEqualToMinimumWithMessageBuilderTest)
    {
        try 
        {
            Ensure::Always::MaximumArgumentIsGreaterOrEqualToMinimum(5, 3, "maxParam", []() { return std::string("Lambda message"); });
            FAIL() << "Expected std::invalid_argument";
        }
        catch (const std::invalid_argument& e) 
        {
            std::string message(e.what());
            EXPECT_TRUE(message.find("Lambda message") != std::string::npos);
        }
    }

    TEST(EnsureExtensionsTests, ArgumentInRangeExceptionTest)
    {
        EXPECT_THROW(Ensure::Always::ArgumentInRange(5, 6, 7), std::invalid_argument);
    }

    TEST(EnsureExtensionsTests, ArgumentInRangeValidTest)
    {
        EXPECT_NO_THROW(Ensure::Always::ArgumentInRange(5, Range<int>(1, 10)));
        EXPECT_NO_THROW(Ensure::Always::ArgumentInRange(5, Range<int>(5, 5)));
        EXPECT_NO_THROW(Ensure::Always::ArgumentInRange(1, Range<int>(1, 10)));
        EXPECT_NO_THROW(Ensure::Always::ArgumentInRange(10, Range<int>(1, 10)));
    }

    TEST(EnsureExtensionsTests, ArgumentInRangeWithArgumentNameTest)
    {
        try 
        {
            Ensure::Always::ArgumentInRange(15, Range<int>(1, 10), "testParam");
            FAIL() << "Expected std::invalid_argument";
        }
        catch (const std::invalid_argument& e) 
        {
            std::string message(e.what());
            EXPECT_TRUE(message.find("testParam") != std::string::npos);
            EXPECT_TRUE(message.find("15") != std::string::npos);
        }
    }

    TEST(EnsureExtensionsTests, ArgumentInRangeWithCustomMessageTest)
    {
        try 
        {
            Ensure::Always::ArgumentInRange(15, Range<int>(1, 10), "testParam", "Custom range message");
            FAIL() << "Expected std::invalid_argument";
        }
        catch (const std::invalid_argument& e) 
        {
            std::string message(e.what());
            EXPECT_TRUE(message.find("Custom range message") != std::string::npos);
        }
    }

    TEST(EnsureExtensionsTests, ArgumentInRangeWithMessageBuilderTest)
    {
        try 
        {
            Ensure::Always::ArgumentInRange(15, Range<int>(1, 10), "testParam", []() { return std::string("Lambda range message"); });
            FAIL() << "Expected std::invalid_argument";
        }
        catch (const std::invalid_argument& e) 
        {
            std::string message(e.what());
            EXPECT_TRUE(message.find("Lambda range message") != std::string::npos);
        }
    }

    TEST(EnsureExtensionsTests, ArgumentInRangeWithMinMaxTest)
    {
        EXPECT_NO_THROW(Ensure::Always::ArgumentInRange(5, 1, 10));
        EXPECT_NO_THROW(Ensure::Always::ArgumentInRange(5, 1, 10, "testParam"));
        
        try 
        {
            Ensure::Always::ArgumentInRange(15, 1, 10, "testParam");
            FAIL() << "Expected std::invalid_argument";
        }
        catch (const std::invalid_argument& e) 
        {
            std::string message(e.what());
            EXPECT_TRUE(message.find("testParam") != std::string::npos);
        }
    }

    TEST(EnsureExtensionsTests, ArgumentInRangeDifferentTypesTest)
    {
        EXPECT_NO_THROW(Ensure::Always::ArgumentInRange(5.5, Range<double>(1.0, 10.0)));
        EXPECT_NO_THROW(Ensure::Always::ArgumentInRange(5.5f, Range<float>(1.0f, 10.0f)));
        EXPECT_NO_THROW(Ensure::Always::ArgumentInRange((uint8_t)5, Range<uint8_t>(1, 10)));
        EXPECT_NO_THROW(Ensure::Always::ArgumentInRange(5L, Range<int64_t>(1L, 10L)));
        
        EXPECT_THROW(Ensure::Always::ArgumentInRange(15.5, Range<double>(1.0, 10.0)), std::invalid_argument);
        EXPECT_THROW(Ensure::Always::ArgumentInRange(15.5f, Range<float>(1.0f, 10.0f)), std::invalid_argument);
        EXPECT_THROW(Ensure::Always::ArgumentInRange((uint8_t)15, Range<uint8_t>(1, 10)), std::invalid_argument);
        EXPECT_THROW(Ensure::Always::ArgumentInRange(15L, Range<int64_t>(1L, 10L)), std::invalid_argument);
    }

    TEST(EnsureExtensionsTests, OnDebugMethodsTest)
    {
        // OnDebug methods should not throw in release builds (with NDEBUG)
        // and should behave like Always methods in debug builds (without NDEBUG)
        EXPECT_NO_THROW(Ensure::OnDebug::MaximumArgumentIsGreaterOrEqualToMinimum(1, 2));
        EXPECT_NO_THROW(Ensure::OnDebug::MaximumArgumentIsGreaterOrEqualToMinimum(1, 2, "testParam"));
        EXPECT_NO_THROW(Ensure::OnDebug::MaximumArgumentIsGreaterOrEqualToMinimum(1, 2, "testParam", "Test message"));
        EXPECT_NO_THROW(Ensure::OnDebug::MaximumArgumentIsGreaterOrEqualToMinimum(1, 2, "testParam", []() { return std::string("Lambda message"); }));

        EXPECT_NO_THROW(Ensure::OnDebug::ArgumentInRange(5, Range<int>(1, 10)));
        EXPECT_NO_THROW(Ensure::OnDebug::ArgumentInRange(5, Range<int>(1, 10), "testParam"));
        EXPECT_NO_THROW(Ensure::OnDebug::ArgumentInRange(5, Range<int>(1, 10), "testParam", "Test message"));
        EXPECT_NO_THROW(Ensure::OnDebug::ArgumentInRange(5, Range<int>(1, 10), "testParam", []() { return std::string("Lambda message"); }));
        EXPECT_NO_THROW(Ensure::OnDebug::ArgumentInRange(5, 1, 10));
        EXPECT_NO_THROW(Ensure::OnDebug::ArgumentInRange(5, 1, 10, "testParam"));

        // In debug builds, these should throw, but in release builds they shouldn't
#ifndef NDEBUG
        EXPECT_THROW(Ensure::OnDebug::MaximumArgumentIsGreaterOrEqualToMinimum(2, 1), std::invalid_argument);
        EXPECT_THROW(Ensure::OnDebug::ArgumentInRange(15, Range<int>(1, 10)), std::invalid_argument);
#endif
    }
}
