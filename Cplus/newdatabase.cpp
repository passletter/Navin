#include <iostream>
#include <sqlite3.h>


int callback(void* data, int argc, char** argv, char** colNames) {
    std::cout << (const char*)data << std::endl;

    

    for (int i = 0; i < argc; i++) {
        std::cout << colNames[i] << ": " << (argv[i] ? argv[i] : "NULL") << " | ";
    }
    std::cout << std::endl << "------------------------" << std::endl;

    return 0;
}

int main() {
    sqlite3* db;
    char* errMsg = nullptr;
    int rc;

    
    rc = sqlite3_open("projects.db", &db);
    if (rc) {
        std::cerr << "Can't open database: " << sqlite3_errmsg(db) << std::endl;
        return rc;
    } else {
        std::cout << "Opened database successfully" << std::endl;
    }

    
    const char* create_sql = 
        "CREATE TABLE IF NOT EXISTS Projects ("
        "ID INTEGER PRIMARY KEY AUTOINCREMENT,"
        "Name TEXT NOT NULL,"
        "Status TEXT NOT NULL);";

    rc = sqlite3_exec(db, create_sql, nullptr, nullptr, &errMsg);
    if (rc != SQLITE_OK) {
        std::cerr << "SQL error on CREATE TABLE: " << errMsg << std::endl;
        sqlite3_free(errMsg);
        sqlite3_close(db);
        return rc;
    }


    const char* insert_sql = 
        "INSERT INTO Projects (Name, Status) VALUES "
        "('Project Alpha', 'Active'),"
        "('Project Beta', 'Completed'),"
        "('Project Gamma', 'Pending');";

    rc = sqlite3_exec(db, insert_sql, nullptr, nullptr, &errMsg);
    if (rc != SQLITE_OK) {
        std::cerr << "SQL error on INSERT: " << errMsg << std::endl;
        sqlite3_free(errMsg);
        
    }


    const char* select_sql = "SELECT * FROM Projects;";
    const char* userMessage = "Project Records:";

    rc = sqlite3_exec(db, select_sql, callback, (void*)userMessage, &errMsg);
    if (rc != SQLITE_OK) {
        std::cerr << "SQL error on SELECT: " << errMsg << std::endl;
        sqlite3_free(errMsg);
    }


    sqlite3_close(db);
    return 0;
}
