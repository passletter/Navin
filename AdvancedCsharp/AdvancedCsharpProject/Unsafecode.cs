using System;

namespace UnsafeCodeApplication
{
    class ProgramUnsafe
    {
        public static unsafe void Swap(int* p, int* q)
        {
            int* temp = p;
            *p = *q;
            *q = *temp;

        }
        static unsafe void Main(string[] args)
        {
            int var = 20;
            int* p = &var;

            Console.WriteLine("Data is: {0} ", var);
            Console.WriteLine("Address is: {0}", (int)p);
            int t1 = 10;
            int t2 = 20;
            Swap(&t1, &t2);

            Console.ReadKey();
        }
        static void NewUnsafeMethod()
        {
            unsafe
            {
                int var = 20;
                int* p = &var;

                Console.WriteLine("Data is: {0} ", var);
                Console.WriteLine("Data is: {0} ", p->ToString());
                Console.WriteLine("Address is: {0} ", (int)p);
            }
        }

    }

    class TestFixedPointer
    {
        public static unsafe void Main(string[] args)
        {
            int[] mylist = { 10, 20, 40 };
            fixed (int* p = mylist)
            
                for (int i = 0; i < mylist.Length; i++)
                {
                    Console.WriteLine("Address of mylist[{1}] is {2}. ", i, (int)(p + i));
                    Console.WriteLine("Value of list[{0}]={1}", i, *(p + i));
                }
            
        }
    }
   
   
}