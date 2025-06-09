#include <iostream>
template<typename T>
class Box {
    T value;
public:
    Box(T val) : value(val) {}
    void show() const { std::cout << value << "\n"; }
};

int main() {
    Box<int> b1(42);
    Box<std::string> b2("Hello");
    b1.show();
    b2.show();
}
