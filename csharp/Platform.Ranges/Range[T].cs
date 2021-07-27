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
        /// <para>Gets the minimum value of the range.</para>
        /// <para>Возвращает минимальное значение диапазона.</para>
        /// </summary>
        public readonly T Minimum;

        /// <summary>
        /// <para>Gets the maximum value of the range.</para>
        /// <para>Возвращает максимальное значение диапазона.</para>
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
        /// </summary> 
        /// <param name="minimum">
        /// <para>A minimum value of the range.</para>
        /// <para>Минимальное значение диапазона.</para>
        /// </param> 
        /// <param name="maximum">
        /// <para>A maximum value of the range.</para>
        /// <para>Максимальное значение диапазона.</para>
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
        /// <para>Строковое представление диапазона.</para>
        /// </returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override string ToString() => $"[{Minimum}..{Maximum}]";

        /// <summary>
        /// <para>Determines if the provided value is inside the <see cref="Range{T}"/>.</para>
        /// <para>Определяет, находится ли указанное значение внутри <see cref="Range{T}"/>.</para>
        /// </summary>
        /// <param name="value">
        /// <para>A value to find in the <see cref="Range{T}"/>.</para>
        /// <para>Значение, которое нужно найти в <see cref="Range{T}"/>.</para>
        /// </param>
        /// <returns>
        /// <para>A <see cref="Boolean"/> value that determines whether the <paramref name="value"/> is inside this <see cref="Range{T}"/>.</para>
        /// <para>Значение типа <see cref="Boolean"/>, определяющее находится ли <paramref name="value"/> в этом <see cref="Range{T}"/>.</para>
        /// </returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Contains(T value) => _comparer.Compare(Minimum, value) <= 0 && _comparer.Compare(Maximum, value) >= 0;

        /// <summary>
        /// <para>Determines if the <paramref name="range"/> is inside this <see cref="Range{T}"/>.</para>
        /// <para>Определяет, находится ли <paramref name="range"/> в этом <see cref="Range{T}"/>.</para>
        /// </summary>
        /// <param name="range">
        /// <para>A range to find in the range.</para>
        /// <para>Диапазон, который нужно найти в диапазоне..</para>
        /// </param>
        /// <returns><para>A <see cref="Boolean"/> value that determines whether the <paramref name="range"/> is in this <see cref="Range{T}"/>.</para><para>Значение типа <see cref="Boolean"/>, определяющее, находится ли <paramref name="range"/> в этом <see cref="Range{T}"/>.</para></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Contains(Range<T> range) => Contains(range.Minimum) && Contains(range.Maximum);

        /// <summary>
        /// <para>Determines whether this <see cref="Range{T}"/> is equal to another <see cref="Range{T}"/>.</para>
        /// <para>Определяет, равен ли этот <see cref="Range{T}"/> другому <see cref="Range{T}"/>.</para>
        /// </summary>
        /// <param name="other"><para>A <see cref="Range{T}"/> to compare with this <see cref="Range{T}"/>.</para><para><see cref="Range{T}"/> для сравнения с этим <see cref="Range{T}"/>.</para></param>
        /// <returns><para>A <see cref="Boolean"/> value that determines whether the current <see cref="Range{T}"/> is equal to the <paramref name="other"/>.</para><para>Значение типа <see cref="Boolean"/>, определяющее, равен ли <paramref name="other"/> этому <see cref="Range{T}"/>.</para></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(Range<T> other) => _equalityComparer.Equals(Minimum, other.Minimum) && _equalityComparer.Equals(Maximum, other.Maximum);

        /// <summary>
        /// <para>Creates a new <see cref="ValueTuple{T,T}"/> struct initialized with <see cref="Minimum"/> as <see cref="ValueTuple{T,T}.Item1"/> and <see cref="Maximum"/> as <see cref="ValueTuple{T,T}.Item2"/>.</para>
        /// <para>Создает новую структуру <see cref="ValueTuple{T,T}"/>, инициализированную с помощью <see cref="Minimum"/> как <see cref="ValueTuple{T,T}.Item1"/> и <see cref="Maximum"/> как <see cref="ValueTuple{T,T}.Item2"/>.</para>
        /// </summary>
        /// <param name="range"><para>The range of <typeparamref name="T"/>.</para><para>Диапазон значений <typeparamref name="T"/>.</para></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator ValueTuple<T, T>(Range<T> range) => (range.Minimum, range.Maximum);

        /// <summary>
        /// <para>Creates a new <see cref="Range{T}"/> struct initialized with <see cref="ValueTuple{T,T}.Item1"/> as <see cref="Range{T}.Minimum"/> and <see cref="ValueTuple{T,T}.Item2"/> as <see cref="Range{T}.Maximum"/>.</para>
        /// <para>Создает новую структуру <see cref="Range{T}"/>, инициализированную с помощью <see cref="ValueTuple{T,T}.Item1"/> как <see cref="Range{T}.Minimum"/> и <see cref="ValueTuple{T,T}.Item2"/> как <see cref="Range{T}.Maximum"/>.</para>
        /// </summary>
        /// <param name="tuple"><para>The tuple.</para><para>Кортеж.</para></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Range<T>(ValueTuple<T, T> tuple) => new Range<T>(tuple.Item1, tuple.Item2);

        /// <summary>
        /// <para>Determines whether the current <see cref="Range{T}"/> is equal to another object.</para>
        /// <para>Определяет, равен ли текущий <see cref="Range{T}"/> другому объекту.</para>
        /// </summary>
        /// <param name="obj"><para>An object to compare with this <see cref="Range{T}"/>.</para><para>Объект для сравнения с этим <see cref="Range{T}"/>.</para></param>
        /// <returns><para>A <see cref="Boolean"/> value that determines whether the current <see cref="Range{T}"/> is equal to the <paramref name="obj"/>.</para><para>Значение типа <see cref="Boolean"/> определяющее, равен ли <paramref name="obj"/> текущему <see cref="Range{T}"/> .</para></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override bool Equals(object obj) => obj is Range<T> range ? Equals(range) : false;

        /// <summary>
        /// <para>Calculates a hash code for the current <see cref="Range{T}"/>.</para>
        /// <para>Вычисляет хеш код для текущего <see cref="Range{T}"/>.</para>
        /// </summary>
        /// <returns>A hash code for the current <see cref="Range{T}"/>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override int GetHashCode() => (Minimum, Maximum).GetHashCode();

        /// <summary>
        /// <para>Determines if the <paramref name="left"/> is equal to the <paramref name="right"/>.</para>
        /// <para>Определяет, равен ли <paramref name="left"/> <paramref name="right"/>.</para>
        /// </summary>
        /// <param name="left"><para>The current <see cref="Range{T}"/>.</para><para>Текущий <see cref="Range{T}"/>.</para></param>
        /// <param name="right"><para>A range to compare with this <see cref="Range{T}"/>.</para><para><see cref="Range{T}"/> для сравнения с этим <see cref="Range{T}"/>.</para></param>
        /// <returns><para>A <see cref="Boolean"/> value that determines whether the <paramref name="left"/> and the <paramref name="right"/> are equal.</para><para>Значение типа <see cref="Boolean"/>, определяющее, равны ли <paramref name="left"/> <paramref name="right"/>.</para></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator ==(Range<T> left, Range<T> right) => left.Equals(right);

        /// <summary>
        /// <para>Determines if the <paramref name="left"/> and the <paramref name="right"/> are not equal.</para>
        /// <para>Определяет, не равны ли <paramref name="left"/> и <paramref name="right"/>.</para>
        /// </summary>
        /// <param name="left"><para>The current <see cref="Range{T}"/>.</para><para>Текущий <see cref="Range{T}"/>.</para></param>
        /// <param name="right"><para>A <see cref="Range{T}"/> to compare with this <see cref="Range{T}"/>.</para><para><see cref="Range{T}"/> для сравнения с этим <see cref="Range{T}"/>.</para></param>
        /// <returns><para>A <see cref="Boolean"/> value that determines whether the <paramref name="left"/> and the <paramref name="right"/> are not equal.</para><para>Значение типа <see cref="Boolean"/>, определяющее, равны ли <paramref name="left"/> <paramref name="right"/>.</para></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator !=(Range<T> left, Range<T> right) => !(left == right);
    }
}
