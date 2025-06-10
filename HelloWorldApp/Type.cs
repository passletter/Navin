using System;

class ProgramType
{
    static unsafe void References()
    {
        object obj = 1001; // Student ID
        Console.WriteLine("Student ID: " + obj);

        obj = "Sudhir Sharma"; // Student Name
        Console.WriteLine("Student Name: " + obj);

        dynamic value = 10;
        Console.WriteLine("Dynamic value: " + value);

        value = "Hello, World!";
        Console.WriteLine("Dynamic now contains: " + value);

        string[] students = { "Zoya", "Yashna", "Olivia", "Naomi" };

        Console.WriteLine("Student List:");
        foreach (string student in students)
        {
            Console.WriteLine(student);
        }

        int grade = 90;
        int* ptr = &grade;

        Console.WriteLine("Original Grade: " + grade);
        Console.WriteLine("Memory Address: " + (ulong)ptr);

        *ptr = 95; // Modifying value using pointer
        Console.WriteLine("Updated Grade: " + grade);

        char c = (char)65; // Outputs 'A'
        // Compilation error: Cannot assign a string to an int
        int age = "25";
        // This will cause a NullReferenceException
        string name;
        Console.WriteLine(name.Length);

        // Error: Should use `decimal`
        float price = 100.99f;

        //Use decimal for money-related calculations.
        decimal price = 100.99m; 
        
        double salary = 50000.75;
        int roundedSalary = (int)salary; // Explicit casting

        Console.WriteLine("Original Salary (Double): " + salary);
        Console.WriteLine("Rounded Salary (Integer): " + roundedSalary);
    }
}