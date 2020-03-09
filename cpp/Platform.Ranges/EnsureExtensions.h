﻿namespace Platform::Ranges
{
    class EnsureExtensions
    {
        private: inline static const char* DefaultMaximumShouldBeGreaterOrEqualToMinimumMessage = "Maximum should be greater or equal to minimum.";

        public: template <typename TArgument> static void MaximumArgumentIsGreaterOrEqualToMinimum(Platform::Exceptions::ExtensionRoots::EnsureAlwaysExtensionRoot root, TArgument minimumArgument, TArgument maximumArgument, const char* maximumArgumentName, std::function<const char*()> messageBuilder)
        {
            if (maximumArgument < minimumArgument)
            {
                throw std::invalid_argument(std::string("Invalid ").append(maximumArgumentName).append(" argument: ").append(messageBuilder()).append(1, '.'));
            }
        }

        public: template <typename TArgument> static void MaximumArgumentIsGreaterOrEqualToMinimum(Platform::Exceptions::ExtensionRoots::EnsureAlwaysExtensionRoot root, TArgument minimumArgument, TArgument maximumArgument, const char* maximumArgumentName, const char* message)
        {
            auto messageBuilder = [&]() -> const char* { return message; };
            MaximumArgumentIsGreaterOrEqualToMinimum(root, minimumArgument, maximumArgument, maximumArgumentName, messageBuilder);
        }

        public: template <typename TArgument> static void MaximumArgumentIsGreaterOrEqualToMinimum(Platform::Exceptions::ExtensionRoots::EnsureAlwaysExtensionRoot root, TArgument minimumArgument, TArgument maximumArgument, const char* maximumArgumentName) { MaximumArgumentIsGreaterOrEqualToMinimum(root, minimumArgument, maximumArgument, "maximumArgument", DefaultMaximumShouldBeGreaterOrEqualToMinimumMessage); }

        public: template <typename TArgument> static void MaximumArgumentIsGreaterOrEqualToMinimum(Platform::Exceptions::ExtensionRoots::EnsureAlwaysExtensionRoot root, TArgument minimumArgument, TArgument maximumArgument) { MaximumArgumentIsGreaterOrEqualToMinimum(root, minimumArgument, maximumArgument, "maximumArgument"); }

        public: template <typename TArgument> static void ArgumentInRange(Platform::Exceptions::ExtensionRoots::EnsureAlwaysExtensionRoot root, TArgument argumentValue, Range<TArgument> range, const char* argumentName, std::function<const char*()> messageBuilder)
        {
            if (!range.Contains(argumentValue))
            {
                throw std::invalid_argument(std::string("Value [").append(Platform::Converters::To<std::string>(argumentValue)).append("] of argument [").append(argumentName).append("] is out of range: ").append(messageBuilder()).append(1, '.'));
            }
        }

        public: template <typename TArgument> static void ArgumentInRange(Platform::Exceptions::ExtensionRoots::EnsureAlwaysExtensionRoot root, TArgument argumentValue, Range<TArgument> range, const char* argumentName, const char* message)
        {
            auto messageBuilder = [&]() -> const char* { return message; };
            ArgumentInRange(root, argumentValue, range, argumentName, messageBuilder);
        }

        public: template <typename TArgument> static void ArgumentInRange(Platform::Exceptions::ExtensionRoots::EnsureAlwaysExtensionRoot root, TArgument argumentValue, Range<TArgument> range, const char* argumentName)
        {
            auto messageBuilder = [&]() -> const char* { return std::string("Argument value [").append(Platform::Converters::To<std::string>(argumentValue)).append("] is out of range ").append(Platform::Converters::To<std::string>(range)).append(1, '.').data(); };
            ArgumentInRange(root, argumentValue, range, argumentName, messageBuilder);
        }

        public: template <typename TArgument> static void ArgumentInRange(Platform::Exceptions::ExtensionRoots::EnsureAlwaysExtensionRoot root, TArgument argumentValue, TArgument minimum, TArgument maximum, const char* argumentName) { ArgumentInRange(root, argumentValue, Range<TArgument>(minimum, maximum), argumentName); }

        public: template <typename TArgument> static void ArgumentInRange(Platform::Exceptions::ExtensionRoots::EnsureAlwaysExtensionRoot root, TArgument argumentValue, TArgument minimum, TArgument maximum) { ArgumentInRange(root, argumentValue, Range<TArgument>(minimum, maximum), nullptr); }

        public: template <typename TArgument> static void ArgumentInRange(Platform::Exceptions::ExtensionRoots::EnsureAlwaysExtensionRoot root, TArgument argumentValue, Range<TArgument> range) { ArgumentInRange(root, argumentValue, range, nullptr); }

        public: template <typename TArgument> static void MaximumArgumentIsGreaterOrEqualToMinimum(Platform::Exceptions::ExtensionRoots::EnsureOnDebugExtensionRoot root, TArgument minimumArgument, TArgument maximumArgument, const char* maximumArgumentName, std::function<const char*()> messageBuilder) { Platform::Ranges::EnsureExtensions::MaximumArgumentIsGreaterOrEqualToMinimum(Platform::Exceptions::Ensure::Always, minimumArgument, maximumArgument, maximumArgumentName, messageBuilder); }

        public: template <typename TArgument> static void MaximumArgumentIsGreaterOrEqualToMinimum(Platform::Exceptions::ExtensionRoots::EnsureOnDebugExtensionRoot root, TArgument minimumArgument, TArgument maximumArgument, const char* maximumArgumentName, const char* message) { Platform::Ranges::EnsureExtensions::MaximumArgumentIsGreaterOrEqualToMinimum(Platform::Exceptions::Ensure::Always, minimumArgument, maximumArgument, maximumArgumentName, message); }

        public: template <typename TArgument> static void MaximumArgumentIsGreaterOrEqualToMinimum(Platform::Exceptions::ExtensionRoots::EnsureOnDebugExtensionRoot root, TArgument minimumArgument, TArgument maximumArgument, const char* argumentName) { Platform::Ranges::EnsureExtensions::MaximumArgumentIsGreaterOrEqualToMinimum(Platform::Exceptions::Ensure::Always, minimumArgument, maximumArgument, argumentName); }

        public: template <typename TArgument> static void MaximumArgumentIsGreaterOrEqualToMinimum(Platform::Exceptions::ExtensionRoots::EnsureOnDebugExtensionRoot root, TArgument minimumArgument, TArgument maximumArgument) { Platform::Ranges::EnsureExtensions::MaximumArgumentIsGreaterOrEqualToMinimum(Platform::Exceptions::Ensure::Always, minimumArgument, maximumArgument, nullptr); }

        public: template <typename TArgument> static void ArgumentInRange(Platform::Exceptions::ExtensionRoots::EnsureOnDebugExtensionRoot root, TArgument argument, Range<TArgument> range, const char* argumentName, std::function<const char*()> messageBuilder) { Platform::Ranges::EnsureExtensions::ArgumentInRange(Platform::Exceptions::Ensure::Always, argument, range, argumentName, messageBuilder); }

        public: template <typename TArgument> static void ArgumentInRange(Platform::Exceptions::ExtensionRoots::EnsureOnDebugExtensionRoot root, TArgument argument, Range<TArgument> range, const char* argumentName, const char* message) { Platform::Ranges::EnsureExtensions::ArgumentInRange(Platform::Exceptions::Ensure::Always, argument, range, argumentName, message); }

        public: template <typename TArgument> static void ArgumentInRange(Platform::Exceptions::ExtensionRoots::EnsureOnDebugExtensionRoot root, TArgument argument, Range<TArgument> range, const char* argumentName) { Platform::Ranges::EnsureExtensions::ArgumentInRange(Platform::Exceptions::Ensure::Always, argument, range, argumentName); }

        public: template <typename TArgument> static void ArgumentInRange(Platform::Exceptions::ExtensionRoots::EnsureOnDebugExtensionRoot root, TArgument argumentValue, TArgument minimum, TArgument maximum) { Platform::Ranges::EnsureExtensions::ArgumentInRange(Platform::Exceptions::Ensure::Always, argumentValue, Range<TArgument>(minimum, maximum), nullptr); }

        public: template <typename TArgument> static void ArgumentInRange(Platform::Exceptions::ExtensionRoots::EnsureOnDebugExtensionRoot root, TArgument argumentValue, TArgument minimum, TArgument maximum, const char* argumentName) { Platform::Ranges::EnsureExtensions::ArgumentInRange(Platform::Exceptions::Ensure::Always, argumentValue, Range<TArgument>(minimum, maximum), argumentName); }

        public: template <typename TArgument> static void ArgumentInRange(Platform::Exceptions::ExtensionRoots::EnsureOnDebugExtensionRoot root, TArgument argument, Range<TArgument> range) { Platform::Ranges::EnsureExtensions::ArgumentInRange(Platform::Exceptions::Ensure::Always, argument, range, nullptr); }
    };
}
