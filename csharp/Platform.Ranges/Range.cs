namespace Platform.Ranges
{
    /// <summary>
    /// <para>Contains static fields with <see cref="Range{T}"/> constants.</para>
    /// <para>Содержит статические поля с константами типа <see cref="Range{T}"/>.</para>
    /// </summary>
    public static class Range
    {
        /// <summary>
        /// <para>Gets the whole <see cref="sbyte"/> values range.</para>
        /// <para>Возвращает весь диапазон значений <see cref="sbyte"/>.</para>
        /// </summary>
        public static readonly Range<sbyte> SByte = new Range<sbyte>(sbyte.MinValue, sbyte.MaxValue);

        /// <summary>
        /// <para>Gets the whole <see cref="short"/> values range.</para>
        /// <para>Возвращает весь диапазон значений <see cref="short"/>.</para>
        /// </summary>
        public static readonly Range<short> Int16 = new Range<short>(short.MinValue, short.MaxValue);

        /// <summary>
        /// <para>Gets the whole <see cref="int"/> values range.</para>
        /// <para>Возвращает весь диапазон значений <see cref="int"/>.</para>
        /// </summary>
        public static readonly Range<int> Int32 = new Range<int>(int.MinValue, int.MaxValue);

        /// <summary>
        /// <para>Gets the whole <see cref="long"/> values range.</para>
        /// <para>Возвращает весь диапазон значений <see cref="long"/>.</para>
        /// </summary>
        public static readonly Range<long> Int64 = new Range<long>(long.MinValue, long.MaxValue);

        /// <summary>
        /// <para>Gets the whole <see cref="byte"/> values range.</para>
        /// <para>Возвращает весь диапазон значений <see cref="byte"/>.</para>
        /// </summary>
        public static readonly Range<byte> Byte = new Range<byte>(byte.MinValue, byte.MaxValue);

        /// <summary>
        /// <para>Gets the whole <see cref="ushort"/> values range.</para>
        /// <para>Возвращает весь диапазон значений <see cref="ushort"/>.</para>
        /// </summary>
        public static readonly Range<ushort> UInt16 = new Range<ushort>(ushort.MinValue, ushort.MaxValue);

        /// <summary>
        /// <para>Gets the whole <see cref="uint"/> values range.</para>
        /// <para>Возвращает весь диапазон значений <see cref="uint"/>.</para>
        /// </summary>
        public static readonly Range<uint> UInt32 = new Range<uint>(uint.MinValue, uint.MaxValue);

        /// <summary>
        /// <para>Gets the whole <see cref="ulong"/> values range.</para>
        /// <para>Возвращает весь диапазон значений <see cref="ulong"/>.</para>
        /// </summary>
        public static readonly Range<ulong> UInt64 = new Range<ulong>(ulong.MinValue, ulong.MaxValue);

        /// <summary>
        /// <para>Gets the whole <see cref="float"/> values range.</para>
        /// <para>Возвращает весь диапазон значений <see cref="float"/>.</para>
        /// </summary>
        public static readonly Range<float> Single = new Range<float>(float.MinValue, float.MaxValue);

        /// <summary>
        /// <para>Gets the whole <see cref="double"/> values range.</para>
        /// <para>Возвращает весь диапазон значений <see cref="double"/>.</para>
        /// </summary>
        public static readonly Range<double> Double = new Range<double>(double.MinValue, double.MaxValue);

        /// <summary>
        /// <para>Gets the whole <see cref="decimal"/> values range.</para>
        /// <para>Возвращает весь диапазон значений <see cref="decimal"/>.</para>
        /// </summary>
        public static readonly Range<decimal> Decimal = new Range<decimal>(decimal.MinValue, decimal.MaxValue);
    }
}
