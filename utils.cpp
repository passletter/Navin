// utils.cpp
#include "utils.h"

#include <sstream>
#include <iomanip>

std::string hashPassword(const std::string& password) {
   // unsigned char hash[SHA256_DIGEST_LENGTH];
   // SHA256((unsigned char*)password.c_str(), password.size(), hash);

    std::stringstream ss;
    // for(int i = 0; i < SHA256_DIGEST_LENGTH; ++i)
    //     ss << std::hex << std::setw(2) << std::setfill('0') << (int)hash[i];
    return ss.str();
}
