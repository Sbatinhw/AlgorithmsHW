using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

namespace AlgorithmsHW
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 };
            TreeNode test = new TreeNode(arr);

            //Console.WriteLine( test.Bfs(2)?.Value); //корректно
            //Console.WriteLine(test.Bfs(112)?.Value); //корректно

            //Console.WriteLine( test.Dfs(2)?.Value); //корректно
            //Console.WriteLine(test.Dfs(112)?.Value); //корректно

            

            Console.ReadLine();
        }
        
    }


    //
}

