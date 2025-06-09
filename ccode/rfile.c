#include <stdio.h>
#include <stdlib.h>

#define BUFFER_SIZE 4096

// Simple XOR encryption/decryption with a key byte
void xor_encrypt_decrypt(unsigned char *data, size_t len, unsigned char key) {
    for (size_t i = 0; i < len; i++) {
        data[i] ^= key;
    }
}

// Encrypt file
int encrypt_file(const char *input_path, const char *output_path, unsigned char key) {
    FILE *fin = fopen(input_path, "rb");
    if (!fin) {
        perror("Failed to open input file");
        return -1;
    }

    FILE *fout = fopen(output_path, "wb");
    if (!fout) {
        perror("Failed to open output file");
        fclose(fin);
        return -1;
    }

    unsigned char buffer[BUFFER_SIZE];
    size_t bytes_read;

    while ((bytes_read = fread(buffer, 1, BUFFER_SIZE, fin)) > 0) {
        xor_encrypt_decrypt(buffer, bytes_read, key);
        fwrite(buffer, 1, bytes_read, fout);
    }

    fclose(fin);
    fclose(fout);
    return 0;
}

// Decrypt file (same operation as encrypt)
int decrypt_file(const char *input_path, const char *output_path, unsigned char key) {
    return encrypt_file(input_path, output_path, key); // XOR is symmetric
}

int main(int argc, char *argv[]) {
    if (argc != 5) {
        printf("Usage: %s <encrypt|decrypt> <inputfile> <outputfile> <key>\n", argv[0]);
        return 1;
    }

    const char *mode = argv[1];
    const char *input = argv[2];
    const char *output = argv[3];
    unsigned char key = (unsigned char)atoi(argv[4]);

    if (strcmp(mode, "encrypt") == 0) {
        if (encrypt_file(input, output, key) == 0)
            printf("File encrypted successfully.\n");
        else
            printf("Encryption failed.\n");
    } else if (strcmp(mode, "decrypt") == 0) {
        if (decrypt_file(input, output, key) == 0)
            printf("File decrypted successfully.\n");
        else
            printf("Decryption failed.\n");
    } else {
        printf("Unknown mode: %s\n", mode);
        return 1;
    }

    return 0;
}
