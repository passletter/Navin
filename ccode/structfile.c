#include <stdio.h>

typedef struct {
    int id;
    char name[30];
    float salary;
} Employee;

void save_employees(const char *filename, Employee *emps, int count) {
    FILE *f = fopen(filename, "w");
    if (!f) {
        perror("Open file");
        return;
    }

    for (int i = 0; i < count; i++) {
        fprintf(f, "%d %s %.2f\n", emps[i].id, emps[i].name, emps[i].salary);
    }

    fclose(f);
}

void load_employees(const char *filename, Employee *emps, int *count) {
    FILE *f = fopen(filename, "r");
    if (!f) {
        perror("Open file");
        return;
    }

    *count = 0;
    while (fscanf(f, "%d %s %f", &emps[*count].id, emps[*count].name, &emps[*count].salary) == 3) {
        (*count)++;
    }

    fclose(f);
}

int main() {
    Employee emps[10] = {
        {1, "Alice", 50000},
        {2, "Bob", 60000}
    };
    int count = 2;

    save_employees("emps.txt", emps, count);

    Employee loaded[10];
    int loaded_count = 0;
    load_employees("emps.txt", loaded, &loaded_count);

    for (int i = 0; i < loaded_count; i++) {
        printf("%d %s %.2f\n", loaded[i].id, loaded[i].name, loaded[i].salary);
    }
    return 0;
}
