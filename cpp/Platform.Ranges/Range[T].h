namespace Platform::Ranges
{
    namespace Internal
    {
        template<typename Self>
        concept formattable = requires(Self self)
        {
            { Converters::To<std::string>(self) };
        };

        template<typename From, typename To>
        From __implicit_helper(const To& to)
        {
            return to;
        }

        template<typename From, typename To>
        concept implicit_convertible_to = std::convertible_to<From, To> &&
            requires(From from, To to)
            {
                __implicit_helper<From>(to);
            };


        enum class __common_type_result { _, T, U };

        template<typename T, typename U>
        consteval __common_type_result __common_type_selecter()
        {
            if (implicit_convertible_to<U, T>)
                return __common_type_result::T;

            if (implicit_convertible_to<T, U>)
                return __common_type_result::U;
        }

        template<typename T, typename U, __common_type_result>
        struct __common_type;

        template<typename T, typename U>
        struct __common_type<T, U, __common_type_result::T>
        {
            using type = T;
        };

        template<typename T, typename U>
        struct __common_type<T, U, __common_type_result::U>
        {
            using type = U;
        };

        template<typename T, typename U>
        struct common_type : __common_type<T, U, __common_type_selecter<T, U>()> {};

        template<typename T, typename U>
        using common_type_t = typename common_type<T, U>::type;
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

        public: explicit Range(T minimumAndMaximum) noexcept
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

        public: constexpr explicit operator std::tuple<T, T>() const noexcept { return { Minimum, Maximum }; }

        public: constexpr explicit Range(std::tuple<T, T> tuple) noexcept : Range(std::get<0>(tuple), std::get<1>(tuple))  { }


    public: // TODO: @Voider extensions
        template<typename TOther> requires std::equality_comparable_with<T, TOther>
        constexpr bool operator==(const Range<TOther>& other) const noexcept
        {
            return Minimum == other.Minimum && Maximum == other.Maximum;
        }

        template<typename TOther> requires std::convertible_to<T, TOther>
        constexpr explicit(not Internal::implicit_convertible_to<T, TOther>)
        operator Range<TOther>() const noexcept
        {
            return Range<TOther>(static_cast<TOther>(Minimum), static_cast<TOther>(Maximum));
        }
    };

    template<typename T>
    Range(T) -> Range<T>;

    template<typename T, typename U> requires std::is_arithmetic_v<T> && std::is_arithmetic_v<U>
    Range(T, U) -> Range<std::common_type_t<T, U>>;

    template<typename T, typename U>
    Range(T, U) -> Range<Internal::common_type_t<T, U>>;
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
