namespace Platform::Ranges
{
    class Range
    {
        public: static readonly Range<std::int8_t> SByte = new Range<std::int8_t>(std::numeric_limits<std::int8_t>::min(), std::numeric_limits<std::int8_t>::max());

        public: static readonly Range<std::int16_t> Int16 = new Range<std::int16_t>(std::numeric_limits<std::int16_t>::min(), std::numeric_limits<std::int16_t>::max());

        public: static readonly Range<std::int32_t> Int32 = new Range<std::int32_t>(std::numeric_limits<std::int32_t>::min(), std::numeric_limits<std::int32_t>::max());

        public: static readonly Range<std::int64_t> Int64 = new Range<std::int64_t>(std::numeric_limits<std::int64_t>::min(), std::numeric_limits<std::int64_t>::max());

        public: static readonly Range<std::uint8_t> Byte = new Range<std::uint8_t>(std::numeric_limits<std::uint8_t>::min(), std::numeric_limits<std::uint8_t>::max());

        public: static readonly Range<std::uint16_t> UInt16 = new Range<std::uint16_t>(std::numeric_limits<std::uint16_t>::min(), std::numeric_limits<std::uint16_t>::max());

        public: static readonly Range<std::uint32_t> UInt32 = new Range<std::uint32_t>(std::numeric_limits<std::uint32_t>::min(), std::numeric_limits<std::uint32_t>::max());

        public: static readonly Range<std::uint64_t> UInt64 = new Range<std::uint64_t>(std::numeric_limits<std::uint64_t>::min(), std::numeric_limits<std::uint64_t>::max());

        public: static readonly Range<float> Single = new Range<float>(std::numeric_limits<float>::min(), std::numeric_limits<float>::max());

        public: static readonly Range<double> Double = new Range<double>(std::numeric_limits<double>::min(), std::numeric_limits<double>::max());

        public: static readonly Range<decimal> Decimal = new Range<decimal>(decimal.MinValue, decimal.MaxValue);
    };
}
