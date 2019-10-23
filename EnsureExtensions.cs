using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Platform.Exceptions;
using Platform.Exceptions.ExtensionRoots;

#pragma warning disable IDE0060 // Remove unused parameter

namespace Platform.Ranges
{
    /// <summary>
    /// <para>Provides a set of extension methods for <see cref="EnsureAlwaysExtensionRoot"/> and <see cref="EnsureOnDebugExtensionRoot"/> objects.</para>
    /// <para>Предоставляет набор методов расширения для объектов <see cref="EnsureAlwaysExtensionRoot"/> и <see cref="EnsureOnDebugExtensionRoot"/>.</para>
    /// </summary>
    public static class EnsureExtensions
    {
        private const string DefaultMaximumShouldBeGreaterOrEqualToMinimumMessage = "Maximum should be greater or equal to minimum.";

        #region Always

        /// <summary>
        /// <para>Ensures that the argument with the maximum value is greater than or equal to the minimum value. This check is performed regardless of the build configuration.</para>
        /// <para>Гарантирует, что аргумент с максимальным значением больше или равен минимальному значению. Эта проверка выполняется внезависимости от конфигурации сборки.</para>
        /// </summary>
        /// <typeparam name="TArgument"><para>Type of argument.</para><para>Тип аргумента.</para></typeparam>
        /// <param name="root"><para>The extension root to which this method is bound.</para><para>Корень-расширения, к которому привязан этот метод.</para></param>
        /// <param name="minimumArgument"><para>The argument with the minimum value.</para><para>Аргумент с минимальным значением.</para></param>
        /// <param name="maximumArgument"><para>The argument with the maximum value.</para><para>Аргумент c максимальным значением.</para></param>
        /// <param name="maximumArgumentName"><para>The name of argument with the maximum value.</para><para>Имя аргумента c максимальным значением.</para></param>
        /// <param name="messageBuilder"><para>The thrown exception's message building <see cref="Func{String}"/>.</para><para>Собирающая сообщение для выбрасываемого исключения <see cref="Func{String}"/>.</para></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void MaximumArgumentIsGreaterOrEqualToMinimum<TArgument>(this EnsureAlwaysExtensionRoot root, TArgument minimumArgument, TArgument maximumArgument, string maximumArgumentName, Func<string> messageBuilder)
        {
            if (Comparer<TArgument>.Default.Compare(maximumArgument, minimumArgument) < 0)
            {
                throw new ArgumentException(messageBuilder(), maximumArgumentName);
            }
        }

        /// <summary>
        /// <para>Ensures that the argument with the maximum value is greater than or equal to the minimum value. This check is performed regardless of the build configuration.</para>
        /// <para>Гарантирует, что аргумент с максимальным значением больше или равен минимальному значению. Эта проверка выполняется внезависимости от конфигурации сборки.</para>
        /// </summary>
        /// <typeparam name="TArgument"><para>Type of argument.</para><para>Тип аргумента.</para></typeparam>
        /// <param name="root"><para>The extension root to which this method is bound.</para><para>Корень-расширения, к которому привязан этот метод.</para></param>
        /// <param name="minimumArgument"><para>The argument with the minimum value.</para><para>Аргумент с минимальным значением.</para></param>
        /// <param name="maximumArgument"><para>The argument with the maximum value.</para><para>Аргумент c максимальным значением.</para></param>
        /// <param name="maximumArgumentName"><para>The name of argument with the maximum value.</para><para>Имя аргумента c максимальным значением.</para></param>
        /// <param name="message"><para>The message of the thrown exception.</para><para>Сообщение выбрасываемого исключения.</para></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void MaximumArgumentIsGreaterOrEqualToMinimum<TArgument>(this EnsureAlwaysExtensionRoot root, TArgument minimumArgument, TArgument maximumArgument, string maximumArgumentName, string message)
        {
            string messageBuilder() => message;
            MaximumArgumentIsGreaterOrEqualToMinimum(root, minimumArgument, maximumArgument, maximumArgumentName, messageBuilder);
        }

