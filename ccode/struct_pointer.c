#include <stdio.h>
#include <stdlib.h>
#include <string.h>

#define MAX_EMPLOYEES 100

typedef struct {
    int id;
    char name[50];
    float salary;
} Employee;

Employee* employees[MAX_EMPLOYEES];
int employee_count = 0;

void addEmployee(int id, const char* name, float salary) {
    if (employee_count >= MAX_EMPLOYEES) {
        printf("Employee list is full!\n");
        return;
    }

    Employee* emp = (Employee*) malloc(sizeof(Employee));
    if (!emp) {
        printf("Memory allocation failed!\n");
        return;
    }

    emp->id = id;
    strncpy(emp->name, name, sizeof(emp->name) - 1);
    emp->name[sizeof(emp->name) - 1] = '\0';
    emp->salary = salary;

    employees[employee_count++] = emp;

    printf("Added employee: %s\n", emp->name);
}

void updateSalary(Employee* emp, float new_salary) {
    if (emp == NULL) {
        printf("Invalid employee pointer!\n");
        return;
    }
    emp->salary = new_salary;
    printf("Updated salary for %s to %.2f\n", emp->name, new_salary);
}

void displayEmployees() {
    printf("\n--- Employee List ---\n");
    if (employee_count == 0) {
        printf("No employees to display.\n");
        return;
    }
    for (int i = 0; i < employee_count; i++) {
        Employee* emp = employees[i];
        printf("ID: %d, Name: %s, Salary: %.2f\n", emp->id, emp->name, emp->salary);
    }
}

Employee* findEmployeeById(int id) {
    for (int i = 0; i < employee_count; i++) {
        if (employees[i]->id == id) {
            return employees[i];
        }
    }
    return NULL;
}

void deleteEmployee(int id) {
    int found_index = -1;
    for (int i = 0; i < employee_count; i++) {
        if (employees[i]->id == id) {
            found_index = i;
            break;
        }
    }

    if (found_index == -1) {
        printf("Employee with ID %d not found.\n", id);
        return;
    }

    free(employees[found_index]);

    for (int i = found_index; i < employee_count - 1; i++) {
        employees[i] = employees[i + 1];
    }
    employee_count--;

    printf("Deleted employee with ID %d\n", id);
}

int main() {
    addEmployee(101, "Alice", 60000);
    addEmployee(102, "Bob", 55000);
    addEmployee(103, "Charlie", 70000);

    displayEmployees();

    Employee* emp = findEmployeeById(102);
    if (emp != NULL) {
        updateSalary(emp, 58000);
    } else {
        printf("Employee not found.\n");
    }

    displayEmployees();

    deleteEmployee(101);

    displayEmployees();

    
    for (int i = 0; i < employee_count; i++) {
        free(employees[i]);
    }

    return 0;
}
