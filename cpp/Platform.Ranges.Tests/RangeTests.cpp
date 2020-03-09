namespace Platform::Ranges::Tests
{
    TEST_CLASS(Range)
    {
        public static void ConstructorsTest()
        {
            auto range1 = new Range<std::int32_t>(1, 3);
            Assert::AreEqual(1, range1.Minimum);
            Assert::AreEqual(3, range1.Maximum);
            Assert::ExpectException<ArgumentException>([&]()-> auto { return new Range<std::int32_t>(2, 1); });
            auto range2 = new Range<std::int32_t>(5);
            Assert::AreEqual(5, range2.Minimum);
            Assert::AreEqual(5, range2.Maximum);
        }

        public: TEST_METHOD(ContainsTest)
        {
            auto range = new Range<std::int32_t>(1, 3);
            Assert.True(range.Contains(1));
            Assert.True(range.Contains(2));
            Assert.True(range.Contains(3));
            Assert.True(range.Contains((2, 3)));
            Assert.False(range.Contains((3, 4)));
        }

        public: TEST_METHOD(DifferenceTest)
        {
            auto range = new Range<std::int32_t>(1, 3);
            Assert::AreEqual(2, range.Difference());
        }

        public: TEST_METHOD(ToStringTest)
        {
            auto range = new Range<std::int32_t>(1, 3);
            Assert::AreEqual("[1, 3]", range.ToString());
        }

        public: TEST_METHOD(EqualityTest)
        {
            auto range1 = new Range<std::int32_t>(1, 3);
            auto range1Duplicate = new Range<std::int32_t>(1, 3);
            auto range2 = new Range<std::int32_t>(2, 5);
            Assert.True(range1 == range1Duplicate);
            Assert::AreEqual(range1, range1Duplicate);
            Assert.True(range1 != range2);
            Assert.NotEqual(range1, range2);
        }
    };
}
