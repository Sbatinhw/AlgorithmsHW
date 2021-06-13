using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsHW
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(lesson1.FibonachiRecurse(10));
            Console.WriteLine(lesson1.FibonachiCycle(10));
            //ожидание: 55 получено: 55 результат: верно
            Console.WriteLine(lesson1.FibonachiRecurse(6));
            Console.WriteLine(lesson1.FibonachiCycle(6));
            //ожидание: 8 получено: 8 результат: верно
            Console.WriteLine(lesson1.FibonachiRecurse(12));
            Console.WriteLine(lesson1.FibonachiCycle(12));
            //ожидание: 144 получено: 144 результат: верно
            Console.WriteLine(lesson1.FibonachiRecurse(-1));
            Console.WriteLine(lesson1.FibonachiCycle(-1));
            //ожидание: 0 получено: 0 результат: верно
            Console.WriteLine(lesson1.FibonachiRecurse(0));
            Console.WriteLine(lesson1.FibonachiCycle(0));
            //ожидание: 0 получено: 0 результат: верно




            Console.ReadLine();
        }
    }

    class lesson1
    {

        /* Требуется реализовать на C# функцию согласно блок-схеме. 
         * Блок-схема описывает алгоритм проверки, простое число или нет. */
        public static bool isPrime(int n)
        {
            int d = 0;
            int i = 2;

            while (i < n)
            {
                if (n % i == 0)
                {
                    d++;
                }
                i++;
            }

            if (d == 0)
            {
                return true; 
            }
            else
            {
                return false;
            }

        }

        /* Вычислите асимптотическую сложность функции из примера ниже. */
        public static int StrangeSum(int[] inputArray)
        {
            int sum = 0; //сложность О(1)
            for (int i = 0; i < inputArray.Length; i++) //сложность становится О(N)
            {
                for (int j = 0; j < inputArray.Length; j++) //сложность становится О(N^2)
                {
                    for (int k = 0; k < inputArray.Length; k++) //сложность становится О(N^3)
                    {
                        int y = 0; //сложность О(1)

                        if (j != 0) //сложность О(1)
                        {
                            y = k / j; //сложность О(1)
                        }

                        sum += inputArray[i] + i + k + j + y; //сложность О(1)
                    }
                }
            }

            return sum;
        }
        /* Асимптоническая сложность функции равна O(N^3) т.к. элементами О(1) можно пренебречь */




        /* Реализуйте функцию вычисления числа Фибоначчи
           Требуется реализовать рекурсивную версию и версию без рекурсии (через цикл). */

        public static int FibonachiRecurse(int num)
        {
            int fib = 0;

            if(num < 0)
            {
                throw new ArgumentOutOfRangeException("Аргумент должен быть неотрицательным.", num.ToString());
            }

            if (num == 0)
            {
                return 0;
            }
            else if (num == 1)
            {
                return 1;
            }
            else if (num > 1)
            {
                return FibonachiRecurse(num - 1) + FibonachiRecurse(num - 2);
            }

            return 0;
        }

        public static int FibonachiCycle(int num)
        {
            int result = 0;
            int n1 = 1;
            int n2 = 0;

            for (int i = 0; i < num; i++)
            {
                n2 = result;
                result = n1;
                n1 += n2;
            }

            return result;
        }



        //
    }

}
