#include <iostream>
#include <sqlite3.h>

int main() {
    sqlite3* db;
    char* errMsg = nullptr;
    int rc;

    rc = sqlite3_open("mydatabase.db", &db);
    if (rc != SQLITE_OK) {
        std::cerr << "Can't open database: " << sqlite3_errmsg(db) << std::endl;
        return rc;
    }

    const char* trigger_sql = 
        "CREATE TRIGGER update_order_items_order_id_after_update "
        "AFTER UPDATE OF id ON orders "
        "FOR EACH ROW "
        "BEGIN "
        "  UPDATE order_items SET order_id = NEW.id WHERE order_id = OLD.id; "
        "  INSERT INTO audit_log(event_type, table_name, record_id) "
        "  VALUES ('UPDATE', 'orders', NEW.id); "
        "END;";

    rc = sqlite3_exec(db, trigger_sql, nullptr, nullptr, &errMsg);
    if (rc != SQLITE_OK) {
        std::cerr << "SQL error creating trigger: " << errMsg << std::endl;
        sqlite3_free(errMsg);
        sqlite3_close(db);
        return rc;
    }

    std::cout << "Trigger created successfully." << std::endl;

    sqlite3_close(db);
    return 0;
}
