#include <iostream>
#include <vector>
#include <algorithm>

class Student {
    int id;
    std::string name;
    int age;
public:
    Student(int i, std::string n, int a) : id(i), name(std::move(n)), age(a) {}
    int getId() const { return id; }
    const std::string& getName() const { return name; }
    int getAge() const { return age; }
    void setAge(int a) { age = a; }
    void display() const {
        std::cout << id << " " << name << " " << age << "\n";
    }
};

int main() {
    std::vector<Student> students;
    students.reserve(100);  // Optimize for bulk insertions

    students.emplace_back(1, "Alice", 15);
    students.emplace_back(2, "Bob", 16);
    students.emplace_back(3, "Charlie", 15);

    // Remove student with id 2
    students.erase(
        std::remove_if(students.begin(), students.end(),
                       [](const Student& s){ return s.getId() == 2; }),
        students.end());

    // Sort by age
    std::sort(students.begin(), students.end(),
              [](const Student& a, const Student& b) { return a.getAge() < b.getAge(); });

    // Increase age by 1 (birthday)
    std::transform(students.begin(), students.end(), students.begin(),
                   [](Student& s) {
                       s.setAge(s.getAge() + 1);
                       return s;
                   });

    // Display all students
    for (const auto& s : students) {
        s.display();
    }

    return 0;
}
