using System;
using System.IO;
using System.THread;
class WhileClass
{
    static void ReverseWithWhile()
    {
        int num = 12345, reverse = 0;

        while (num != 0)
        {
            int digit = num % 10;
            reverse = reverse * 10 + digit;
            num /= 10;
        }
        Console.WriteLine("Reversed Number: " + reverse);
    }

    static void CountDigits()
    {
        int num = 987654, count = 0;

        while (num != 0)
        {
            num /= 10; // Remove last digit
            count++;
        }
        Console.WriteLine("Total Digits: " + count);
    }

    static void TakeInput()
    {
        string input;
        while (true)
        {
            Console.Write("Enter a word (type 'exit' to stop): ");
            input = Console.ReadLine();
            if (input == "exit")
                break;
            Console.WriteLine("You entered: " + input);
        }
    }
    static void TakeValidNumber()
    {
        int number;
        Console.Write("Enter a positive number: ");
        while (!int.TryParse(Console.ReadLine(), out number) || number <= 0)
        {
            Console.Write("Invalid input! Please enter a positive number: ");
        }
        Console.WriteLine("You entered: " + number);
    }

    static void ReadFullFile()
    {
        string filePath = "sample.txt";
        if (File.Exists(filePath))
        {
            using (StreamReader reader = new StreamReader(filePath))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    Console.WriteLine(line);
                }
            }
        }
    }
    static void TakeRandomValid()
    {
        Random rand = new Random();
        int number;
        do
        {
            number = rand.Next(1, 10);
            Console.WriteLine("Generated: " + number);
        } while (number != 7);
        Console.WriteLine("Stopped at 7!");
    }

    static void MonitoredRun()
    {
        bool isRunning = true;
        int counter = 0;
        while (isRunning)
        {
            Console.WriteLine("Running... " + counter);
            Thread.Sleep(1000); // Simulates a delay
            counter++;
            if (counter == 5) isRunning = false;
        }
        Console.WriteLine("Process stopped.");
        
        /////Countdown thread
          int countdown = 5;
        do
        {
            Console.WriteLine($"Countdown: {countdown}");
            countdown--;
            Thread.Sleep(1000);
        } while (countdown > 0);

        Console.WriteLine("Time's up!");
    }
}