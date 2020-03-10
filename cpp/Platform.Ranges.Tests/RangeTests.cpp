namespace Platform::Ranges::Tests
{
    TEST_CLASS(RangeTests)
    {
        public: TEST_METHOD(ConstructorsTest)
        {
            auto range1 = Range<std::int32_t>(1, 3);
            Assert::AreEqual(1, range1.Minimum);
            Assert::AreEqual(3, range1.Maximum);
            Assert::ExpectException<std::invalid_argument>([&]()-> auto { return Range<std::int32_t>(2, 1); });
            auto range2 = Range<std::int32_t>(5);
            Assert::AreEqual(5, range2.Minimum);
            Assert::AreEqual(5, range2.Maximum);
        }

        public: TEST_METHOD(ContainsTest)
        {
            auto range = Range<std::int32_t>(1, 3);
            Assert::IsTrue(range.Contains(1));
            Assert::IsTrue(range.Contains(2));
            Assert::IsTrue(range.Contains(3));
            Assert::IsTrue(range.Contains({2, 3}));
            Assert::IsFalse(range.Contains({3, 4}));
        }

        public: TEST_METHOD(DifferenceTest)
        {
            auto range = Range<std::int32_t>(1, 3);
            Assert::AreEqual(2, Platform::Ranges::RangeExtensions::Difference(range));
        }

        public: TEST_METHOD(ToStringTest)
        {
            auto range = Range<std::int32_t>(1, 3);
            Assert::AreEqual("[1, 3]", Platform::Converters::To<std::string>(range).data());
        }

        public: TEST_METHOD(EqualityTest)
        {
            auto range1 = Range<std::int32_t>(1, 3);
            auto range1Duplicate = Range<std::int32_t>(1, 3);
            auto range2 = Range<std::int32_t>(2, 5);
            Assert::IsTrue(range1 == range1Duplicate);
            Assert::AreEqual(range1, range1Duplicate);
            Assert::IsTrue(range1 != range2);
            Assert::AreNotEqual(range1, range2);
        }
    };
}
