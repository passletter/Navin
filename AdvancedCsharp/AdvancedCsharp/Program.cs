using System;

class MyCode
{
    private int code;

    public MyCode(int code)
    {
        this.code = code;
    }

    
    public static implicit operator int(MyCode mc) => mc.code;
}

class NullablesAtShow {
      static void Main(string[] args) {
         int? num1 = null;
         int? num2 = 45;
         
         double? num3 = new double?();
         double? num4 = 3.14157;
         
         bool? boolval = new bool?();

         // display the values
         Console.WriteLine("Nullables at Show: {0}, {1}, {2}, {3}", num1, num2, num3, num4);
         Console.WriteLine("A Nullable boolean value: {0}", boolval);
         Console.ReadLine();
      }
   }
class ProjectArray
{
    static void ArrayHandle(int[] numbers)
    {


        // Sorting the array in descending order
        Array.Sort(numbers);
        Array.Reverse(numbers);

        Console.WriteLine("Sorted Array in Descending Order:");
        foreach (int num in numbers)
        {
            Console.Write(num + " ");
        }



        Console.ReadKey();
    }

    static void CopyAndCloneArray(int[] sourceArray)
    {

        int[] destinationArray = new int[sourceArray.Length];

        // Copying array using Array.Copy()
        Array.Copy(sourceArray, destinationArray, sourceArray.Length);

        Console.WriteLine("Copied Array:");
        foreach (int num in destinationArray)
        {
            Console.Write(num + " ");
        }

        int[] clonedArray = (int[])sourceArray.Clone();

        Console.WriteLine("Cloned Array:");
        foreach (int num in clonedArray)
        {
            Console.Write(num + " ");
        }

        Console.ReadKey();
    }
    static void TwoDArray(int[,] array)
    {
        // Declare and initialize a 3x4 matrix
        int[,] matrix = {
            {1, 2, 3, 4},
            {5, 6, 7, 8},
            {9, 10, 11, 12}
         };

        // Get dimensions
        int rows = matrix.GetLength(0);
        int cols = matrix.GetLength(1);

        // Display the dimensions
        Console.WriteLine("Number of Rows: " + rows);
        Console.WriteLine("Number of Columns: " + cols);

        // Sorting each row
        for (int i = 0; i < array.GetLength(0); i++)
        {
            int[] row = new int[array.GetLength(1)];

            // Copy row to 1D array
            for (int j = 0; j < array.GetLength(1); j++)
            {
                row[j] = array[i, j];
            }

            // Sort the row
            Array.Sort(row);

            // Copy back sorted row to 2D array
            for (int j = 0; j < array.GetLength(1); j++)
            {
                array[i, j] = row[j];
            }
        }

        // Display sorted array
        for (int i = 0; i < array.GetLength(0); i++)
        {
            for (int j = 0; j < array.GetLength(1); j++)
            {
                Console.Write(array[i, j] + " ");
            }
            Console.WriteLine();
        }



        Console.ReadKey();
    }


    static void ModifyArray(ref int[] arr)

    {
        //before manipulation
        foreach (int a in arr)
        {
            Console.WriteLine(a);
        }
        for (int i = 0; i < arr.Length; i++)
        {
            arr[i] *= 2;
        }
        //After manipulation
        foreach (int a in arr)
        {
            Console.WriteLine(a);
        }
   }
    static void PrintNumbers(params int[] numbers)
    {
        foreach (int num in numbers)
        {
            Console.WriteLine(num);
        }
    }
    //You can also use params keyword with different types of values such as strings, objects, or custom types.
    static void PrintCities(params string[] cities)
    {
        foreach (string city in cities)
        {
            Console.WriteLine(city);
        }
    }


}

class MyArray
{
    double getAverage(int[] arr, int size)
    {
        int i;
        double avg;
        int sum = 0;

        for (i = 0; i < size; ++i)
        {
            sum += arr[i];
        }
        avg = (double)sum / size;
        return avg;
    }
    static void MainArray(string[] args)
    {
        MyArray app = new MyArray();

        /* an int array with 5 elements */
        int[] balance = new int[] { 1000, 2, 3, 17, 50 };
        double avg;

        /* pass pointer to the array as an argument */
        avg = app.getAverage(balance, 5);

        /* output the returned value */
        Console.WriteLine("Average value is: {0} ", avg);
        Console.ReadKey();
    }
    static void JaggedArray()
    {
        int[][] jaggedArray = new int[][] //flexible length but non-contiguously stored
           {
            new int[] {1, 2, 3},
            new int[] {4, 5},
            new int[] {6, 7, 8, 9}
           };

        for (int i = 0; i < jaggedArray.Length; i++)
        {
            for (int j = 0; j < jaggedArray[i].Length; j++)
            {
                Console.Write(jaggedArray[i][j] + " ");
            }
            Console.WriteLine();
        }
    }
}
class Program
    {
        static void Main()
        {
            MyCode status = new MyCode(2);

            switch (status)
            {
                case 1:
                    Console.WriteLine("One");
                    break;
                case 2:
                    Console.WriteLine("Two");
                    break;
                default:
                    Console.WriteLine("Other");
                    break;
            }
        }
    }

