namespace Platform::Ranges
{
    class RangeExtensions
    {
        public: static ulong Difference(Range<ulong> range) { return range.Maximum - range.Minimum; }

        public: static std::uint32_t Difference(Range<std::uint32_t> range) { return range.Maximum - range.Minimum; }

        public: static ushort Difference(Range<ushort> range) { return (ushort)(range.Maximum - range.Minimum); }

        public: static byte Difference(Range<byte> range) { return (byte)(range.Maximum - range.Minimum); }

        public: static long Difference(Range<long> range) { return range.Maximum - range.Minimum; }

        public: static int Difference(Range<int> range) { return range.Maximum - range.Minimum; }

        public: static short Difference(Range<short> range) { return (short)(range.Maximum - range.Minimum); }

        public: static std::int8_t Difference(Range<std::int8_t> range) { return (std::int8_t)(range.Maximum - range.Minimum); }

        public: static double Difference(Range<double> range) { return range.Maximum - range.Minimum; }

        public: static float Difference(Range<float> range) { return range.Maximum - range.Minimum; }

        public: static decimal Difference(Range<decimal> range) { return range.Maximum - range.Minimum; }
    };
}
