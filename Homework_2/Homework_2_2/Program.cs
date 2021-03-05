using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_2_2
{
    class ArrayCal
    {
        static void Main(string[] args)
        {
            Console.WriteLine("请输入数组元素个数：");
            int[] a;
            int min = int.MaxValue, max=0,sum=0 ;
            int length = int.Parse(Console.ReadLine());
            a = new int[length];
            for (int i = 0; i < length; i++)
                a[i] = int.Parse(Console.ReadLine());
            foreach(int i in a)
            {
                if (i > max) max = i;
                if (i < min) min = i;
                sum += i;
            }
            Console.WriteLine($"该数组的最小值为：{min} 最大值为：{max} 总和为：{sum} 平均值为：{(double)sum / length}");

        }
    }
}
