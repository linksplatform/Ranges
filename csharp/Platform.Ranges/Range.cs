using System.Runtime.CompilerServices;

namespace Platform.Ranges
{
    /// <summary>
    /// <para>Contains static properties with <see cref="Range{T}"/> constants.</para>
    /// <para>Содержит статические свойства с константами типа <see cref="Range{T}"/>.</para>
    /// </summary>
    public static class Range
    {
        /// <summary>
        /// <para>Gets the whole <see cref="sbyte"/> values range.</para>
        /// <para>Возвращает весь диапазон значений <see cref="sbyte"/>.</para>
        /// </summary>
        public static Range<sbyte> SByte
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => new Range<sbyte>(sbyte.MinValue, sbyte.MaxValue);
        }

        /// <summary>
        /// <para>Gets the whole <see cref="short"/> values range.</para>
        /// <para>Возвращает весь диапазон значений <see cref="short"/>.</para>
        /// </summary>
        public static Range<short> Int16
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => new Range<short>(short.MinValue, short.MaxValue);
        }

        /// <summary>
        /// <para>Gets the whole <see cref="int"/> values range.</para>
        /// <para>Возвращает весь диапазон значений <see cref="int"/>.</para>
        /// </summary>
        public static Range<int> Int32
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => new Range<int>(int.MinValue, int.MaxValue);
        }

        /// <summary>
        /// <para>Gets the whole <see cref="long"/> values range.</para>
        /// <para>Возвращает весь диапазон значений <see cref="long"/>.</para>
        /// </summary>
        public static Range<long> Int64
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => new Range<long>(long.MinValue, long.MaxValue);
        }

        /// <summary>
        /// <para>Gets the whole <see cref="byte"/> values range.</para>
        /// <para>Возвращает весь диапазон значений <see cref="byte"/>.</para>
        /// </summary>
        public static Range<byte> Byte
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => new Range<byte>(byte.MinValue, byte.MaxValue);
        }

        /// <summary>
        /// <para>Gets the whole <see cref="ushort"/> values range.</para>
        /// <para>Возвращает весь диапазон значений <see cref="ushort"/>.</para>
        /// </summary>
        public static Range<ushort> UInt16
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => new Range<ushort>(ushort.MinValue, ushort.MaxValue);
        }

        /// <summary>
        /// <para>Gets the whole <see cref="uint"/> values range.</para>
        /// <para>Возвращает весь диапазон значений <see cref="uint"/>.</para>
        /// </summary>
        public static Range<uint> UInt32
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => new Range<uint>(uint.MinValue, uint.MaxValue);
        }

        /// <summary>
        /// <para>Gets the whole <see cref="ulong"/> values range.</para>
        /// <para>Возвращает весь диапазон значений <see cref="ulong"/>.</para>
        /// </summary>
        public static Range<ulong> UInt64
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => new Range<ulong>(ulong.MinValue, ulong.MaxValue);
        }

        /// <summary>
        /// <para>Gets the whole <see cref="float"/> values range.</para>
        /// <para>Возвращает весь диапазон значений <see cref="float"/>.</para>
        /// </summary>
        public static Range<float> Single
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => new Range<float>(float.MinValue, float.MaxValue);
        }

        /// <summary>
        /// <para>Gets the whole <see cref="double"/> values range.</para>
        /// <para>Возвращает весь диапазон значений <see cref="double"/>.</para>
        /// </summary>
        public static Range<double> Double
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => new Range<double>(double.MinValue, double.MaxValue);
        }

        /// <summary>
        /// <para>Gets the whole <see cref="decimal"/> values range.</para>
        /// <para>Возвращает весь диапазон значений <see cref="decimal"/>.</para>
        /// </summary>
        public static Range<decimal> Decimal
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => new Range<decimal>(decimal.MinValue, decimal.MaxValue);
        }
    }
}
