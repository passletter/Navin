#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <time.h>

typedef struct {
    int book_id;
    char title[100];
    char author[50];
    int available;
} Book;

typedef struct {
    int member_id;
    char name[50];
    char email[100];
    int borrowed_book_id;
    time_t borrow_time;
} Member;


void add_book() {
    FILE *fp = fopen("books.dat", "ab");
    Book b;
    printf("Enter Book ID, Title, Author: ");
    scanf("%d", &b.book_id);
    getchar();
    fgets(b.title, sizeof(b.title), stdin);
    fgets(b.author, sizeof(b.author), stdin);
    b.title[strcspn(b.title, "\n")] = '\0';
    b.author[strcspn(b.author, "\n")] = '\0';
    b.available = 1;
    fwrite(&b, sizeof(Book), 1, fp);
    fclose(fp);
}

void add_member() {
    FILE *fp = fopen("members.dat", "ab");
    Member m = {.borrowed_book_id = -1};
    printf("Enter Member ID, Name, Email: ");
    scanf("%d", &m.member_id);
    getchar();
    fgets(m.name, sizeof(m.name), stdin);
    fgets(m.email, sizeof(m.email), stdin);
    m.name[strcspn(m.name, "\n")] = '\0';
    m.email[strcspn(m.email, "\n")] = '\0';
    fwrite(&m, sizeof(Member), 1, fp);
    fclose(fp);
}


void borrow_book(int member_id, int book_id) {
    FILE *bfp = fopen("books.dat", "rb+");
    FILE *mfp = fopen("members.dat", "rb+");
    Book b;
    Member m;
    int book_found = 0, member_found = 0;

    while (fread(&b, sizeof(Book), 1, bfp)) {
        if (b.book_id == book_id && b.available) {
            book_found = 1;
            b.available = 0;
            fseek(bfp, -sizeof(Book), SEEK_CUR);
            fwrite(&b, sizeof(Book), 1, bfp);
            break;
        }
    }

    while (fread(&m, sizeof(Member), 1, mfp)) {
        if (m.member_id == member_id && m.borrowed_book_id == -1) {
            member_found = 1;
            m.borrowed_book_id = book_id;
            m.borrow_time = time(NULL);
            fseek(mfp, -sizeof(Member), SEEK_CUR);
            fwrite(&m, sizeof(Member), 1, mfp);
            break;
        }
    }

    fclose(bfp);
    fclose(mfp);
    if (book_found && member_found)
        printf("Book borrowed successfully.\n");
    else
        printf("Borrowing failed.\n");
}


void return_book(int member_id) {
    FILE *mfp = fopen("members.dat", "rb+");
    FILE *bfp = fopen("books.dat", "rb+");
    FILE *log = fopen("transactions.log", "a");
    Member m;
    Book b;
    time_t now = time(NULL);
    int days_late = 0, fine_per_day = 5;

    while (fread(&m, sizeof(Member), 1, mfp)) {
        if (m.member_id == member_id && m.borrowed_book_id != -1) {
            int book_id = m.borrowed_book_id;

            rewind(bfp);
            while (fread(&b, sizeof(Book), 1, bfp)) {
                if (b.book_id == book_id) {
                    b.available = 1;
                    fseek(bfp, -sizeof(Book), SEEK_CUR);
                    fwrite(&b, sizeof(Book), 1, bfp);
                    break;
                }
            }

            double seconds = difftime(now, m.borrow_time);
            days_late = (int)(seconds / (60 * 60 * 24)) - 7;
            if (days_late < 0) days_late = 0;

            char *timestamp = strtok(ctime(&now), "\n");
            fprintf(log, "Return: Member %d returned Book %d on %s. Fine: Rs.%d\n",
                    member_id, book_id, timestamp, days_late * fine_per_day);

            m.borrowed_book_id = -1;
            m.borrow_time = 0;
            fseek(mfp, -sizeof(Member), SEEK_CUR);
            fwrite(&m, sizeof(Member), 1, mfp);
            break;
        }
    }

    fclose(mfp);
    fclose(bfp);
    fclose(log);
}


void search_book_by_title(const char *title) {
    FILE *fp = fopen("books.dat", "rb");
    Book b;
    while (fread(&b, sizeof(Book), 1, fp)) {
        if (strstr(b.title, title)) {
            printf("Book ID: %d, Title: %s, Author: %s, %s\n",
                   b.book_id, b.title, b.author,
                   b.available ? "Available" : "Not Available");
        }
    }
    fclose(fp);
}

int main() {
    int choice, mid, bid;
    char keyword[100];

    while (1) {
        printf("\n Welcome to the Library Menu\n");
        printf("1. Add Book\n2. Add Member\n3. Borrow Book\n4. Return Book\n5. Search Book by Title\n0. Exit\n");
        printf("Enter your choice: ");
        scanf("%d", &choice);
        getchar();

        switch (choice) {
            case 1:
                add_book();
                break;
            case 2:
                add_member();
                break;
            case 3:
                printf("Enter Member ID and Book ID: ");
                scanf("%d %d", &mid, &bid);
                borrow_book(mid, bid);
                break;
            case 4:
                printf("Enter Member ID: ");
                scanf("%d", &mid);
                return_book(mid);
                break;
            case 5:
                printf("Enter keyword to search in title: ");
                fgets(keyword, sizeof(keyword), stdin);
                keyword[strcspn(keyword, "\n")] = '\0';
                search_book_by_title(keyword);
                break;
            case 0:
                exit(0);
            default:
                printf("Invalid choice.\n");
        }
    }

    return 0;
}