        /// <summary>
        /// <para>Ensures that the argument with the maximum value is greater than or equal to the minimum value. This check is performed regardless of the build configuration.</para>
        /// <para>Гарантирует, что аргумент с максимальным значением больше или равен минимальному значению. Эта проверка выполняется внезависимости от конфигурации сборки.</para>
        /// </summary>
        /// <typeparam name="TArgument"><para>Type of argument.</para><para>Тип аргумента.</para></typeparam>
        /// <param name="root"><para>The extension root to which this method is bound.</para><para>Корень-расширения, к которому привязан этот метод.</para></param>
        /// <param name="minimumArgument"><para>The argument with the minimum value.</para><para>Аргумент с минимальным значением.</para></param>
        /// <param name="maximumArgument"><para>The argument with the maximum value.</para><para>Аргумент c максимальным значением.</para></param>
        /// <param name="maximumArgumentName"><para>The name of argument with the maximum value.</para><para>Имя аргумента c максимальным значением.</para></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void MaximumArgumentIsGreaterOrEqualToMinimum<TArgument>(this EnsureAlwaysExtensionRoot root, TArgument minimumArgument, TArgument maximumArgument, string maximumArgumentName) => MaximumArgumentIsGreaterOrEqualToMinimum(root, minimumArgument, maximumArgument, nameof(maximumArgument), DefaultMaximumShouldBeGreaterOrEqualToMinimumMessage);

        /// <summary>
        /// <para>Ensures that the argument with the maximum value is greater than or equal to the minimum value. This check is performed regardless of the build configuration.</para>
        /// <para>Гарантирует, что аргумент с максимальным значением больше или равен минимальному значению. Эта проверка выполняется внезависимости от конфигурации сборки.</para>
        /// </summary>
        /// <typeparam name="TArgument"><para>Type of argument.</para><para>Тип аргумента.</para></typeparam>
        /// <param name="root"><para>The extension root to which this method is bound.</para><para>Корень-расширения, к которому привязан этот метод.</para></param>
        /// <param name="minimumArgument"><para>The argument with the minimum value.</para><para>Аргумент с минимальным значением.</para></param>
        /// <param name="maximumArgument"><para>The argument with the maximum value.</para><para>Аргумент c максимальным значением.</para></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void MaximumArgumentIsGreaterOrEqualToMinimum<TArgument>(this EnsureAlwaysExtensionRoot root, TArgument minimumArgument, TArgument maximumArgument) => MaximumArgumentIsGreaterOrEqualToMinimum(root, minimumArgument, maximumArgument, nameof(maximumArgument));

        /// <summary>
        /// <para>Ensures that the argument value is in the specified range. This check is performed regardless of the build configuration.</para>
        /// <para>Гарантирует, что значение аргумента находится в указанном диапазоне. Эта проверка выполняется внезависимости от конфигурации сборки.</para>
        /// </summary>
        /// <typeparam name="TArgument"><para>Type of argument.</para><para>Тип аргумента.</para></typeparam>
        /// <param name="root"><para>The extension root to which this method is bound.</para><para>Корень-расширения, к которому привязан этот метод.</para></param>
        /// <param name="argumentValue"><para>The argument's value.</para><para>Значение аргумента.</para></param>
        /// <param name="range"><para>The range restriction.</para><para>Ограничение в виде диапазона.</para></param>
        /// <param name="argumentName"><para>The argument's name.</para><para>Имя аргумента.</para></param>
        /// <param name="messageBuilder"><para>The thrown exception's message building <see cref="Func{String}"/>.</para><para>Собирающая сообщение для выбрасываемого исключения <see cref="Func{String}"/>.</para></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ArgumentInRange<TArgument>(this EnsureAlwaysExtensionRoot root, TArgument argumentValue, Range<TArgument> range, string argumentName, Func<string> messageBuilder)
        {
            if (!range.Contains(argumentValue))
            {
                throw new ArgumentOutOfRangeException(argumentName, argumentValue, messageBuilder());
            }
        }

        /// <summary>
        /// <para>Ensures that the argument value is in the specified range. This check is performed regardless of the build configuration.</para>
        /// <para>Гарантирует, что значение аргумента находится в указанном диапазоне. Эта проверка выполняется внезависимости от конфигурации сборки.</para>
        /// </summary>
        /// <typeparam name="TArgument"><para>Type of argument.</para><para>Тип аргумента.</para></typeparam>
        /// <param name="root"><para>The extension root to which this method is bound.</para><para>Корень-расширения, к которому привязан этот метод.</para></param>
        /// <param name="argumentValue"><para>The argument's value.</para><para>Значение аргумента.</para></param>
        /// <param name="range"><para>The range restriction.</para><para>Ограничение в виде диапазона.</para></param>
        /// <param name="argumentName"><para>The argument's name.</para><para>Имя аргумента.</para></param>
        /// <param name="message"><para>The message of the thrown exception.</para><para>Сообщение выбрасываемого исключения.</para></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ArgumentInRange<TArgument>(this EnsureAlwaysExtensionRoot root, TArgument argumentValue, Range<TArgument> range, string argumentName, string message)
        {
            string messageBuilder() => message;
            ArgumentInRange(root, argumentValue, range, argumentName, messageBuilder);
        }

