using System;
namespace RectangleApplication
{
    class Rectangle
    {
        //member variables
        public double length;
        public double width;

        public double GetArea()
        {
            return length * width;
        }
        public void Display()
        {
            Console.WriteLine("Length: {0}", length);
            Console.WriteLine("Width: {0}", width);
            Console.WriteLine("Area: {0}", GetArea());
        }
    }//end class Rectangle

    class ExecuteRectangle
    {
        static void MainE()
        {
            Rectangle r = new Rectangle();
            r.length = 4.5;
            r.width = 3.5;
            r.Display();
            Console.ReadLine();
        }
    }


}

namespace RectangleApplicationWithEncapsulation
{
    class Rectangle
    {
        //member variables
        private double length;
        private double width;

        public void Acceptdetails()
        {
            Console.WriteLine("Enter Length: ");
            length = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Enter Width: ");
            width = Convert.ToDouble(Console.ReadLine());
        }
        public double GetArea()
        {
            return length * width;
        }
        public void Display()
        {
            Console.WriteLine("Length: {0}", length);
            Console.WriteLine("Width: {0}", width);
            Console.WriteLine("Area: {0}", GetArea());
        }
    }
    //end class Rectangle  
    class ExecuteRectangle
    {
        static void Main(string[] args)
        {
            Rectangle r = new Rectangle();
            r.Acceptdetails();
            r.Display();
            Console.ReadLine();
        }
    }

    ///////////////////////
    /// Encapsulation using property
    class Person
    {
        // Private field
        private string name;

        // Public method - Setting the name
        public void SetName(string newName)
        {
            if (!string.IsNullOrEmpty(newName))
            {
                name = newName;
            }
            else
            {
                Console.WriteLine("Name cannot be empty.");
            }
        }

        // Public method - Getting the name
        public string GetName()
        {
            return name;
        }
    }

    class ProgramWithPrivacy
    {
        static void MainP()
        {
            Person person = new Person();
            person.SetName("Sudhir Sharma");
            Console.WriteLine("Person's Name: " + person.GetName());
        }
    }

    //Encapsulation with properties
    class EmployeeWithProperty
    {
        private double salary;  // Private field

        // Public property with validation logic
        public double Salary
        {
            get { return salary; }
            set
            {
                if (value >= 3000)
                {
                    salary = value;
                }
                else
                {
                    Console.WriteLine("Salary must be at least 3000.");
                }
            }
        }
    }
    class ProgramWithPrivateProperty
    {
        static void MainProeprty()
        {
            Employee emp = new EmployeeWithProperty();
            emp.Salary = 5000;  // Valid salary
            Console.WriteLine("Employee Salary: " + emp.Salary);

            emp.Salary = 2000;  // Invalid salary
            Console.WriteLine("Updated Salary: " + emp.Salary);
        }
    }

    /// internal properties and fields
    class RectangleInternal
    {
        //member variables
        internal double length;
        internal double width;

        double GetArea()
        {
            return length * width;
        }
        public void Display()
        {
            Console.WriteLine("Length: {0}", length);
            Console.WriteLine("Width: {0}", width);
            Console.WriteLine("Area: {0}", GetArea());
        }
    }//end class Rectangle

    class ExecuteRectangleInernal
    {
        static void MainInternal()
        {
            Rectangle r = new RectangleInternal();
            r.length = 4.5;
            r.width = 3.5;
            r.Display();
            Console.ReadLine();
        }
    }


    //Using protected internal properties
   class RectanglePi {
      // member variables
      protected internal double length;
      protected internal double width;
      
      double GetArea() {
         return length * width;
      }
      public void Display() {
         Console.WriteLine("Length: {0}", length);
         Console.WriteLine("Width: {0}", width);
         Console.WriteLine("Area: {0}", GetArea());
      }
   }// end class Rectangle
   
   class ExecuteRectanglePi {
      static void MainPi() {
         Rectangle r = new RectanglePi();
         r.length = 4.5;
         r.width = 3.5;
         r.Display();
         Console.ReadLine();
      }
   }
}