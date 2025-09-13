#include "../cpp/Platform.Ranges/Platform.Ranges.h"
#include <iostream>
#include <type_traits>

int main()
{
    // Test single parameter deduction
    auto range1 = Platform::Ranges::Range(5);
    static_assert(std::is_same_v<decltype(range1), Platform::Ranges::Range<int>>);
    
    // Test two parameter deduction  
    auto range2 = Platform::Ranges::Range(1, 10);
    static_assert(std::is_same_v<decltype(range2), Platform::Ranges::Range<int>>);
    
    // Test mixed types deduction
    auto range3 = Platform::Ranges::Range(1, 10.5);
    static_assert(std::is_same_v<decltype(range3), Platform::Ranges::Range<double>>);
    
    std::cout << "All deduction guide tests passed!" << std::endl;
    
    return 0;
}