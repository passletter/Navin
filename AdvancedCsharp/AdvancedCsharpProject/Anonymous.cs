// using System;

// delegate void NumberChanger(int n);

// namespace DelegateAppl {
//     class TestDelegatep {
//         static int num = 10;

//         public static void AddNum(int p) {
//             num += p;
//             Console.WriteLine("Named Method: {0}", num);
//         }

//         public static void MultNum(int q) {
//             num *= q;
//             Console.WriteLine("Named Method: {0}", num);
//         }

//         public static int getNum() {
//             return num;
//         }

//         static void Main(string[] args) {
//             NumberChanger nc = x=>{
//                 Console.WriteLine("Anonymous Method: {0}", x);
//             };

//             nc(10);  

//             nc = new NumberChanger(AddNum);
//             nc(5);

//             nc = new NumberChanger(MultNum);
//             nc(2);   

//             Console.ReadKey();
//         }
//     }
// }
