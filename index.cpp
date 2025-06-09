#include <iostream>
#include "db.h"
#include "user.h"
#include "account.h"

void showMenu() {
    std::cout << "1. Create User\n";
    std::cout << "2. Login\n";
    std::cout << "3. Exit\n";
    std::cout << "Choose: ";
}

void userMenu(int userId, Database* db) {
    Account account(db);
    int accountId = -1;

    // For simplicity, assume one account per user, or pick first:
    //You can add a query to fetch accountId for userId

    std::cout << "Logged in User ID: " << userId << "\n";
    // TODO: fetch accountId from DB for this user

    while(true) {
        std::cout << "\nBank Menu:\n";
        std::cout << "1. Create Account\n";
        std::cout << "2. Deposit\n";
        std::cout << "3. Withdraw\n";
        std::cout << "4. Check Balance\n";
        std::cout << "5. Transfer\n";
        std::cout << "6. Logout\n";
        std::cout << "Choose: ";

        int choice;
        std::cin >> choice;

        if(choice == 6) break;

        switch(choice) {
            case 1:
                if(account.createAccount(userId))
                    std::cout << "Account created successfully.\n";
                else
                    std::cout << "Failed to create account.\n";
                break;
            case 2: {
                if(accountId == -1) { std::cout << "No account found.\n"; break; }
                double amt; std::cout << "Deposit amount: "; std::cin >> amt;
                if(account.deposit(accountId, amt))
                    std::cout << "Deposit successful.\n";
                else
                    std::cout << "Deposit failed.\n";
                break;
            }
            case 3: {
                if(accountId == -1) { std::cout << "No account found.\n"; break; }
                double amt; std::cout << "Withdraw amount: "; std::cin >> amt;
                if(account.withdraw(accountId, amt))
                    std::cout << "Withdrawal successful.\n";
                else
                    std::cout << "Withdrawal failed.\n";
                break;
            }
            case 4: {
                if(accountId == -1) { std::cout << "No account found.\n"; break; }
                double bal; 
                if(account.getBalance(accountId, bal))
                    std::cout << "Balance: " << bal << "\n";
                else
                    std::cout << "Failed to get balance.\n";
                break;
            }
            case 5: {
                if(accountId == -1) { std::cout << "No account found.\n"; break; }
                int toAcc; double amt;
                std::cout << "Transfer to Account ID: "; std::cin >> toAcc;
                std::cout << "Amount: "; std::cin >> amt;
                if(account.transfer(accountId, toAcc, amt))
                    std::cout << "Transfer successful.\n";
                else
                    std::cout << "Transfer failed.\n";
                break;
            }
            default:
                std::cout << "Invalid option.\n";
        }
    }
}

int main() {
    Database db("bank.db");
    db.execute("CREATE TABLE IF NOT EXISTS users (id INTEGER PRIMARY KEY AUTOINCREMENT, username TEXT UNIQUE NOT NULL, password_hash TEXT NOT NULL, full_name TEXT NOT NULL, created_at TEXT DEFAULT CURRENT_TIMESTAMP);");
    db.execute("CREATE TABLE IF NOT EXISTS accounts (account_id INTEGER PRIMARY KEY AUTOINCREMENT, user_id INTEGER NOT NULL, balance REAL NOT NULL DEFAULT 0, created_at TEXT DEFAULT CURRENT_TIMESTAMP, FOREIGN KEY(user_id) REFERENCES users(id));");
    db.execute("CREATE TABLE IF NOT EXISTS transactions (txn_id INTEGER PRIMARY KEY AUTOINCREMENT, account_id INTEGER NOT NULL, txn_type TEXT NOT NULL, amount REAL NOT NULL, txn_date TEXT DEFAULT CURRENT_TIMESTAMP, remarks TEXT, FOREIGN KEY(account_id) REFERENCES accounts(account_id));");

    User user(&db);
    while(true) {
        showMenu();
        int choice; std::cin >> choice;

        if(choice == 3) break;

        if(choice == 1) {
            std::string username, password, fullName;
            std::cout << "Username: "; std::cin >> username;
            std::cout << "Password: "; std::cin >> password;
            std::cout << "Full Name: "; std::cin.ignore(); std::getline(std::cin, fullName);

            if(user.createUser(username, password, fullName))
                std::cout << "User created successfully.\n";
            else
                std::cout << "User creation failed.\n";
        }
        else if(choice == 2) {
            std::string username, password;
            std::cout << "Username: "; std::cin >> username;
            std::cout << "Password: "; std::cin >> password;

            int userId;
            if(user.loginUser(username, password, userId)) {
                userMenu(userId, &db);
            }
        }
        else {
            std::cout << "Invalid choice.\n";
        }
    }

    return 0;
}
