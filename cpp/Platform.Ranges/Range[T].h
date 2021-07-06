namespace Platform::Ranges
{
    namespace Internal
    {
        template<typename Self>
        concept formattable = requires(Self self)
        {
            { Converters::To<std::string>(self) };
        };

        template<typename Self>
        concept ranged = std::three_way_comparable<Self> and formattable<Self>;
    }

    namespace Always
    {
        template<typename TArgument>
        void MaximumArgumentIsGreaterOrEqualToMinimum(TArgument&& minimumArgument, TArgument&& maximumArgument, const std::string& maximumArgumentName);
    }

    template <typename ...> struct Range;
    template <Internal::ranged T> struct Range<T>
    {
        public: const T Minimum;

        public: const T Maximum;

        public: explicit Range(T minimumAndMaximum) noexcept
            : Minimum(std::move(minimumAndMaximum)), Maximum(std::move(minimumAndMaximum))
        {
        }

        public: constexpr Range(T minimum, T maximum)
            : Minimum(std::move(minimum)), Maximum(std::move(maximum))
        {
            if (minimum > maximum) // for constexpr
            {
                Always::MaximumArgumentIsGreaterOrEqualToMinimum(minimum, maximum, "maximum");
            }
        }

        public: explicit operator std::string() const { return std::string("[").append(Converters::To<std::string>(Minimum)).append(", ").append(Converters::To<std::string>(Maximum)).append(1, ']'); }

        public: friend std::ostream& operator<<(std::ostream& out, const Range<T>& obj) { return out << (std::string)obj; }

        public: constexpr bool Contains(T value) noexcept { return Minimum <= value && Maximum >= value; }

        public: constexpr bool Contains(const Range<T>& range) noexcept { return Contains(range.Minimum) && Contains(range.Maximum); }

        public: constexpr bool operator==(const Range<T> &other) const noexcept { return Minimum == other.Minimum && Maximum == other.Maximum; }

        public: constexpr explicit operator std::tuple<T, T>() const noexcept { return { Minimum, Maximum }; }

        public: constexpr explicit Range(std::tuple<T, T> tuple) : Range(std::get<0>(tuple), std::get<1>(tuple)) noexcept { }

        // TODO: @Voider extension
        template<typename TOther> requires std::convertible_to<T, TOther>
        constexpr explicit operator Range<TOther>() const noexcept
        {
            return Range<TOther>(Minimum, Maximum);
        }
    };

    // TODO: @Voider extension
    template<typename T, typename... U> requires (Range<int>(0, 1).Contains(sizeof...(U)))
    Range(T, U...) -> Range<T>;
}

namespace std
{
    template <typename T>
    struct hash<Platform::Ranges::Range<T>>
    {
        std::size_t operator()(const Platform::Ranges::Range<T>& obj) const
        {
            return Platform::Hashing::Hash(obj.Minimum, obj.Maximum);
        }
    };
}
