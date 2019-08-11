using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Platform.Exceptions;
using Platform.Exceptions.ExtensionRoots;

#pragma warning disable IDE0060 // Remove unused parameter

namespace Platform.Ranges
{
    public static class EnsureExtensions
    {
        private const string DefaultMaximumShouldBeGreaterOrEqualToMinimumMessage = "Maximum should be greater or equal to minimum.";

        #region Always

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void MaximumArgumentIsGreaterOrEqualToMinimum<T>(this EnsureAlwaysExtensionRoot root, T minimum, T maximum) => MaximumArgumentIsGreaterOrEqualToMinimum(root, minimum, maximum, nameof(maximum));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void MaximumArgumentIsGreaterOrEqualToMinimum<T>(this EnsureAlwaysExtensionRoot root, T minimum, T maximum, string argumentName) => MaximumArgumentIsGreaterOrEqualToMinimum(root, minimum, maximum, nameof(maximum), DefaultMaximumShouldBeGreaterOrEqualToMinimumMessage);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void MaximumArgumentIsGreaterOrEqualToMinimum<T>(this EnsureAlwaysExtensionRoot root, T minimum, T maximum, string argumentName, string message)
        {
            string messageBuilder() => message;
            MaximumArgumentIsGreaterOrEqualToMinimum(root, minimum, maximum, argumentName, messageBuilder);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void MaximumArgumentIsGreaterOrEqualToMinimum<T>(this EnsureAlwaysExtensionRoot root, T minimum, T maximum, string argumentName, Func<string> messageBuilder)
        {
            if (Comparer<T>.Default.Compare(maximum, minimum) < 0)
            {
                throw new ArgumentException(messageBuilder(), argumentName);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ArgumentInRange<T>(this EnsureAlwaysExtensionRoot root, T argumentValue, T minimum, T maximum) => ArgumentInRange(root, argumentValue, new Range<T>(minimum, maximum), null);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ArgumentInRange<T>(this EnsureAlwaysExtensionRoot root, T argumentValue, T minimum, T maximum, string argumentName) => ArgumentInRange(root, argumentValue, new Range<T>(minimum, maximum), argumentName);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ArgumentInRange<T>(this EnsureAlwaysExtensionRoot root, T argumentValue, Range<T> range) => ArgumentInRange(root, argumentValue, range, null);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ArgumentInRange<T>(this EnsureAlwaysExtensionRoot root, T argumentValue, Range<T> range, string argumentName)
        {
            string messageBuilder() => $"Argument value [{argumentValue}] is out of range {range}.";
            ArgumentInRange(root, argumentValue, range, argumentName, messageBuilder);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ArgumentInRange<T>(this EnsureAlwaysExtensionRoot root, T argumentValue, Range<T> range, string argumentName, string message)
        {
            string messageBuilder() => message;
            ArgumentInRange(root, argumentValue, range, argumentName, messageBuilder);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ArgumentInRange<T>(this EnsureAlwaysExtensionRoot root, T argumentValue, Range<T> range, string argumentName, Func<string> messageBuilder)
        {
            if (!range.ContainsValue(argumentValue))
            {
                throw new ArgumentOutOfRangeException(argumentName, argumentValue, messageBuilder());
            }
        }

        #endregion

        #region OnDebug

        [Conditional("DEBUG")]
        public static void MaximumArgumentIsGreaterOrEqualToMinimum<T>(this EnsureOnDebugExtensionRoot root, T minimum, T maximum) => Ensure.Always.MaximumArgumentIsGreaterOrEqualToMinimum(minimum, maximum, null);

        [Conditional("DEBUG")]
        public static void MaximumArgumentIsGreaterOrEqualToMinimum<T>(this EnsureOnDebugExtensionRoot root, T minimum, T maximum, string argumentName) => Ensure.Always.MaximumArgumentIsGreaterOrEqualToMinimum(minimum, maximum, argumentName);

        [Conditional("DEBUG")]
        public static void MaximumArgumentIsGreaterOrEqualToMinimum<T>(this EnsureOnDebugExtensionRoot root, T minimum, T maximum, string argumentName, string message) => Ensure.Always.MaximumArgumentIsGreaterOrEqualToMinimum(minimum, maximum, argumentName, message);

        [Conditional("DEBUG")]
        public static void MaximumArgumentIsGreaterOrEqualToMinimum<T>(this EnsureOnDebugExtensionRoot root, T minimum, T maximum, string argumentName, Func<string> messageBuilder) => Ensure.Always.MaximumArgumentIsGreaterOrEqualToMinimum(minimum, maximum, argumentName, messageBuilder);

        [Conditional("DEBUG")]
        public static void ArgumentInRange<T>(this EnsureOnDebugExtensionRoot root, T argumentValue, T minimum, T maximum) => Ensure.Always.ArgumentInRange(argumentValue, new Range<T>(minimum, maximum), null);

        [Conditional("DEBUG")]
        public static void ArgumentInRange<T>(this EnsureOnDebugExtensionRoot root, T argumentValue, T minimum, T maximum, string argumentName) => Ensure.Always.ArgumentInRange(argumentValue, new Range<T>(minimum, maximum), argumentName);

        [Conditional("DEBUG")]
        public static void ArgumentInRange<T>(this EnsureOnDebugExtensionRoot root, T argument, Range<T> range) => Ensure.Always.ArgumentInRange(argument, range, null);

        [Conditional("DEBUG")]
        public static void ArgumentInRange<T>(this EnsureOnDebugExtensionRoot root, T argument, Range<T> range, string argumentName) => Ensure.Always.ArgumentInRange(argument, range, argumentName);

        [Conditional("DEBUG")]
        public static void ArgumentInRange<T>(this EnsureOnDebugExtensionRoot root, T argument, Range<T> range, string argumentName, string message) => Ensure.Always.ArgumentInRange(argument, range, argumentName, message);

        [Conditional("DEBUG")]
        public static void ArgumentInRange<T>(this EnsureOnDebugExtensionRoot root, T argument, Range<T> range, string argumentName, Func<string> messageBuilder) => Ensure.Always.ArgumentInRange(argument, range, argumentName, messageBuilder);

        #endregion
    }
}
