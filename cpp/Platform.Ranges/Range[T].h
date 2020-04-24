namespace Platform::Ranges
{
    template <typename ...> struct Range;
    template <typename T> struct Range<T>
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

        public: operator std::string() const { return std::string("[").append(Platform::Converters::To<std::string>(Minimum)).append(", ").append(Platform::Converters::To<std::string>(Maximum)).append(1, ']'); }

        public: friend std::ostream & operator <<(std::ostream &out, const Range<T> &obj) { return out << (std::string)obj; }

        public: bool Contains(T value) { return Minimum <= value && Maximum >= value; }

        public: bool Contains(Range<T> range) { return this->Contains(range.Minimum) && this->Contains(range.Maximum); }

        public: bool operator ==(const Range<T> &other) const { return Minimum == other.Minimum && Maximum == other.Maximum; }

        public: operator std::tuple<T, T>() const { return {this->Minimum, this->Maximum}; }

        public: Range(std::tuple<T, T> tuple) : Range(std::get<0>(tuple), std::get<1>(tuple)) { }
    };
}

namespace std
{
    template <typename T>
    struct hash<Platform::Ranges::Range<T>>
    {
        std::size_t operator()(const Platform::Ranges::Range<T> &obj) const
        {
            return Platform::Hashing::Hash(obj.Minimum, obj.Maximum);
        }
    };
}
