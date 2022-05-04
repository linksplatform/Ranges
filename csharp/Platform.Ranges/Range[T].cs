using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Platform.Exceptions;

namespace Platform.Ranges
{
    /// <summary>
    /// <para>Represents a range between minimum and maximum values.</para>
    /// <para>Представляет диапазон между минимальным и максимальным значениями.</para>
    /// </summary>
    /// <remarks>
    /// <para>Based on <a href="http://stackoverflow.com/questions/5343006/is-there-a-c-sharp-type-for-representing-an-integer-range">the question at StackOverflow</a>.</para>
    /// <para>Основано на <a href="http://stackoverflow.com/questions/5343006/is-there-a-c-sharp-type-for-representing-an-integer-range">вопросе в StackOverflow</a>.</para>
    /// </remarks>
    public struct Range<T> : IEquatable<Range<T>>
    {
        private static readonly Comparer<T> _comparer = Comparer<T>.Default;
        private static readonly EqualityComparer<T> _equalityComparer = EqualityComparer<T>.Default;

        /// <summary>
        /// <para>A read-only field that represents a minimum value of the range.</para>
        /// <para>Поле для чтения, которое представляет минимальное значение диапазона.</para>
        /// </summary>
        public readonly T Minimum;

        /// <summary>
        /// <para>A read-only field that represents a maximum value of the range.</para>
        /// <para>оле для чтения, которое представляет максимальное значение диапазона.</para>
        /// </summary>
        public readonly T Maximum;

        /// <summary>
        /// <para>Initializes a new instance of the <see cref="Range{T}"/> structure with a single specified value as minimum and maximum values.</para>
        /// <para>Инициализирует новый экземпляр структуры <see cref="Range{T}"/> с одним указанным значением в качестве минимального и максимального значений.</para>
        /// </summary>
        /// <param name="minimumAndMaximum">
        /// <para>A single value for the both <see cref="Minimum"/> and <see cref="Maximum"/>.</para>
        /// <para>Одно значение для <see cref="Minimum"/> и <see cref="Maximum"/>.</para>
        /// </param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Range(T minimumAndMaximum)
        {
            Minimum = minimumAndMaximum;
            Maximum = minimumAndMaximum;
        }

        /// <summary>
        /// <para>Initializes a new instance of the <see cref="Range{T}"/> structure with the specified minimum and maximum values.</para>
        /// <para>Инициализирует новый экземпляр структуры <see cref="Range{T}"/> с указанными минимальным и максимальным значениями.</para>
        /// </summary>
        /// <param name="minimum">
        /// <para>A minimum value of the <see cref="Range{T}"/>.</para>
        /// <para>Минимальное значение <see cref="Range{T}"/>.</para>
        /// </param>
        /// <param name="maximum">
        /// <para>A maximum value of the <see cref="Range{T}"/>.</para>
        /// <para>Максимальное значение <see cref="Range{T}"/>.</para>
        /// </param>
        /// <exception cref="ArgumentException">
        /// <para>The <paramref name="maximum"/> is less than the <paramref name="minimum"/>.</para>
        /// <para><paramref name="maximum"/> меньше <paramref name="minimum"/>.</para>
        /// </exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Range(T minimum, T maximum)
        {
            Ensure.Always.MaximumArgumentIsGreaterOrEqualToMinimum(minimum, maximum, nameof(maximum));
            Minimum = minimum;
            Maximum = maximum;
        }

        /// <summary>
        /// <para>Returns a string representation of the current <see cref="Range{T}"/> struct.</para>
        /// <para>Возвращает строковое представление текущей структуры <see cref="Range{T}"/>.</para>
        /// </summary>
        /// <returns>
        /// <para>A string representation of the current <see cref="Range{T}"/> struct.</para>
        /// <para>Строковое представление текущей структуры <see cref="Range{T}"/>.</para>
        /// </returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override string ToString() => $"[{Minimum}..{Maximum}]";

