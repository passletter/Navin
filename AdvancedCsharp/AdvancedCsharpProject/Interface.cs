using System.Collections.Generic;
using System.Linq;
using System.Collections;
using System.Text;
using System;
namespace InterfaceApplication {  
   public interface ITransactions {
      // interface members
      void showTransaction();
      double getAmount();
   }
   public class Transaction : ITransactions {
      private string tCode;
      private string date;
      private double amount;
      
      public Transaction() {
         tCode = " ";
         date = " ";
         amount = 0.0;
      }
      public Transaction(string c, string d, double a) {
         tCode = c;
         date = d;
         amount = a;
      }
      public double getAmount() {
         return amount;
      }
      public void showTransaction() {
         Console.WriteLine("Transaction: {0}", tCode);
         Console.WriteLine("Date: {0}", date);
         Console.WriteLine("Amount: {0}", getAmount());
      }
   }
   class Tester {
     
      static void Main(string[] args) {
         Transaction t1 = new Transaction("001", "8/10/2012", 78900.00);
         Transaction t2 = new Transaction("002", "9/10/2012", 451900.00);
         
         t1.showTransaction();
         t2.showTransaction();
         Console.ReadKey();
      }
   }
}

namespace IteratorName
{
    class Demo : IEnumerable, IEnumerator
{
    private int[] numbers = { 1, 2, 3, 4, 5 };
    private int currentIndex = -1;

    // IEnumerable method GetEnumerator()
    public IEnumerator GetEnumerator()
    {
        return this; // Returns the current instance for iteration
    }

    // IEnumerator method - Current property
    public object Current
    {
        get
        {
            if (currentIndex == -1 || currentIndex >= numbers.Length)
                throw new InvalidOperationException();
            return numbers[currentIndex];
        }
    }

    // IEnumerator method - MoveNext
    public bool MoveNext()
    {
        if (currentIndex < numbers.Length - 1)
        {
            currentIndex++;
            return true;
        }
        return false;
    }

    // IEnumerator method - Reset
    public void Reset()
    {
        // Reset index to start iteration 
		// from the beginning
		currentIndex = -1; 
    }
}

class Program
{
        static void Main(string[] args)
        {
            Demo demo = new Demo();

            foreach (var number in demo)
            {
                Console.WriteLine(number);
            }
            IDictionary<string, int> ages = new Dictionary<string, int>();

            // Adding key-value pairs to the dictionary
            ages.Add("Sudhir Shamra", 27);
            ages.Add("Prakash", 26);
            ages.Add("Yash", 22);

            // Accessing values using keys
            Console.WriteLine("Yash's age: " + ages["Yash"]); // Output: 30

            // Checking if a key exists
            if (ages.ContainsKey("Prakash"))
            {
                Console.WriteLine("Prakash's age is in the dictionary.");
            }

            // Iterating over the dictionary
            Console.WriteLine("List of people and their ages:");
            foreach (var kvp in ages)
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value}");
            }

            // Removing an entry
            ages.Remove("Yash");
            Console.WriteLine("Removed Yash from the dictionary.");

            // Checking the updated dictionary
            Console.WriteLine("Updated list of people and their ages:");
            foreach (var kvp in ages)
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value}");
            }
        
        IList<int> numbers = new List<int> { 1, 2, 3, 4, 5 };

        // Accessing elements by index
        Console.WriteLine("Element at index 2: " + numbers[2]); // Output: 3

        // Adding an element to the list
        numbers.Add(6);
        Console.WriteLine("Added 6 to the list.");

        // Removing an element from the list
        numbers.Remove(3); // Removes the first occurrence of 3
        Console.WriteLine("Removed 3 from the list.");

        // Iterating over the list
        Console.WriteLine("Updated list:");
        foreach (var num in numbers)
        {
            Console.WriteLine(num);
        }

    }
}
}