        /// <summary>
        /// <para>Ensures that the argument value is in the specified range. This check is performed regardless of the build configuration.</para>
        /// <para>Гарантирует, что значение аргумента находится в указанном диапазоне. Эта проверка выполняется внезависимости от конфигурации сборки.</para>
        /// </summary>
        /// <typeparam name="TArgument"><para>Type of argument.</para><para>Тип аргумента.</para></typeparam>
        /// <param name="root"><para>The extension root to which this method is bound.</para><para>Корень-расширения, к которому привязан этот метод.</para></param>
        /// <param name="argumentValue"><para>The argument's value.</para><para>Значение аргумента.</para></param>
        /// <param name="range"><para>The range restriction.</para><para>Ограничение в виде диапазона.</para></param>
        /// <param name="argumentName"><para>The argument's name.</para><para>Имя аргумента.</para></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ArgumentInRange<TArgument>(this EnsureAlwaysExtensionRoot root, TArgument argumentValue, Range<TArgument> range, string argumentName)
        {
            string messageBuilder() => $"Argument value [{argumentValue}] is out of range {range}.";
            ArgumentInRange(root, argumentValue, range, argumentName, messageBuilder);
        }

        /// <summary>
        /// <para>Ensures that the argument value is in the specified range. This check is performed regardless of the build configuration.</para>
        /// <para>Гарантирует, что значение аргумента находится в указанном диапазоне. Эта проверка выполняется внезависимости от конфигурации сборки.</para>
        /// </summary>
        /// <typeparam name="TArgument"><para>Type of argument.</para><para>Тип аргумента.</para></typeparam>
        /// <param name="root"><para>The extension root to which this method is bound.</para><para>Корень-расширения, к которому привязан этот метод.</para></param>
        /// <param name="argumentValue"><para>The argument's value.</para><para>Значение аргумента.</para></param>
        /// <param name="minimum"><para>The minimum possible argument's value.</para><para>Минимально возможное значение аргумента.</para></param>
        /// <param name="maximum"><para>The maximum possible argument's value.</para><para>Максимально возможное значение аргумента.</para></param>
        /// <param name="argumentName"><para>The argument's name.</para><para>Имя аргумента.</para></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ArgumentInRange<TArgument>(this EnsureAlwaysExtensionRoot root, TArgument argumentValue, TArgument minimum, TArgument maximum, string argumentName) => ArgumentInRange(root, argumentValue, new Range<TArgument>(minimum, maximum), argumentName);

        /// <summary>
        /// <para>Ensures that the argument value is in the specified range. This check is performed regardless of the build configuration.</para>
        /// <para>Гарантирует, что значение аргумента находится в указанном диапазоне. Эта проверка выполняется внезависимости от конфигурации сборки.</para>
        /// </summary>
        /// <typeparam name="TArgument"><para>Type of argument.</para><para>Тип аргумента.</para></typeparam>
        /// <param name="root"><para>The extension root to which this method is bound.</para><para>Корень-расширения, к которому привязан этот метод.</para></param>
        /// <param name="argumentValue"><para>The argument's value.</para><para>Значение аргумента.</para></param>
        /// <param name="minimum"><para>The minimum possible argument's value.</para><para>Минимально возможное значение аргумента.</para></param>
        /// <param name="maximum"><para>The maximum possible argument's value.</para><para>Максимально возможное значение аргумента.</para></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ArgumentInRange<TArgument>(this EnsureAlwaysExtensionRoot root, TArgument argumentValue, TArgument minimum, TArgument maximum) => ArgumentInRange(root, argumentValue, new Range<TArgument>(minimum, maximum), null);

        /// <summary>
        /// <para>Ensures that the argument value is in the specified range. This check is performed regardless of the build configuration.</para>
        /// <para>Гарантирует, что значение аргумента находится в указанном диапазоне. Эта проверка выполняется внезависимости от конфигурации сборки.</para>
        /// </summary>
        /// <typeparam name="TArgument"><para>Type of argument.</para><para>Тип аргумента.</para></typeparam>
        /// <param name="root"><para>The extension root to which this method is bound.</para><para>Корень-расширения, к которому привязан этот метод.</para></param>
        /// <param name="argumentValue"><para>The argument's value.</para><para>Значение аргумента.</para></param>
        /// <param name="range"><para>The range restriction.</para><para>Ограничение в виде диапазона.</para></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ArgumentInRange<TArgument>(this EnsureAlwaysExtensionRoot root, TArgument argumentValue, Range<TArgument> range) => ArgumentInRange(root, argumentValue, range, null);

