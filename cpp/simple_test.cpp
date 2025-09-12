#include <iostream>
#include <gsl/gsl>

void test_expects() {
    int x = 5;
    Expects(x > 0);  // This should pass
    std::cout << "First Expects passed" << std::endl;
    
    std::cout << "About to test failing Expects..." << std::endl;
    Expects(false);  // This should terminate the program
    std::cout << "This should not be reached!" << std::endl;
}

int main() {
    test_expects();
    return 0;
}