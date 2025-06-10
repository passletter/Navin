namespace CalculatorApplication {
   class NumberManipulator {
      public int factorial(int num) {
         /* local variable declaration */
         int result;
         if (num == 1) {
            return 1;
         } else {
            result = factorial(num - 1) * num;
            return result;
         }
      }

        //Method with value parameters
      public void ModifyValues(int x, int y) {
         x *= 2;
         y *= 2;
         Console.WriteLine("Inside ModifyValues method, x: {0}, y: {1}", x, y);
      }

        //Method with ref params
       public void swap(ref int x, ref int y) {
         int temp;
   
         temp = x; /* save the value of x */
         x = y;    /* put y into x */
         y = temp; /* put temp into y */
      }

        public void Deposit(ref double balance, double amount) {
         balance += amount; // Modifies the original balance
         Console.WriteLine("Balance after deposit: $" + balance);
      }

      static void MainMethod(string[] args)
        {
            NumberManipulator n = new NumberManipulator();
            //calling the factorial method {0}", n.factorial(6));
            Console.WriteLine("Factorial of 7 is : {0}", n.factorial(7));
            Console.WriteLine("Factorial of 8 is : {0}", n.factorial(8));
            Console.ReadLine();
        }
   }
}