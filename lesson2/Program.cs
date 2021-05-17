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

            int[] testarr = new int[] {0, 1, 2, 3, 4, 5, 7, 8 };
            int test = 8;

            Console.WriteLine (BinarySearch.BinSearch(testarr, test));

            Console.ReadLine();
        }
    }
}
