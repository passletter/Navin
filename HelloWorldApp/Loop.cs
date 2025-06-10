using System;
namespace Loops {
    class LoopProgram
    {
        static void InfiniteLoop(string[] args)
        {
            for (; ; )
            {
                Console.WriteLine("Hey! I am trapped in never ending loop");
            }
        }
        static void EvenFinder()
        {
            for (int a = 10; a < 20; a = a + 1)
            {
                if (a % 2 == 0)
                    Console.WriteLine("Even Value: {0}", a);
            }

        }

        static void NestedFor()
        {
            for (int i = 1; i <= 5; i++)
            {
                for (int j = 1; j <= 5; j++)
                {
                    Console.Write(i * j + "\t");
                }
                Console.WriteLine();
            }
        }

        static void SearchInsideArray()
        {
        int[] arr = { 10, 20, 30, 40, 50 };
int target = 30;
bool found = false;

for (int i = 0; i < arr.Length; i++)
{
    if (arr[i] == target)
    {
        found = true;
        Console.WriteLine($"Element {target} found at index {i}");
        break;
    }
}

if (!found)
    Console.WriteLine("Element not found.");
       }
   }
} 