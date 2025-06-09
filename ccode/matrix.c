#include <stdio.h>
#include <stdlib.h>


int* allocate_matrix(int rows, int cols) {
    int *mat = (int *)calloc(rows * cols, sizeof(int));
    if (!mat) {
        fprintf(stderr, "Memory allocation failed\n");
        exit(EXIT_FAILURE);
    }
    return mat;
}

void print_matrix(int *mat, int rows, int cols) {
    for (int i = 0; i < rows; i++) {
        for (int j = 0; j < cols; j++) {
            printf("%5d ", mat[i * cols + j]);
        }
        printf("\n");
    }
}

void matrix_add(int *A, int *B, int *C, int rows, int cols) {
    for (int i = 0; i < rows * cols; i++) {
        C[i] = A[i] + B[i];
    }
}


void matrix_multiply(int *A, int *B, int *C, int rowsA, int colsA, int colsB) {
    for (int i = 0; i < rowsA; i++) {
        for (int j = 0; j < colsB; j++) {
            C[i * colsB + j] = 0;
            for (int k = 0; k < colsA; k++) {
                C[i * colsB + j] += A[i * colsA + k] * B[k * colsB + j];
            }
        }
    }
}


void matrix_transpose(int *A, int *B, int rows, int cols) {
    for (int i = 0; i < rows; i++)
        for (int j = 0; j < cols; j++)
            B[j * rows + i] = A[i * cols + j];
}

int main() {
    int rows = 3, cols = 3;


    int *A = allocate_matrix(rows, cols);
    int *B = allocate_matrix(rows, cols);
    int *C = allocate_matrix(rows, cols); 
    int *D = allocate_matrix(rows, cols);

    
    for (int i = 0; i < rows; i++)
        for (int j = 0; j < cols; j++) {
            A[i * cols + j] = i + j + 1;   
            B[i * cols + j] = (i == j) ? 1 : 0; 
        }

    printf("Matrix A:\n");
    print_matrix(A, rows, cols);

    printf("Matrix B (Identity):\n");
    print_matrix(B, rows, cols);

    
    matrix_add(A, B, C, rows, cols);
    printf("A + B = \n");
    print_matrix(C, rows, cols);

    
    matrix_multiply(A, B, D, rows, cols, cols);
    printf("A * B = \n");
    print_matrix(D, rows, cols);

    
    matrix_transpose(A, C, rows, cols);
    printf("Transpose of A:\n");
    print_matrix(C, cols, rows);

    //now cleanup
    free(A);
    free(B);
    free(C);
    free(D);

    return 0;
}
