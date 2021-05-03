using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Homework_2_3
{
    class CalPrime
    {
        public const int MAX=100;
        static void Main(string[] args)
        {

            int[] a = new int[MAX];
            for (int i = 2; i <= MAX; i++)
                a[i-1] = i;
            for(int j=2; j <= MAX; j++)
            {
                for (int i = 2; i <= MAX; i++)
                    if (a[i-1] % j == 0 && a[i-1]!=j) a[i-1] = 0;
            }
            foreach(int num in a)
            {
                if (num != 0)
                    Console.Write($"{num} ");
            }

        }
    }
}
