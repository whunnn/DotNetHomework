using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_3_1
{
    public abstract class Shape
    {
        public abstract void Show();
        public abstract double CalculateArea();
        public abstract bool IsLegal();
    }
    public class Rectangle : Shape
    {
        protected double length;
        protected double width;
        public Rectangle(double length,double width)
        {
            this.length = length;
            this.width = width;
            
        }
        public double Length
        {
            get => length;
            set => length = value;
        }
        public double Width
        {
            get => width;
            set => width = value;
        }
        public override void Show()
        {
            Console.WriteLine($"矩形：长为{length} 宽为{width}");
        }
        public override double CalculateArea()
        {
            return width * length;
        }
        public override bool IsLegal()
        {
            return length > 0 && width > 0;

        }
    }
    public class Square : Rectangle
    {
        public Square(double length) : base(length, length)
        {
        }
        public override void Show()
        {
            Console.WriteLine($"正方形：边长为{length}");
        }
    }
    public class Triangle : Shape
    {    
        //三角形的三条边
        private double a;
        private double b;
        private double c;
        public Triangle(double a,double b,double c)
        {
            this.a = a;
            this.b = b;
            this.c = c;
        }
        public override void Show()
        {
            Console.WriteLine($"三角形：三条边分别为{a} {b} {c}"); 
        }
        public override double CalculateArea()
        {
            //海伦公式计算三角形面积
            return ( Math.Sqrt((a + b + c)*(a + b - c)*(a + c - b)*(b + c - a))/4);
        }
        public override bool IsLegal()
        {
            return (a + b > c && a + c > b && b + c > a);
        }
    }
    class Test
    {   //测试图形函数
        public static void TestShape(Shape shape)
        {
            if (shape.IsLegal())
                Console.WriteLine($"该图形合法，且其面积为{shape.CalculateArea()}");
            else Console.WriteLine("此图形不合法");         
        }
        static void Main(string[] args)
        {   //矩形
            Console.WriteLine("实例化一个矩形，请输入其长和宽（中间用空格隔开）：");
            string s = Console.ReadLine();
            string[] data = s.Split(' ');
            double length = double.Parse(data[0]);
            double width = double.Parse(data[1]);
            Rectangle rect = new Rectangle(length, width);
            TestShape(rect);
            //正方形
            Console.WriteLine("实例化一个正方形，请输入其边长：");
            length = double.Parse(Console.ReadLine());
            Square square = new Square(length);
            TestShape(square);
            //三角形
            Console.WriteLine("实例化一个三角形，请输入其三边长（中间用空格隔开）：");
            s = Console.ReadLine();
            data = s.Split(' ');
            double a= double.Parse(data[0]),b=double.Parse(data[1]),c= double.Parse(data[2]);
            Triangle triangle = new Triangle(a, b, c);
            TestShape(triangle);

        }
    }
}
