using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Homework_3_1;

namespace Homework_3_2
{
    public class ShapeFactory
    {
        /*
         *由于程序进程过快生成的随机数有很多重复的
         *查找资料后使用加密服务提供程序 (CSP) 提供的实现来实现加密随机数生成器（RNG）
         */
        static int GetRandomSeed()
        {

            byte[] bytes = new byte[4];

            System.Security.Cryptography.RNGCryptoServiceProvider rng = new System.Security.Cryptography.RNGCryptoServiceProvider(); rng.GetBytes(bytes);

            return BitConverter.ToInt32(bytes, 0);

        }
        public static Shape CreatShape(string shape)
        {
            Random rd = new Random(GetRandomSeed());
            Shape mshape = null;
            switch (shape)
            {
                case "rectangle":
                    do
                    {
                        mshape = new Rectangle(rd.Next(0,20), rd.Next(0, 20));
                    } while (!mshape.IsLegal());
                    return mshape;
                case "square":
                    do
                    {
                        mshape = new Square(rd.Next(0, 20));
                    } while (!mshape.IsLegal());
                    return mshape;
                case "triangle":
                    do
                    {
                        mshape = new Triangle(rd.Next(0, 20), rd.Next(0, 20), rd.Next(0, 20));
                    } while (!mshape.IsLegal());
                    return mshape;
                default:
                    return null;
            }
        }
    }
    class Test
    {
        static void Main(string[] args)
        {
            Shape[] shapes = new Shape[10];
            Random random = new Random();
            for (int i = 0; i < 10; i++)
            {
                switch (random.Next() % 3)
                {
                    case 0:
                        shapes[i]=ShapeFactory.CreatShape("rectangle");
                        break;
                    case 1:
                        shapes[i] = ShapeFactory.CreatShape("square");
                        break;
                    case 2:
                        shapes[i] = ShapeFactory.CreatShape("triangle");
                        break;
                }
            }
            double sumArea = 0;
            for(int i=0;i<shapes.Length;i++){
                shapes[i].Show();
                sumArea += shapes[i].CalculateArea();
            }
            Console.WriteLine($"这些图形的总面积为：{sumArea}");
        }
    }
}
