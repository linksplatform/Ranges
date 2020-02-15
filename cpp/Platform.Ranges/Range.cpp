namespace Platform::Ranges
{
    class Range
    {
        public: static readonly Range<std::int8_t> SByte = new Range<std::int8_t>(std::int8_t.MinValue, std::int8_t.MaxValue);

        public: static readonly Range<short> Int16 = new Range<short>(short.MinValue, short.MaxValue);

        public: static readonly Range<int> Int32 = new Range<int>(int.MinValue, int.MaxValue);

        public: static readonly Range<long> Int64 = new Range<long>(long.MinValue, long.MaxValue);

        public: static readonly Range<byte> Byte = new Range<byte>(byte.MinValue, byte.MaxValue);

        public: static readonly Range<ushort> UInt16 = new Range<ushort>(ushort.MinValue, ushort.MaxValue);

        public: static readonly Range<std::uint32_t> UInt32 = new Range<std::uint32_t>(std::uint32_t.MinValue, std::uint32_t.MaxValue);

        public: static readonly Range<ulong> UInt64 = new Range<ulong>(ulong.MinValue, ulong.MaxValue);

        public: static readonly Range<float> Single = new Range<float>(float.MinValue, float.MaxValue);

        public: static readonly Range<double> Double = new Range<double>(double.MinValue, double.MaxValue);

        public: static readonly Range<decimal> Decimal = new Range<decimal>(decimal.MinValue, decimal.MaxValue);
    };
}
