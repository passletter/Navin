#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <time.h>

#define MAX_USERS 1000
#define PIN_TRIES 3
#define ACC_FILE "accounts.dat"
#define LOG_FILE "transactions.log"

struct Account {
    int id;
    char name[50];
    char pin[5];
    double balance;
    int locked;
};

void log_transaction(const char *msg) {
    FILE *log = fopen(LOG_FILE, "a");
    time_t now = time(NULL);
    fprintf(log, "%s: %s\n", strtok(ctime(&now), "\n"), msg);
    fclose(log);
}

void create_account() {
    struct Account acc;
    FILE *fp = fopen(ACC_FILE, "ab");

    printf("Enter ID: "); 
    scanf("%d", &acc.id);
    printf("Enter name: "); 
    scanf("%s", acc.name);
    printf("Set 4-digit PIN: "); 
    scanf("%4s", acc.pin);
    acc.balance = 0.0;
    acc.locked = 0;

    fwrite(&acc, sizeof(struct Account), 1, fp);
    fclose(fp);
    log_transaction("New account created.");
}

int authenticate_user(struct Account *acc) {
    int attempts = 0;
    char entered_pin[5];

    while (attempts < PIN_TRIES) {
        printf("Enter PIN: ");
        scanf("%4s", entered_pin);
        if (strcmp(entered_pin, acc->pin) == 0)
            return 1;
        attempts++;
    }

    acc->locked = 1;
    log_transaction("Account locked due to incorrect PIN.");
    return 0;
}

int find_account(int id, struct Account *out) {
    FILE *fp = fopen(ACC_FILE, "rb");
    struct Account temp;
    while (fread(&temp, sizeof(temp), 1, fp)) {
        if (temp.id == id) {
            *out = temp;
            fclose(fp);
            return 1;
        }
    }
    fclose(fp);
    return 0;
}

void update_account(struct Account acc) {
    FILE *fp = fopen(ACC_FILE, "rb+");
    struct Account temp;
    while (fread(&temp, sizeof(temp), 1, fp)) {
        if (temp.id == acc.id) {
            fseek(fp, -sizeof(temp), SEEK_CUR);
            fwrite(&acc, sizeof(acc), 1, fp);
            break;
        }
    }
    fclose(fp);
}

void deposit(struct Account *acc) {
    double amount;
    printf("Enter amount to deposit: ");
    scanf("%lf", &amount);
    acc->balance += amount;
    update_account(*acc);
    log_transaction("Deposit successful.");
}

void withdraw(struct Account *acc) {
    double amount;
    printf("Enter amount to withdraw: ");
    scanf("%lf", &amount);
    if (acc->balance >= amount) {
        acc->balance -= amount;
        update_account(*acc);
        log_transaction("Withdrawal successful.");
    } else {
        printf("Insufficient balance.\n");
        log_transaction("Withdrawal failed: Insufficient balance.");
    }
}

void transfer() {
    int from_id, to_id;
    double amount;
    struct Account from_acc, to_acc;

    printf("Enter your ID: "); scanf("%d", &from_id);
    if (!find_account(from_id, &from_acc) || from_acc.locked) {
        printf("Account not found or locked.\n"); return;
    }
    if (!authenticate_user(&from_acc)) return;

    printf("Enter recipient ID: "); scanf("%d", &to_id);
    if (!find_account(to_id, &to_acc)) {
        printf("Recipient not found.\n"); return;
    }

    printf("Enter amount: "); scanf("%lf", &amount);
    if (from_acc.balance < amount) {
        printf("Insufficient funds.\n");
        return;
    }

    from_acc.balance -= amount;
    to_acc.balance += amount;
    update_account(from_acc);
    update_account(to_acc);
    log_transaction("Transfer successful.");
}

void display_menu() {
    printf("\n1. Create Account\n2. Deposit\n3. Withdraw\n4. Transfer\n5. Exit\n");
}

int main() {
    int choice, id;
    struct Account acc;

    while (1) {
        display_menu();
        printf("Choose: ");
        scanf("%d", &choice);

        switch (choice) {
            case 1:
                create_account(); break;
            case 2:
                printf("Enter your ID: ");
                scanf("%d", &id);
                if (!find_account(id, &acc) || acc.locked) {
                    printf("Account not found or locked.\n"); break;
                }
                if (authenticate_user(&acc)) deposit(&acc);
                break;
            case 3:
                printf("Enter your ID: ");
                scanf("%d", &id);
                if (!find_account(id, &acc) || acc.locked) {
                    printf("Account not found or locked.\n"); break;
                }
                if (authenticate_user(&acc)) withdraw(&acc);
                break;
            case 4:
                transfer(); 
                break;
            case 5:
                exit(0);
        }
    }
    return 0;
}
