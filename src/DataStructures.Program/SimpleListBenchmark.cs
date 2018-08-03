using System;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Columns;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Diagnosers;
using DataStructures.Lib;


namespace DataStructures.Program
{
    [MemoryDiagnoser]
    [Config(typeof(ExampleConfig))]
    public class SimpleListBenchmark
    {
        SimpleList<int> sl1;
        SimpleList<int> sl2;
        SimpleList<int> sl3;
        
        private class ExampleConfig : ManualConfig
        {

            
            public ExampleConfig()
            {                
                Add(StatisticColumn.Max); // Добавляем необходимую колонку      
                Add(MemoryDiagnoser.Default);
            }
        }

        public SimpleListBenchmark()
        {
            sl1 = new SimpleList<int>();
            sl2 = new SimpleList<int>();
            sl3 = new SimpleList<int>();
        }
        
        [Benchmark(Description = "Add100")]
        public int Add100()
        {
            SimpleList<int> sl1 = new SimpleList<int>();
            for (int i = 0; i < 100; i++)
            {
                sl1.PushValue(i);
            }
            return sl1.Length;
        }
        
                
        [Benchmark(Description = "Add10000")]
        public int Add10000()
        {
            SimpleList<int> sl = new SimpleList<int>();
            for (int i = 0; i < 10000; i++)
            {
                sl2.PushValue(i);
            }
            return sl2.Length;
        }
        
                
        [Benchmark(Description = "Add1kk")]
        public int Add1kk()
        {
            SimpleList<int> sl = new SimpleList<int>();
            for (int i = 0; i < 1000000; i++)
            {
                sl3.PushValue(i);
            }
            return sl3.Length;
        }
        
        [Benchmark(Description = "Pos100")]
        public int Pos100()
        {
            for (int i = 0; i < 100; i++)
            {
                int j = sl1[i];
            }
            return sl1.Length;
        }
        
        [Benchmark(Description = "Pos10000")]
        public int Pos10000()
        {
            for (int i = 0; i < 10000; i++)
            {
                int j = sl2[i];
            }
            return sl2.Length;
        }
        
        [Benchmark(Description = "Pos1kk")]
        public int Pos1kk()
        {
            for (int i = 0; i < 1000000; i++)
            {
                int j = sl3[i];
            }
            return sl3.Length;
        }
        
        [Benchmark(Description = "Remove100")]
        public int Remove100()
        {
            for (int i = 0; i < 100; i++)
            {
                int j = sl1.PopValue();
            }
            return sl1.Length;
        }
        
        [Benchmark(Description = "Remove10000")]
        public int Remove10000()
        {
            for (int i = 0; i < 10000; i++)
            {
                int j = sl2.PopValue();
            }
            return sl2.Length;
        }
        
        [Benchmark(Description = "Remove1kk")]
        public int Remove1kk()
        {
            for (int i = 0; i < 1000000; i++)
            {
                int j = sl3.PopValue();
            }
            return sl3.Length;
        }

    }
}