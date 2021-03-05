using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Homework_2_1
{
    class CalPrimFactors
    {
        static bool IsPrime(int a)     //判断是否是素数
        {
            int i;
            for (i=2; i*i<=a; i++)
                if (a % i == 0) return false;
            return true;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("输入一个整数即可输出其所有素数因子：");
            int x = 0;
            try
            {
                x = int.Parse(Console.ReadLine());
            }
            catch (Exception)
            {
                Console.WriteLine("输入类型错误");
            }
            for (int a = 2; a <= x; a++) 
            {
                if (x % a == 0 && IsPrime(a))   //因数是素数则打印
                    Console.Write($"{a} ");
            }

        }
    }
}
