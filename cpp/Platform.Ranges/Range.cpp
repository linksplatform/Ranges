namespace Platform::Ranges
{
    class Range
    {
        public: static readonly Range<std::int8_t> SByte = new Range<std::int8_t>(INT8_MIN, INT8_MAX);

        public: static readonly Range<std::int16_t> Int16 = new Range<std::int16_t>(INT16_MIN, INT16_MAX);

        public: static readonly Range<std::int32_t> Int32 = new Range<std::int32_t>(INT32_MIN, INT32_MAX);

        public: static readonly Range<std::int64_t> Int64 = new Range<std::int64_t>(INT64_MIN, INT64_MAX);

        public: static readonly Range<std::uint8_t> Byte = new Range<std::uint8_t>((std::uint8_t)0, UINT8_MAX);

        public: static readonly Range<std::uint16_t> UInt16 = new Range<std::uint16_t>((std::uint16_t)0, UINT16_MAX);

        public: static readonly Range<std::uint32_t> UInt32 = new Range<std::uint32_t>((std::uint32_t)0, UINT32_MAX);

        public: static readonly Range<std::uint64_t> UInt64 = new Range<std::uint64_t>((std::uint64_t)0, UINT64_MAX);

        public: static readonly Range<float> Single = new Range<float>(float.MinValue, float.MaxValue);

        public: static readonly Range<double> Double = new Range<double>(double.MinValue, double.MaxValue);

        public: static readonly Range<decimal> Decimal = new Range<decimal>(decimal.MinValue, decimal.MaxValue);
    };
}
