using System;

class ActionDelegate
{
    static void Main()
    {
        Action<string> greet = name => Console.WriteLine("Hello, " + name + "!");

        greet("Alice");   // Output: Hello, Alice!

        PrintGreeting(greet);
    }

    static void PrintGreeting(Action<string> greetAction)
    {
        greetAction("Bob");  // Output: Hello, Bob!
    }
}

class MulticastDelegate
{
    static void FirstMethod(string name)
    {
        Console.WriteLine("Myanme is: " + name);
    }

    static void SecondMethod(string name)
    {
        Console.WriteLine("School is :" + name);
    }

    static void HelloMain()
    {
        Action<string> greet = FirstMethod;
        greet += SecondMethod;
        greet("Navin Karki");
   }
}
