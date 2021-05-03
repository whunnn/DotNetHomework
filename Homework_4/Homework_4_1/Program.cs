using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_4_1
{
    class Program
    {
        public class Node<T>
        {
            public Node<T> Next { get; set; }
            public T Data { get; set; }
            public Node(T t)
            {
                Next = null;
                Data = t;
            }
        }
        public class GenericList<T>
        {
            private Node<T> head;
            private Node<T> tail;
            public GenericList()
            {
                tail = head = null;
            }
            public Node<T> Head
            {
                get => head;
            }
            public void Add(T t)
            {
                Node<T> n = new Node<T>(t);
                if (tail == null)
                {
                    head = tail = n;
                }
                else
                {
                    tail.Next = n;
                    tail = n;
                }
            }
            public static void ForEach(GenericList<T> genericlist, Action<T> f)
            {
                for (Node<T> node = genericlist.Head; node != null; node = node.Next)
                {
                    f(node.Data);
                }
            }

        }
        static void Main(string[] args)
        {
            GenericList<int> List = new GenericList<int>();
            Random rd = new Random();
            for (int i = 0; i < 10; i++)
            {
                List.Add(rd.Next(1, 50));
            }
            int sum = 0, max = 0, min = int.MaxValue;
            Console.WriteLine("随机产生的十个链表元素为：");
            GenericList<int>.ForEach(List, m => Console.Write($"{m} "));
            Console.WriteLine("");
            GenericList<int>.ForEach(List, m => sum += m);
            GenericList<int>.ForEach(List, m => max = m < max ? max : m);
            GenericList<int>.ForEach(List, m => min = m > min ? min : m);
            Console.WriteLine($"最大值为{max} 最小值为{min} 总和为{sum} 平均值为{sum / 10.0}");
        }
    }
}
