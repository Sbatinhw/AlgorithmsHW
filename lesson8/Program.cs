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

            //test = RandomArray(); //верно

            //test = new int[] { 5, 5 }; //верно

            //test = new int[] { 1, -4, -5, 0, 2, 1 }; //верно

            //test = new int[] { 5, 5, 3, 0 }; //верно



            SelectArray(test);
            SelectArray(BuckSort(test));

            Console.ReadLine();
        }

        public static int[] BuckSort(int[] arr)
        {
            //количество блоков
            int quant = Convert.ToInt32(Math.Sqrt(arr.Length));

            if(quant * quant != arr.Length) { quant += 1; }

            //минимальное значение в массиве
            int min = SearchMin(arr);
            //максимальное значение в массиве
            int max = SearchMax(arr);

            int len = max - min;
            //диапазон для значений блоков
            int step = 0;

            if (len / quant < 1) { step = 0; }
            else if (len % quant != 0) { step = (len / quant) + 1; }
            else { step = len / quant; }

            //список отсортированных элементов
            List<int> EndPart = new List<int>();
            //список блоков
            List<List<int>> list = new List<List<int>>();

            for(int i = 0; i < quant; i++)
            {
                list.Add(new List<int>());
            }

            //перебор и сортировка элементов изначального массива
            for(int i = 0; i < arr.Length; i++)
            {
                int val = arr[i];

                //минимальное значение блока
                int minEdge = min;
                //максимальное значение блока
                int maxEdge = minEdge + step;

                //добавление элемента в блок
                for(int j = 0; j < quant; j++)
                {
                    if(val >= minEdge && val <= maxEdge)
                    {
                        list[j].Add(val);
                        break;
                    }
                    //переход к следующему блоку если не удаётся вставить элемент
                    else
                    {
                        minEdge = maxEdge + 1;
                        maxEdge = minEdge + step - 1;
                        //костыль если массив состоит из одинаковых значений или значения отличаются на единицу
                        if(maxEdge < minEdge)
                        {
                            maxEdge = minEdge;
                        }
                    }
                }
            }

            for(int i = 0; i < quant; i++)
            {
                //блок отправляется в рекурсивную сортировку если состоит больше чем из одного элемента
                //и состоит из не одинаковых значений
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

        public static int[] RandomArray(int min = -10000, int max = 10000)
        {
            Random rand = new Random();
            int[] arr = new int[20];

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
