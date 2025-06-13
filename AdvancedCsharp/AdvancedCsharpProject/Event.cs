using System;
using Pubsub;
namespace SampleApp {
   public delegate string MyDel(string str);
	
   class EventProgram {
      event MyDel MyEvent;
		
      public EventProgram() {
         this.MyEvent += new MyDel(this.WelcomeUser);
      }
      public string WelcomeUser(string username) {
         return "Welcome " + username;
      }
      static void Main(string[] args) {
         EventProgram obj1 = new EventProgram();
         string result = obj1.MyEvent("Tutorials Point");
         Console.WriteLine(result);
      }
   }
}

namespace NewNameSpace
{
    public delegate string NewEventDelegate(string str, int num);
    class NewEventClass
    {
        event NewEventDelegate NewEvent;
        public NewEventClass()
        {
            NewEvent += new NewEventDelegate(this.NewHandler);

        }
        public string NewHandler(string str, int num)
        {
            return "" + str + "" + num;
        }
        static void Main(string[] args) {
            NewEventClass ne = new NewEventClass();
            string result = ne.NewEvent("Hello", 10);
         Console.WriteLine(result);
      }
    }
}

namespace Pubsub{
    public delegate void Notify(string message);
   
   // Publisher class
   class User {
      // Declare event
       public event Notify? UserLoggedIn;
      
      public void Login(string username) {
         Console.WriteLine($"{username} logged in successfully.");
         
         // Trigger event
         UserLoggedIn?.Invoke($"Notification: {username} has logged in.");
      }
   }
   
   // Subscriber class
   class Program {
      static void Main(string[] args) {
         User user = new User();
         
         // Subscribe to the event
         user.UserLoggedIn += DisplayMessage;
         
         // Simulate login
         user.Login("JohnDoe");
      }
      
      // Event handler method
      static void DisplayMessage(string message) {
         Console.WriteLine(message);
      }
   }
}

namespace MultipleHandler
{
   class MultiHandlerClass
   {
      public delegate string Notify(string message);
      public event Notify? OnNotify;
      public void CheckId(int id)
      {
         if (id > 100)
         {
            Console.WriteLine("Your id is greater than 100 with :" + id.ToString());
            OnNotify?.Invoke("Hello your handler is triggered...");
         }
      }
   }

   class MultiProgram
   {
      static string NotifyUser(string msg1) => msg1.ToUpper();
      static string NotifyOther(string msg2) => msg2.ToLower();
      static void Main()
      {
         MultiHandlerClass mh = new MultiHandlerClass();
         mh.OnNotify += NotifyUser;
         mh.OnNotify += NotifyOther;
         mh.CheckId(300);
      }
   }
}