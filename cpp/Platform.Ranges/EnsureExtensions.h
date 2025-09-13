namespace Platform::Ranges::Ensure::Always
{
    constexpr std::string_view DefaultMaximumShouldBeGreaterOrEqualToMinimumMessage = "Maximum should be greater or equal to minimum.";

    template<typename TArgument>
    void MaximumArgumentIsGreaterOrEqualToMinimum(TArgument&& minimumArgument, TArgument&& maximumArgument, std::string_view maximumArgumentName, std::string_view message)
    {
        if (maximumArgument < minimumArgument)
        {
            throw std::invalid_argument(std::string("Invalid ").append(maximumArgumentName).append(" argument: ").append(message).append(1, '.'));
        }
    }

    template <typename TArgument>
    void MaximumArgumentIsGreaterOrEqualToMinimum(TArgument&& minimumArgument, TArgument&& maximumArgument, std::string_view maximumArgumentName)
    {
        MaximumArgumentIsGreaterOrEqualToMinimum(minimumArgument, maximumArgument, maximumArgumentName, DefaultMaximumShouldBeGreaterOrEqualToMinimumMessage);
    }

    template <typename TArgument>
    void MaximumArgumentIsGreaterOrEqualToMinimum(TArgument&& minimumArgument, TArgument&& maximumArgument) noexcept(false)
    { 
        MaximumArgumentIsGreaterOrEqualToMinimum(minimumArgument, maximumArgument, "maximumArgument"); 
    }

    template <typename TArgument, typename T = std::decay_t<TArgument>>
    void ArgumentInRange(TArgument&& argumentValue, const Range<T>& range, std::string_view argumentName, std::string_view message)
    {
        if (!range.Contains(argumentValue))
        {
            throw std::invalid_argument(std::string("Value [").append(Converters::To<std::string>(argumentValue)).append("] of argument [").append(argumentName).append("] is out of range: ").append(message).append(1, '.'));
        }
    }

    template <typename TArgument, typename T = std::decay_t<TArgument>>
    void ArgumentInRange(TArgument&& argumentValue, const Range<T>& range, std::string_view argumentName = {})
    {
        if (!range.Contains(argumentValue))
        {
            std::string message = std::string("Argument value [").append(Converters::To<std::string>(argumentValue)).append("] is out of range ").append(Converters::To<std::string>(range)).append(1, '.');
            throw std::invalid_argument(std::string("Value [").append(Converters::To<std::string>(argumentValue)).append("] of argument [").append(argumentName).append("] is out of range: ").append(message).append(1, '.'));
        }
    }

    template <typename TArgument>
    void ArgumentInRange(TArgument&& argumentValue, TArgument&& minimum, TArgument&& maximum, std::string_view argumentName = {}) 
    { 
        ArgumentInRange(argumentValue, Range{minimum, maximum}, argumentName); 
    }
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
