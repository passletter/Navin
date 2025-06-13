using System;
using System.Collections.ObjectModel;
using System.Collections;

class Person {
   public string? Name { get; set; }
   public int Age { get; set; } 

   public override string ToString() {
      return $"Name: {Name}, Age: {Age}";
   }
}
class ProgramArray
{
    static void ArrayReadOnly()
    {
        // Original array
        int[] numbers = { 1, 2, 3, 4, 5 };

        // Wrap the array as a read-only collection
        ReadOnlyCollection<int> readOnlyNumbers = Array.AsReadOnly(numbers);

        // Display the read-only collection
        Console.WriteLine("Read-only collection elements:");
        foreach (int num in readOnlyNumbers)
        {
            Console.WriteLine(num);
        }

        // Original array can still be modified
        numbers[0] = 10;

        Console.WriteLine("\nAfter modifying the original array:");
        foreach (int num in readOnlyNumbers)
        {
            Console.WriteLine(num);
        }

        Person[] persons = new Person[]{
            new Person(){Name="vante",Age=20},
            new Person(){Name="Harley",Age=40}
        };
        ReadOnlyCollection<Person> ReadOnlyPersons = new ReadOnlyCollection<Person>(persons);
        foreach (Person p in ReadOnlyPersons)
        {
            Console.WriteLine(p.Name);
            Console.WriteLine(p.Age);
        }
        //another way of creating a read-only collection
        ReadOnlyCollection<Person> readOnlyPeople = Array.AsReadOnly(persons);
    }

    static void BinaryGet()
    {
        int[] numbers = { 1, 2, 3, 4, 5 };
        int value_to_search = 4;
        int index = Array.BinarySearch(numbers, value_to_search);

        if (index >= 0)
        {
            Console.WriteLine("Index: " + index);
        }
        else
        {
            Console.WriteLine("Value not found. Insertion point: " + ~index);
        }
    }

}

class DescendingComparer : IComparer {
   public int Compare(object? x, object? y) {
     if (x == null && y == null) return 0; 
        if (x == null) return -1;         
        if (y == null) return 1;   
      return Comparer<object>.Default.Compare(y, x);
   }
}

class Custom
{
    static void RealCompare()
    {
        // Sorted array in des order
        int[] numbers = { 50, 40, 30, 20, 10 };
        int valueToFind = 30;

        int index = Array.BinarySearch(numbers, valueToFind, new DescendingComparer());

        if (index >= 0)
        {
            Console.WriteLine($"Value {valueToFind} found at index {index}.");
        }
        else
        {
            Console.WriteLine($"Value {valueToFind} not found. Insertion point: {~index}");
        }
    }
}

class CaseInsensitiveComparer : IComparer {
   public int Compare(object? x, object? y) {
        if (x == null) return -1; if (y == null) return 1;
        if (x == null && y == null) return 0;
        return Comparer<object>.Default.Compare(x, y);
   }
}
class StringBinary {
   static void CompareAndFind() {
      string[] fruits = { "Apple", "Banana", "Grape", "Mango", "Orange" };
      string valueToSearch = "mango";

      int index = Array.BinarySearch(fruits, valueToSearch, new CaseInsensitiveComparer());

      if (index >= 0) {
         Console.WriteLine($"Value '{valueToSearch}' found at index {index}.");
      }
      else {
         Console.WriteLine($"Value '{valueToSearch}' not found. Insertion point: {~index}");
      }
   }
}