namespace Platform::Ranges::Ensure::Always
{
    const std::string DefaultMaximumShouldBeGreaterOrEqualToMinimumMessage = "Maximum should be greater or equal to minimum.";

    template<typename TArgument>
    void MaximumArgumentIsGreaterOrEqualToMinimum(TArgument&& minimumArgument, TArgument&& maximumArgument, const std::string& maximumArgumentName, auto&& messageBuilder)
        requires requires { { messageBuilder() } -> std::same_as<std::string>; }
    {
        if (maximumArgument < minimumArgument)
        {
            throw std::invalid_argument(std::string("Invalid ").append(maximumArgumentName).append(" argument: ").append(messageBuilder()).append(1, '.'));
        }
    }

    template <typename TArgument>
    void MaximumArgumentIsGreaterOrEqualToMinimum(TArgument&& minimumArgument, TArgument&& maximumArgument, const std::string& maximumArgumentName, std::string message)
    {
        auto messageBuilder = [&message]() { return message; };
        MaximumArgumentIsGreaterOrEqualToMinimum(minimumArgument, maximumArgument, maximumArgumentName, messageBuilder);
    }

    template <typename TArgument>
    void MaximumArgumentIsGreaterOrEqualToMinimum(TArgument&& minimumArgument, TArgument&& maximumArgument, const std::string& maximumArgumentName)
    {
        MaximumArgumentIsGreaterOrEqualToMinimum(minimumArgument, maximumArgument, "maximumArgument", DefaultMaximumShouldBeGreaterOrEqualToMinimumMessage);
    }

    template <typename TArgument>
    void MaximumArgumentIsGreaterOrEqualToMinimum(TArgument&& minimumArgument, TArgument&& maximumArgument) { MaximumArgumentIsGreaterOrEqualToMinimum(minimumArgument, maximumArgument, "maximumArgument"); }

    template <typename TArgument, typename RTArgument = std::decay_t<TArgument>>
    void ArgumentInRange(TArgument&& argumentValue, Range<RTArgument> range, const std::string& argumentName, auto&& messageBuilder)
        requires requires { { messageBuilder() } -> std::same_as<std::string>; }
    {
        if (!range.Contains(argumentValue))
        {
            throw std::invalid_argument(std::string("Value [").append(Converters::To<std::string>(argumentValue)).append("] of argument [").append(argumentName).append("] is out of range: ").append(messageBuilder()).append(1, '.'));
        }
    }

    template <typename TArgument>
    void ArgumentInRange(TArgument&& argumentValue, const Range<TArgument>& range, const std::string& argumentName, const std::string& message)
    {
        auto messageBuilder = [&message](){ return message; };
        ArgumentInRange(argumentValue, range, argumentName, messageBuilder);
    }

    template <typename TArgument, typename RTArgument = std::decay_t<TArgument>>
    void ArgumentInRange(TArgument&& argumentValue, Range<RTArgument> range, const std::string& argumentName)
    {
        auto messageBuilder = [&argumentValue, &range]() { return std::string("Argument value [").append(Converters::To<std::string>(argumentValue)).append("] is out of range ").append(Converters::To<std::string>(range)).append(1, '.'); };
        ArgumentInRange(argumentValue, range, argumentName, messageBuilder);
    }

    template <typename TArgument, typename RTArgument = std::decay_t<TArgument>>
    void ArgumentInRange(TArgument&& argumentValue, TArgument&& minimum, TArgument&& maximum, const std::string& argumentName) { ArgumentInRange(argumentValue, Range{minimum, maximum}, argumentName); }

    template <typename TArgument>
    void ArgumentInRange(TArgument&& argumentValue, TArgument&& minimum, TArgument&& maximum) { ArgumentInRange(argumentValue, Range{minimum, maximum}, {}); }

    template <typename TArgument, typename T>
    void ArgumentInRange(TArgument&& argumentValue, Range<T> range) { ArgumentInRange(argumentValue, range, {}); }
}

namespace Platform::Ranges::Ensure::OnDebug
{
    void MaximumArgumentIsGreaterOrEqualToMinimum(auto&&... args)
    #ifdef NDEBUG
        noexcept {}
    #else
        { Always::MaximumArgumentIsGreaterOrEqualToMinimum(std::forward<decltype(args)>(args)...); }
    #endif

    void ArgumentInRange(auto&&... args)
    #ifdef NDEBUG
        noexcept {}
    #else
        { Always::ArgumentInRange(std::forward<decltype(args)>(args)...); }
    #endif
}
