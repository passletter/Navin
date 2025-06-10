using System;
class ContinueExample
{
    static void ForContiune()
    {
        for (int i = 1; i <= 10; i++)
        {
            // Skip even numbers
            if (i % 2 == 0)
            {
                // Jump to the next iteration
                continue;
            }
            Console.WriteLine("Odd number: " + i);
        }
        Console.WriteLine("Loop completed.");


    }
   static void DoWhileContinue() {
         /* local variable definition */
         int a = 10;
         
         /* do loop execution */
         do {
            if (a == 15) {
               /* skip the iteration */
               a = a + 1;
               continue;
            }
            Console.WriteLine("value of a: {0}", a);
            a++;
         } 
         while (a < 20);
         Console.ReadLine();
      }

}