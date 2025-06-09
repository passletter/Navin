#include <stdio.h>
#include <stdlib.h>
#include <string.h>

#define MAX_COURSES 10
#define MAX_NAME_LEN 50





//Here we calculate the gpa of students in the range of 0-4
typedef struct {
    char course_name[30];
    float grade;
    int attendance;
} Course;

typedef struct {
    int student_id;
    char name[MAX_NAME_LEN];
    Course courses[MAX_COURSES];
    int course_count;
} Student;


void add_student(FILE *fp, Student *s) {
    fseek(fp, 0, SEEK_END);
    fwrite(s, sizeof(Student), 1, fp);
}


long find_student(FILE *fp, int student_id, Student *s) {
    rewind(fp);
    while (fread(s, sizeof(Student), 1, fp) == 1) {
        if (s->student_id == student_id) {
            return ftell(fp) - sizeof(Student);
        }
    }
    return -1;
}

void update_student_grades(FILE *fp, int student_id) {
    Student s;
    long pos = find_student(fp, student_id, &s);
    if (pos == -1) {
        printf("Student not found\n");
        return;
    }

    for (int i = 0; i < s.course_count; i++) {
        s.courses[i].grade += 0.1f;
        if (s.courses[i].grade > 4.0f) s.courses[i].grade = 4.0f;
    }
    fseek(fp, pos, SEEK_SET);
    fwrite(&s, sizeof(Student), 1, fp);
    printf("Student grades updated\n");
}


float calculate_gpa(Student *s) {
    if (s->course_count == 0) return 0.0f;
    float total = 0;
    for (int i = 0; i < s->course_count; i++) {
        total += s->courses[i].grade;
    }
    return total / s->course_count;
}


void generate_report(Student *s) {
    char filename[64];
    snprintf(filename, sizeof(filename), "report_%d.txt", s->student_id);
    FILE *f = fopen(filename, "w");
    if (!f) {
        perror("Error creating report file");
        return;
    }
    fprintf(f, "Report Card for %s (ID: %d)\n", s->name, s->student_id);
    fprintf(f, "---------------------------------\n");
    fprintf(f, "Courses:\n");
    for (int i = 0; i < s->course_count; i++) {
        fprintf(f, "%s - Grade: %.2f, Attendance: %d%%\n",
                s->courses[i].course_name,
                s->courses[i].grade,
                s->courses[i].attendance);
    }
    fprintf(f, "\nGPA: %.2f\n", calculate_gpa(s));
    fclose(f);
    printf("Report generated: %s\n", filename);
}

void input_student(Student *s) {
    printf("Enter Student ID: ");
    scanf("%d", &s->student_id);
    getchar();
    printf("Enter Student Name: ");
    fgets(s->name, MAX_NAME_LEN, stdin);
    s->name[strcspn(s->name, "\n")] = 0;

    printf("Enter number of courses (max %d): ", MAX_COURSES);
    scanf("%d", &s->course_count);
    getchar();
    if (s->course_count > MAX_COURSES) s->course_count = MAX_COURSES;

    for (int i = 0; i < s->course_count; i++) {
        printf("Course %d name: ", i+1);
        fgets(s->courses[i].course_name, 30, stdin);
        s->courses[i].course_name[strcspn(s->courses[i].course_name, "\n")] = 0;

        printf("Grade (0.0-4.0): ");
        scanf("%f", &s->courses[i].grade);

        printf("Attendance (0-100%%): ");
        scanf("%d", &s->courses[i].attendance);
        getchar();
    }
}

int main() {
    FILE *fp = fopen("students.dat", "r+b");
    if (!fp) {
        fp = fopen("students.dat", "w+b");
        if (!fp) {
            perror("Cannot open students.dat");
            return 1;
        }
    }

    int choice;
    Student s;
    int sid;

    while (1) {
        printf("\nStudent Report Card System\n");
        printf("1. Add Student\n");
        printf("2. Find Student and Generate Report\n");
        printf("3. Update Student Grades\n");
        printf("0. Exit\n");
        printf("Enter choice: ");
        scanf("%d", &choice);
        getchar();

        switch (choice) {
            case 1:
                input_student(&s);
                add_student(fp, &s);
                printf("Student added\n");
                break;

            case 2:
                printf("Enter Student ID to find: ");
                scanf("%d", &sid);
                getchar();
                if (find_student(fp, sid, &s) != -1) {
                    generate_report(&s);
                } else {
                    printf("Student not found\n");
                }
                break;

            case 3:
                printf("Enter Student ID to update grades: ");
                scanf("%d", &sid);
                getchar();
                update_student_grades(fp, sid);
                break;

            case 0:
                fclose(fp);
                exit(0);

            default:
                printf("Invalid choice\n");
        }
    }
    return 0;
}
