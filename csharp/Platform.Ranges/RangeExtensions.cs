using System.Runtime.CompilerServices;

namespace Platform.Ranges
{
    /// <summary>
    /// <para>Represents a set of extension methods for <see cref="Range{T}"/> structs.</para>
    /// <para>Представляет набор методов расширения для структур <see cref="Range{T}"/>.</para>
    /// </summary>
    public static class RangeExtensions
    {
        /// <summary>
        /// <para>Calculates difference between <see cref="Range{T}.Minimum"/> and <see cref="Range{T}.Maximum"/>.</para>
        /// <para>Вычисляет разницу между <see cref="Range{T}.Minimum"/> и <see cref="Range{T}.Maximum"/>.</para>
        /// </summary>
        /// <param name="range"><para>The range of <see cref="ulong"/>.</para><para>Диапазон значений <see cref="ulong"/>.</para></param>
        /// <returns><para>Difference between <see cref="Range{T}.Minimum"/> and <see cref="Range{T}.Maximum"/>.</para><para>Разницу между <see cref="Range{T}.Minimum"/> и <see cref="Range{T}.Maximum"/>.</para></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong Difference(this Range<ulong> range) => range.Maximum - range.Minimum;

        /// <summary>
        /// <para>Calculates difference between <see cref="Range{T}.Minimum"/> and <see cref="Range{T}.Maximum"/>.</para>
        /// <para>Вычисляет разницу между <see cref="Range{T}.Minimum"/> и <see cref="Range{T}.Maximum"/>.</para>
        /// </summary>
        /// <param name="range"><para>The range of <see cref="uint"/>.</para><para>Диапазон значений <see cref="uint"/>.</para></param>
        /// <returns><para>Difference between <see cref="Range{T}.Minimum"/> and <see cref="Range{T}.Maximum"/>.</para><para>Разницу между <see cref="Range{T}.Minimum"/> и <see cref="Range{T}.Maximum"/>.</para></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint Difference(this Range<uint> range) => range.Maximum - range.Minimum;

        /// <summary>
        /// <para>Calculates difference between <see cref="Range{T}.Minimum"/> and <see cref="Range{T}.Maximum"/>.</para>
        /// <para>Вычисляет разницу между <see cref="Range{T}.Minimum"/> и <see cref="Range{T}.Maximum"/>.</para>
        /// </summary>
        /// <param name="range"><para>The range of <see cref="ushort"/>.</para><para>Диапазон значений <see cref="ushort"/>.</para></param>
        /// <returns><para>Difference between <see cref="Range{T}.Minimum"/> and <see cref="Range{T}.Maximum"/>.</para><para>Разницу между <see cref="Range{T}.Minimum"/> и <see cref="Range{T}.Maximum"/>.</para></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort Difference(this Range<ushort> range) => (ushort)(range.Maximum - range.Minimum);

        /// <summary>
        /// <para>Calculates difference between <see cref="Range{T}.Minimum"/> and <see cref="Range{T}.Maximum"/>.</para>
        /// <para>Вычисляет разницу между <see cref="Range{T}.Minimum"/> и <see cref="Range{T}.Maximum"/>.</para>
        /// </summary>
        /// <param name="range"><para>The range of <see cref="byte"/>.</para><para>Диапазон значений <see cref="byte"/>.</para></param>
        /// <returns><para>Difference between <see cref="Range{T}.Minimum"/> and <see cref="Range{T}.Maximum"/>.</para><para>Разницу между <see cref="Range{T}.Minimum"/> и <see cref="Range{T}.Maximum"/>.</para></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte Difference(this Range<byte> range) => (byte)(range.Maximum - range.Minimum);

        /// <summary>
        /// <para>Calculates difference between <see cref="Range{T}.Minimum"/> and <see cref="Range{T}.Maximum"/>.</para>
        /// <para>Вычисляет разницу между <see cref="Range{T}.Minimum"/> и <see cref="Range{T}.Maximum"/>.</para>
        /// </summary>
        /// <param name="range"><para>The range of <see cref="long"/>.</para><para>Диапазон значений <see cref="long"/>.</para></param>
        /// <returns><para>Difference between <see cref="Range{T}.Minimum"/> and <see cref="Range{T}.Maximum"/>.</para><para>Разницу между <see cref="Range{T}.Minimum"/> и <see cref="Range{T}.Maximum"/>.</para></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long Difference(this Range<long> range) => range.Maximum - range.Minimum;

