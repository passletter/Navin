// account.h
#ifndef ACCOUNT_H
#define ACCOUNT_H

#include "db.h"

class Account {
public:
    Account(Database* db);

    bool createAccount(int userId);
    bool deposit(int accountId, double amount);
    bool withdraw(int accountId, double amount);
    bool getBalance(int accountId, double& balance);
    bool transfer(int fromAccountId, int toAccountId, double amount);

private:
    Database* db;
    bool recordTransaction(int accountId, const std::string& txnType, double amount, const std::string& remarks);
};

#endif
