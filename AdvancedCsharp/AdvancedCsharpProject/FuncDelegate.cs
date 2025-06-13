using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace AdvancedFuncDemo
{
    class AdFuncDelegateProgram
    {
        static async Task Main(string[] args)
        {
            // 1. Basic Func
            Func<int, int> square = x => x * x;
            Console.WriteLine("Square of 5 is :" + square(5));
            await Task.Run(() => Console.WriteLine("We are dealing with async function with funcdelegate"));
            Func<int, int> mult = x => x * 5;
            Func<int, int> combined = x => mult(square(x));
            await Task.Run(() => Console.WriteLine("Now final result of combined delegate is " + combined(5)));

            ////////////////////////
            Func<int, int> multiplyBy2 = x => x * 2;
            Func<int, int> add3 = x => x + 3;
            Func<int, int> composed = x => add3(multiplyBy2(x));
            Console.WriteLine($"Composed(4): {composed(4)}"); // (4 * 2) + 3 = 11

            ////////////////////
            // 7. Multi-parameter Func
            Func<int, int, string> sumToString = (a, b) => (a + b).ToString();
            Console.WriteLine($"SumToString(2, 3): {sumToString(2, 3)}");

            Func<Task<string>> AsyncFunc = async () =>
            {
                await Task.Run(() => Console.WriteLine("Now starting async function"));
                return "Hello there.";
            };
            //use it
            await AsyncFunc();
            Console.WriteLine($"Awaited call:{await AsyncFunc()}");

        }

        static T Processor<T>(T value, Func<T, T> process)
        {
            return process(value);
        }


    
      static Func<T, TResult> NewProcessor<T, TResult>(Func<T, TResult> func) where T : notnull
        {
            var cache = new Dictionary<T, TResult>();
            return arg =>
            {
                if (!cache.ContainsKey(arg))
                {
                    cache[arg] = func(arg);
                }
                return cache[arg];
            };


        }
        static void Main()
{
    Func<int, int> myf = x => x * x;
    Func<int, int> UseMem = NewProcessor(myf);

    Console.WriteLine(UseMem(4));  // Output: 16
    Console.WriteLine(UseMem(4));  // Output: 16 (from cache)
}
    }
       
}