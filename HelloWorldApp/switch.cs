using System;
namespace DecisionMaking {
    class ProgramSwitch
    {
        static void SimpleSwitch(string[] args)
        {

            char grade = 'B';

            switch (grade)
            {
                case 'A':
                    Console.WriteLine("Excellent!");
                    break;
                case 'B':
                case 'C':
                    Console.WriteLine("Well done");
                    break;
                case 'D':
                    Console.WriteLine("You passed");
                    break;
                case 'F':
                    Console.WriteLine("Better try again");
                    break;
                default:
                    Console.WriteLine("Invalid grade");
                    break;
            }
            Console.WriteLine("Your grade is  {0}", grade);
            Console.ReadLine();
        }
        static void NestedSwitch()
        {
            int a = 100;
            int b = 200;

            switch (a)
            {
                case 100:
                    Console.WriteLine("This is part of outer switch ");

                    switch (b)
                    {
                        case 200:
                            Console.WriteLine("This is part of inner switch ");
                            break;
                    }
                    break;
            }
            Console.WriteLine("Exact value of a is : {0}", a);
            Console.WriteLine("Exact value of b is : {0}", b);
         

        
      string department = "IT";

 
      string role = "Manager";

      switch (department) {
      case "IT":
         switch (role) {
         case "Developer":
            Console.WriteLine("IT - Developer: Responsible for coding.");
            break;
         case "Tester":
            Console.WriteLine("IT - Tester: Ensures software quality.");
            break;
         case "Manager":
            Console.WriteLine("IT - Manager: Oversees IT projects.");
            break;
         default:
            Console.WriteLine("Invalid IT Role!");
            break;
         }
         break;

      case "HR":
         switch (role) {
         case "Recruiter":
            Console.WriteLine("HR - Recruiter: Manages hiring.");
            break;
         case "Trainer":
            Console.WriteLine("HR - Trainer: Conducts training sessions.");
            break;
         case "Coordinator":
            Console.WriteLine("HR - Coordinator: Handles HR operations.");
            break;
         default:
            Console.WriteLine("Invalid HR Role!");
            break;
         }
         break;

      case "Finance":
         switch (role) {
         case "Accountant":
            Console.WriteLine("Finance - Accountant: Manages financial records.");
            break;
         case "Auditor":
            Console.WriteLine("Finance - Auditor: Conducts financial audits.");
            break;
         case "Analyst":
            Console.WriteLine("Finance - Analyst: Analyzes financial data.");
            break;
         default:
            Console.WriteLine("Invalid Finance Role!");
            break;
         }
         break;

      default:
         Console.WriteLine("Invalid Department!");
         break;
      }
      }
   }
}