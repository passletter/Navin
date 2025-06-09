#include <stdio.h>
#include <stdlib.h>  
#include <time.h>   

int main() {
    srand(time(NULL)); 

    int random_number = rand(); 

    
    int min = 1, max = 100;
    int ranged = rand() % (max - min + 1) + min;
    printf("Random number between %d and %d: %d\n", min, max, ranged);

    return 0;
}