        #endregion

        #region OnDebug

        /// <summary>
        /// <para>Ensures that the argument with the maximum value is greater than or equal to the minimum value. This check is performed only for DEBUG build configuration.</para>
        /// <para>Гарантирует, что аргумент с максимальным значением больше или равен минимальному значению. Эта проверка выполняется только для конфигурации сборки DEBUG.</para>
        /// </summary>
        /// <typeparam name="TArgument"><para>Type of argument.</para><para>Тип аргумента.</para></typeparam>
        /// <param name="root"><para>The extension root to which this method is bound.</para><para>Корень-расширения, к которому привязан этот метод.</para></param>
        /// <param name="minimumArgument"><para>The argument with the minimum value.</para><para>Аргумент с минимальным значением.</para></param>
        /// <param name="maximumArgument"><para>The argument with the maximum value.</para><para>Аргумент c максимальным значением.</para></param>
        /// <param name="maximumArgumentName"><para>The name of argument with the maximum value.</para><para>Имя аргумента c максимальным значением.</para></param>
        /// <param name="messageBuilder"><para>The thrown exception's message building <see cref="Func{String}"/>.</para><para>Собирающая сообщение для выбрасываемого исключения <see cref="Func{String}"/>.</para></param>
        [Conditional("DEBUG")]
        public static void MaximumArgumentIsGreaterOrEqualToMinimum<TArgument>(this EnsureOnDebugExtensionRoot root, TArgument minimumArgument, TArgument maximumArgument, string maximumArgumentName, Func<string> messageBuilder) => Ensure.Always.MaximumArgumentIsGreaterOrEqualToMinimum(minimumArgument, maximumArgument, maximumArgumentName, messageBuilder);

        /// <summary>
        /// <para>Ensures that the argument with the maximum value is greater than or equal to the minimum value. This check is performed only for DEBUG build configuration.</para>
        /// <para>Гарантирует, что аргумент с максимальным значением больше или равен минимальному значению. Эта проверка выполняется только для конфигурации сборки DEBUG.</para>
        /// </summary>
        /// <typeparam name="TArgument"><para>Type of argument.</para><para>Тип аргумента.</para></typeparam>
        /// <param name="root"><para>The extension root to which this method is bound.</para><para>Корень-расширения, к которому привязан этот метод.</para></param>
        /// <param name="minimumArgument"><para>The argument with the minimum value.</para><para>Аргумент с минимальным значением.</para></param>
        /// <param name="maximumArgument"><para>The argument with the maximum value.</para><para>Аргумент c максимальным значением.</para></param>
        /// <param name="maximumArgumentName"><para>The name of argument with the maximum value.</para><para>Имя аргумента c максимальным значением.</para></param>
        /// <param name="message"><para>The message of the thrown exception.</para><para>Сообщение выбрасываемого исключения.</para></param>
        [Conditional("DEBUG")]
        public static void MaximumArgumentIsGreaterOrEqualToMinimum<TArgument>(this EnsureOnDebugExtensionRoot root, TArgument minimumArgument, TArgument maximumArgument, string maximumArgumentName, string message) => Ensure.Always.MaximumArgumentIsGreaterOrEqualToMinimum(minimumArgument, maximumArgument, maximumArgumentName, message);

        /// <summary>
        /// <para>Ensures that the argument with the maximum value is greater than or equal to the minimum value. This check is performed only for DEBUG build configuration.</para>
        /// <para>Гарантирует, что аргумент с максимальным значением больше или равен минимальному значению. Эта проверка выполняется только для конфигурации сборки DEBUG.</para>
        /// </summary>
        /// <typeparam name="TArgument"><para>Type of argument.</para><para>Тип аргумента.</para></typeparam>
        /// <param name="root"><para>The extension root to which this method is bound.</para><para>Корень-расширения, к которому привязан этот метод.</para></param>
        /// <param name="minimumArgument"><para>The argument with the minimum value.</para><para>Аргумент с минимальным значением.</para></param>
        /// <param name="maximumArgument"><para>The argument with the maximum value.</para><para>Аргумент c максимальным значением.</para></param>
        /// <param name="argumentName"><para>The argument's name.</para><para>Имя аргумента.</para></param>
        [Conditional("DEBUG")]
        public static void MaximumArgumentIsGreaterOrEqualToMinimum<TArgument>(this EnsureOnDebugExtensionRoot root, TArgument minimumArgument, TArgument maximumArgument, string argumentName) => Ensure.Always.MaximumArgumentIsGreaterOrEqualToMinimum(minimumArgument, maximumArgument, argumentName);

