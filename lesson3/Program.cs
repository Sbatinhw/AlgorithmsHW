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
            //BenchmarkRunner.Run<TestAlg>();

            /*Node testn = new Node { Value = 2 };
            testn.LeftChild = new Node { Value = 3 } ;
            testn.RightChild = new Node { Value = 4 };
            TreeNode.TestSelectAllNode(testn);*/

            int[] testarr = new int[] { 0, 1, 2, 3, 4, 5, 6 };

            //int[] testarr = new int[] { 0 };
            //int[] testarr = new int[] { 0, 1, 3 };

            TreeNode testree = new TreeNode(testarr);
            testree.SelectNode();
            Console.ReadLine();
            //Console.Clear();
            //testree.SelectNode(testree.start_node);


            //testree.RemoveItem(1);

            Node zds = testree.GetNodeByValue(20);
            Console.WriteLine($"tst {zds?.Value}");




            //testree.SelectNode();

            //Console.WriteLine (TreeNode.DeepCulc(testree.start_node));



            Console.ReadLine();
        }
        /*
          Результаты:
        
          | Method |       Mean |     Error |    StdDev |     Median |
          |------- |-----------:|----------:|----------:|-----------:|
          |  test1 | 12.6186 ns | 0.3016 ns | 0.3097 ns | 12.5100 ns |
          |  test2 |  0.0111 ns | 0.0180 ns | 0.0150 ns |  0.0030 ns |
          |  test3 |  0.0141 ns | 0.0144 ns | 0.0134 ns |  0.0126 ns |
          |  test4 |  0.0037 ns | 0.0071 ns | 0.0066 ns |  0.0000 ns | */



        //
    }

    //задание 1
    public class TestAlg
    {
        [Benchmark(Description = "test1")]
        public void test1()
        {
            PointClassFloat point1 = new PointClassFloat { X = 10, Y = 5 };
            PointClassFloat point2 = new PointClassFloat { X = 15, Y = 10 };
            PointClassFloat.PointDistance(point1, point2);
        }

        [Benchmark(Description = "test2")]
        public void test2()
        {
            PointStructFloat point1 = new PointStructFloat { X = 10, Y = 5 };
            PointStructFloat point2 = new PointStructFloat { X = 15, Y = 10 };
            PointStructFloat.PointDistance(point1, point2);
        }

        [Benchmark(Description = "test3")]
        public void test3()
        {
            PointStructDouble point1 = new PointStructDouble { X = 10, Y = 5 };
            PointStructDouble point2 = new PointStructDouble { X = 15, Y = 10 };
            PointStructDouble.PointDistance(point1, point2);
        }

        [Benchmark(Description = "test4")]
        public void test4()
        {
            PointStructFloat point1 = new PointStructFloat { X = 10, Y = 5 };
            PointStructFloat point2 = new PointStructFloat { X = 15, Y = 10 };
            PointStructFloat.PointDistanceNoSqrt(point1, point2);
        }
    }

    public class PointClassFloat
    {
        public float X;
        public float Y;

        public static float PointDistance(PointClassFloat pointOne, PointClassFloat pointTwo)
        {
            float x = pointOne.X - pointTwo.X;
            float y = pointOne.Y - pointTwo.Y;
            return MathF.Sqrt((x * x) + (y * y));
        }

    }

    public struct PointStructFloat
    {
        public float X;
        public float Y;
        public static float PointDistance(PointStructFloat pointOne, PointStructFloat pointTwo)
        {
            float x = pointOne.X - pointTwo.X;
            float y = pointOne.Y - pointTwo.Y;
            return MathF.Sqrt((x * x) + (y * y));
        }
        public static float PointDistanceNoSqrt(PointStructFloat pointOne, PointStructFloat pointTwo)
        {
            float x = pointOne.X - pointTwo.X;
            float y = pointOne.Y - pointTwo.Y;
            return ((x * x) + (y * y));
        }
    }

    public struct PointStructDouble
    {
        public double X;
        public double Y;
        public static double PointDistance(PointStructDouble pointOne, PointStructDouble pointTwo)
        {
            double x = pointOne.X - pointTwo.X;
            double y = pointOne.Y - pointTwo.Y;
            return Math.Sqrt((x * x) + (y * y));
        }
    }

    


    //
}

