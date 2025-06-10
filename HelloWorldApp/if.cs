using System;
namespace DecisionMaking {
   class ProgramIf {
        static void MainIf(string[] args)
        {

            int a = 10;


            if (a < 20)
            {

                Console.WriteLine("a is less than 20");
            }
            Console.WriteLine("value of a is : {0}", a);


            string[] arr = new string[] { "aman", "tutorialspoint", "India" };
            foreach (var item in arr)
            {

                if (item.Length >= 5)
                {
                    Console.WriteLine(item);
                }
            }

            int a = 100;


            if (a < 20)
            {

                Console.WriteLine("a is less than 20");
            }
            else
            {

                Console.WriteLine("a is not less than 20");
            }
            Console.WriteLine("value of a is : {0}", a);

            int a = 100;


            if (a == 10)
            {

                Console.WriteLine("Value of a is 10");
            }
            else if (a == 20)
            {

                Console.WriteLine("Value of a is 20");
            }
            else if (a == 30)
            {

                Console.WriteLine("Value of a is 30");
            }
            else
            {

                Console.WriteLine("None of the values is matching");
            }
            Console.WriteLine("Exact value of a is: {0}", a);

            //Nested if
            int a = 100;
            int b = 200;


            if (a == 100)
            {


                if (b == 200)
                {

                    Console.WriteLine("Value of a is 100 and b is 200");
                }
            }
            Console.WriteLine("Exact value of a is : {0}", a);
            Console.WriteLine("Exact value of b is : {0}", b);
         

         //////////Nested if-else
         int marks = 85;
      
      if (marks >= 90)
      {
         Console.WriteLine("Grade: A+");
      }
      else if (marks >= 80)
      {
         Console.WriteLine("Grade: A");
         
         if (marks >= 85)
         {
            Console.WriteLine("Excellent Performance!");
         }
         else
         {
            Console.WriteLine("Good Job!");
         }
      }
      else if (marks >= 70)
      {
         Console.WriteLine("Grade: B");
      }
      else if (marks >= 60)
      {
         Console.WriteLine("Grade: C");
      }
      else
      {
         Console.WriteLine("Grade: F - Needs Improvement");
      }
      }
   }
}