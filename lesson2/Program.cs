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

            //int[] testarr = new int[] {0, 1, 2, 3, 4, 5, 7, 8 };
            //int test = 8;
            //Console.WriteLine (BinarySearch.BinSearch(testarr, test));

            Node testNode = new Node { Value = 1 };
            testNode.NextNode = new Node { Value = 2 };

            UseNode.PrintAllNode(testNode);

            UseNode testUse = new UseNode { start_node = testNode };
            testUse.AddNode(3);
            UseNode.PrintAllNode(testUse.start_node); //1 2 3


            Console.ReadLine();
        }
    }
}
