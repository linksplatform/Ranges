namespace Platform::Ranges
{
    #define LIMIT_AS_RANGE(type) std::numeric_limits<type>::lowest(), std::numeric_limits<type>::max()

    constexpr auto SByte =  Range(LIMIT_AS_RANGE(std::int8_t));

    constexpr auto Int16 =  Range(LIMIT_AS_RANGE(std::int16_t));

    constexpr auto Int32 =  Range(LIMIT_AS_RANGE(std::int32_t));

    constexpr auto Int64 =  Range(LIMIT_AS_RANGE(std::int64_t));

    constexpr auto Byte =   Range(LIMIT_AS_RANGE(std::uint8_t));

    constexpr auto UInt16 = Range(LIMIT_AS_RANGE(std::uint16_t));

    constexpr auto UInt32 = Range(LIMIT_AS_RANGE(std::uint32_t));

    constexpr auto UInt64 = Range(LIMIT_AS_RANGE(std::uint64_t));

    constexpr auto Single = Range(LIMIT_AS_RANGE(std::float_t));

    constexpr auto Double = Range(LIMIT_AS_RANGE(std::double_t));

    #undef LIMIT_AS_RANGE
}
