// user.h
#ifndef USER_H
#define USER_H

#include <string>
#include "db.h"

class User {
public:
    User(Database* db);
    bool createUser(const std::string& username, const std::string& password, const std::string& fullName);
    bool loginUser(const std::string& username, const std::string& password, int& userId);

private:
    Database* db;
};

#endif
