#include <gsl/gsl>
#include <iostream>

int main() {
    int x = 5;
    Expects(x > 0);
    std::cout << "GSL Expects works!" << std::endl;
    return 0;
}