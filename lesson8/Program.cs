using System;
using System.Collections.Generic;

namespace AlgorithmHW
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] test = new int[] { 1, -5, -3, 2, 3 }; //верно

            //test =new int[] { 1, -4, -5, -3, 2, 3 }; //верно

            //test = new int[] { 1, -4, -5}; //верно

            test = RandomArray(15); //верно



            SelectArray(test);
            SelectArray(BuckSort(test));

            Console.ReadLine();
        }

        public static int[] BuckSort(int[] arr)
        {
            int quant = 5; //количество списков
            int min = SearchMin(arr);
            int max = SearchMax(arr);
            int len = max - min;
            int step = 0;

            if (len / quant < 1) { step = 0; }
            else if (len % quant != 0) { step = (len / quant) + 1; }
            else { step = len / quant; }

            List<int> part1 = new List<int>();
            List<int> part2 = new List<int>();
            List<int> part3 = new List<int>();
            List<int> part4 = new List<int>();
            List<int> part5 = new List<int>();

            List<int> EndPart = new List<int>();

            int p1min = min;
            int p1max = p1min + step;
            int p2min = p1max + 1;
            int p2max = p2min + step;
            int p3min = p2max + 1;
            int p3max = p3min + step;
            int p4min = p3max + 1;
            int p4max = p4min + step;
            int p5min = p4max + 1;
            int p5max = p5min + step;

            for(int i = 0; i < arr.Length; i++)
            {
                int val = arr[i];
                if (val >= p1min && val <= p1max) { part1.Add(val); }
                else if (val >= p2min && val <= p2max) { part2.Add(val); }
                else if (val >= p3min && val <= p3max) { part3.Add(val); }
                else if (val >= p4min && val <= p4max) { part4.Add(val); }
                else if (val >= p5min && val <= p5max) { part5.Add(val); }


            }

            if(part1.Count > 1) { EndPart.AddRange(BuckSort(part1.ToArray())); }
            else { EndPart.AddRange(part1); }
            if (part2.Count > 1) { EndPart.AddRange(BuckSort(part2.ToArray())); }
            else { EndPart.AddRange(part2); }
            if (part3.Count > 1) { EndPart.AddRange(BuckSort(part3.ToArray())); }
            else { EndPart.AddRange(part3); }
            if (part4.Count > 1) { EndPart.AddRange(BuckSort(part4.ToArray())); }
            else { EndPart.AddRange(part4); }
            if (part5.Count > 1) { EndPart.AddRange(BuckSort(part5.ToArray())); }
            else { EndPart.AddRange(part5); }


            return EndPart.ToArray();

        }

        public static int[] RandomArray(int maxlen = 20, int min = -10000, int max = 10000)
        {
            Random rand = new Random();
            int[] arr = new int[rand.Next(1, maxlen)];

            for(int i = 0; i < arr.Length; i++)
            {
                arr[i] = rand.Next(min, max);
            }

            return arr;
        }

        public static void SelectArray(int[] arr)
        {
            foreach (int val in arr) 
            {
                Console.Write($"{val} ");
            }
            Console.WriteLine();
        }

        public static int SearchMax(int[] arr)
        {
            int max = arr[0];
            for(int i = 1; i < arr.Length; i++)
            {
                if(arr[i] > max) { max = arr[i]; }
            }
            return max;
        }

        public static int SearchMin(int[] arr)
        {
            int min = arr[0];
            for (int i = 1; i < arr.Length; i++)
            {
                if (arr[i] < min) { min = arr[i]; }
            }
            return min;
        }

        //
    }
}
