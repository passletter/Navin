using System;
using System.Text;
namespace StringApplication {
   class StringProg {
        static void Main(string[] args)
        {
            string str = "C# Programming";
            int length = str.Length;
            Console.WriteLine("Length of the string: " + length);

            string str1 = "C# by TP";

            foreach (char ch in str1)
            {
                Console.WriteLine(ch);
            }

            string str11 = "Hello";
            string str2 = "World";

            if (String.Compare(str11, str2) == 0)
            {
                Console.WriteLine("Strings are equal.");
            }
            else
            {
                Console.WriteLine("Strings are not equal.");
            }

            if (str.Contains("C#"))
            {
                Console.WriteLine("The sequence 'C#' was found.");
            }

            string substr = str.Substring(3, 11);
            Console.WriteLine(substr);

            string[] lines = new string[] {
            "C# is a modern",
            "Object-oriented",
            "Programming language"
         };

            string result = String.Join("\n", lines);
            Console.WriteLine(result);

            StringBuilder sb = new StringBuilder("Hello");
            sb.Append(" World!");
            sb.Insert(6, "C# ");
            sb.Replace("World", "Everyone");

            Console.WriteLine(sb.ToString());

            string strn = "Hello, tutorialspoint";
            bool res = strn.EndsWith("spoint");
            Console.Write(res == true
               ? "The specified string is available in this string"
               : "The specified string is not available in the string");

            string stru = "Hii, tutorialspoint!";
            // Array of characters to search for
            char[] charsToFind = { 'i', 'o', '!' };
            int first_indx = stru.IndexOfAny(charsToFind);
            Console.WriteLine(first_indx);

            int index = str.IndexOfAny(charsToFind, 7);
            Console.WriteLine(index);
            
              int index1 = str.IndexOfAny(charsToFind, 7, 5);
            Console.WriteLine(index1);
      }
   }
}