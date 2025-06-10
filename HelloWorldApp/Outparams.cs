namespace CalculatorApplication {
   class NumberManipulator {
      public void getValue(out int x) {
         int temp = 5;
         x = temp; // Assigning a value inside the method
      }
       public void getValues(out int x, out int y) {
          Console.WriteLine("Enter the first value: ");
          x = Convert.ToInt32(Console.ReadLine());
          
          Console.WriteLine("Enter the second value: ");
          y = Convert.ToInt32(Console.ReadLine());
      }
      static void Mainout()
        {
            NumberManipulator n = new NumberManipulator();

            /* Local variable definition */
            int a = 100;

            Console.WriteLine("Before method call, value of a: {0}", a);

            /* Calling a function to get the value */
            n.getValue(out a);

            Console.WriteLine("After method call, value of a: {0}", a);
            Console.ReadLine();
        }
   }
}