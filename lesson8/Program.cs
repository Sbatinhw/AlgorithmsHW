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

            //test = RandomArray(15); //верно

            //test = new int[] { 5, 5 }; //верно

            //test = new int[] { 1, -4, -5, 0, 2, 1 }; //верно



            SelectArray(test);
            SelectArray(BuckSort(test));

            Console.ReadLine();
        }

        public static int[] BuckSort(int[] arr)
        {
            //
            Console.WriteLine("tst");
            Console.ReadLine();
            //
            int quant = Convert.ToInt32(Math.Sqrt(arr.Length));

            if(quant * quant != arr.Length) { quant += 1; }

            int min = SearchMin(arr);
            int max = SearchMax(arr);
            int len = max - min;
            int step = 0;

            if (len / quant < 1) { step = 0; }
            else if (len % quant != 0) { step = (len / quant) + 1; }
            else { step = len / quant; }

            List<int> EndPart = new List<int>();
            List<List<int>> list = new List<List<int>>();

            for(int i = 0; i < quant; i++)
            {
                list.Add(new List<int>());
            }

            for(int i = 0; i < arr.Length; i++)
            {
                int val = arr[i];
                int minEdge = min;
                int maxEdge = minEdge + step;

                for(int j = 0; j < quant; j++)
                {
                    if(val >= minEdge && val <= maxEdge)
                    {
                        list[j].Add(val);
                        break;
                    }
                    else
                    {
                        minEdge = maxEdge + 1;
                        maxEdge = minEdge + step - 1;

                        if(maxEdge < minEdge)
                        {
                            maxEdge = minEdge;
                        }
                    }
                }
            }

            for(int i = 0; i < quant; i++)
            {
                if(list[i].Count > 1 && step != 0) 
                { 
                    EndPart.AddRange(BuckSort(list[i].ToArray())); 
                }
                else
                {
                    EndPart.AddRange(list[i]);
                }
            }

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
