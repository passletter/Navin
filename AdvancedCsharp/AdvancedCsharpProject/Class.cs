using System;

class Personu {
    public string Name;       // Public: Accessible everywhere
    private int age;          // Private: Only accessible within this class
    protected string Address; // Protected: Accessible in derived classes
    internal string Email;    // Internal: Accessible within the same assembly
    public static int num;
      
      public void count() {
         num++;
      }
      public static int getNum() {
         return num;
      }
    public Personu(string name, int age, string address, string email) {
        Name = name;
        this.age = age;
        Address = address;
        Email = email;
    }
    ~Personu() {   //destructor
         Console.WriteLine("Object is being deleted");
      }
    public void Display() {
        Console.WriteLine($"Name: {Name}, Age: {age}, Email: {Email}");
    }
}

class Programu {
    static void Main()
    {
        Personu p1 = new Personu("Sudhir Sharma", 27, "New Delhi", "test@email.com");
        Console.WriteLine($"Name: {p1.Name}");  // Accessible (public)
        Console.WriteLine($"Email: {p1.Email}"); // Accessible (internal)

        // p1.age and p1.Address are not accessible due to private and protected access
        p1.count();
         p1.count();
         p1.count();
         
         Console.WriteLine("Variable num: {0}", Personu.getNum());
    }
}