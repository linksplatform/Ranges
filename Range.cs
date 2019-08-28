using System;
using System.Collections.Generic;
using Platform.Exceptions;

namespace Platform.Ranges
{
    /// <summary>
    /// Represents a range between minumum and maximum values.
    /// Представляет диапазон между минимальным и максимальным значениями.
    /// </summary>
    /// <remarks>
    /// Based on http://stackoverflow.com/questions/5343006/is-there-a-c-sharp-type-for-representing-an-integer-range
    /// </remarks>
    public struct Range<T> : IEquatable<Range<T>>
    {
        private static readonly Comparer<T> _comparer = Comparer<T>.Default;
        private static readonly EqualityComparer<T> _equalityComparer = EqualityComparer<T>.Default;

        /// <summary>
        /// Returns minimum value of the range.
        /// Возвращает минимальное значение диапазона.
        /// </summary>
        public readonly T Minimum;

        /// <summary>
        /// Returns maximum value of the range.
        /// Возвращает максимальное значение диапазона.
        /// </summary>
        public readonly T Maximum;

        /// <summary>
        /// Initializes a new instance of the Range class.
        /// Инициализирует новый экземпляр класса Range.
        /// </summary>
        /// <param name="minimumAndMaximum">Single value for both Minimum and Maximum fields. Одно значение для полей Minimum и Maximum.</param>
        public Range(T minimumAndMaximum)
        {
            Minimum = minimumAndMaximum;
            Maximum = minimumAndMaximum;
        }

        /// <summary>
        /// Initializes a new instance of the Range class.
        /// Инициализирует новый экземпляр класса Range.
        /// </summary>
        /// <param name="minimum">The minimum value of the range. Минимальное значение диапазона.</param>
        /// <param name="maximum">The maximum value of the range. Максимальное значение диапазона.</param>
        /// <exception cref="ArgumentException">Thrown when maximum is less than minimum.</exception>
        public Range(T minimum, T maximum)
        {
            Ensure.Always.MaximumArgumentIsGreaterOrEqualToMinimum(minimum, maximum, nameof(maximum));
            Minimum = minimum;
            Maximum = maximum;
        }

        /// <summary>
        /// Presents the Range in readable format.
        /// Представляет диапазон в удобном для чтения формате.
        /// </summary>
        /// <returns>String representation of the Range. Строковое представление диапазона.</returns>
        public override string ToString() => $"[{Minimum}, {Maximum}]";

        /// <summary>
        /// Determines if the provided value is inside the range.
        /// Определяет, находится ли указанное значение внутри диапазона.
        /// </summary>
        /// <param name="value">The value to test. Значение для проверки.</param>
        /// <returns>True if the value is inside Range, else false. True, если значение находится внутри диапазона, иначе false.</returns>
        public bool ContainsValue(T value) => _comparer.Compare(Minimum, value) <= 0 && _comparer.Compare(Maximum, value) >= 0;

        /// <summary>
        /// Determines if this Range is inside the bounds of another range.
        /// Определяет, находится ли этот диапазон в пределах другого диапазона.
        /// </summary>
        /// <param name="range">The parent range to test on. Родительский диапазон для проверки.</param>
        /// <returns>True if range is inclusive, else false. True, если диапазон включен, иначе false.</returns>
        public bool IsInsideRange(Range<T> range) => range.ContainsRange(this);

        /// <summary>
        /// Determines if another range is inside the bounds of this range.
        /// Определяет, находится ли другой диапазон внутри границ этого диапазона.
        /// </summary>
        /// <param name="range">The child range to test. Дочерний диапазон для проверки.</param>
        /// <returns>True if range is inside, else false. True, если диапазон находится внутри, иначе false.</returns>
        public bool ContainsRange(Range<T> range) => ContainsValue(range.Minimum) && ContainsValue(range.Maximum);

        /// <summary>
        /// Indicates whether the current range is equal to another range.
        /// Определяет, равен ли текущий диапазон другому диапазону.
        /// </summary>
        /// <param name="other">A range to compare with this range. Диапазон для сравнения с этим диапазоном.</param>
        /// <returns>True if the current range is equal to the other range; otherwise, false. True, если текущий диапазон равен другому диапазону; иначе false.</returns>
        public bool Equals(Range<T> other) => _equalityComparer.Equals(Minimum, other.Minimum) && _equalityComparer.Equals(Maximum, other.Maximum);

        /// <summary>
        /// <para>Creates a new <see cref="ValueTuple{T,T}"/> struct initialized with <see cref="Range{T}.Minimum"/> as <see cref="ValueTuple{T,T}.Item1"/> and <see cref="Range{T}.Maximum"/> as <see cref="ValueTuple{T,T}.Item2"/>.</para>
        /// <para>Создает новую структуру <see cref="ValueTuple{T,T}"/>, инициализированную с помощью <see cref="Range{T}.Minimum"/> как <see cref="ValueTuple{T,T}.Item1"/> и <see cref="Range{T}.Maximum"/> как <see cref="ValueTuple{T,T}.Item2"/>.</para>
        /// </summary>
        /// <param name="range"><para>The range of <typeparamref name="T"/>.</para><para>Диапазон значений <typeparamref name="T"/>.</para></param>
        public static implicit operator ValueTuple<T, T>(Range<T> range) => (range.Minimum, range.Maximum);

        /// <summary>
        /// <para>Creates a new <see cref="Range{T}"/> struct initialized with <see cref="ValueTuple{T,T}.Item1"/> as <see cref="Range{T}.Minimum"/> and <see cref="ValueTuple{T,T}.Item2"/> as <see cref="Range{T}.Maximum"/>.</para>
        /// <para>Создает новую структуру <see cref="Range{T}"/>, инициализированную с помощью <see cref="ValueTuple{T,T}.Item1"/> как <see cref="Range{T}.Minimum"/> и <see cref="ValueTuple{T,T}.Item2"/> как <see cref="Range{T}.Maximum"/>.</para>
        /// </summary>
        /// <param name="tuple"><para>The tuple.</para><para>Кортеж.</para></param>
        public static implicit operator Range<T>(ValueTuple<T, T> tuple) => new Range<T>(tuple.Item1, tuple.Item2);
    }
}
