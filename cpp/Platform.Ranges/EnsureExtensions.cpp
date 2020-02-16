namespace Platform::Ranges
{
    class EnsureExtensions
    {
        private: static const const char* DefaultMaximumShouldBeGreaterOrEqualToMinimumMessage = "Maximum should be greater or equal to minimum.";

        public: template <typename TArgument> static void MaximumArgumentIsGreaterOrEqualToMinimum(Platform::Exceptions::ExtensionRoots::EnsureAlwaysExtensionRoot root, TArgument minimumArgument, TArgument maximumArgument, const char* maximumArgumentName, std::function<const char*()> messageBuilder)
        {
            if (maximumArgument < minimumArgument)
            {
                throw std::invalid_argument(((std::string)"Invalid ").append(maximumArgumentName).append(" argument: ").append(messageBuilder()).append("."));
            }
        }

        public: template <typename TArgument> static void MaximumArgumentIsGreaterOrEqualToMinimum(Platform::Exceptions::ExtensionRoots::EnsureAlwaysExtensionRoot root, TArgument minimumArgument, TArgument maximumArgument, const char* maximumArgumentName, const char* message)
        {
            const char* messageBuilder() { return message; }
            MaximumArgumentIsGreaterOrEqualToMinimum(root, minimumArgument, maximumArgument, maximumArgumentName, messageBuilder);
        }

        public: template <typename TArgument> static void MaximumArgumentIsGreaterOrEqualToMinimum(Platform::Exceptions::ExtensionRoots::EnsureAlwaysExtensionRoot root, TArgument minimumArgument, TArgument maximumArgument, const char* maximumArgumentName) { MaximumArgumentIsGreaterOrEqualToMinimum(root, minimumArgument, maximumArgument, nameof(maximumArgument), DefaultMaximumShouldBeGreaterOrEqualToMinimumMessage); }

        public: template <typename TArgument> static void MaximumArgumentIsGreaterOrEqualToMinimum(Platform::Exceptions::ExtensionRoots::EnsureAlwaysExtensionRoot root, TArgument minimumArgument, TArgument maximumArgument) { MaximumArgumentIsGreaterOrEqualToMinimum(root, minimumArgument, maximumArgument, nameof(maximumArgument)); }

        public: template <typename TArgument> static void ArgumentInRange(Platform::Exceptions::ExtensionRoots::EnsureAlwaysExtensionRoot root, TArgument argumentValue, Range<TArgument> range, const char* argumentName, std::function<const char*()> messageBuilder)
        {
            if (!range.Contains(argumentValue))
            {
                throw std::invalid_argument(((std::string)"Value [").append(std::to_string(argumentValue)).append("] of argument [").append(argumentName).append("] is out of range: ").append(messageBuilder()).append("."));
            }
        }

        public: template <typename TArgument> static void ArgumentInRange(Platform::Exceptions::ExtensionRoots::EnsureAlwaysExtensionRoot root, TArgument argumentValue, Range<TArgument> range, const char* argumentName, const char* message)
        {
            const char* messageBuilder() { return message; }
            ArgumentInRange(root, argumentValue, range, argumentName, messageBuilder);
        }

        public: template <typename TArgument> static void ArgumentInRange(Platform::Exceptions::ExtensionRoots::EnsureAlwaysExtensionRoot root, TArgument argumentValue, Range<TArgument> range, const char* argumentName)
        {
            const char* messageBuilder() { return ((std::string)((std::string)"Argument value [").append(argumentValue).append("] is out of range ").data()).append(range).append(".").data(); }
            ArgumentInRange(root, argumentValue, range, argumentName, messageBuilder);
        }

        public: template <typename TArgument> static void ArgumentInRange(Platform::Exceptions::ExtensionRoots::EnsureAlwaysExtensionRoot root, TArgument argumentValue, TArgument minimum, TArgument maximum, const char* argumentName) { ArgumentInRange(root, argumentValue, new Range<TArgument>(minimum, maximum), argumentName); }

        public: template <typename TArgument> static void ArgumentInRange(Platform::Exceptions::ExtensionRoots::EnsureAlwaysExtensionRoot root, TArgument argumentValue, TArgument minimum, TArgument maximum) { ArgumentInRange(root, argumentValue, new Range<TArgument>(minimum, maximum), nullptr); }

        public: template <typename TArgument> static void ArgumentInRange(Platform::Exceptions::ExtensionRoots::EnsureAlwaysExtensionRoot root, TArgument argumentValue, Range<TArgument> range) { ArgumentInRange(root, argumentValue, range, nullptr); }

        public: template <typename TArgument> static void MaximumArgumentIsGreaterOrEqualToMinimum(Platform::Exceptions::ExtensionRoots::EnsureOnDebugExtensionRoot root, TArgument minimumArgument, TArgument maximumArgument, const char* maximumArgumentName, std::function<const char*()> messageBuilder) { Ensure.Always.MaximumArgumentIsGreaterOrEqualToMinimum(minimumArgument, maximumArgument, maximumArgumentName, messageBuilder); }

        public: template <typename TArgument> static void MaximumArgumentIsGreaterOrEqualToMinimum(Platform::Exceptions::ExtensionRoots::EnsureOnDebugExtensionRoot root, TArgument minimumArgument, TArgument maximumArgument, const char* maximumArgumentName, const char* message) { Ensure.Always.MaximumArgumentIsGreaterOrEqualToMinimum(minimumArgument, maximumArgument, maximumArgumentName, message); }

        public: template <typename TArgument> static void MaximumArgumentIsGreaterOrEqualToMinimum(Platform::Exceptions::ExtensionRoots::EnsureOnDebugExtensionRoot root, TArgument minimumArgument, TArgument maximumArgument, const char* argumentName) { Ensure.Always.MaximumArgumentIsGreaterOrEqualToMinimum(minimumArgument, maximumArgument, argumentName); }

        public: template <typename TArgument> static void MaximumArgumentIsGreaterOrEqualToMinimum(Platform::Exceptions::ExtensionRoots::EnsureOnDebugExtensionRoot root, TArgument minimumArgument, TArgument maximumArgument) { Ensure.Always.MaximumArgumentIsGreaterOrEqualToMinimum(minimumArgument, maximumArgument, nullptr); }

        public: template <typename TArgument> static void ArgumentInRange(Platform::Exceptions::ExtensionRoots::EnsureOnDebugExtensionRoot root, TArgument argument, Range<TArgument> range, const char* argumentName, std::function<const char*()> messageBuilder) { Ensure.Always.ArgumentInRange(argument, range, argumentName, messageBuilder); }

        public: template <typename TArgument> static void ArgumentInRange(Platform::Exceptions::ExtensionRoots::EnsureOnDebugExtensionRoot root, TArgument argument, Range<TArgument> range, const char* argumentName, const char* message) { Ensure.Always.ArgumentInRange(argument, range, argumentName, message); }

        public: template <typename TArgument> static void ArgumentInRange(Platform::Exceptions::ExtensionRoots::EnsureOnDebugExtensionRoot root, TArgument argument, Range<TArgument> range, const char* argumentName) { Ensure.Always.ArgumentInRange(argument, range, argumentName); }

        public: template <typename TArgument> static void ArgumentInRange(Platform::Exceptions::ExtensionRoots::EnsureOnDebugExtensionRoot root, TArgument argumentValue, TArgument minimum, TArgument maximum) { Ensure.Always.ArgumentInRange(argumentValue, new Range<TArgument>(minimum, maximum), nullptr); }

        public: template <typename TArgument> static void ArgumentInRange(Platform::Exceptions::ExtensionRoots::EnsureOnDebugExtensionRoot root, TArgument argumentValue, TArgument minimum, TArgument maximum, const char* argumentName) { Ensure.Always.ArgumentInRange(argumentValue, new Range<TArgument>(minimum, maximum), argumentName); }

        public: template <typename TArgument> static void ArgumentInRange(Platform::Exceptions::ExtensionRoots::EnsureOnDebugExtensionRoot root, TArgument argument, Range<TArgument> range) { Ensure.Always.ArgumentInRange(argument, range, nullptr); }
    };
}
