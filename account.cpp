// account.cpp
#include "account.h"
#include <iostream>
#include <sstream>

Account::Account(Database* db) : db(db) {}

bool Account::createAccount(int userId) {
    std::string sql = "INSERT INTO accounts (user_id, balance) VALUES (" + std::to_string(userId) + ", 0);";
    return db->execute(sql);
}

bool Account::deposit(int accountId, double amount) {
    if(amount <= 0) return false;

    std::string sql = "UPDATE accounts SET balance = balance + " + std::to_string(amount) + 
                      " WHERE account_id = " + std::to_string(accountId) + ";";
    if(!db->execute(sql)) return false;

    return recordTransaction(accountId, "deposit", amount, "Deposit");
}

bool Account::withdraw(int accountId, double amount) {
    if(amount <= 0) return false;

    double balance = 0;
    if(!getBalance(accountId, balance)) return false;
    if(balance < amount) {
        std::cerr << "Insufficient funds\n";
        return false;
    }

    std::string sql = "UPDATE accounts SET balance = balance - " + std::to_string(amount) +
                      " WHERE account_id = " + std::to_string(accountId) + ";";
    if(!db->execute(sql)) return false;

    return recordTransaction(accountId, "withdrawal", amount, "Withdrawal");
}

bool Account::getBalance(int accountId, double& balance) {
    std::string sql = "SELECT balance FROM accounts WHERE account_id = " + std::to_string(accountId) + ";";

    struct BalanceData {
        double val = 0;
    } data;

    auto callback = [](void* ptr, int argc, char** argv, char**) -> int {
        if(argc > 0 && argv[0]) {
            BalanceData* d = static_cast<BalanceData*>(ptr);
            d->val = std::stod(argv[0]);
        }
        return 0;
    };

    if(!db->executeWithCallback(sql, callback, &data)) return false;

    balance = data.val;
    return true;
}

bool Account::transfer(int fromAccountId, int toAccountId, double amount) {
    if(amount <= 0) return false;

    double fromBalance = 0;
    if(!getBalance(fromAccountId, fromBalance)) return false;
    if(fromBalance < amount) {
        std::cerr << "Insufficient funds for transfer\n";
        return false;
    }

    std::string withdrawSql = "UPDATE accounts SET balance = balance - " + std::to_string(amount) +
                             " WHERE account_id = " + std::to_string(fromAccountId) + ";";
    std::string depositSql = "UPDATE accounts SET balance = balance + " + std::to_string(amount) +
                             " WHERE account_id = " + std::to_string(toAccountId) + ";";

    //now are using transaction
    if(!db->execute("BEGIN TRANSACTION;")) return false;
    if(!db->execute(withdrawSql)) { db->execute("ROLLBACK;"); return false; }
    if(!db->execute(depositSql)) { db->execute("ROLLBACK;"); return false; }

    if(!recordTransaction(fromAccountId, "transfer", amount, "Transfer to account " + std::to_string(toAccountId))) {
        db->execute("ROLLBACK;");
        return false;
    }
    if(!recordTransaction(toAccountId, "transfer", amount, "Transfer from account " + std::to_string(fromAccountId))) {
        db->execute("ROLLBACK;");
        return false;
    }

    if(!db->execute("COMMIT;")) {
        db->execute("ROLLBACK;");
        return false;
    }
    return true;
}

bool Account::recordTransaction(int accountId, const std::string& txnType, double amount, const std::string& remarks) {
    std::string sql = "INSERT INTO transactions (account_id, txn_type, amount, remarks) VALUES (" +
                      std::to_string(accountId) + ", '" + txnType + "', " + std::to_string(amount) + ", '" + remarks + "');";
    return db->execute(sql);
}
