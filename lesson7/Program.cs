using System;

namespace AlgorithmHW
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] field = new int[3, 3];
            int[,] block = CreateBlock(field);

            Calc(field);
            //PrintArr(field); //верно


            //Calc(field, block);
            //PrintArr(field); //верно


            //block[1, 1] = 0;
            //Calc(field, block);
            //PrintArr(field); //верно



            Console.ReadLine();
        }

        public static void PrintArr(int[,] arr)
        {
            int rows = arr.GetUpperBound(0) + 1;
            int columns = arr.Length / rows;

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    Console.Write(arr[i, j].ToString());
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        //создание массива для добавления препятствий
        public static int[,] CreateBlock(int[,] arr)
        {
            int rows = arr.GetUpperBound(0) + 1;
            int columns = arr.Length / rows;
            int[,] block = new int[rows, columns];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    block[i, j] = 1;
                }
            }

            return block;
        }

        //подсчет количества путей
        public static int[,] Calc(int[,] arr, int[,] block = null)
        {
            int rows = arr.GetUpperBound(0) + 1;
            int columns = arr.Length / rows;

            arr[0, 0] = 1;

            //заполнение левой грани единицами
            for (int i = 1; i < rows; i++)
            {
                if (block != null && block[i, 0] == 0)
                { arr[i, 0] = 0; }
                else
                { arr[i, 0] = arr[i - 1, 0]; }
            }

            //заполнение верхней грани единицами
            for (int i = 1; i < columns; i++)
            {
                if (block != null && block[0, i] == 0)
                { arr[0, i] = 0; }
                else
                { arr[0, i] = arr[0, i - 1]; }
            }

            //заполнение остальных элементов
            for (int i = 1; i < rows; i++)
            {
                for (int j = 1; j < columns; j++)
                {
                    if (block != null && block[i, j] == 0)
                    { arr[i, j] = 0; }
                    else
                    { arr[i, j] = arr[i - 1, j] + arr[i, j - 1]; }
                }
            }


            return arr;
        }

        //
    }
}
