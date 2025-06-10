using System;
namespace Loops {
   class NestedLoops
   {
      static void NestedDoWhile()
      {
         int i = 2, j;

         // Outer loop
         do
         {
            j = 2;

            // Inner loop
            do
            {
               if ((i % j) == 0)
                  break; // If factor found, not prime
               j++;
            } while (j <= (i / j));

            if (j > (i / j))
               Console.WriteLine("{0} is prime", i);

            i++;
         } while (i < 100);

         Console.ReadLine();
      }
      static void NestedWhile() {
         int i = 2, j;
         
         // Outer loop
         while (i < 100) {
            j = 2;
            // Inner loop
            while (j <= (i / j)) {
               if ((i % j) == 0)
                  // If factor found, not prime
                  break;
               j++;
            }
            if (j > (i / j)) 
               Console.WriteLine("{0} is prime", i);
            i++;
         }
         Console.ReadLine();
      }
      static void NestedFor() {
      
         int i, j;
         
         for (i = 2; i < 100; i++) {
            for (j = 2; j <= (i / j); j++)
            if ((i % j) == 0) break; // if factor found, not prime
            if (j > (i / j)) Console.WriteLine("{0} is prime", i);
         }
         Console.ReadLine();
      }
   }
}