namespace Platform::Ranges
{
    class RangeExtensions
    {
        public: static std::uint64_t Difference(Range<std::uint64_t> range) { return range.Maximum - range.Minimum; }

        public: static std::uint32_t Difference(Range<std::uint32_t> range) { return range.Maximum - range.Minimum; }

        public: static std::uint16_t Difference(Range<std::uint16_t> range) { return (std::uint16_t)(range.Maximum - range.Minimum); }

        public: static std::uint8_t Difference(Range<std::uint8_t> range) { return (std::uint8_t)(range.Maximum - range.Minimum); }

        public: static std::int64_t Difference(Range<std::int64_t> range) { return range.Maximum - range.Minimum; }

        public: static std::int32_t Difference(Range<std::int32_t> range) { return range.Maximum - range.Minimum; }

        public: static std::int16_t Difference(Range<std::int16_t> range) { return (std::int16_t)(range.Maximum - range.Minimum); }

        public: static std::int8_t Difference(Range<std::int8_t> range) { return (std::int8_t)(range.Maximum - range.Minimum); }

        public: static double Difference(Range<double> range) { return range.Maximum - range.Minimum; }

        public: static float Difference(Range<float> range) { return range.Maximum - range.Minimum; }
    };
}
