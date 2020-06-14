using System;

namespace task_6
{
    class Program
    {
        static bool IsElBiggerOrEqualsM(double el, double m, int n)
        {
            if (el == m)
            {
                Console.Write(el + "\nN = " + n + "\nКонец последовательности, аN=M\n");
                Console.ReadKey();
                return true;
            }
            if (el > m)
            {
                Console.WriteLine(n == 1 // Если первый элемент больше M, значит последовательность пуста
                    ? "пуста" + "\nN не существует"
                    : "\nN = " + n + "\nКонец последовательности, аN не равно M");
                Console.ReadKey();
                return true;
            }
            Console.Write(el + " ");       // Если элемент меньше М, то печатаем его и идём дальше
            return false;
        }                     // Проверка для начальных элементов

        static void NumericalSequence(double a1, double a2, double a3, double m, int n)
        {
            double a4 = (a1 + a2 + a3) / 2;
            if (a4 == m)
            {
                Console.Write(a4 + "\nN = " + n + "\nКонец последовательности, аN=M");
                return;
            }
            if (a4 > m)
            {
                Console.Write("\nN = " + (n - 1) + "\nКонец последовательности, аN не равно M");
                return;
            }
            Console.Write(a4 + " "); // Если элемент меньше М, то печатаем его и идём дальше
            NumericalSequence(a2, a3, a4, m, n + 1);
        } // Вычисление и вывод числовой последовательности

        static void Main(string[] args)
        {
            Console.Write("Введите а1: "); double a1 = Read.Double();
            Console.Write("Введите а2: "); double a2 = Read.Double();
            Console.Write("Введите а3: "); double a3 = Read.Double();
            Console.Write("Введите М: "); double m = Read.Double();

            Console.Write("Последоватлеьность: ");
            if (IsElBiggerOrEqualsM(a1, m, 1) || IsElBiggerOrEqualsM(a2, m, 2) || IsElBiggerOrEqualsM(a3, m, 3)) return; // Проверка первых элементов по очереди

            NumericalSequence(a1, a2, a3, m, 4);
            Console.ReadKey();
        }                                                 // Чтение переменных, вызов их сравнения с M и после вызов вычисления и вывод последовательности
    }
}
