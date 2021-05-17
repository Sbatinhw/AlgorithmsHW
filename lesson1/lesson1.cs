using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsHW
{
    class lesson1
    {

        /* Требуется реализовать на C# функцию согласно блок-схеме. 
         * Блок-схема описывает алгоритм проверки, простое число или нет. */
        public static bool TaskOne(int number)
        {
            int d = 0;
            int i = 2;
            
            while(i < number)
            {
                if(number % i == 0)
                {
                    d++;
                }
                i++;
            }

            if(d == 0)
            {
                return true; //простое
            } else
            {
                return false;
            }
           
        }

        /* Вычислите асимптотическую сложность функции из примера ниже. */
        public static int StrangeSum(int[] inputArray)
        {
            int sum = 0;
            for (int i = 0; i < inputArray.Length; i++)
            {
                for (int j = 0; j < inputArray.Length; j++)
                {
                    for (int k = 0; k < inputArray.Length; k++)
                    {
                        int y = 0;

                        if (j != 0)
                        {
                            y = k / j;
                        }

                        sum += inputArray[i] + i + k + j + y;
                    }
                }
            }

            return sum;
        }
        /* Асимптоническая сложность функции равна O(N * N * N)*/




        /* Реализуйте функцию вычисления числа Фибоначчи
           Требуется реализовать рекурсивную версию и версию без рекурсии (через цикл). */

        public static int FibonachiRecurse(int num)
        {
            int fib = 0;
            
            if(num == 0)
            {
                return 0;
            } else if(num == 1)
            {
                return 1;
            } else if(num > 1)
            {
                return FibonachiRecurse(num - 1) + FibonachiRecurse(num - 2);
            }

            return 0;
        }

        public static int FibonachiCycle(int num)
        {
            int x = 0;
            int y = 1;
            int z = 0;

            for(int i = 0; i < num; i++)
            {
                z = x;
                x = y;
                y += z;
            }

            return x;
        }



        //
    }
}
