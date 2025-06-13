using System;
using System.Collections;

class CollectionProgram
{
    static void Main()
    {
        //sortedlist
        SortedList sortedList = new SortedList();
        sortedList.Add(3, "Three");
        sortedList.Add(1, "One");
        sortedList.Add(2, "Two");

        foreach (DictionaryEntry item in sortedList)
        {
            Console.WriteLine($"{item.Key}: {item.Value}");
        }

        //stack
        Stack stack = new Stack();
        stack.Push("First");
        stack.Push("Second");
        stack.Push("Third");


        while (stack.Count > 0)
        {
            Console.WriteLine(stack.Pop());
        }

        Stack st = new Stack();

        st.Push('A');
        st.Push('M');
        st.Push('G');
        st.Push('W');

        Console.WriteLine("Current stack: ");
        foreach (char c in st)
        {
            Console.Write(c + " ");
        }
        Console.WriteLine();

        st.Push('V');
        st.Push('H');
        Console.WriteLine("The next poppable value in stack: {0}", st.Peek());
        Console.WriteLine("Current stack: ");

        foreach (char c in st)
        {
            Console.Write(c + " ");
        }

        Console.WriteLine();

        Console.WriteLine("Removing values ");
        st.Pop();
        st.Pop();
        st.Pop();

        Console.WriteLine("Current stack: ");
        foreach (char c in st)
        {
            Console.Write(c + " ");
        }

        //Queue
        Queue queue = new Queue();
        queue.Enqueue("First");
        queue.Enqueue("Second");
        queue.Enqueue("Third");

        while (queue.Count > 0)
        {
            Console.WriteLine(queue.Dequeue());
        }

        Queue<char> q = new Queue<char>();

        q.Enqueue('A');
        q.Enqueue('M');
        q.Enqueue('G');
        q.Enqueue('W');

        Console.WriteLine("Current queue: ");
        foreach (char c in q) Console.Write(c + " ");

        Console.WriteLine();
        q.Enqueue('V');
        q.Enqueue('H');
        Console.WriteLine("Current queue: ");
        foreach (char c in q) Console.Write(c + " ");

        Console.WriteLine();
        Console.WriteLine("Removing some values ");
        char ch = (char)q.Dequeue();
        Console.WriteLine("The removed value: {0}", ch);
        ch = (char)q.Dequeue();
        Console.WriteLine("The removed value: {0}", ch);

        //HashTable
        Hashtable hashtable = new Hashtable();
        hashtable.Add("ID", 101);
        hashtable.Add("Name", "Sudhir");
        hashtable.Add("Age", 30);

        Console.WriteLine($"ID: {hashtable["ID"]}");
        Console.WriteLine($"Name: {hashtable["Name"]}");
        Console.WriteLine($"Age: {hashtable["Age"]}");

        Hashtable hashtable1 = new Hashtable();
        hashtable1.Add("101", "Rahul Mishra");
        hashtable1.Add("102", "Sneha Kapoor");
        hashtable1.Add("103", "Irfan Khan");
        hashtable1.Remove("103");

        foreach (DictionaryEntry entry in hashtable1)
        {
            Console.WriteLine($"Key: {entry.Key}, Value: {entry.Value}");
        }
        ICollection keys = hashtable1.Keys;
        foreach (string key in keys)
        {
            Console.WriteLine("" + key);
        }
         hashtable1.Clear();


        //Arraylist
        ArrayList list = new ArrayList();
        list.Add(1);
        list.Add("Hello");
        list.Add(3.14);

        foreach (var item in list)
        {
            Console.WriteLine(item);
        }

        ArrayList list2 = new ArrayList { 1, "World", 2.5 };


        ArrayList al = new ArrayList();

        Console.WriteLine("Adding some numbers:");
        al.Add(45);
        al.Add(78);
        al.Add(33);
        al.Add(56);
        al.Add(12);
        al.Add(23);
        al.Add(9);

        Console.WriteLine("Capacity: {0} ", al.Capacity);
        Console.WriteLine("Count: {0}", al.Count);

        Console.Write("Content: ");
        foreach (int i in al)
        {
            Console.Write(i + " ");
        }

        Console.WriteLine();
        Console.Write("Sorted Content: ");
        al.Sort();
        foreach (int i in al)
        {
            Console.Write(i + " ");
        }
        // Accessing the first element
        var firstElement = al[0];
        Console.WriteLine("First Element: " + firstElement);

        // Modifying the second element
        al[1] = "Hello";

        //converting arraylist into array
        object?[] array = al.ToArray();

        Console.WriteLine("Array Elements:");
        foreach (var item in array)
        {
            Console.WriteLine(item);
        }

        //making the array list non-modifiable but any changes made to the original ArrayList are still reflected in the read-only version
        ArrayList readonlList = ArrayList.ReadOnly(al);

        ArrayList arrayList = new ArrayList { "A", "B", "C", "D" };

        Console.Write("Before Clear: ");
        foreach (var item in arrayList)
        {
            Console.Write(item + " ");
        }

        // Clear the ArrayList
        arrayList.Clear();

        //Attempting to clear the fixedsized array
        // Create a fixed-size ArrayList
        ArrayList arrayList1 = ArrayList.FixedSize(new ArrayList { 1, 2, 3 });

        try
        {
            arrayList1.Clear();
        }
        catch (NotSupportedException ex)
        {
            Console.WriteLine($"Exception: {ex.Message}");
        }



    }
}

class Personb {
   public string Name { get; set; }
   public int Age { get; set; }

   public Personb(string name, int age) {
      Name = name;
      Age = age;
   }

   public override string ToString() {
      return $"Name: {Name}, Age: {Age}";
   }
   // Override Equals and GetHashCode to compare objects by value instead of reference
   public override bool Equals(object? obj) {
      if (obj is Person other) {
         return Name == other.Name && Age == other.Age;
      }
      return false;
   }

   public override int GetHashCode() {
      return HashCode.Combine(Name, Age);
   }
}
class CustomStack
{
    static void Main()
    {
        // Create a stack of Person objects
        Stack<Personb> people = new Stack<Personb>();

        // Push Person objects onto the stack
        people.Push(new Personb("Aman", 25));
        people.Push(new Personb("Gupta", 24));
        people.Push(new Personb("Vivek", 26));

        Console.WriteLine("People stack before Contains:");
        foreach (var person in people)
        {
            Console.WriteLine(person);
        }

        // use the contains method
        bool res = people.Contains(new Personb("Aman", 25));
        Console.Write("Is this object avialable: " + res);
    }
}