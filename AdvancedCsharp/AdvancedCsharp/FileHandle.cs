using System;
using System.IO;
namespace FileIOApplication {
   class Program {
      static void Main(string[] args) {
         FileStream F = new FileStream("test.dat", FileMode.OpenOrCreate, 
            FileAccess.ReadWrite);
         
         for (int i = 1; i <= 20; i++) {
            F.WriteByte((byte)i);
         }
         F.Position = 0;
         for (int i = 0; i <= 20; i++) {
            Console.Write(F.ReadByte() + " ");
         }
         F.Close();


         using (StreamReader reader = new StreamReader("data1.txt")) {
            string? line;
            while ((line = reader.ReadLine()) != null) {
                Console.WriteLine(line);
            }
        }

        using (StreamWriter writer = File.CreateText("data1.txt")) {
            writer.WriteLine("This is the first line.");
            writer.WriteLine("This is the second line.");
        }

            //Appending to the file
        using (StreamWriter writer = File.AppendText("data.txt")) {
            writer.WriteLine("This line is appended.");
        }

        //Deleting the file
        string path = "data.txt";
        if (File.Exists(path)) {
            File.Delete(path);
            Console.WriteLine("File deleted.");
        } else {
            Console.WriteLine("File does not exist.");
        }
        
        //checking the existence of the file
        if (File.Exists(path)) {
            Console.WriteLine("File exists.");
        } else {
            Console.WriteLine("File does not exist.");
        }

         string[] names = new string[] {"Zara Ali", "Nuha Ali"};
         
         using (StreamWriter sw = new StreamWriter("names.txt")) {

            foreach (string s in names) {
               sw.WriteLine(s);
            }
         }


         Console.ReadKey();
      }
   }
}