#include <stdio.h>
#include <stdlib.h>
#include <string.h>

#define FILE_NAME "employees.dat"

typedef struct {
    int id;
    char name[50];
    float salary;
    char department[30];
    int is_active;
} Employee;


void addEmployee(FILE *fp, Employee emp) {
    fseek(fp, 0, SEEK_END); 
    fwrite(&emp, sizeof(Employee), 1, fp);
    fflush(fp);
    printf("Employee added successfully.\n");
}


int findEmployeeRecordNum(FILE *fp, int id) {
    Employee emp;
    int rec_num = 0;
    rewind(fp);

    while (fread(&emp, sizeof(Employee), 1, fp) == 1) {
        if (emp.is_active && emp.id == id)
            return rec_num;
        rec_num++;
    }
    return -1;
}


int readEmployee(FILE *fp, int rec_num, Employee *emp) {
    fseek(fp, rec_num * sizeof(Employee), SEEK_SET);
    if (fread(emp, sizeof(Employee), 1, fp) == 1)
        return 1;
    return 0;
}


void updateEmployee(FILE *fp, int rec_num, Employee emp) {
    fseek(fp, rec_num * sizeof(Employee), SEEK_SET);
    fwrite(&emp, sizeof(Employee), 1, fp);
    fflush(fp);
    printf("Employee updated successfully.\n");
}

void deleteEmployee(FILE *fp, int rec_num) {
    Employee emp;
    if (readEmployee(fp, rec_num, &emp)) {
        emp.is_active = 0;
        updateEmployee(fp, rec_num, emp);
        printf("Employee deleted (soft delete).\n");
    } else {
        printf("Failed to delete employee.\n");
    }
}


void listEmployees(FILE *fp) {
    Employee emp;
    rewind(fp);
    printf("\n--- Employee List ---\n");
    printf("ID\tName\t\tSalary\tDepartment\n");
    printf("-----------------------------------------------\n");
    while (fread(&emp, sizeof(Employee), 1, fp) == 1) {
        if (emp.is_active) {
            printf("%d\t%-15s\t%.2f\t%s\n", emp.id, emp.name, emp.salary, emp.department);
        }
    }
    printf("-----------------------------------------------\n\n");
}


void menu() {
    printf("1. Add Employee\n");
    printf("2. Search Employee by ID\n");
    printf("3. Update Employee\n");
    printf("4. Delete Employee\n");
    printf("5. List Employees\n");
    printf("0. Exit\n");
    printf("Enter choice: ");
}

int main() {
    FILE *fp = fopen(FILE_NAME, "rb+");
    if (!fp) {
        
        fp = fopen(FILE_NAME, "wb+");
        if (!fp) {
            perror("File opening failed");
            return 1;
        }
    }

    int choice;
    Employee emp;
    int rec_num;

    while (1) {
        menu();
        scanf("%d", &choice);
        getchar();

        switch (choice) {
            case 1:
                printf("Enter ID: ");
                scanf("%d", &emp.id);
                getchar();

            
                if (findEmployeeRecordNum(fp, emp.id) != -1) {
                    printf("Employee ID already exists.\n");
                    break;
                }

                printf("Enter Name: ");
                fgets(emp.name, sizeof(emp.name), stdin);
                emp.name[strcspn(emp.name, "\n")] = 0;

                printf("Enter Salary: ");
                scanf("%f", &emp.salary);
                getchar();

                printf("Enter Department: ");
                fgets(emp.department, sizeof(emp.department), stdin);
                emp.department[strcspn(emp.department, "\n")] = 0;

                emp.is_active = 1;
                addEmployee(fp, emp);
                break;

            case 2:
                printf("Enter Employee ID to search: ");
                int id;
                scanf("%d", &id);
                getchar();

                rec_num = findEmployeeRecordNum(fp, id);
                if (rec_num == -1) {
                    printf("Employee not found.\n");
                } else {
                    readEmployee(fp, rec_num, &emp);
                    printf("ID: %d\nName: %s\nSalary: %.2f\nDepartment: %s\n", 
                        emp.id, emp.name, emp.salary, emp.department);
                }
                break;

            case 3:
                printf("Enter Employee ID to update: ");
                scanf("%d", &id);
                getchar();

                rec_num = findEmployeeRecordNum(fp, id);
                if (rec_num == -1) {
                    printf("Employee not found.\n");
                    break;
                }
                readEmployee(fp, rec_num, &emp);

                printf("Enter new Name (current: %s): ", emp.name);
                fgets(emp.name, sizeof(emp.name), stdin);
                emp.name[strcspn(emp.name, "\n")] = 0;

                printf("Enter new Salary (current: %.2f): ", emp.salary);
                scanf("%f", &emp.salary);
                getchar();

                printf("Enter new Department (current: %s): ", emp.department);
                fgets(emp.department, sizeof(emp.department), stdin);
                emp.department[strcspn(emp.department, "\n")] = 0;

                updateEmployee(fp, rec_num, emp);
                break;

            case 4:
                printf("Enter Employee ID to delete: ");
                scanf("%d", &id);
                getchar();

                rec_num = findEmployeeRecordNum(fp, id);
                if (rec_num == -1) {
                    printf("Employee not found.\n");
                } else {
                    deleteEmployee(fp, rec_num);
                }
                break;

            case 5:
                listEmployees(fp);
                break;

            case 0:
                fclose(fp);
                printf("Exiting...\n");
                return 0;

            default:
                printf("Invalid choice.\n");
        }
    }
}
