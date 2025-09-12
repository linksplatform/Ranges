#include <iostream>
#include <gsl/gsl>
#include <string>
#include <Platform.Converters.h>

// Simplified headers for testing
namespace Platform::Converters {
    template<typename T, typename U>
    T To(U&& value) {
        if constexpr (std::is_same_v<T, std::string> && std::is_integral_v<std::decay_t<U>>) {
            return std::to_string(value);
        }
        return static_cast<T>(value);
    }
}

namespace Platform::Hashing {
    template<typename... Args>
    std::size_t Hash(Args&&... args) {
        return 0; // Simplified implementation
    }
}

#include "Platform.Ranges/Range[T].h"

int main() {
    try {
        Platform::Ranges::Range<int> validRange(1, 3);
        std::cout << "Valid range created: " << validRange.Minimum << " to " << validRange.Maximum << std::endl;
        
        std::cout << "About to create invalid range (2, 1) - this should terminate with GSL::Expects..." << std::endl;
        Platform::Ranges::Range<int> invalidRange(2, 1);  // This should terminate the program
        
        std::cout << "This line should not be reached!" << std::endl;
    } catch (...) {
        std::cout << "Caught exception (should not happen with GSL::Expects)" << std::endl;
    }
    
    return 0;
}