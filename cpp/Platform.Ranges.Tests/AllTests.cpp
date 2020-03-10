#include "pch.h"

#include <Platform.Ranges.h>

#include <locale>
#include <codecvt>
#include <string>

#include "CppUnitTest.h"

namespace Microsoft::VisualStudio::CppUnitTestFramework
{
    template<> static std::wstring ToString<Platform::Ranges::Range<std::int32_t>>(const struct Platform::Ranges::Range<std::int32_t> &t)
    {
        std::wstring_convert<std::codecvt_utf8_utf16<wchar_t>> converter;
        auto string = Platform::Converters::To<std::string>(t);
        return converter.from_bytes(string);
    }
}

using namespace Microsoft::VisualStudio::CppUnitTestFramework;
#include "EnsureExtensionsTests.cpp"
#include "RangeTests.cpp"