using System;
using System.Diagnostics.CodeAnalysis;

namespace Task3
{
    public class Program
    {
        static void Main(string[] args)
        {
            double a = 0;
            bool check = true;
            do
            {
                Console.WriteLine("Введите действительное число");
                check = double.TryParse(Console.ReadLine(), out a);
                if (!check) Console.WriteLine("Введено неправильное число");
            } while (!check);

            Console.WriteLine(Function(a));
        }
        public static double Function(double a)
        {
            double y;
            double k;
            double b;

            if (a <= 0)
            {
                k = -1;
                b = 0;
            }
            else if (a <= 1)
            {
                k = 1;
                b = 0;
            }
            else if (a < 2)
            {
                k = 0;
                b = 1;
            }
            else
            {
                k = -2;
                b = 5;
            }
            y = k * a + b;

        }
    }

}
