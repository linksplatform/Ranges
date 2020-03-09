namespace Platform::Ranges
{
    template <typename ...> struct Range;
    template<> class Range<>
    {
        public: inline static Range<std::int8_t> SByte = Range<std::int8_t>(std::numeric_limits<std::int8_t>::min(), std::numeric_limits<std::int8_t>::max());

        public: inline static Range<std::int16_t> Int16 = Range<std::int16_t>(std::numeric_limits<std::int16_t>::min(), std::numeric_limits<std::int16_t>::max());

        public: inline static Range<std::int32_t> Int32 = Range<std::int32_t>(std::numeric_limits<std::int32_t>::min(), std::numeric_limits<std::int32_t>::max());

        public: inline static Range<std::int64_t> Int64 = Range<std::int64_t>(std::numeric_limits<std::int64_t>::min(), std::numeric_limits<std::int64_t>::max());

        public: inline static Range<std::uint8_t> Byte = Range<std::uint8_t>(std::numeric_limits<std::uint8_t>::min(), std::numeric_limits<std::uint8_t>::max());

        public: inline static Range<std::uint16_t> UInt16 = Range<std::uint16_t>(std::numeric_limits<std::uint16_t>::min(), std::numeric_limits<std::uint16_t>::max());

        public: inline static Range<std::uint32_t> UInt32 = Range<std::uint32_t>(std::numeric_limits<std::uint32_t>::min(), std::numeric_limits<std::uint32_t>::max());

        public: inline static Range<std::uint64_t> UInt64 = Range<std::uint64_t>(std::numeric_limits<std::uint64_t>::min(), std::numeric_limits<std::uint64_t>::max());

        public: inline static Range<float> Single = Range<float>(std::numeric_limits<float>::lowest(), std::numeric_limits<float>::max());

        public: inline static Range<double> Double = Range<double>(std::numeric_limits<double>::lowest(), std::numeric_limits<double>::max());

        public: inline static Range<decimal> Decimal = Range<decimal>(decimal.MinValue, decimal.MaxValue);
    };
}