        /// <summary>
        /// <para>Ensures that the argument with the maximum value is greater than or equal to the minimum value. This check is performed only for DEBUG build configuration.</para>
        /// <para>Гарантирует, что аргумент с максимальным значением больше или равен минимальному значению. Эта проверка выполняется только для конфигурации сборки DEBUG.</para>
        /// </summary>
        /// <typeparam name="TArgument"><para>Type of argument.</para><para>Тип аргумента.</para></typeparam>
        /// <param name="root"><para>The extension root to which this method is bound.</para><para>Корень-расширения, к которому привязан этот метод.</para></param>
        /// <param name="minimumArgument"><para>The argument with the minimum value.</para><para>Аргумент с минимальным значением.</para></param>
        /// <param name="maximumArgument"><para>The argument with the maximum value.</para><para>Аргумент c максимальным значением.</para></param>
        [Conditional("DEBUG")]
        public static void MaximumArgumentIsGreaterOrEqualToMinimum<TArgument>(this EnsureOnDebugExtensionRoot root, TArgument minimumArgument, TArgument maximumArgument) => Ensure.Always.MaximumArgumentIsGreaterOrEqualToMinimum(minimumArgument, maximumArgument, null);

        /// <summary>
        /// <para>Ensures that the argument value is in the specified range. This check is performed only for DEBUG build configuration.</para>
        /// <para>Гарантирует, что значение аргумента находится в указанном диапазоне. Эта проверка выполняется только для конфигурации сборки DEBUG.</para>
        /// </summary>
        /// <typeparam name="TArgument"><para>Type of argument.</para><para>Тип аргумента.</para></typeparam>
        /// <param name="root"><para>The extension root to which this method is bound.</para><para>Корень-расширения, к которому привязан этот метод.</para></param>
        /// <param name="argument"></param>
        /// <param name="range"><para>The range restriction.</para><para>Ограничение в виде диапазона.</para></param>
        /// <param name="argumentName"><para>The argument's name.</para><para>Имя аргумента.</para></param>
        /// <param name="messageBuilder"><para>The thrown exception's message building <see cref="Func{String}"/>.</para><para>Собирающая сообщение для выбрасываемого исключения <see cref="Func{String}"/>.</para></param>
        [Conditional("DEBUG")]
        public static void ArgumentInRange<TArgument>(this EnsureOnDebugExtensionRoot root, TArgument argument, Range<TArgument> range, string argumentName, Func<string> messageBuilder) => Ensure.Always.ArgumentInRange(argument, range, argumentName, messageBuilder);

        /// <summary>
        /// <para>Ensures that the argument value is in the specified range. This check is performed only for DEBUG build configuration.</para>
        /// <para>Гарантирует, что значение аргумента находится в указанном диапазоне. Эта проверка выполняется только для конфигурации сборки DEBUG.</para>
        /// </summary>
        /// <typeparam name="TArgument"><para>Type of argument.</para><para>Тип аргумента.</para></typeparam>
        /// <param name="root"><para>The extension root to which this method is bound.</para><para>Корень-расширения, к которому привязан этот метод.</para></param>
        /// <param name="argument"></param>
        /// <param name="range"><para>The range restriction.</para><para>Ограничение в виде диапазона.</para></param>
        /// <param name="argumentName"><para>The argument's name.</para><para>Имя аргумента.</para></param>
        /// <param name="message"><para>The message of the thrown exception.</para><para>Сообщение выбрасываемого исключения.</para></param>
        [Conditional("DEBUG")]
        public static void ArgumentInRange<TArgument>(this EnsureOnDebugExtensionRoot root, TArgument argument, Range<TArgument> range, string argumentName, string message) => Ensure.Always.ArgumentInRange(argument, range, argumentName, message);

