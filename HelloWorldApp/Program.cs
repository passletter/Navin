
using System;

struct Employee
{
    public int ID;
    public string Name;
    public double Salary;
}

class Program
{
    static void Main()
    {
        Employee emp;
        emp.ID = 101;
        emp.Name = "Zoya";
        emp.Salary = 60000.50;

        Console.WriteLine("Employee ID: " + emp.ID);
        Console.WriteLine("Employee Name: " + emp.Name);
        Console.WriteLine("Employee Salary: $" + emp.Salary);

        string str = "789";
        if (int.TryParse(str, out int result))
        {
            Console.WriteLine(result);
        }
        else
        {
            Console.WriteLine("Conversion failed.");
        }
        string str = "456";
        int num = int.Parse(str);
        Console.WriteLine(num);
         
         string str = "123";
         int num = Convert.ToInt32(str);
         Console.WriteLine(num);
    }
}

