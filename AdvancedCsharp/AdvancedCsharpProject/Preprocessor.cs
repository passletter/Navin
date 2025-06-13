#define PI 
#define DEBUG
#define VC_V10
#define DEBUG_MODE
using System;
namespace PreprocessorDAppl {
   class Program {
      static void Main(string[] args) {
         #if (PI)
            Console.WriteLine("PI is defined");
#else
            Console.WriteLine("PI is not defined");
#endif
         
         #if (DEBUG && !VC_V10)
         Console.WriteLine("DEBUG is defined");
      #elif (!DEBUG && VC_V10)
         Console.WriteLine("VC_V10 is defined");
      #elif (DEBUG && VC_V10)
         Console.WriteLine("DEBUG and VC_V10 are defined");
#else
         Console.WriteLine("DEBUG and VC_V10 are not defined");
#endif

            //   #if DEBUG_MODE
            //      #error "Debug mode is enabled. Disable it before compiling."
            //   #endif
     Console.WriteLine("Code outside region");

      #region Math Operations
      int a = 10, b = 20;
      int sum = a + b;
      Console.WriteLine("Sum: " + sum);
      #endregion

      Console.WriteLine("Code outside region");
      
         Console.ReadKey();
      }
   }
}