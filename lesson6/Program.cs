using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

namespace AlgorithmHW
{
    class Program
    {
        static void Main(string[] args)
        {
            Node n1 = new Node(1);
            Node n2 = new Node(2);
            Node n3 = new Node(3);
            Node n4 = new Node(4);
            Node n5 = new Node(5);
            Node n6 = new Node(6);

            //Node.PrintAllNodeDfs(n1); //корректно
            //Console.WriteLine(Node.Dfs(n1, 4)?.Value); //null == корректно

            Node.AddDoubleEdge(n1, n2, 0);
            Node.AddDoubleEdge(n1, n5, 0);
            Node.AddDoubleEdge(n2, n6, 0);
            Node.AddDoubleEdge(n2, n3, 0);
            Node.AddDoubleEdge(n3, n6, 0);
            Node.AddDoubleEdge(n3, n4, 0);
            Node.AddDoubleEdge(n4, n5, 0);
            Node.AddDoubleEdge(n5, n6, 0);


            //Node.PrintAllNodeDfs(n1); //корректно

            //Console.WriteLine(Node.Dfs(n1, 4).Value); //корректно
            //Console.WriteLine(Node.Dfs(n1, 444)?.Value); //корректно

            //Console.WriteLine(Node.Bfs(n1, 4).Value); //корректно
            //Console.WriteLine(Node.Bfs(n1, 44)?.Value); //корректно








            Console.ReadLine();
        }
        
    }


    //
}

