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
        /// <para>Initializes a <see cref="Range"/> instance.</para>
        /// <para>Инициализирует экземпляр <see cref="Range"/>.</para>
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
        /// <para>Initializes a <see cref="Range"/> instance.</para> 
        /// <para>Инициализирует экземпляр <see cref="Range"/>.</para> 
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
        /// <para>Presents the Range in readable format.</para>
        /// <para>Представляет диапазон в удобном для чтения формате.</para>
        /// </summary>
        /// <returns><para>String representation of the Range.</para><para>Строковое представление диапазона.</para></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override string ToString() => $"[{Minimum}..{Maximum}]";

        /// <summary>
        /// <para>Determines if the provided value is inside the range.</para>
        /// <para>Определяет, находится ли указанное значение внутри диапазона.</para>
        /// </summary>
        /// <param name="value"><para>The value to test.</para><para>Значение для проверки.</para></param>
        /// <returns><para>True if the value is inside Range, else false.</para><para>True, если значение находится внутри диапазона, иначе false.</para></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Contains(T value) => _comparer.Compare(Minimum, value) <= 0 && _comparer.Compare(Maximum, value) >= 0;

        /// <summary>
        /// <para>Determines if another range is inside the bounds of this range.</para>
        /// <para>Определяет, находится ли другой диапазон внутри границ этого диапазона.</para>
        /// </summary>
        /// <param name="range"><para>The child range to test.</para><para>Дочерний диапазон для проверки.</para></param>
        /// <returns><para>True if range is inside, else false.</para><para>True, если диапазон находится внутри, иначе false.</para></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Contains(Range<T> range) => Contains(range.Minimum) && Contains(range.Maximum);

        /// <summary>
        /// <para>Determines whether the current range is equal to another range.</para>
        /// <para>Определяет, равен ли текущий диапазон другому диапазону.</para>
        /// </summary>
        /// <param name="other"><para>A range to compare with this range.</para><para>Диапазон для сравнения с этим диапазоном.</para></param>
        /// <returns><para>True if the current range is equal to the other range; otherwise, false.</para><para>True, если текущий диапазон равен другому диапазону; иначе false.</para></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(Range<T> other) => _equalityComparer.Equals(Minimum, other.Minimum) && _equalityComparer.Equals(Maximum, other.Maximum);

        /// <summary>
        /// <para>Creates a new <see cref="ValueTuple{T,T}"/> struct initialized with <see cref="Range{T}.Minimum"/> as <see cref="ValueTuple{T,T}.Item1"/> and <see cref="Range{T}.Maximum"/> as <see cref="ValueTuple{T,T}.Item2"/>.</para>
        /// <para>Создает новую структуру <see cref="ValueTuple{T,T}"/>, инициализированную с помощью <see cref="Range{T}.Minimum"/> как <see cref="ValueTuple{T,T}.Item1"/> и <see cref="Range{T}.Maximum"/> как <see cref="ValueTuple{T,T}.Item2"/>.</para>
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
        /// <para>Determines whether the current range is equal to another object.</para>
        /// <para>Определяет, равен ли текущий диапазон другому объекту.</para>
        /// </summary>
        /// <param name="obj"><para>An object to compare with this range.</para><para>Объект для сравнения с этим диапазоном.</para></param>
        /// <returns><para>True if the current range is equal to the other object; otherwise, false.</para><para>True, если текущий диапазон равен другому объекту; иначе false.</para></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override bool Equals(object obj) => obj is Range<T> range ? Equals(range) : false;

        /// <summary>
        /// Calculates the hash code for the current <see cref="Range{T}"/> instance.
        /// </summary>
        /// <returns>The hash code for the current <see cref="Range{T}"/> instance.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override int GetHashCode() => (Minimum, Maximum).GetHashCode();

        /// <summary>
        /// <para>Determines if the specified range is equal to the current range.</para>
        /// <para>Определяет, равен ли указанный диапазон текущему диапазону.</para>
        /// </summary>
        /// <param name="left"><para>The current range.</para><para>Текущий диапазон.</para></param>
        /// <param name="right"><para>A range to compare with this range.</para><para>Диапазон для сравнения с этим диапазоном.</para></param>
        /// <returns><para>True if the current range is equal to the other range; otherwise, false.</para><para>True, если текущий диапазон равен другому диапазону; иначе false.</para></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator ==(Range<T> left, Range<T> right) => left.Equals(right);

        /// <summary>
        /// <para>Determines if the specified range is not equal to the current range.</para>
        /// <para>Определяет, не равен ли указанный диапазон текущему диапазону.</para>
        /// </summary>
        /// <param name="left"><para>The current range.</para><para>Текущий диапазон.</para></param>
        /// <param name="right"><para>A range to compare with this range.</para><para>Диапазон для сравнения с этим диапазоном.</para></param>
        /// <returns><para>True if the current range is not equal to the other range; otherwise, false.</para><para>True, если текущий диапазон не равен другому диапазону; иначе false.</para></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator !=(Range<T> left, Range<T> right) => !(left == right);
    }
}
