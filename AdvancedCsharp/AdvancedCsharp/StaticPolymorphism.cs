using System;
namespace PolymorphismApplication
{
    class Printdata
    {
        void print(int i)
        {
            Console.WriteLine("Printing int: {0}", i);
        }
        void print(double f)
        {
            Console.WriteLine("Printing float: {0}", f);
        }
        void print(string s)
        {
            Console.WriteLine("Printing string: {0}", s);
        }
        static void Main(string[] args)
        {
            Printdata p = new Printdata();

            // Call print to print integer
            p.print(5);

            // Call print to print float
            p.print(500.263);

            // Call print to print string
            p.print("Hello C++");
            Console.ReadKey();
        }
    }
}

namespace PolymorphismApplicationWithOperatorOverloading {
    class Box
    {
        // Length, Breadth, and Height of a box
        private double length;
        private double breadth;
        private double height;

        public Box(double l, double b, double h)
        {
            length = l;
            breadth = b;
            height = h;
        }

        public double Volume()
        {
            return length * breadth * height;
        }

        // Overloading the + operator
        public static Box operator +(Box b1, Box b2)
        {
            return new Box(b1.length + b2.length, b1.breadth + b2.breadth, b1.height + b2.height);
        }

        public void Display()
        {
            Console.WriteLine("Dimensions: {0} x {1} x {2}", length, breadth, height);
        }

        static void Main(string[] args)
        {
            Box box1 = new Box(3.0, 4.0, 5.0);
            Box box2 = new Box(2.0, 3.0, 4.0);
            Box box3;

            // Add two Box objects
            box3 = box1 + box2;

            Console.WriteLine("Box 1:");
            box1.Display();

            Console.WriteLine("Box 2:");
            box2.Display();

            Console.WriteLine("Resultant Box after addition:");
            box3.Display();

            Console.ReadKey();
        }
    }
    }

namespace OperatorOvlApplication2
{
    class Box
    {
        private double length;   // Length of a box
        private double breadth;  // Breadth of a box
        private double height;   // Height of a box

        public double getVolume()
        {
            return length * breadth * height;
        }
        public void setLength(double len)
        {
            length = len;
        }
        public void setBreadth(double bre)
        {
            breadth = bre;
        }
        public void setHeight(double hei)
        {
            height = hei;
        }

        // Overload + operator to add two Box objects.
        public static Box operator +(Box b, Box c)
        {
            Box box = new Box();
            box.length = b.length + c.length;
            box.breadth = b.breadth + c.breadth;
            box.height = b.height + c.height;
            return box;
        }
    }
    class Tester
    {
        static void Main(string[] args)
        {
            Box Box1 = new Box();   // Declare Box1 of type Box
            Box Box2 = new Box();   // Declare Box2 of type Box
            Box Box3 = new Box();   // Declare Box3 of type Box
            double volume = 0.0;    // Store the volume of a box here

            // box 1 specification
            Box1.setLength(6.0);
            Box1.setBreadth(7.0);
            Box1.setHeight(5.0);

            // box 2 specification
            Box2.setLength(12.0);
            Box2.setBreadth(13.0);
            Box2.setHeight(10.0);

            // volume of box 1
            volume = Box1.getVolume();
            Console.WriteLine("Volume of Box1 : {0}", volume);

            // volume of box 2
            volume = Box2.getVolume();
            Console.WriteLine("Volume of Box2 : {0}", volume);

            // Add two object as follows:
            Box3 = Box1 + Box2;

            // volume of box 3
            volume = Box3.getVolume();
            Console.WriteLine("Volume of Box3 : {0}", volume);
            Console.ReadKey();
        }
    }
}

namespace OperatorOvlApplication {
   class Box {
      private double length;    // Length of a box
      private double breadth;   // Breadth of a box
      private double height;    // Height of a box
      
      public double getVolume() {
         return length * breadth * height;
      }
      public void setLength( double len ) {
         length = len;
      }
      public void setBreadth( double bre ) {
         breadth = bre;
      }
      public void setHeight( double hei ) {
         height = hei;
      }
      
