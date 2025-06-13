using System;

class PredicateClass
{

    static void PrintIf(List<int> list, Predicate<int> condition)
    {
        foreach (var item in list)
        {
            if (condition(item))
                Console.WriteLine(item);
        }
    }

    static void Main()
    {
        List<int> mynumbers = new List<int> { 1, 3, 4, 5, 6, 7, 8, };
        Predicate<int> prediacate = n => n % 2 == 0;
        PrintIf(mynumbers, prediacate);

        //combining predicates
        Predicate<int> pred1 = n => n > 0;
        Predicate<int> pred2 = n => n % 2 != 0;
        Predicate<int> combined = n => pred1(n) && pred2(n);
        PrintIf(mynumbers, combined);
    }
}

class ComplexPredicate
{
    class Person { public string? Name; public int Age; }


    void Main()
    {
        Predicate<Person> isAdult = p => p.Age >= 18;
        List<Person> people = new List<Person>
{
    new Person { Name = "Alice", Age = 30 },
    new Person { Name = "Bob", Age = 17 }
};
        Person? firstAdult = people.Find(isAdult);
        Console.WriteLine(firstAdult?.Name); // Output: Alice
    }

}