        /// <summary>
        /// <para>Ensures that the argument value is in the specified range. This check is performed only for DEBUG build configuration.</para>
        /// <para>Гарантирует, что значение аргумента находится в указанном диапазоне. Эта проверка выполняется только для конфигурации сборки DEBUG.</para>
        /// </summary>
        /// <typeparam name="TArgument"><para>Type of argument.</para><para>Тип аргумента.</para></typeparam>
        /// <param name="root"><para>The extension root to which this method is bound.</para><para>Корень-расширения, к которому привязан этот метод.</para></param>
        /// <param name="argument"></param>
        /// <param name="range"><para>The range restriction.</para><para>Ограничение в виде диапазона.</para></param>
        /// <param name="argumentName"><para>The argument's name.</para><para>Имя аргумента.</para></param>
        [Conditional("DEBUG")]
        public static void ArgumentInRange<TArgument>(this EnsureOnDebugExtensionRoot root, TArgument argument, Range<TArgument> range, string argumentName) => Ensure.Always.ArgumentInRange(argument, range, argumentName);

        /// <summary>
        /// <para>Ensures that the argument value is in the specified range. This check is performed only for DEBUG build configuration.</para>
        /// <para>Гарантирует, что значение аргумента находится в указанном диапазоне. Эта проверка выполняется только для конфигурации сборки DEBUG.</para>
        /// </summary>
        /// <typeparam name="TArgument"><para>Type of argument.</para><para>Тип аргумента.</para></typeparam>
        /// <param name="root"><para>The extension root to which this method is bound.</para><para>Корень-расширения, к которому привязан этот метод.</para></param>
        /// <param name="argumentValue"><para>The argument's value.</para><para>Значение аргумента.</para></param>
        /// <param name="minimum"><para>The minimum possible argument's value.</para><para>Минимально возможное значение аргумента.</para></param>
        /// <param name="maximum"><para>The maximum possible argument's value.</para><para>Максимально возможное значение аргумента.</para></param>
        [Conditional("DEBUG")]
        public static void ArgumentInRange<TArgument>(this EnsureOnDebugExtensionRoot root, TArgument argumentValue, TArgument minimum, TArgument maximum) => Ensure.Always.ArgumentInRange(argumentValue, new Range<TArgument>(minimum, maximum), null);

        /// <summary>
        /// <para>Ensures that the argument value is in the specified range. This check is performed only for DEBUG build configuration.</para>
        /// <para>Гарантирует, что значение аргумента находится в указанном диапазоне. Эта проверка выполняется только для конфигурации сборки DEBUG.</para>
        /// </summary>
        /// <typeparam name="TArgument"><para>Type of argument.</para><para>Тип аргумента.</para></typeparam>
        /// <param name="root"><para>The extension root to which this method is bound.</para><para>Корень-расширения, к которому привязан этот метод.</para></param>
        /// <param name="argumentValue"><para>The argument's value.</para><para>Значение аргумента.</para></param>
        /// <param name="minimum"><para>The minimum possible argument's value.</para><para>Минимально возможное значение аргумента.</para></param>
        /// <param name="maximum"><para>The maximum possible argument's value.</para><para>Максимально возможное значение аргумента.</para></param>
        /// <param name="argumentName"><para>The argument's name.</para><para>Имя аргумента.</para></param>
        [Conditional("DEBUG")]
        public static void ArgumentInRange<TArgument>(this EnsureOnDebugExtensionRoot root, TArgument argumentValue, TArgument minimum, TArgument maximum, string argumentName) => Ensure.Always.ArgumentInRange(argumentValue, new Range<TArgument>(minimum, maximum), argumentName);

        /// <summary>
        /// <para>Ensures that the argument value is in the specified range. This check is performed only for DEBUG build configuration.</para>
        /// <para>Гарантирует, что значение аргумента находится в указанном диапазоне. Эта проверка выполняется только для конфигурации сборки DEBUG.</para>
        /// </summary>
        /// <typeparam name="TArgument"><para>Type of argument.</para><para>Тип аргумента.</para></typeparam>
        /// <param name="root"><para>The extension root to which this method is bound.</para><para>Корень-расширения, к которому привязан этот метод.</para></param>
        /// <param name="argument"></param>
        /// <param name="range"><para>The range restriction.</para><para>Ограничение в виде диапазона.</para></param>
        [Conditional("DEBUG")]
        public static void ArgumentInRange<TArgument>(this EnsureOnDebugExtensionRoot root, TArgument argument, Range<TArgument> range) => Ensure.Always.ArgumentInRange(argument, range, null);

        #endregion
    }
}