        /// <summary>
        /// <para>Calculates difference between <see cref="Range{T}.Minimum"/> and <see cref="Range{T}.Maximum"/>.</para>
        /// <para>Вычисляет разницу между <see cref="Range{T}.Minimum"/> и <see cref="Range{T}.Maximum"/>.</para>
        /// </summary>
        /// <param name="range"><para>The range of <see cref="int"/>.</para><para>Диапазон значений <see cref="int"/>.</para></param>
        /// <returns><para>Difference between <see cref="Range{T}.Minimum"/> and <see cref="Range{T}.Maximum"/>.</para><para>Разницу между <see cref="Range{T}.Minimum"/> и <see cref="Range{T}.Maximum"/>.</para></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Difference(this Range<int> range) => range.Maximum - range.Minimum;

        /// <summary>
        /// <para>Calculates difference between <see cref="Range{T}.Minimum"/> and <see cref="Range{T}.Maximum"/>.</para>
        /// <para>Вычисляет разницу между <see cref="Range{T}.Minimum"/> и <see cref="Range{T}.Maximum"/>.</para>
        /// </summary>
        /// <param name="range"><para>The range of <see cref="short"/>.</para><para>Диапазон значений <see cref="short"/>.</para></param>
        /// <returns><para>Difference between <see cref="Range{T}.Minimum"/> and <see cref="Range{T}.Maximum"/>.</para><para>Разницу между <see cref="Range{T}.Minimum"/> и <see cref="Range{T}.Maximum"/>.</para></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short Difference(this Range<short> range) => (short)(range.Maximum - range.Minimum);

        /// <summary>
        /// <para>Calculates difference between <see cref="Range{T}.Minimum"/> and <see cref="Range{T}.Maximum"/>.</para>
        /// <para>Вычисляет разницу между <see cref="Range{T}.Minimum"/> и <see cref="Range{T}.Maximum"/>.</para>
        /// </summary>
        /// <param name="range"><para>The range of <see cref="sbyte"/>.</para><para>Диапазон значений <see cref="sbyte"/>.</para></param>
        /// <returns><para>Difference between <see cref="Range{T}.Minimum"/> and <see cref="Range{T}.Maximum"/>.</para><para>Разницу между <see cref="Range{T}.Minimum"/> и <see cref="Range{T}.Maximum"/>.</para></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte Difference(this Range<sbyte> range) => (sbyte)(range.Maximum - range.Minimum);

        /// <summary>
        /// <para>Calculates difference between <see cref="Range{T}.Minimum"/> and <see cref="Range{T}.Maximum"/>.</para>
        /// <para>Вычисляет разницу между <see cref="Range{T}.Minimum"/> и <see cref="Range{T}.Maximum"/>.</para>
        /// </summary>
        /// <param name="range"><para>The range of <see cref="double"/>.</para><para>Диапазон значений <see cref="double"/>.</para></param>
        /// <returns><para>Difference between <see cref="Range{T}.Minimum"/> and <see cref="Range{T}.Maximum"/>.</para><para>Разницу между <see cref="Range{T}.Minimum"/> и <see cref="Range{T}.Maximum"/>.</para></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Difference(this Range<double> range) => range.Maximum - range.Minimum;

        /// <summary>
        /// <para>Calculates difference between <see cref="Range{T}.Minimum"/> and <see cref="Range{T}.Maximum"/>.</para>
        /// <para>Вычисляет разницу между <see cref="Range{T}.Minimum"/> и <see cref="Range{T}.Maximum"/>.</para>
        /// </summary>
        /// <param name="range"><para>The range of <see cref="float"/>.</para><para>Диапазон значений <see cref="float"/>.</para></param>
        /// <returns><para>Difference between <see cref="Range{T}.Minimum"/> and <see cref="Range{T}.Maximum"/>.</para><para>Разницу между <see cref="Range{T}.Minimum"/> и <see cref="Range{T}.Maximum"/>.</para></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Difference(this Range<float> range) => range.Maximum - range.Minimum;

        /// <summary>
        /// <para>Calculates difference between <see cref="Range{T}.Minimum"/> and <see cref="Range{T}.Maximum"/>.</para>
        /// <para>Вычисляет разницу между <see cref="Range{T}.Minimum"/> и <see cref="Range{T}.Maximum"/>.</para>
        /// </summary>
        /// <param name="range"><para>The range of <see cref="decimal"/>.</para><para>Диапазон значений <see cref="decimal"/>.</para></param>
        /// <returns><para>Difference between <see cref="Range{T}.Minimum"/> and <see cref="Range{T}.Maximum"/>.</para><para>Разницу между <see cref="Range{T}.Minimum"/> и <see cref="Range{T}.Maximum"/>.</para></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static decimal Difference(this Range<decimal> range) => range.Maximum - range.Minimum;
    }
}