        /// <summary>
        /// <para>Determines whether the current <see cref="Range{T}"/> struct contains the <paramref name="value"/>.</para>
        /// <para>Определяет, содержится ли <paramref name="value"/> в текущей структуре <see cref="Range{T}"/>.</para>
        /// </summary>
        /// <param name="value">
        /// <para>A value to test for inclusion in the <see cref="Range{T}"/> struct.</para>
        /// <para>Значение для проверки его присутствия в структуре <see cref="Range{T}"/>.</para>
        /// </param>
        /// <returns>
        /// <para>A <see cref="Boolean"/> value that determines whether the <see cref="Range{T}"/> struct contains the <paramref name="value"/>.</para>
        /// <para>Значение типа <see cref="Boolean"/>, определяющее, содержится ли <paramref name="value"/> в структуре <see cref="Range{T}"/>.</para>
        /// </returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Contains(T value) => _comparer.Compare(Minimum, value) <= 0 && _comparer.Compare(Maximum, value) >= 0;

        /// <summary>
        /// <para>Determines whether the <see cref="Range{T}"/> struct contains the <paramref name="range"/>.</para>
        /// <para>Определяет, содержится ли <paramref name="range"/> в структуре <see cref="Range{T}"/>.</para>
        /// </summary>
        /// <param name="range">
        /// <para>A <see cref="Range{T}"/> struct to test for inclusion in the current <see cref="Range{T}"/> struct.</para>
        /// <para>Структура <see cref="Range{T}"/>, для проверки включённости в текущей структуре <see cref="Range{T}"/>.</para>
        /// </param>
        /// <returns>
        /// <para>A <see cref="Boolean"/> value that determines whether the current <see cref="Range{T}"/> struct contains the <paramref name="range"/>.</para>
        /// <para>Значение типа <see cref="Boolean"/>, определяющее, содержится ли <paramref name="range"/> в текущей структуре <see cref="Range{T}"/>.</para>
        /// </returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Contains(Range<T> range) => Contains(range.Minimum) && Contains(range.Maximum);

        /// <summary>
        /// <para>Determines whether the current <see cref="Range{T}"/> struct and <paramref name="other"/> are equal.</para>
        /// <para>Определяет, равны ли текущая структура <see cref="Range{T}"/> и <paramref name="other"/>.</para>
        /// </summary>
        /// <param name="other">
        /// <para>A <see cref="Range{T}"/> struct to compare with the current <see cref="Range{T}"/> struct.</para>
        /// <para>Структура <see cref="Range{T}"/> для сравнения с текущей структурой.</para>
        /// </param>
        /// <returns>
        /// <para>A <see cref="Boolean"/> value that determines whether the current <see cref="Range{T}"/> struct and <paramref name="other"/> are equal.</para>
        /// <para>Значение типа <see cref="Boolean"/>, определяющее, равны ли текущая структура <see cref="Range{T}"/> и <paramref name="other"/>.</para>
        /// </returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(Range<T> other) => _equalityComparer.Equals(Minimum, other.Minimum) && _equalityComparer.Equals(Maximum, other.Maximum);

        /// <summary>
        /// <para>Initializes a new <see cref="ValueTuple{T,T}"/> struct with the <see cref="Minimum"/> and <see cref="Maximum"/> values of the <paramref name="range"/>.</para>
        /// <para>Инициализирует новую структуру <see cref="ValueTuple{T,T}"/>, с значениями <see cref="Minimum"/> и <see cref="Maximum"/> из <paramref name="range"/>.</para>
        /// </summary>
        /// <param name="range">
        /// <para>A <see cref="Range{T}"/> struct to initialize a tuple with the <see cref="Minimum"/> and <see cref="Maximum"/> values.</para>
        /// <para>Структура <see cref="Range{T}"/> для инициализации кортежа со значениями <see cref="Minimum"/> и <see cref="Maximum"/>.</para>
        /// </param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator ValueTuple<T, T>(Range<T> range) => (range.Minimum, range.Maximum);

        /// <summary>
        /// <para>Initializes a new <see cref="Range{T}"/> struct using items of the <paramref name="tuple"/>: the first item as the <see cref="Minimum"/> and the second item as the <see cref="Maximum"/>.</para>
        /// <para>Инициализирует новую структуру <see cref="Range{T}"/>, используя элементы <paramref name="tuple"/>: первый для <see cref="Minimum"/> и второй для <see cref="Maximum"/>.</para>
        /// </summary>
        /// <param name="tuple">
        /// <para>A tuple of the <see cref="Minimum"/> and <see cref="Maximum"/> values.</para>
        /// <para>Кортеж со значениями <see cref="Minimum"/> и <see cref="Maximum"/>.</para>
        /// </param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Range<T>(ValueTuple<T, T> tuple) => new Range<T>(tuple.Item1, tuple.Item2);

