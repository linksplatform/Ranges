namespace Platform::Ranges
{
    namespace Internal
    {
        template<typename T>
        constexpr Range<T> FullRange() noexcept
        {
            return Range<T>(std::numeric_limits<T>::lowest(), std::numeric_limits<T>::max());
        }
    }

    constexpr auto SByte  = Internal::FullRange<std::int8_t>();

    constexpr auto Int16  = Internal::FullRange<std::int16_t>();

    constexpr auto Int32  = Internal::FullRange<std::int32_t>();

    constexpr auto Int64  = Internal::FullRange<std::int64_t>();

    constexpr auto Byte   = Internal::FullRange<std::uint8_t>();

    constexpr auto UInt16 = Internal::FullRange<std::uint16_t>();

    constexpr auto UInt32 = Internal::FullRange<std::uint32_t>();

    constexpr auto UInt64 = Internal::FullRange<std::uint64_t>();

    constexpr auto Single = Internal::FullRange<std::float_t>();

    constexpr auto Double = Internal::FullRange<std::double_t>();
}
