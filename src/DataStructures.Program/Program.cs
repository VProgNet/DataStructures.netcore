using System;

using BenchmarkDotNet.Running;

using DataStructures.Lib;

namespace DataStructures.Program
{
    
    class Program
    {
        static void Main(string[] args)
        {
            SimpleList<int> sl = new SimpleList<int>();
            for (int i = 0; i < 100; i++)
            {
                
                sl.PushValue(i);
                Console.WriteLine("Pushing:" + i.ToString());
            }
            
            sl.Shift();
            
            for (int i = 0; i < sl.Length; i++)
            {
                Console.WriteLine($"Element at {i.ToString()} is {sl[i].ToString()}");
            }
            sl.Shift();
            for (int i = sl.Length; i > 0; i--)
            {
                
                Console.WriteLine("Poping:" + sl.PopValue().ToString());
            }

            sl.Shift();
            //BenchmarkRunner.Run<SimpleListBenchmark>();
        }
    }
}