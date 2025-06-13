using System;

class ProgramExceptionHandler
{
    static void Main()
    {
        try
        {
            Console.WriteLine("Inside try block.");
            int result = 10 / 2; // Change to 0 to force exception
            Console.WriteLine("Result: " + result);
        }
        catch (DivideByZeroException ex)
        {
            Console.WriteLine("Exception caught: " + ex.Message);
        }
        finally
        {
            Console.WriteLine("Finally block executed.");
        }

        //Nested try-catch-finally block
        try
        {
            try
            {
                int x = 0;
                int result = 10 / x;
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine("Inner catch: " + ex.Message);
                throw; // Rethrow the same exception
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Outer catch: " + ex.Message);
        }

        //Multiple Catch blocks for a try block
        try
        {
            int[] numbers = { 1, 2, 3 };
            Console.WriteLine("Accessing element: " + numbers[5]);
        }
        catch (DivideByZeroException ex)
        {
            Console.WriteLine("DivideByZeroException caught: " + ex.Message);
        }
        catch (IndexOutOfRangeException ex)
        {
            Console.WriteLine("IndexOutOfRangeException caught: " + ex.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine("General Exception caught: " + ex.Message);
        }
        
         try
        {
            int x = 0; int result = 10 / x;
        }
        catch (Exception e)
        {
            Console.WriteLine("Exception caught in Main:");
            Console.WriteLine(e.Message);
        }
        
    }
}