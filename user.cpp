// user.cpp
#include "user.h"
#include "utils.h"
#include <iostream>

User::User(Database* db) : db(db) {}

bool User::createUser(const std::string& username, const std::string& password, const std::string& fullName) {
    std::string hashedPass = hashPassword(password);
    std::string sql = "INSERT INTO users (username, password_hash, full_name) VALUES ('" + 
                      username + "', '" + hashedPass + "', '" + fullName + "');";

    if(!db->execute(sql)) {
        std::cerr << "Failed to create user. Username might be taken.\n";
        return false;
    }
    return true;
}

static int callbackGetUserId(void* data, int argc, char** argv, char** colName) {
    if (argc > 0 && argv[0]) {
        int* userIdPtr = static_cast<int*>(data);
        *userIdPtr = std::stoi(argv[0]);
    }
    return 0;
}

bool User::loginUser(const std::string& username, const std::string& password, int& userId) {
    std::string hashedPass = hashPassword(password);
    std::string sql = "SELECT id FROM users WHERE username = '" + username + 
                      "' AND password_hash = '" + hashedPass + "';";
    userId = -1;
    bool ok = db->executeWithCallback(sql, callbackGetUserId, &userId);
    if (!ok || userId == -1) {
        std::cerr << "Invalid username or password.\n";
        return false;
    }
    return true;
}
