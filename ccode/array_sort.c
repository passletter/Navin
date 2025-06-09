#include <stdio.h>
#include <stdlib.h>
#include <time.h>

#define ARRAY_SIZE 15
#define NUM_ARRAYS 3


void print_array(int arr[], int n) {
    for (int i = 0; i < n; i++) {
        printf("%d ", arr[i]);
    }
    printf("\n");
}


void copy_array(int src[], int dest[], int n) {
    for (int i = 0; i < n; i++) dest[i] = src[i];
}


void merge(int arr[], int l, int m, int r) {
    int n1 = m - l + 1;
    int n2 = r - m;

    
    int *L = malloc(n1 * sizeof(int));
    int *R = malloc(n2 * sizeof(int));

    for (int i = 0; i < n1; i++) L[i] = arr[l + i];
    for (int j = 0; j < n2; j++) R[j] = arr[m + 1 + j];

    int i = 0, j = 0, k = l;

   
    while (i < n1 && j < n2) {
        if (L[i] <= R[j]) arr[k++] = L[i++];
        else arr[k++] = R[j++];
    }

    
    while (i < n1) arr[k++] = L[i++];
    while (j < n2) arr[k++] = R[j++];

    free(L);
    free(R);
}

void merge_sort(int arr[], int l, int r) {
    if (l < r) {
        int m = l + (r - l)/2;
        merge_sort(arr, l, m);
        merge_sort(arr, m+1, r);
        merge(arr, l, m, r);
    }
}


int partition(int arr[], int l, int r) {
    int pivot = arr[r];
    int i = l - 1; 

    for (int j = l; j <= r - 1; j++) {
        if (arr[j] <= pivot) {
            i++;
        
            int temp = arr[i];
             arr[i] = arr[j]; 
             arr[j] = temp;
        }
    }
    
    int temp = arr[i+1]; arr[i+1] = arr[r]; arr[r] = temp;
    return i+1;
}

void quick_sort(int arr[], int l, int r) {
    if (l < r) {
        int pi = partition(arr, l, r);
        quick_sort(arr, l, pi - 1);
        quick_sort(arr, pi + 1, r);
    }
}

void heapify(int arr[], int n, int i) {
    int largest = i; 
    int left = 2*i + 1;
    int right = 2*i + 2;

    if (left < n && arr[left] > arr[largest]) largest = left;
    if (right < n && arr[right] > arr[largest]) largest = right;

    if (largest != i) {
        int temp = arr[i]; arr[i] = arr[largest]; arr[largest] = temp;
        heapify(arr, n, largest);
    }
}

void heap_sort(int arr[], int n) {
    
    for (int i = n/2 -1; i >=0; i--) {
        heapify(arr, n, i);
    }
   
    for (int i = n-1; i > 0; i--) {
        
        int temp = arr[0]; 
        arr[0] = arr[i]; 
        arr[i] = temp;
        heapify(arr, i, 0);
    }
}



int main() {
    srand((unsigned int)time(NULL));

    
    int arrays[NUM_ARRAYS][ARRAY_SIZE];
    for (int i = 0; i < NUM_ARRAYS; i++) {
        for (int j = 0; j < ARRAY_SIZE; j++) {
            arrays[i][j] = rand() % 100;  
        }
    }

    
    int buffer[ARRAY_SIZE];

    for (int i = 0; i < NUM_ARRAYS; i++) {
        printf("Original array %d: ", i+1);
        print_array(arrays[i], ARRAY_SIZE);

        
        printf("NOW STARTING MERGET_SORT");
        copy_array(arrays[i], buffer, ARRAY_SIZE);
        merge_sort(buffer, 0, ARRAY_SIZE - 1);
        printf("After Merge Sort: ");
        print_array(buffer, ARRAY_SIZE);

        
        printf("NOW STARTING QUICK SORT");
        copy_array(arrays[i], buffer, ARRAY_SIZE);
        quick_sort(buffer, 0, ARRAY_SIZE - 1);
        printf("After Quick Sort: ");
        print_array(buffer, ARRAY_SIZE);

        
        printf("NOW STARTITNG HEAP SORT");
        copy_array(arrays[i], buffer, ARRAY_SIZE);
        heap_sort(buffer, ARRAY_SIZE);
        printf("After Heap Sort: ");
        print_array(buffer, ARRAY_SIZE);

        printf("\nFinished sorting!!\n");
    }

    return 0;
}
