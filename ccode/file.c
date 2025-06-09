#include <stdio.h>

int copy_char_by_char(const char *src, const char *dest) {
    FILE *fsrc = fopen(src, "r");
    if (!fsrc) {
        perror("Open source");
        return -1;
    }

    FILE *fdest = fopen(dest, "w");
    if (!fdest) {
        perror("Open dest");
        fclose(fsrc);
        return -1;
    }

    int ch;
    while ((ch = fgetc(fsrc)) != EOF) {
        fputc(ch, fdest);
    }

    fclose(fsrc);
    fclose(fdest);
    return 0;
}

int main() {
    copy_char_by_char("input.txt", "output.txt");
    return 0;
}
