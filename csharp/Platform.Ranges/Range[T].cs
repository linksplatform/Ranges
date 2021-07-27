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
        /// <para>Gets the minimum value of the <see cref="Range{T}"/>.</para>
        /// <para>Возвращает минимальное значение <see cref="Range{T}"/>.</para>
        /// </summary>
        public readonly T Minimum;

        /// <summary>
        /// <para>Gets the maximum value of the <see cref="Range{T}"/>.</para>
        /// <para>Возвращает максимальное значение <see cref="Range{T}"/>.</para>
        /// </summary>
        public readonly T Maximum;

        /// <summary>
        /// <para>Initializes a new <see cref="Range{T}"/> instance.</para>
        /// <para>Инициализирует новый экземпляр <see cref="Range{T}"/>.</para>
        /// </summary>
        /// <param name="minimumAndMaximum">
        /// <para>Single value for both <see cref="Minimum"/> and <see cref="Maximum"/>.</para>
        /// <para>Одно значение для обоих полей <see cref="Minimum"/> и <see cref="Maximum"/>.</para>
        /// </param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Range(T minimumAndMaximum)
        {
            Minimum = minimumAndMaximum;
            Maximum = minimumAndMaximum;
        }

        /// <summary> 
        /// <para>Initializes a new <see cref="Range{T}"/> instance.</para> 
        /// <para>Инициализирует новый экземпляр <see cref="Range{T}"/>.</para> 
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
        /// <para>The <paramref name="maximum"/> is less than the <paramref name="minumum"/>.</para>
        /// <para><paramref name="maximum"/> меньше <paramref name="minumum"/>.</para>
        /// </exception> 
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Range(T minimum, T maximum)
        {
            Ensure.Always.MaximumArgumentIsGreaterOrEqualToMinimum(minimum, maximum, nameof(maximum));
            Minimum = minimum;
            Maximum = maximum;
        }

        /// <summary>
        /// <para>Presents the <see cref="Range{T}"/> in readable format.</para>
        /// <para>Представляет <see cref="Range{T}"/> в удобном для чтения формате.</para>
        /// </summary>
        /// <returns>
        /// <para>String representation of the <see cref="Range{T}"/>.</para>
        /// <para>Строковое представление <see cref="Range{T}"/>.</para>
        /// </returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override string ToString() => $"[{Minimum}..{Maximum}]";

        /// <summary>
        /// <para>Determines if the <see cref="Range{T}"/> contains the <paramref name="value"/>.</para>
        /// <para>Определяет, содержит ли <see cref="Range{T}"/> <paramref name="value"/>.</para>
        /// </summary>
        /// <param name="value">
        /// <para>A value to find in the <see cref="Range{T}"/>.</para>
        /// <para>Значение, которое нужно найти в <see cref="Range{T}"/>.</para>
        /// </param>
        /// <returns>
        /// <para>A <see cref="Boolean"/> value that determines whether the <see cref="Range{T}"/> contains the <paramref name="value"/>.</para>
        /// <para>Значение типа <see cref="Boolean"/>, определяющее содержит ли <see cref="Range{T}"/> <paramref name="value"/>.</para>
        /// </returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Contains(T value) => _comparer.Compare(Minimum, value) <= 0 && _comparer.Compare(Maximum, value) >= 0;

        /// <summary>
        /// <para>Determines if the current <see cref="Range{T}"/> contains the <paramref name="range"/>.</para>
        /// <para>Определяет, содержит ли текущий <see cref="Range{T}"/> <paramref name="range"/>.</para>
        /// </summary>
        /// <param name="range">
        /// <para>A <see cref="Range{T}"/> to find in the current <see cref="Range{T}"/>.</para>
        /// <para><see cref="Range{T}"/>, который нужно найти в текущем <see cref="Range{T}"/>.</para>
        /// </param>
        /// <returns>
        /// <para>A <see cref="Boolean"/> value that determines whether the current <see cref="Range{T}"/> contains the <paramref name="range"/>.</para>
        /// <para>Значение типа <see cref="Boolean"/>, определяющее, содержит ли текущий <see cref="Range{T}"/> <paramref name="range"/>.</para>
        /// </returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Contains(Range<T> range) => Contains(range.Minimum) && Contains(range.Maximum);

        /// <summary>
        /// <para>Determines whether the current <see cref="Range{T}"/> and the <paramref name="other"/> are equal.</para>
        /// <para>Определяет, равны ли текущий <see cref="Range{T}"/> и <paramref name="other"/>.</para>
        /// </summary>
        /// <param name="other">
        /// <para>A <see cref="Range{T}"/> to compare with the current <see cref="Range{T}"/>.</para>
        /// <para><see cref="Range{T}"/> для сравнения с текущим <see cref="Range{T}"/>.</para>
        /// </param>
        /// <returns>
        /// <para>A <see cref="Boolean"/> value that determines whether the current <see cref="Range{T}"/> and the <paramref name="other"/> are equal.</para>
        /// <para>Значение типа <see cref="Boolean"/>, определяющее, равны ли <paramref name="other"/> и текущий <see cref="Range{T}"/>.</para>
        /// </returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(Range<T> other) => _equalityComparer.Equals(Minimum, other.Minimum) && _equalityComparer.Equals(Maximum, other.Maximum);

        /// <summary>
        /// <para>Creates a new <see cref="ValueTuple{T,T}"/> struct initialized with <see cref="Minimum"/> as <see cref="ValueTuple{T,T}.Item1"/> and <see cref="Maximum"/> as <see cref="ValueTuple{T,T}.Item2"/>.</para>
        /// <para>Создает новую структуру <see cref="ValueTuple{T,T}"/>, инициализированную с помощью <see cref="Minimum"/> как <see cref="ValueTuple{T,T}.Item1"/> и <see cref="Maximum"/> как <see cref="ValueTuple{T,T}.Item2"/>.</para>
        /// </summary>
        /// <param name="range">
        /// <para>The range of <typeparamref name="T"/>.</para>
        /// <para>Диапазон значений <typeparamref name="T"/>.</para>
        /// </param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator ValueTuple<T, T>(Range<T> range) => (range.Minimum, range.Maximum);

        /// <summary>
        /// <para>Creates a new <see cref="Range{T}"/> struct initialized with <see cref="ValueTuple{T,T}.Item1"/> as the <see cref="Minimum"/> and <see cref="ValueTuple{T,T}.Item2"/> as the <see cref="Maximum"/>.</para>
        /// <para>Создает новую структуру <see cref="Range{T}"/>, инициализированную с помощью <see cref="ValueTuple{T,T}.Item1"/> как <see cref="Minimum"/> и <see cref="ValueTuple{T,T}.Item2"/> как <see cref="Maximum"/>.</para>
        /// </summary>
        /// <param name="tuple">
        /// <para>The tuple of values for the <see cref="Minimum"/> and <see cref="Maximum"/>.</para>
        /// <para>Кортеж значений для <see cref="Minimum"/> и <see cref="Maximum"/>.</para>
        /// </param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Range<T>(ValueTuple<T, T> tuple) => new Range<T>(tuple.Item1, tuple.Item2);

        /// <summary>
        /// <para>Determines whether the current <see cref="Range{T}"/> and the <paramref name="obj"/> are equal.</para>
        /// <para>Определяет, равны ли текущий <see cref="Range{T}"/> и <paramref name="obj"/>.</para>
        /// </summary>
        /// <param name="obj">
        /// <para>An object to compare with the current <see cref="Range{T}"/>.</para>
        /// <para>Объект для сравнения с текущим <see cref="Range{T}"/>.</para>
        /// </param>
        /// <returns>
        /// <para>A <see cref="Boolean"/> value that determines whether the current <see cref="Range{T}"/> and the <paramref name="obj"/> are equal.</para>
        /// <para>Значение типа <see cref="Boolean"/> определяющее, равны ли текущий <see cref="Range{T}"/> и <paramref name="obj"/>.</para>
        /// </returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override bool Equals(object obj) => obj is Range<T> range ? Equals(range) : false;

        /// <summary>
        /// <para>Calculates a hash code for the current <see cref="Range{T}"/>.</para>
        /// <para>Вычисляет хеш код для текущего <see cref="Range{T}"/>.</para>
        /// </summary>
        /// <returns>
        /// <para>A hash code for the current <see cref="Range{T}"/>.</para>
        /// <para>Хеш код для текущего <see cref="Range{T}"/>.</para>
        /// </returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override int GetHashCode() => (Minimum, Maximum).GetHashCode();

        /// <summary>
        /// <para>Determines if the <paramref name="left"/> and the <paramref name="right"/> are equal.</para>
        /// <para>Определяет, равны ли <paramref name="left"/> и <paramref name="right"/>.</para>
        /// </summary>
        /// <param name="left">
        /// <para>The current <see cref="Range{T}"/> to compare with the <paramref name="right"/>.</para>
        /// <para>Текущий <see cref="Range{T}"/> для сравнения с <paramref name="right"/>.</para>
        /// </param>
        /// <param name="right">
        /// <para>A range to compare with the <paramref name="left"/>.</para>
        /// <para><see cref="Range{T}"/> для сравнения с <paramref name="left"/>.</para>
        /// </param>
        /// <returns>
        /// <para>A <see cref="Boolean"/> value that determines whether the <paramref name="left"/> and the <paramref name="right"/> are equal.</para>
        /// <para>Значение типа <see cref="Boolean"/>, определяющее, равны ли <paramref name="left"/> <paramref name="right"/>.</para>
        /// </returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator ==(Range<T> left, Range<T> right) => left.Equals(right);

        /// <summary>
        /// <para>Determines if the <paramref name="left"/> and the <paramref name="right"/> are not equal.</para>
        /// <para>Определяет, не равны ли <paramref name="left"/> и <paramref name="right"/>.</para>
        /// </summary>
        /// <param name="left"><para>The current <see cref="Range{T}"/>.</para><para>Текущий <see cref="Range{T}"/>.</para></param>
        /// <param name="right"><para>A <see cref="Range{T}"/> to compare with this <see cref="Range{T}"/>.</para><para><see cref="Range{T}"/> для сравнения с этим <see cref="Range{T}"/>.</para></param>
        /// <returns>
        /// <para>A <see cref="Boolean"/> value that determines whether the <paramref name="left"/> and the <paramref name="right"/> are not equal.</para>
        /// <para>Значение типа <see cref="Boolean"/>, определяющее, равны ли <paramref name="left"/> <paramref name="right"/>.</para>
        /// </returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator !=(Range<T> left, Range<T> right) => !(left == right);
    }
}
