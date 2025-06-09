#include <stdio.h>
#include <stdlib.h>

int main() {
    FILE *fp = fopen("example.txt", "w");
    if (!fp) {
        perror("File open failed");
        return 1;
    }

   
    char buffer[1024];

   //we set the buffer type here
    if (setvbuf(fp, buffer, _IOFBF, sizeof(buffer)) != 0) {
        perror("Failed to set buffer");
        fclose(fp);
        return 1;
    }

   
    for (int i = 0; i < 5; i++) {
        fprintf(fp, "Line %d: This is an example of full buffering.\n", i+1);
    }

   
    fflush(fp);
    printf("Data flushed to disk.\n");

    fclose(fp);
    return 0;
}
