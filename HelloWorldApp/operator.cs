using System;

class ProgramOperator
{
    static void MainOperate()
    {
        int x = 10, y = 4;
        Console.WriteLine("Addition: " + (x + y));
        Console.WriteLine("Multiplication: " + (x * y));
        Console.WriteLine("Modulo: " + (x % y));

        int a = 20, b = 15;
        Console.WriteLine("Is a > b? " + (a > b));
        Console.WriteLine("Is a == b? " + (a == b));

        bool x = true, y = false;
        Console.WriteLine("AND (&&) : " + (x && y));
        Console.WriteLine("OR (||)  : " + (x || y));
        Console.WriteLine("NOT (!)  : " + (!x));

        int a = 5, b = 3;
        Console.WriteLine("Bitwise AND: " + (a & b));
        Console.WriteLine("Bitwise OR: " + (a | b));

        int num = 10;
        num += 5;  // Equivalent to num = num + 5
        Console.WriteLine(num);
        int age = 18;
        string result = (age >= 18) ? "Eligible to vote" : "Not eligible";
        Console.WriteLine(result);

        // typeof operator
        Console.WriteLine("Type of int: " + typeof(int));

        // sizeof operator
        Console.WriteLine("Size of int: " + sizeof(int));

        // is operator
        object obj = "Hello";
        Console.WriteLine("Is obj a string? " + (obj is string));

        // as operator
        object number = 42;
        string str = number as string;
        Console.WriteLine("Using 'as' operator: " + (str ?? "Conversion failed"));

        // nameof operator
        string variableName = nameof(number);
        Console.WriteLine("Variable name: " + variableName);

        int a = 20;
        int b = 10;
        int c = 15;
        int d = 5;
        int e;
        e = (a + b) * c / d;     // ( 30 * 15 ) / 5
        Console.WriteLine("Value of (a + b) * c / d is : {0}", e);

        e = ((a + b) * c) / d;   // (30 * 15 ) / 5
        Console.WriteLine("Value of ((a + b) * c) / d is  : {0}", e);

        e = (a + b) * (c / d);   // (30) * (15/5) {0}", e);

        e = a + (b * c) / d;    //  20 + (150/5) {0}", e);



        int score = 85;
        bool passedExam = true;

        if (score >= 80 && passedExam)
        {
            Console.WriteLine("Eligible for scholarship.");
        }
        else
        {
            Console.WriteLine("Not eligible.");
        }

        bool hasVIPPass = false;
        bool hasRegularTicket = true;

        if (hasVIPPass || hasRegularTicket)
        {
            Console.WriteLine("Access granted.");
        }
        else
        {
            Console.WriteLine("Access denied.");
        }

        bool isMember = true;
        double purchaseAmount = 120.0;

        if (isMember || purchaseAmount > 100)
        {
            Console.WriteLine("Discount applied.");
        }
        else
        {
            Console.WriteLine("No discount available.");
        }


        int a = 5, b = 3;
        int result = a & b;

        Console.WriteLine("Bitwise AND: " + result);

        int a = 5, b = 3;  // Binary: a = 0101, b = 0011
        int result = a | b; // 0101 | 0011 = 0111 (7)

        Console.WriteLine("Bitwise OR: " + result);

        int a = 5, b = 3;  // Binary: a = 0101, b = 0011
        int result = a ^ b; // 0101 ^ 0011 = 0110 (6)

        Console.WriteLine("Bitwise XOR: " + result);

        int a = 5;         // Binary: 00000101
        int result = ~a;   // NOT 00000101 = 11111010 (Twos Complement)

        Console.WriteLine("Bitwise NOT: " + result);

        //Miscellaneous operators
        Console.WriteLine("The size of int is {0}", sizeof(int));
        Console.WriteLine("The size of short is {0}", sizeof(short));
        Console.WriteLine("The size of double is {0}", sizeof(double));

        /* example of ternary operator */
        int a, b;
        a = 10;
        b = (a == 1) ? 20 : 30;
        Console.WriteLine("Value of b is {0}", b);

        b = (a == 10) ? 20 : 30;
        Console.WriteLine("Value of b is {0}", b);
        Console.ReadLine();

        int? number = null;
        int result = number ?? 100; // If 'number' is null, assign 100

        Console.WriteLine(result);

        string message = null;
        message ??= "Default Message"; // Assigns value only if message is null

        Console.WriteLine(message);

        object obj = "Hello, World!";

        if (obj is string)
        {
            Console.WriteLine("obj is a string.");
        }

        object obj = "Hello, C#";
        string str = obj as string;

        if (str != null)
        {
            Console.WriteLine("Safe casting successful: " + str);
        }

        Console.WriteLine("Size of int: " + sizeof(int) + " bytes");
        
        
        object obj = 42;

        if (obj is int number)
        {
            Console.WriteLine("obj is an integer: " + number);
        }
    }
}