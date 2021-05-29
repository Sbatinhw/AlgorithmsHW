using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;



namespace AlgorithmsHW
{
    public class TestSearch
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
