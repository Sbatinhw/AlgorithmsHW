using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//
namespace AlgorithmsHW
{
    class Node
    {
        public int Value { get; set; }
        public Node LeftChild { get; set; }
        public Node RightChild { get; set; }
    }
    class TreeNode
    {
        public Node start_node = null;


        public TreeNode(int value)
        {
            start_node = new Node { Value = value };
        }
        public TreeNode(int[] array)
        {
            start_node = GenerateNode(array);
        }

        public static Node GenerateNode(int[] arr)
        {
            int low = 0;
            int top = arr.Length - 1;
            Node node = new Node();
            if (low > top) { node = null; }
            else
            {
                int mid = (low + top) / 2;
                node.Value = arr[mid];
                node.LeftChild = GenerateNode(GenerateArr(low, mid - 1, arr));
                node.RightChild = GenerateNode(GenerateArr(mid + 1, top, arr));

            }
            return node;
        }

        public static int[] GenerateArr(int low, int top, int[] arr)
        {
            int[] newarr = new int[top - low + 1];
            for (int i = 0; i < newarr.Length; i++)
            {
                newarr[i] = arr[i + low];
            }
            return newarr;
        }

        

        public void SelectNode()
        {
            SelectNode(start_node);
        }

        public static void SelectOneNode(Node node)
        {
            Console.WriteLine($"Левая:    {node?.LeftChild?.Value}");
            Console.WriteLine($"Значение: {node?.Value}");
            Console.WriteLine($"Правая:   {node?.RightChild?.Value}\n");
        }

        public void SelectNode(Node node, int rowlen = 0)
        {
            int len = rowlen + 11 + CalcLenRow(node);
            if (node.LeftChild != null) { SelectNode(node.LeftChild, len); }

            StringBuilder space = new StringBuilder();


            for (int i = 0; i < len; i++)
            {
                space.Append(" ");
            }

            Console.WriteLine($"{space}Левая:    {node?.LeftChild?.Value}");
            Console.WriteLine($"{space}Значение: {node?.Value}");
            Console.WriteLine($"{space}Правая:   {node?.RightChild?.Value}");

            if (node.RightChild != null) { SelectNode(node.RightChild, len); }

        }

        public static int CalcLenRow(Node node)
        {
            int max = 0;
            if (node.LeftChild != null) { max = node.LeftChild.Value.ToString().Length; }
            if (node.RightChild != null && node.RightChild.Value.ToString().Length > max)
            { max = node.RightChild.Value.ToString().Length; }
            if (node.Value.ToString().Length > max)
            { max = node.Value.ToString().Length; }
            return max;
        }

        /// <summary>
        /// поиск в глубину
        /// </summary>
        /// <param name="Value"></param>
        /// <returns></returns>
        public Node Dfs(int Value)
        {
            Stack<Node> stack = new Stack<Node>();
            stack.Push(start_node);

            while (true)
            {
                if(!stack.TryPop(out Node result))
                {
                    Console.WriteLine("Значение не найдено или дерево пустое");
                    break;
                }
                //
                SelectOneNode(result);
                Console.ReadLine();
                //
                if (result.Value == Value)
                {
                    return result;
                }
                if (result.LeftChild != null) { stack.Push(result.LeftChild); }
                if (result.RightChild != null) { stack.Push(result.RightChild); }
            }

            return null;
        }

        /// <summary>
        /// поиск в ширину
        /// </summary>
        /// <param name="Value"></param>
        /// <returns></returns>
        public Node Bfs(int Value)
        {
            Queue<Node> queue = new Queue<Node>();
            queue.Enqueue(start_node);
            while(true)
            {
                if(!queue.TryDequeue(out Node result)) 
                {
                    Console.WriteLine("Значение не найдено или дерево пустое");                   
                    break; 
                }
                //
                SelectOneNode(result);
                Console.ReadLine();
                //
                if(result.Value == Value)
                {
                    return result;
                }
                if(result.LeftChild != null) { queue.Enqueue(result.LeftChild); }
                if(result.RightChild != null) { queue.Enqueue(result.RightChild); }
            }
            return null;
        }

        public void RemoveItem(int value)
        {

            if (start_node.Value == value)
            {
                Node node = start_node;
                start_node = null;
                if (node.LeftChild != null) { InsertValue(node.LeftChild); }
                if (node.RightChild != null) { InsertValue(node.RightChild); }
                return;
            }
            Node prev = start_node;

            Node current = start_node;
            while (true)
            {
                //
                SelectOneNode(prev);
                SelectOneNode(current);
                Console.ReadLine();

                //
                if (current.Value == value)
                {
                    Node left = current.LeftChild;
                    Node right = current.RightChild;
                    //current = null;
                    if (prev?.LeftChild?.Value == value)
                    {
                        prev.LeftChild = null;
                    }
                    else if (prev?.RightChild?.Value == value)
                    {
                        prev.RightChild = null;
                    }
                    if (left != null) { InsertValue(left); }
                    if (right != null) { InsertValue(right); }
                    break;
                }
                else if (current.Value > value)
                {
                    if (current.LeftChild != null)
                    {
                        prev = current;
                        current = current.LeftChild;
                        continue;
                    }
                    else
                    {

                        Console.WriteLine("notfound");
                        Console.ReadLine();
                        break;
                    }
                }
                else if (current.Value < value)
                {
                    if (current.RightChild != null)
                    {
                        prev = current;
                        current = current.RightChild;
                        continue;
                    }
                    else
                    {
                        Console.WriteLine("notfound");
                        Console.ReadLine();
                        break;
                    }
                }
            }
        }

        public Node GetNodeByValue(int value)
        {
            Node node = start_node;
            Node result = null;
            while (true)
            {
                if (node.Value == value)
                {
                    result = node;
                    break;
                }
                else if (node.Value > value)
                {
                    if (node.LeftChild == null) { break; }
                    node = node.LeftChild;
                }
                else if (node.Value < value)
                {
                    if (node.RightChild == null) { break; }
                    node = node.RightChild;
                }



            }
            return result;
        }


        public void InsertValue(int value)
        {
            Node add_node = new Node { Value = value };
            InsertValue(add_node);
        }

        public void InsertValue(Node insert_node)
        {
            Node node = start_node;
            if (start_node == null)
            {
                start_node = insert_node;
                return;
            }
            while (true)
            {
                if (insert_node.Value > node.Value)
                {
                    if (node.RightChild == null)
                    {
                        node.RightChild = insert_node;
                        break;
                    }
                    else
                    {
                        node = node.RightChild;
                        continue;
                    }
                }
                else if (insert_node.Value < node.Value)
                {
                    if (node.LeftChild == null)
                    {
                        node.LeftChild = insert_node;
                        break;
                    }
                    else
                    {
                        node = node.LeftChild;
                        continue;
                    }
                }
                else //добавляемое значение уже есть в дереве
                {
                    Console.WriteLine("Значение уже есть в дереве.");
                    break;
                }

            }
        }

        public static int DeepCulc(Node node, int len = 0)
        {
            if (node == null)
            { return 0; }
            if (node.LeftChild == null && node.RightChild == null) { return len + 1; }
            int right = 0;
            int left = 0;

            if (node.RightChild != null)
            { right = DeepCulc(node.RightChild, len + 1); }
            if (node.LeftChild != null)
            { left = DeepCulc(node.LeftChild, len + 1); }
            if (right > left)
            {
                return right;
            }
            else
            {
                return left;
            }

        }


    }
}

