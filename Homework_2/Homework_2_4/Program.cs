using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_2_4
{
    class ToeplitzMatrix
    {
        static void Main(string[] args)
        {
            Console.WriteLine("请输入一个M*N的矩阵：");
            Console.Write("M:");
            int m = int.Parse(Console.ReadLine());
            Console.Write("N:");
            int n = int.Parse(Console.ReadLine());
            int[,] matrix = new int[m, n];
            for (int i = 0; i < m; i++)
            {
                Console.Write($"请输入第{i + 1}行(数值之间用空格隔开)：");
                string s = Console.ReadLine();
                string[] data = s.Split(' ');
                for (int j = 0; j < n; j++)
                {
                    matrix[i, j] = int.Parse(data[j]);
                }
            }
            bool flag = true;
            for (int i = 0; i < m - 1; i++)
            {
                for (int j = 0; j < n - 1; j++)
                {
                    if (matrix[i, j] != matrix[i + 1, j + 1])
                        flag = false;
                }
            }
            if (flag) Console.WriteLine("该矩阵是托普利茨矩阵");
            else Console.WriteLine("该矩阵不是托普利茨矩阵");
        }
    }
}
