using System;
namespace EnumApplication {
   class EnumProgram {
      enum Days { Sun, Mon, tue, Wed, thu, Fri, Sat };
      enum StatusCode
        {
            Success = 200,
            NotFound = 404,
            ServerError = 500
        }

        enum Weekday
        {
            Sunday,
            Monday,
            Tuesday,
            Wednesday,
            Thursday,
            Friday,
            Saturday
        }

        [Flags]
        enum Permissions
        {
            None = 0,
            Read = 1,
            Write = 2,
            Execute = 4,
            FullControl = Read | Write | Execute
        }
 enum OrderStatus {
    Pending = 0,
    Processing = 1,
    Shipped = 2,
    Delivered = 3
}

      static void Main(string[] args)
        {
            int WeekdayStart = (int)Days.Mon;
            int WeekdayEnd = (int)Days.Fri;

            Console.WriteLine("Monday: {0}", WeekdayStart);
            Console.WriteLine("Friday: {0}", WeekdayEnd);

            StatusCode status = StatusCode.NotFound;
            Console.WriteLine("Status: " + status);
            Console.WriteLine("Numeric Value: " + (int)status);

            Weekday day = Weekday.Tuesday;
            switch (day)
            {
                case Weekday.Sunday:
                    Console.WriteLine("It's Sunday");
                    break;
                case Weekday.Monday:
                    Console.WriteLine("It's Monday.");
                    break;
                case Weekday.Tuesday:
                    Console.WriteLine("It's Tuesday.");
                    break;
                case Weekday.Wednesday:
                    Console.WriteLine("It's Wednesday.");
                    break;
                case Weekday.Thursday:
                    Console.WriteLine("It's Thursday.");
                    break;
                case Weekday.Friday:
                    Console.WriteLine("It's Friday.");
                    break;
                case Weekday.Saturday:
                    Console.WriteLine("It's Saturday.");
                    break;
            }

            Permissions userPermissions = Permissions.Read | Permissions.Write;

        // Displaying
        Console.WriteLine($"User's Permissions: {userPermissions}");

        // Checking
        Console.WriteLine($"You Have Write Permission? {userPermissions.HasFlag(Permissions.Write)}");
        Console.WriteLine($"You Have Execute Permission? {userPermissions.HasFlag(Permissions.Execute)}");

        string input = "Processing";
        OrderStatus statusFromString = (OrderStatus)Enum.Parse(typeof(OrderStatus), input);
        Console.WriteLine($"Converted from string: {statusFromString}");

        // Convert Integer to Enum
        int value = 3;
        OrderStatus statusFromInt = (OrderStatus)value;
        Console.WriteLine($"Converted from integer: {statusFromInt}");

            Console.ReadKey();
        }
   }
}