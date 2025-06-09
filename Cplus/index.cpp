#include <iostream>
#include <vector>
#include <fstream>
#include <sstream>

class Student {
private:
    int id;
    std::string name;
    int age;

public:
    Student(int id, const std::string& name, int age)
        : id(id), name(name), age(age) {}

    // Display student info
    void display() const {
        std::cout << "ID: " << id 
                  << ", Name: " << name 
                  << ", Age: " << age << std::endl;
    }

    int getId() const { return id; }
    const std::string& getName() const { return name; }
    int getAge() const { return age; }

    void setName(const std::string& newName) { name = newName; }
    void setAge(int newAge) { age = newAge; }
};

class School {
private:
    std::vector<Student> students;

public:
    // Add a student
    void addStudent(const Student& student) {
        students.push_back(student);
        std::cout << "Student added successfully.\n";
    }

    // Remove student by ID
    void removeStudent(int id) {
        for (auto it = students.begin(); it != students.end(); ++it) {
            if (it->getId() == id) {
                students.erase(it);
                std::cout << "Student removed successfully.\n";
                return;
            }
        }
        std::cout << "Student with ID " << id << " not found.\n";
    }

    // Search student by ID
    void searchStudent(int id) const {
        for (const auto& student : students) {
            if (student.getId() == id) {
                std::cout << "Student found:\n";
                student.display();
                return;
            }
        }
        std::cout << "Student with ID " << id << " not found.\n";
    }

    // Display all students
    void displayAllStudents() const {
        if (students.empty()) {
            std::cout << "No students to display.\n";
            return;
        }

        std::cout << "All Students:\n";
        for (const auto& student : students) {
            student.display();
        }
    }

    // Save students to file (CSV format: id,name,age)
    void saveToFile(const std::string& filename) const {
        std::ofstream file(filename);
        if (!file) {
            std::cerr << "Error opening file for writing.\n";
            return;
        }

        for (const auto& student : students) {
            file << student.getId() << ","
                 << student.getName() << ","
                 << student.getAge() << "\n";
        }

        file.close();
        std::cout << "Data saved to " << filename << std::endl;
    }

    // Load students from file
    void loadFromFile(const std::string& filename) {
        std::ifstream file(filename);
        if (!file) {
            std::cerr << "Error opening file for reading.\n";
            return;
        }

        students.clear();

        std::string line;
        while (std::getline(file, line)) {
            std::stringstream ss(line);
            std::string idStr, name, ageStr;

            if (!std::getline(ss, idStr, ',')) continue;
            if (!std::getline(ss, name, ',')) continue;
            if (!std::getline(ss, ageStr, ',')) continue;

            int id = std::stoi(idStr);
            int age = std::stoi(ageStr);

            students.emplace_back(id, name, age);
        }

        file.close();
        std::cout << "Data loaded from " << filename << std::endl;
    }
};

// Example usage
int main() {
    School school;

    // Load data if available
    school.loadFromFile("students.txt");

    // Add some students
    school.addStudent(Student(1, "Alice", 15));
    school.addStudent(Student(2, "Bob", 16));

    // Display all students
    school.displayAllStudents();

    // Search for a student
    school.searchStudent(1);

    // Remove a student
    school.removeStudent(2);

    // Display all students again
    school.displayAllStudents();

    // Save current data
    school.saveToFile("students.txt");

    return 0;
}
