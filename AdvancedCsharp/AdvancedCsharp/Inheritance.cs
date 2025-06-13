using System;
namespace RectangleApplication {
   class Rectangle {
      
      //member variables
      protected double length;
      protected double width;
      
      public Rectangle(double l, double w) {
         length = l;
         width = w;
      }
      public double GetArea() {
         return length * width;
      }
      public void Display() {
         Console.WriteLine("Length: {0}", length);
         Console.WriteLine("Width: {0}", width);
         Console.WriteLine("Area: {0}", GetArea());
      }
   } 
   class Tabletop : Rectangle {
      private double cost;
	  
	  // initializing base class member variable
      public Tabletop(double l, double w) : base(l, w) { }
      
      public double GetCost() {
         double cost;
         cost = GetArea() * 70;
         return cost;
      }
      public void Displays() {
         base.Display();
         Console.WriteLine("Cost: {0}", GetCost());
      }
   }

   //Multilevel inheritance
   class Grandparent {
    public void Display() {
        Console.WriteLine("Grandparent class.");
    }
}

class Parent : Grandparent { }

    class Child : Parent { }


    //Hierarchical inheritance
   class Vehicle {
    public void Start() {
        Console.WriteLine("Vehicle is starting.");
    }
}

class Car : Vehicle {
    public void Drive() {
        Console.WriteLine("Car is driving.");
    }
}

    class Bike : Vehicle
    {
        public void Ride()
        {
            Console.WriteLine("Bike is riding.");
        }
    }


//Overriding in inheritance
    class Animal
    {
        public virtual void MakeSound()
        {
            Console.WriteLine("Animal makes a sound.");
        }
    }

    class Dog : Animal
    {
        public override void MakeSound()
        {
            Console.WriteLine("Dog barks.");
        }
    }


//using base keyword
    class Person
    {
        public string Name;

        public Person(string name)
        {
            Name = name;
        }
    }

    class Student : Person
    {
        public int RollNo;

        public Student(string name, int rollNo) : base(name)
        {
            RollNo = rollNo;
        }

        public void Display()
        {
            Console.WriteLine($"Name: {Name}, Roll No: {RollNo}");
        }
    }


//No class can inherit from this base class as it is sealed
    sealed class FinalClass
    {
        public void Display()
        {
            Console.WriteLine("This is a sealed class.");
        }
    }

    class ExecuteRectangle
    {
        static void Main(string[] args)
        {
            Tabletop t = new Tabletop(4.5, 7.5);
            t.Displays();

            Child c = new Child();
            c.Display();

            Bike b = new Bike();
            b.Start();
            b.Ride();

            Animal myPet = new Dog();
            myPet.MakeSound(); // Calls overridden method

            Student student = new Student("Sudhir", 101);
            student.Display();

            Console.ReadLine();
        }
    }
}