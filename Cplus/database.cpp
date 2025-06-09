#include <iostream>
#include "sqlite3.h"

int main() {
    sqlite3* db;
    char* errMsg = nullptr;
    int rc;

    
    rc = sqlite3_open("test.db", &db);
    if (rc) {
        std::cerr << "Can't open database: " << sqlite3_errmsg(db) << "\n";
        return rc;
    }
    std::cout << "Opened database successfully\n";

    
    const char* create_sql = "CREATE TABLE IF NOT EXISTS users (id INTEGER PRIMARY KEY, name TEXT);";
    rc = sqlite3_exec(db, create_sql, nullptr, nullptr, &errMsg);
    if (rc != SQLITE_OK) {
        std::cerr << "SQL error: " << errMsg << "\n";
        sqlite3_free(errMsg);
        sqlite3_close(db);
        return rc;
    }
    std::cout << "Table created successfully\n";

    
    const char* insert_sql = "INSERT INTO users (name) VALUES ('Alice');";
    rc = sqlite3_exec(db, insert_sql, nullptr, nullptr, &errMsg);
    if (rc != SQLITE_OK) {
        std::cerr << "Insert error: " << errMsg << "\n";
        sqlite3_free(errMsg);
        sqlite3_close(db);
        return rc;
    }
    std::cout << "Record inserted successfully\n";

    
    const char* select_sql = "SELECT id, name FROM users;";
    auto callback = [](void*, int argc, char** argv, char** colName) -> int {
        for (int i = 0; i < argc; ++i) {
            std::cout << colName[i] << ": " << (argv[i] ? argv[i] : "NULL") << " | ";
        }
        std::cout << "\n";
        return 0;
    };

    rc = sqlite3_exec(db, select_sql, callback, nullptr, &errMsg);
    if (rc != SQLITE_OK) {
        std::cerr << "Select error: " << errMsg << "\n";
        sqlite3_free(errMsg);
    }

    
    sqlite3_close(db);
    return 0;
}
