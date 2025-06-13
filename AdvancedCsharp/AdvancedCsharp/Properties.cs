using System;
namespace tutorialspoint {
    
     public abstract class Persona {
      public abstract string SurName {
         get;
         set;
      }
      public abstract int SurAge {
         get;
         set;
      }
   }
   class Student:Persona
    {
         private string? password;

    // Read-only property
    public string CreatedBy { get; } = "Ravi Kumar";

    // Write-only property
    public string Password
    {
        set { password = value; }
    }
         public string? FirstName { get; set; }  // Auto-implemented
    public string? LastName { get; set; }   // Auto-implemented
        private string? _surname;
        public override string SurName
        {
            get { return _surname?? "karki"; }
            set { _surname = value; }
        }

        private int _surAge;

public override int SurAge
{
    get { return _surAge; }
    set { _surAge = value; }
}

        private string code = "N.A";
        private string name = "not known";
        private int age = 0;

        // Declare a Code property of type string:
        public string Code
        {
            get
            {
                return code;
            }
            set
            {
                code = value;
            }
        }

        // Declare a Name property of type string:
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }


         private int myage;

    public int MyAge
    {
        get { return myage; }
        set
        {
            if (value < 18)
                throw new ArgumentException("Minimum age is 18.");
            myage = value;
        }
    }

        // Declare a Age property of type int:
        public int Age
        {
            get
            {
                return age;
            }
            set
            {
                age = value;
            }
        }
        public override string ToString()
        {
            return "Code = " + Code + ", Name = " + Name + ", Age = " + Age;
        }
    }
   
   class ExampleDemo {
      public static void Main() {
      
         // Create a new Student object:
         Student s = new Student();
         
         // Setting code, name and the age of the student
         s.Code = "001";
         s.Name = "Zara";
         s.Age = 9;
         Console.WriteLine("Student Info: {0}", s);
         
         //let us increase age
         s.Age += 1;
         Console.WriteLine("Student Info: {0}", s);

            s.SurName = "Larrson";
         Console.ReadKey();
      }
   }
}