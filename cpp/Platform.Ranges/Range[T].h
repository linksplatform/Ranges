namespace Platform::Ranges
{
    namespace Internal
    {
        template<typename T>
        struct protector
        {
            static constexpr bool stop = false;
        };

        template<typename To>
        void implicit_helper(To to) noexcept
        {
            static_assert(protector<To>::stop,
                "implicit_helper() must not be used!");
        }

        template<typename From, typename To>
        concept implicit_convertible_to = requires(From from)
        {
            implicit_helper<To>(from);
        };

        template<typename Self>
        concept formattable = requires(Self self)
        {
            { Converters::To<std::string>(self) };
        };
    }

    namespace Ensure::Always
    {
        template<typename TArgument>
        void MaximumArgumentIsGreaterOrEqualToMinimum(TArgument&& minimumArgument, TArgument&& maximumArgument, const std::string& maximumArgumentName);
    }

    template <typename ...> struct Range;
    template <std::three_way_comparable T> struct Range<T>
    {
        public: const T Minimum;

        public: const T Maximum;

        public: constexpr explicit Range(T minimumAndMaximum) noexcept
            : Minimum(std::move(minimumAndMaximum)), Maximum(Minimum)
        {
        }

        public: constexpr Range(T minimum, T maximum)
            : Minimum(std::move(minimum)), Maximum(std::move(maximum))
        {
            if (Minimum > Maximum) // for constexpr support
            {
                Ensure::Always::MaximumArgumentIsGreaterOrEqualToMinimum(minimum, maximum, "maximum");
            }
        }

        public: explicit operator std::string() const requires Internal::formattable<T> { return std::string("[").append(Converters::To<std::string>(Minimum)).append(", ").append(Converters::To<std::string>(Maximum)).append(1, ']'); }

        public: friend std::ostream& operator<<(std::ostream& out, const Range<T>& obj) { return out << (std::string)obj; }

        public: [[nodiscard]] constexpr bool Contains(T value) const noexcept { return Minimum <= value && Maximum >= value; }

        public: [[nodiscard]] constexpr bool Contains(const Range<T>& range) const noexcept { return Contains(range.Minimum) && Contains(range.Maximum); }

        public: constexpr bool operator==(const Range<T>& other) const noexcept { return Minimum == other.Minimum && Maximum == other.Maximum; }

        public: constexpr operator std::tuple<T, T>() const noexcept { return { Minimum, Maximum }; }

        public: constexpr explicit Range(std::tuple<T, T> tuple) noexcept : Range(std::get<0>(tuple), std::get<1>(tuple))  { }

        public: template<std::convertible_to<T> TOther> requires std::convertible_to<T, TOther> constexpr explicit(not Internal::implicit_convertible_to<T, TOther>) operator Range<TOther>() const noexcept(noexcept(static_cast<TOther>(Minimum))) { return Range<TOther>(static_cast<TOther>(Minimum), static_cast<TOther>(Maximum)); }
    };

    template<typename T, typename... U>
    Range(T, U...) -> Range<std::common_type_t<T, U...>>;
}

namespace std
{
    template<typename T>
    struct hash<Platform::Ranges::Range<T>>
    {
        std::size_t operator()(const Platform::Ranges::Range<T>& obj) const
        {
            return Platform::Hashing::Hash(obj.Minimum, obj.Maximum);
        }
    };
}
