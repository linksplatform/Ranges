namespace Platform::Ranges
{
    template<typename T> requires requires(T a, T b) { a - b; }
    auto Difference(Range<T> range)
    {
        return range.Maximum - range.Minimum;
    }
}
