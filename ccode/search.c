#include <stdio.h>
#include <string.h>
#include <time.h>
#include <stdlib.h>

#define MAX_LINE 1024
#define MAX_USERNAME 50
#define MAX_FILENAME 100

void write_entry(const char *username);
void search_keyword(const char *username);

int main() {
    char username[MAX_USERNAME];

    printf("Enter your username: ");
    scanf("%s", username);
    getchar();

    int choice;
    while (1) {
        printf("\n--- Journal Menu ---\n");
        printf("1. Write new entry\n");
        printf("2. Search in journal\n");
        printf("3. Exit\n");
        printf("Enter choice: ");
        scanf("%d", &choice);
        getchar();

        if (choice == 1) {
            write_entry(username);
        } else if (choice == 2) {
            search_keyword(username);
        } else {
            break;
        }
    }

    return 0;
}

void write_entry(const char *username) {
    char filename[MAX_FILENAME];
    snprintf(filename, sizeof(filename), "%s.txt", username);
    FILE *fp = fopen(filename, "a");
    if (!fp) {
        perror("Failed to open file");
        return;
    }

    char line[MAX_LINE];
    time_t now = time(NULL);
    fprintf(fp, "\n--- Entry on %s", ctime(&now)); 

    printf("Write your diary entry. Type 'END' alone on a line to finish:\n");

    while (1) {
        fgets(line, MAX_LINE, stdin);
        if (strncmp(line, "END", 3) == 0 && (line[3] == '\n' || line[3] == '\0')) {
            break;
        }
        fputs(line, fp);
    }

    fclose(fp);
    printf("Entry saved to %s\n", filename);
}

void search_keyword(const char *username) {
    char keyword[MAX_LINE];
    char filename[MAX_FILENAME];
    snprintf(filename, sizeof(filename), "%s.txt", username);

    FILE *fp = fopen(filename, "r");
    if (!fp) {
        perror("Could not open file");
        return;
    }

    printf("Enter keyword to search: ");
    fgets(keyword, MAX_LINE, stdin);
    keyword[strcspn(keyword, "\n")] = '\0';

    char line[MAX_LINE];
    int found = 0;
    printf("\n--- Search Results ---\n");
    while (fgets(line, MAX_LINE, fp)) {
        if (strstr(line, keyword)) {
            printf("%s", line);
            found = 1;
        }
    }

    if (!found) {
        printf("No matches found.\n");
    }

    fclose(fp);
}
