// db.h
#ifndef DB_H
#define DB_H

#include "sqlite3.h"
#include <string>

class Database {
public:
    Database(const std::string& dbFile);
    ~Database();

    bool execute(const std::string& sql);
    bool executeWithCallback(const std::string& sql, int (*callback)(void*,int,char**,char**), void* data);

    sqlite3* getDB() { return db; }

private:
    sqlite3* db = nullptr;
};

#endif