      // Overload + operator to add two Box objects.
      public static Box operator+ (Box b, Box c) {
         Box box = new Box();
         box.length = b.length + c.length;
         box.breadth = b.breadth + c.breadth;
         box.height = b.height + c.height;
         return box;
      }
      public static bool operator == (Box lhs, Box rhs) {
         bool status = false;
         if (lhs.length == rhs.length && lhs.height == rhs.height 
            && lhs.breadth == rhs.breadth) {
            
            status = true;
         }
         return status;
      }
      public static bool operator !=(Box lhs, Box rhs) {
         bool status = false;
         
         if (lhs.length != rhs.length || lhs.height != rhs.height || 
            lhs.breadth != rhs.breadth) {
            
            status = true;
         }
         return status;
      }
      public static bool operator <(Box lhs, Box rhs) {
         bool status = false;
         
         if (lhs.length < rhs.length && lhs.height < rhs.height 
            && lhs.breadth < rhs.breadth) {
            
            status = true;
         }
         return status;
      }
      public static bool operator >(Box lhs, Box rhs) {
         bool status = false;
         
         if (lhs.length > rhs.length && lhs.height > 
            rhs.height && lhs.breadth > rhs.breadth) {
            
            status = true;
         }
         return status;
      }
      public static bool operator <=(Box lhs, Box rhs) {
         bool status = false;
         
         if (lhs.length <= rhs.length && lhs.height 
            <= rhs.height && lhs.breadth <= rhs.breadth) {
            
            status = true;
         }
         return status;
      }
      public static bool operator >=(Box lhs, Box rhs) {
         bool status = false;
         
         if (lhs.length >= rhs.length && lhs.height 
            >= rhs.height && lhs.breadth >= rhs.breadth) {
            
            status = true;
         }
         return status;
      }
      public override string ToString() {
         return String.Format("({0}, {1}, {2})", length, breadth, height);
      }
   }
   class Tester {
      static void Main(string[] args) {
         Box Box1 = new Box();   // Declare Box1 of type Box
         Box Box2 = new Box();   // Declare Box2 of type Box
         Box Box3 = new Box();   // Declare Box3 of type Box
         Box Box4 = new Box();
         double volume = 0.0;    // Store the volume of a box here
         
         // box 1 specification
         Box1.setLength(6.0);
         Box1.setBreadth(7.0);
         Box1.setHeight(5.0);
         
         // box 2 specification
         Box2.setLength(12.0);
         Box2.setBreadth(13.0);
         Box2.setHeight(10.0);
         
         //displaying the Boxes using the overloaded ToString():
         Console.WriteLine("Box 1: {0}", Box1.ToString());
         Console.WriteLine("Box 2: {0}", Box2.ToString());
         
         // volume of box 1
         volume = Box1.getVolume();
         Console.WriteLine("Volume of Box1 : {0}", volume);
         
         // volume of box 2
         volume = Box2.getVolume();
         Console.WriteLine("Volume of Box2 : {0}", volume);
         
         // Add two object as follows:
         Box3 = Box1 + Box2;
         Console.WriteLine("Box 3: {0}", Box3.ToString());
         
         // volume of box 3
         volume = Box3.getVolume();
         Console.WriteLine("Volume of Box3 : {0}", volume);
         
         //comparing the boxes
         if (Box1 > Box2)
            Console.WriteLine("Box1 is greater than Box2");
         else
            Console.WriteLine("Box1 is not greater than Box2");
         
         if (Box1 < Box2)
            Console.WriteLine("Box1 is less than Box2");
         else
            Console.WriteLine("Box1 is not less than Box2");
         
         if (Box1 >= Box2)
            Console.WriteLine("Box1 is greater or equal to Box2");
         else
            Console.WriteLine("Box1 is not greater or equal to Box2");
         
         if (Box1 <= Box2)
            Console.WriteLine("Box1 is less or equal to Box2");
         else
            Console.WriteLine("Box1 is not less or equal to Box2");
         
         if (Box1 != Box2)
            Console.WriteLine("Box1 is not equal to Box2");
         else
            Console.WriteLine("Box1 is not greater or equal to Box2");
         Box4 = Box3;
         
         if (Box3 == Box4)
            Console.WriteLine("Box3 is equal to Box4");
         else
            Console.WriteLine("Box3 is not equal to Box4");

         Console.ReadKey();
      }
   }
}