        /// <summary>
        /// <para>Determines whether the current <see cref="Range{T}"/> struct and <paramref name="obj"/> are equal.</para>
        /// <para>Определяет, равны ли текущая структура <see cref="Range{T}"/> и <paramref name="obj"/>.</para>
        /// </summary>
        /// <param name="obj">
        /// <para>An object to compare with the <see cref="Range{T}"/>.</para>
        /// <para>Объект для сравнения с <see cref="Range{T}"/>.</para>
        /// </param>
        /// <returns>
        /// <para>A <see cref="Boolean"/> value that determines whether the current <see cref="Range{T}"/> struct and <paramref name="obj"/> are equal.</para>
        /// <para>Значение типа <see cref="Boolean"/> определяющее, равны ли текущая структура <see cref="Range{T}"/> и <paramref name="obj"/>.</para>
        /// </returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override bool Equals(object obj) => obj is Range<T> range ? Equals(range) : false;

        /// <summary>
        /// <para>Calculates a hash code for the current <see cref="Range{T}"/> struct.</para>
        /// <para>Вычисляет хеш код для структуры <see cref="Range{T}"/>.</para>
        /// </summary>
        /// <returns>
        /// <para>A hash code for the current <see cref="Range{T}"/> struct.</para>
        /// <para>Хеш код для текущей структуры <see cref="Range{T}"/>.</para>
        /// </returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override int GetHashCode() => (Minimum, Maximum).GetHashCode();

        /// <summary>
        /// <para>Determines if the <paramref name="left"/> and <paramref name="right"/> ranges are equal.</para>
        /// <para>Определяет, равны ли диапазоны <paramref name="left"/> и <paramref name="right"/>.</para>
        /// </summary>
        /// <param name="left">
        /// <para>A <see cref="Range{T}"/> struct to compare with the <paramref name="right"/>.</para>
        /// <para>Структура <see cref="Range{T}"/> для сравнения с <paramref name="right"/>.</para>
        /// </param>
        /// <param name="right">
        /// <para>A <see cref="Range{T}"/> struct instance to compare with the <paramref name="left"/>.</para>
        /// <para>Структура <see cref="Range{T}"/> для сравнения с <paramref name="left"/>.</para>
        /// </param>
        /// <returns>
        /// <para>A <see cref="Boolean"/> value that determines whether the <paramref name="left"/> and <paramref name="right"/> ranges are equal.</para>
        /// <para>Значение типа <see cref="Boolean"/>, определяющее, равны ли диапазоны <paramref name="left"/> и <paramref name="right"/>.</para>
        /// </returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator ==(Range<T> left, Range<T> right) => left.Equals(right);

        /// <summary>
        /// <para>Determines if the <paramref name="left"/> and <paramref name="right"/> ranges are not equal.</para>
        /// <para>Определяет, не равны ли диапазоны <paramref name="left"/> и <paramref name="right"/>.</para>
        /// </summary>
        /// <param name="left">
        /// <para>A <see cref="Range{T}"/> struct to compare with the <paramref name="right"/>.</para>
        /// <para>Структура <see cref="Range{T}"/> для сравнения с <paramref name="right"/>.</para>
        /// </param>
        /// <param name="right">
        /// <para>A <see cref="Range{T}"/> struct to compare with the <paramref name="left"/>.</para>
        /// <para>Структура <see cref="Range{T}"/> для сравнения с <paramref name="left"/>.</para>
        /// </param>
        /// <returns>
        /// <para>A <see cref="Boolean"/> value that determines whether the <paramref name="left"/> and <paramref name="right"/> ranges are not equal.</para>
        /// <para>Значение типа <see cref="Boolean"/>, определяющее, не равны ли диапазоны <paramref name="left"/> и <paramref name="right"/>.</para>
        /// </returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator !=(Range<T> left, Range<T> right) => !(left == right);
    }
}
