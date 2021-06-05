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
            {
                int[] testarr = new int[] { 0, 1, 2, 3, 4, 5, 7, 8, 9 };
                int test = 8;
                Console.WriteLine(BinarySearch.BinSearch(testarr, test)); // 7 верно

                test = 0;
                Console.WriteLine(BinarySearch.BinSearch(testarr, test)); // 0 верно

                test = 5;
                Console.WriteLine(BinarySearch.BinSearch(testarr, test)); // 5 верно

                test = 6;
                Console.WriteLine(BinarySearch.BinSearch(testarr, test)); // -1 верно

                test = -10;
                Console.WriteLine(BinarySearch.BinSearch(testarr, test)); // -1 верно
            }


            {
                UseNode testnode = new UseNode { start_node = new Node { Value = 1 } };
                testnode.PrintAllNode(); //1 верно

                testnode.AddNode(2);
                testnode.PrintAllNode();//1 2 верно

                testnode.AddNodeAfter(testnode.start_node, 3);
                testnode.PrintAllNode();//1 3 2 верно

                Node ts1 = testnode.FindNode(1);
                Console.WriteLine($"\n{ts1.Value}\n"); //1 верно

                testnode.RemoveNode(1);
                testnode.PrintAllNode(); //1 2 верно

                testnode.RemoveNode(1);
                testnode.PrintAllNode(); //1 верно

                testnode.AddNode(2);
                testnode.AddNode(3);
                testnode.PrintAllNode();

                testnode.RemoveNode(ts1);
                testnode.PrintAllNode(); //2 3 верно
            }



            Console.ReadLine();
        }
    }
}
