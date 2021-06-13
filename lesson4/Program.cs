using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;


namespace AlgorithmsHW
{
    class Program
    {
        static void Main(string[] args)
        {
            //задание 1
            //результаты в TestSearch
            //BenchmarkRunner.Run<TestSearch5>();


            //задание 2
            int[] arr = new int[] { 1, 2, 3, 4, 5, 6, 7 };

            TreeNode tree = new TreeNode(arr);
            //tree.SelectNode(); //верно
            

            tree.InsertValue(8);
            //tree.SelectNode(); //верно

            tree.InsertValue(9);
            //tree.SelectNode(); //верно

            tree.RemoveItem(9);
            tree.SelectNode(); //верно


            Console.ReadLine();
        }
        //
    }

    

}
