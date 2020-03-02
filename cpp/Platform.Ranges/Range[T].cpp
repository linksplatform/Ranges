namespace Platform::Ranges
{
    struct Range<T>
    {
        public: T Minimum = 0;

        public: T Maximum = 0;

        public: Range(T minimumAndMaximum)
        {
            Minimum = minimumAndMaximum;
            Maximum = minimumAndMaximum;
        }

        public: Range(T minimum, T maximum)
        {
            Platform::Ranges::EnsureExtensions::MaximumArgumentIsGreaterOrEqualToMinimum(Platform::Exceptions::Ensure::Always, minimum, maximum, "maximum");
            Minimum = minimum;
            Maximum = maximum;
        }

        public: operator std::string() const { return std::string("[").append(Platform::Converters::To<std::string>(Minimum)).append(", ").append(Platform::Converters::To<std::string>(Maximum)).append(1, ']').data(); }

        public: friend std::ostream & operator << (std::ostream &out, const Range<T> &obj) { return out << (std::string)obj; }

        public: bool Contains(T value) { return Minimum <= value && Maximum >= value; }

        public: bool Contains(Range<T> range) { return this->Contains(range.Minimum) && this->Contains(range.Maximum); }

        public: bool operator ==(const Range<T> &other) const { return Minimum == other.Minimum && Maximum == other.Maximum; }

        public: static implicit operator std::tuple<T, T>(Range<T> range) { return {range.Minimum, range.Maximum}; }

        public: static implicit operator Range<T>(std::tuple<T, T> tuple) { return new Range<T>(tuple.Item1, tuple.Item2); }

        public: override std::int32_t GetHashCode() { return {Minimum, Maximum}.GetHashCode(); }
    };
}
