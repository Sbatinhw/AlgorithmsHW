using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsHW
{
    /* Требуется реализовать класс двусвязного списка и операции вставки, 
     * удаления и поиска элемента в нём в соответствии с интерфейсом.*/
    public class Node
    {
        public int Value { get; set; }
        public Node NextNode { get; set; }
        public Node PrevNode { get; set; }
    }

    //Начальную и конечную ноду нужно хранить в самой реализации интерфейса
    public interface ILinkedList
    {
        int GetCount(); // возвращает количество элементов в списке
        void AddNode(int value);  // добавляет новый элемент списка
        void AddNodeAfter(Node node, int value); // добавляет новый элемент списка после определённого элемента
        void RemoveNode(int index); // удаляет элемент по порядковому номеру
        void RemoveNode(Node node); // удаляет указанный элемент
        Node FindNode(int searchValue); // ищет элемент по его значению
    }

    public class UseNode : ILinkedList
    {
        public Node start_node;
        public void AddNode(int value)
        {
            if(start_node == null) 
            {
                start_node = new Node { Value = value };
            } else
            {
                AddNodeAfter( RetLastNode (start_node), value);
            }

        }

        public void AddNodeAfter(Node node, int value)
        {
            var newNode = new Node { Value = value };
            var newItem = node.NextNode;
            node.NextNode = newNode;
            newNode.NextNode = newItem;
            newNode.PrevNode = node;
        }

        public Node FindNode(int searchValue)
        {
            Node retNode = start_node;
            while (true)
            {
                if(retNode.Value == searchValue)
                {
                    return retNode;
                } else if (retNode.NextNode == null)
                {
                    return null;
                } else
                {
                    retNode = retNode.NextNode;
                }
            }
        }

        public int GetCount()
        {
            Node test = start_node;
            int i = 0;

            while (test != null)
            {
                i++;
                test = test.NextNode;
            }
            return i;
        }

        public void RemoveNode(int index)
        {
            int i = 0;
            Node node = start_node;
            while (true)
            {
                if(i < index) 
                { 
                    i++;
                    node = node.NextNode;
                    continue; 
                }
                Node prev = node.PrevNode;
                Node next = node.NextNode;
                if(prev != null){ prev.NextNode = next; }
                else { start_node = next; }
                if (next != null) { next.PrevNode = prev; }
                else { start_node = prev; }
                //start_node = node;
                break;
            }
        }

        public void RemoveNode(Node node)
        {
            while (true)
            {
                if(start_node == node)
                {
                    Node prev = node.PrevNode;
                    Node next = node.NextNode;
                    if (prev != null) { prev.NextNode = next; }
                    else { start_node = next; }
                    if (next != null) { next.PrevNode = prev; }
                    else { start_node = prev; }
                } 
                else if (start_node.NextNode == null) 
                { 
                    break; 
                } 
                else
                {
                    
                    start_node = start_node.NextNode;
                }
            }
        }

        public static Node RetLastNode(Node node) //возвращает последний элемент
        {
            while (true)
            {
                if(node.NextNode == null) { return node; }
                else { node = node.NextNode; }
            }
        }

        public void PrintAllNode()
        {
            Node node = start_node;
            while (true)
            {
                if (node.PrevNode == null) { break; }
                else { node = node.PrevNode; }
            }

            Console.WriteLine("\n-");

            while (true)
            {
                Console.WriteLine(node.Value); 
                //Console.ReadLine();
                if (node.NextNode == null) { break; }
                else { node = node.NextNode; }
            }

        }

    }

}
