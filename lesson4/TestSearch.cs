using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;



namespace AlgorithmsHW
{

    public class TestSearch1
    {
        [Benchmark(Description = "поиск в массиве")]
        public void SearchInArray()
        {
            ArrTest test = new ArrTest();
            test.SearchValue(10);
        }
        [Benchmark(Description = "поиск в HashSet")]
        public void SearchInHashSet()
        {
            HashTest test = new HashTest();
            test.SearchValue(10);
        }
        /*
         Результаты теста:
         |            Method |     Mean |   Error |  StdDev |
         |------------------ |---------:|--------:|--------:|
         | 'поиск в массиве' | 314.0 us | 3.51 us | 3.11 us |
         | 'поиск в HashSet' | 547.8 us | 5.95 us | 5.27 us |
        */
    }

    public class TestSearch2
    {
        [Benchmark(Description = "поиск в массиве")]
        public void SearchInArray()
        {
            ArrTest test = new ArrTest();
            test.SearchValue(20);
        }
        [Benchmark(Description = "поиск в HashSet")]
        public void SearchInHashSet()
        {
            HashTest test = new HashTest();
            test.SearchValue(20);
        }
        /*
         Результаты теста:
        |            Method |     Mean |    Error |   StdDev |
        |------------------ |---------:|---------:|---------:|
        | 'поиск в массиве' | 316.9 us |  5.17 us |  4.84 us |
        | 'поиск в HashSet' | 554.2 us | 10.80 us | 11.56 us |
        */
    }

    public class TestSearch3
    {
        [Benchmark(Description = "поиск в массиве")]
        public void SearchInArray()
        {
            ArrTest test = new ArrTest();
            test.SearchValue(-100);
        }
        [Benchmark(Description = "поиск в HashSet")]
        public void SearchInHashSet()
        {
            HashTest test = new HashTest();
            test.SearchValue(-100);
        }
        /*
         Результаты теста:
        |            Method |     Mean |   Error |  StdDev |
        |------------------ |---------:|--------:|--------:|
        | 'поиск в массиве' | 294.9 us | 4.47 us | 3.96 us |
        | 'поиск в HashSet' | 553.4 us | 7.97 us | 7.46 us |
        */
    }

    public class TestSearch4
    {
        [Benchmark(Description = "поиск в массиве")]
        public void SearchInArray()
        {
            ArrTest test = new ArrTest();
            test.SearchValue(0);
        }
        [Benchmark(Description = "поиск в HashSet")]
        public void SearchInHashSet()
        {
            HashTest test = new HashTest();
            test.SearchValue(0);
        }
        /*
         Результаты теста:
        |            Method |     Mean |    Error |   StdDev |
        |------------------ |---------:|---------:|---------:|
        | 'поиск в массиве' | 294.3 us |  3.00 us |  2.66 us |
        | 'поиск в HashSet' | 548.5 us | 10.53 us | 10.35 us |
        */
    }

    public class TestSearch5
    {
        static Random rnd = new Random();
        static int num = rnd.Next(-100, 100);
        [Benchmark(Description = "поиск в массиве")]
        public void SearchInArray()
        {
            ArrTest test = new ArrTest();
            test.SearchValue(num);
        }
        [Benchmark(Description = "поиск в HashSet")]
        public void SearchInHashSet()
        {
            HashTest test = new HashTest();
            test.SearchValue(num);
        }
        /*
         Результаты теста:
        |            Method |     Mean |   Error |  StdDev |
        |------------------ |---------:|--------:|--------:|
        | 'поиск в массиве' | 293.1 us | 3.04 us | 2.70 us |
        | 'поиск в HashSet' | 569.8 us | 6.00 us | 5.01 us |
        */
    }

    public class ArrTest
    {
        int[] ArrTab = new int[10000];
        public ArrTest()
        {
            Random rnd = new Random();
            for (int i = 0; i < ArrTab.Length; i++)
            {
                ArrTab[i] = rnd.Next(-100, 100);
            }
        }
        public bool SearchValue(int val)
        {
            int index = Array.IndexOf(ArrTab, val);
            if (index == -1) { return false; }
            return true;
        }

    }

    public class HashTest
    {
        HashSet<int> HashTab = new HashSet<int>();
        int hashlen = 10000;
        public HashTest()
        {
            Random rnd = new Random();
            for (int i = 0; i < hashlen; i++)
            {
                HashTab.Add( rnd.Next(-100, 100));
            }
        }

        public bool SearchValue(int val)
        {
            return HashTab.Contains(val);
        }


    }

}
