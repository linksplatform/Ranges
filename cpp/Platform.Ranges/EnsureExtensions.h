namespace Platform::Ranges
{
    class EnsureExtensions
    {
        private: inline static std::string DefaultMaximumShouldBeGreaterOrEqualToMinimumMessage = "Maximum should be greater or equal to minimum.";

        public: template <typename TArgument> static void MaximumArgumentIsGreaterOrEqualToMinimum(Platform::Exceptions::ExtensionRoots::EnsureAlwaysExtensionRoot root, TArgument minimumArgument, TArgument maximumArgument, std::string maximumArgumentName, std::function<std::string()> messageBuilder)
        {
            if (maximumArgument < minimumArgument)
            {
                throw std::invalid_argument(std::string("Invalid ").append(maximumArgumentName).append(" argument: ").append(messageBuilder()).append(1, '.'));
            }
        }

        public: template <typename TArgument> static void MaximumArgumentIsGreaterOrEqualToMinimum(Platform::Exceptions::ExtensionRoots::EnsureAlwaysExtensionRoot root, TArgument minimumArgument, TArgument maximumArgument, std::string maximumArgumentName, std::string message)
        {
            auto messageBuilder = [&]() -> std::string { return message; };
            MaximumArgumentIsGreaterOrEqualToMinimum(root, minimumArgument, maximumArgument, maximumArgumentName, messageBuilder);
        }

        public: template <typename TArgument> static void MaximumArgumentIsGreaterOrEqualToMinimum(Platform::Exceptions::ExtensionRoots::EnsureAlwaysExtensionRoot root, TArgument minimumArgument, TArgument maximumArgument, std::string maximumArgumentName) { MaximumArgumentIsGreaterOrEqualToMinimum(root, minimumArgument, maximumArgument, "maximumArgument", DefaultMaximumShouldBeGreaterOrEqualToMinimumMessage); }

        public: template <typename TArgument> static void MaximumArgumentIsGreaterOrEqualToMinimum(Platform::Exceptions::ExtensionRoots::EnsureAlwaysExtensionRoot root, TArgument minimumArgument, TArgument maximumArgument) { MaximumArgumentIsGreaterOrEqualToMinimum(root, minimumArgument, maximumArgument, "maximumArgument"); }

        public: template <typename TArgument> static void ArgumentInRange(Platform::Exceptions::ExtensionRoots::EnsureAlwaysExtensionRoot root, TArgument argumentValue, Range<TArgument> range, std::string argumentName, std::function<std::string()> messageBuilder)
        {
            if (!range.Contains(argumentValue))
            {
                throw std::invalid_argument(std::string("Value [").append(Platform::Converters::To<std::string>(argumentValue)).append("] of argument [").append(argumentName).append("] is out of range: ").append(messageBuilder()).append(1, '.'));
            }
        }

        public: template <typename TArgument> static void ArgumentInRange(Platform::Exceptions::ExtensionRoots::EnsureAlwaysExtensionRoot root, TArgument argumentValue, Range<TArgument> range, std::string argumentName, std::string message)
        {
            auto messageBuilder = [&]() -> std::string { return message; };
            ArgumentInRange(root, argumentValue, range, argumentName, messageBuilder);
        }

        public: template <typename TArgument> static void ArgumentInRange(Platform::Exceptions::ExtensionRoots::EnsureAlwaysExtensionRoot root, TArgument argumentValue, Range<TArgument> range, std::string argumentName)
        {
            auto messageBuilder = [&]() -> std::string { return std::string("Argument value [").append(Platform::Converters::To<std::string>(argumentValue)).append("] is out of range ").append(Platform::Converters::To<std::string>(range)).append(1, '.'); };
            ArgumentInRange(root, argumentValue, range, argumentName, messageBuilder);
        }

        public: template <typename TArgument> static void ArgumentInRange(Platform::Exceptions::ExtensionRoots::EnsureAlwaysExtensionRoot root, TArgument argumentValue, TArgument minimum, TArgument maximum, std::string argumentName) { ArgumentInRange(root, argumentValue, Range<TArgument>(minimum, maximum), argumentName); }

        public: template <typename TArgument> static void ArgumentInRange(Platform::Exceptions::ExtensionRoots::EnsureAlwaysExtensionRoot root, TArgument argumentValue, TArgument minimum, TArgument maximum) { ArgumentInRange(root, argumentValue, Range<TArgument>(minimum, maximum), {}); }

        public: template <typename TArgument> static void ArgumentInRange(Platform::Exceptions::ExtensionRoots::EnsureAlwaysExtensionRoot root, TArgument argumentValue, Range<TArgument> range) { ArgumentInRange(root, argumentValue, range, {}); }

        public: template <typename TArgument> static void MaximumArgumentIsGreaterOrEqualToMinimum(Platform::Exceptions::ExtensionRoots::EnsureOnDebugExtensionRoot root, TArgument minimumArgument, TArgument maximumArgument, std::string maximumArgumentName, std::function<std::string()> messageBuilder) { Platform::Ranges::EnsureExtensions::MaximumArgumentIsGreaterOrEqualToMinimum(Platform::Exceptions::Ensure::Always, minimumArgument, maximumArgument, maximumArgumentName, messageBuilder); }

        public: template <typename TArgument> static void MaximumArgumentIsGreaterOrEqualToMinimum(Platform::Exceptions::ExtensionRoots::EnsureOnDebugExtensionRoot root, TArgument minimumArgument, TArgument maximumArgument, std::string maximumArgumentName, std::string message) { Platform::Ranges::EnsureExtensions::MaximumArgumentIsGreaterOrEqualToMinimum(Platform::Exceptions::Ensure::Always, minimumArgument, maximumArgument, maximumArgumentName, message); }

        public: template <typename TArgument> static void MaximumArgumentIsGreaterOrEqualToMinimum(Platform::Exceptions::ExtensionRoots::EnsureOnDebugExtensionRoot root, TArgument minimumArgument, TArgument maximumArgument, std::string argumentName) { Platform::Ranges::EnsureExtensions::MaximumArgumentIsGreaterOrEqualToMinimum(Platform::Exceptions::Ensure::Always, minimumArgument, maximumArgument, argumentName); }

        public: template <typename TArgument> static void MaximumArgumentIsGreaterOrEqualToMinimum(Platform::Exceptions::ExtensionRoots::EnsureOnDebugExtensionRoot root, TArgument minimumArgument, TArgument maximumArgument) { Platform::Ranges::EnsureExtensions::MaximumArgumentIsGreaterOrEqualToMinimum(Platform::Exceptions::Ensure::Always, minimumArgument, maximumArgument, {}); }

        public: template <typename TArgument> static void ArgumentInRange(Platform::Exceptions::ExtensionRoots::EnsureOnDebugExtensionRoot root, TArgument argument, Range<TArgument> range, std::string argumentName, std::function<std::string()> messageBuilder) { Platform::Ranges::EnsureExtensions::ArgumentInRange(Platform::Exceptions::Ensure::Always, argument, range, argumentName, messageBuilder); }

        public: template <typename TArgument> static void ArgumentInRange(Platform::Exceptions::ExtensionRoots::EnsureOnDebugExtensionRoot root, TArgument argument, Range<TArgument> range, std::string argumentName, std::string message) { Platform::Ranges::EnsureExtensions::ArgumentInRange(Platform::Exceptions::Ensure::Always, argument, range, argumentName, message); }

        public: template <typename TArgument> static void ArgumentInRange(Platform::Exceptions::ExtensionRoots::EnsureOnDebugExtensionRoot root, TArgument argument, Range<TArgument> range, std::string argumentName) { Platform::Ranges::EnsureExtensions::ArgumentInRange(Platform::Exceptions::Ensure::Always, argument, range, argumentName); }

        public: template <typename TArgument> static void ArgumentInRange(Platform::Exceptions::ExtensionRoots::EnsureOnDebugExtensionRoot root, TArgument argumentValue, TArgument minimum, TArgument maximum) { Platform::Ranges::EnsureExtensions::ArgumentInRange(Platform::Exceptions::Ensure::Always, argumentValue, Range<TArgument>(minimum, maximum), {}); }

        public: template <typename TArgument> static void ArgumentInRange(Platform::Exceptions::ExtensionRoots::EnsureOnDebugExtensionRoot root, TArgument argumentValue, TArgument minimum, TArgument maximum, std::string argumentName) { Platform::Ranges::EnsureExtensions::ArgumentInRange(Platform::Exceptions::Ensure::Always, argumentValue, Range<TArgument>(minimum, maximum), argumentName); }

        public: template <typename TArgument> static void ArgumentInRange(Platform::Exceptions::ExtensionRoots::EnsureOnDebugExtensionRoot root, TArgument argument, Range<TArgument> range) { Platform::Ranges::EnsureExtensions::ArgumentInRange(Platform::Exceptions::Ensure::Always, argument, range, {}); }
    };
}
