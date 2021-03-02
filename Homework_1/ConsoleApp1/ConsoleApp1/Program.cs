using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("请输入两个数字：");
            double a = Double.Parse(Console.ReadLine());
            double b = Double.Parse(Console.ReadLine());
            Console.WriteLine("请输入要进行的运算：");
            String op = Console.ReadLine();
            double result = 0;
            switch (op)
            {
                case "+":
                    result = a + b;
                    Console.WriteLine($"{a}{op}{b}={result}");
                    break;
                case "-":
                    result = a - b;
                    Console.WriteLine($"{a}{op}{b}={result}");
                    break;
                case "*":
                    result = a * b;
                    Console.WriteLine($"{a}{op}{b}={result}");
                    break;
                case "/":
                    result = a / b;
                    Console.WriteLine($"{a}{op}{b}={result}");
                    break;
                default:Console.WriteLine("输入的运算符非法");
                    break;
            }
            
        }
    }
}
