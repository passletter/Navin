using System;
struct Books {
   public string title;
   public string author;
   public string subject;
   public int book_id;
};

struct Personi
{
    public string name;
    public int age;
    public string empid;
}

interface IPerson {
    string GetDetails();
}

struct Personin : IPerson {
    public string name;
    public int age;
    public string empid;

    // Constructor to initialize fields
    public Personin(string name, int age, string empid) {
        this.name = name;
        this.age = age;
        this.empid = empid;
    }

    // Implementing the interface method
    public string GetDetails() => $"Name: {name}, Age: {age}, Employee ID: {empid}";
}




struct Persont
{
    public readonly string name;
    public readonly int age;
    public readonly string empid;

    public Persont(string name, int age, string empid)
    {
        this.name = name;
        this.age = age;
        this.empid = empid;
    }

    public void Display()
    {
        Console.WriteLine($"Name: {name}, Age: {age}, Employee ID: {empid}");
    }
}

struct Booki {
   private string title;
   private string author;
   private string subject;
   private int book_id;
   
   public void getValues(string t, string a, string s, int id) {
      title = t;
      author = a;
      subject = s;
      book_id = id;
   }
   
   public void display() {
      Console.WriteLine("Title : {0}", title);
      Console.WriteLine("Author : {0}", author);
      Console.WriteLine("Subject : {0}", subject);
      Console.WriteLine("Book_id :{0}", book_id);
   }
};  


public class testStructure
{
    public static void Main(string[] args)
    {
        Books Book1;
        Books Book2;


        Book1.title = "C Programming";
        Book1.author = "Nuha Ali";
        Book1.subject = "C Programming Tutorial";
        Book1.book_id = 6495407;


        Book2.title = "Telecom Billing";
        Book2.author = "Zara Ali";
        Book2.subject = "Telecom Billing Tutorial";
        Book2.book_id = 6495700;


        Console.WriteLine("Book 1 title : {0}", Book1.title);
        Console.WriteLine("Book 1 author : {0}", Book1.author);
        Console.WriteLine("Book 1 subject : {0}", Book1.subject);
        Console.WriteLine("Book 1 book_id :{0}", Book1.book_id);


        Console.WriteLine("Book 2 title : {0}", Book2.title);
        Console.WriteLine("Book 2 author : {0}", Book2.author);
        Console.WriteLine("Book 2 subject : {0}", Book2.subject);
        Console.WriteLine("Book 2 book_id : {0}", Book2.book_id);

        Personi p1 = new Personi();
        p1.name = "Sudhir Sharma";
        p1.age = 27;
        p1.empid = "SEO01";

        Console.WriteLine($"Name: {p1.name}, Age: {p1.age}, Employee ID: {p1.empid}");

        Persont p = new Persont("navin", 10, "1001");
        p.Display();

        Booki B1 = new Booki();
        B1.getValues("C Programming","Nuha Ali", "C Programming Tutorial",6495407);
        B1.display();

        Personin pin = new Personin("Sudhir Sharma", 27, "SEO01");
        Console.WriteLine(pin.GetDetails());


        Console.ReadKey();
    }
}