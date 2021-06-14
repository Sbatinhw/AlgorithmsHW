using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmHW
{
    public class Node //Вершина
    {
        public int Value { get; set; }
        public List<Edge> Edges { get; set; } //исходящие связи

        public Node(int value)
        {
            Value = value;
            Edges = new List<Edge>();
        }

        

        public static void AddDoubleEdge(Node node1, Node node2, int weight)
        {
            node1.AddEdge(node2, weight);
            node2.AddEdge(node1, weight);
        }

        public void AddEdge(Node node, int weight)
        {
            Edges.Add(new Edge { Node = node, Weight = weight });
        }

        /// <summary>
        /// поиск в ширину
        /// </summary>
        /// <param name="node">граф в котором производится поиск</param>
        /// <param name="value">искомое значение</param>
        /// <returns>нода значение которой равно искомому \ null если значение не найдено</returns>
        public static Node Bfs(Node node, int value)
        {
            Queue<Node> queue = new Queue<Node>();
            
            //список уже провереных элементов
            List<Node> list = new List<Node>();

            queue.Enqueue(node);

            while (true)
            {
                //выход из цикла если очередь пуста
                if(!queue.TryDequeue(out Node result)) { break; }

                //отображение текущего шага
                result.PrintNode();

                //возврат элемента если его значение совпадает
                if(result.Value == value) { return result; }

                //добавление проверенного элемента в список уже проверенных
                list.Add(result);

                //перебор массива с путями
                for (int i = 0; i < result.Edges.Count; i++)
                {
                    //проверка что элементов из массива с путями нет 
                    //в списке уже проверенных и очереди
                    if (!queue.Contains(result.Edges[i].Node) && list.IndexOf(result.Edges[i].Node) == -1)
                    {
                        //добавление следующего элемента в очередь
                        queue.Enqueue(result.Edges[i].Node);
                    }
                }

            }
            //если элемент не найден возвращаем null
            return null;
        }

        /// <summary>
        /// поиск в глубину
        /// </summary>
        /// <param name="node">граф в котором производится поиск</param>
        /// <param name="value">искомое значение</param>
        /// <returns>нода значение которой равно искомому \ null если значение не найдено</returns>
        public static Node Dfs(Node node, int value)
        {
            //список уже провереных элементов
            List<Node> list = new List<Node>();

            //стек элементов для проверки
            Stack<Node> stack = new Stack<Node>();

            //добавление корня в стек
            stack.Push(node);

            while (true)
            {
                //выход из цикла если очередь пуста 
                if (!stack.TryPop(out Node result)) { break; }

                //отображение текущего шага 
                result.PrintNode();

                //выход из цикла если найдено нужное значение
                if(result.Value == value) { return result; }

                //добавление в список проверенных элементов
                list.Add(result);

                //перебор списка путей
                foreach(Edge way in result.Edges)
                {
                    //проверка что элемент из списка путей
                    //не проверялся и не находится в стеке на проверку
                    if(!stack.Contains(way.Node) && !list.Contains(way.Node))
                    {
                        //добавление в стек
                        stack.Push(way.Node);
                    }
                }
            }
            //возвращает null если все элементы проверены и значение не найдено
            return null;
        }

        public static void PrintAllNodeDfs(Node node)
        {
            List<Node> list = new List<Node>();
            Stack<Node> stack = new Stack<Node>();
            stack.Push(node);
            while (true)
            {
                if (!stack.TryPop(out Node result)) { break; }
                result.PrintNode();
                list.Add(result);

                for (int i = 0; i < result?.Edges?.Count; i++)
                {
                    if (!stack.Contains(result.Edges[i].Node) && list.IndexOf(result.Edges[i].Node) == -1)
                    {
                        stack.Push(result.Edges[i].Node);
                    }
                }
            }
        }

        

        public void PrintNode()
        {
            Console.WriteLine($"\nЗначение: {Value}");
            for (int i = 0; i < Edges?.Count; i++)
            {
                Console.WriteLine($"Ребро: {Edges[i].Node.Value} Вес: {Edges[i].Weight}");
            }
            Console.WriteLine("");
        }

        

        public override bool Equals(object obj)
        {
            var node = obj as Node;

            if (node == null) { return false; }
            return Value == node.Value && Edges == node.Edges;
        }

    }

    public class Edge //Ребро
    {
        public int Weight { get; set; } //вес связи
        public Node Node { get; set; } // узел, на который связь ссылается
    }
}
