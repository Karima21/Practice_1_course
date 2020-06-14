using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library_Functions;

namespace Задача_12
{
    class Program
    {

        public class BinaryTree
        {
            public int Value;

            public BinaryTree Left, Right;

            public BinaryTree(int value)
            {
                Value = value;
                Left = null;
                Right = null;
            }

            public BinaryTree()
            {
                Value = 0;
                Left = null;
                Right = null;
            }

            public static int CountComparison = 0;

            public static int CountSwap = 0;

            public static int[] Mas = new int[1000];

            public static int CurrentPostion = 0;

            public static void Add(BinaryTree root, int number)
            {
                BinaryTree shelfRoot = root;

                if (shelfRoot.Value > number)
                {
                    CountComparison++;
                    if (shelfRoot.Left == null)
                    {
                        shelfRoot.Left = new BinaryTree(number);
                        CountSwap++;
                    }
                    else
                    {
                        shelfRoot = shelfRoot.Left;
                        Add(shelfRoot, number);
                    }
                }
                else
                {
                    CountComparison++;
                    if (shelfRoot.Right == null)
                    {
                        shelfRoot.Right = new BinaryTree(number);
                        CountSwap++;
                    }
                    else
                    {
                        shelfRoot = shelfRoot.Right;
                        Add(shelfRoot, number);
                    }
                }
            }

            public static void BinarySort()
            {
                BinaryTree root = new BinaryTree(Mas[0]);
                for (int index = 1; index < Mas.Length; index++)
                {
                    Add(root, Mas[index]);
                }
                TraversalTree(root);
                CurrentPostion = 0;
            }

            public static void TraversalTree(BinaryTree root) // Обход дерева
            {
                if (root != null)
                {
                    TraversalTree(root.Left);
                    Mas[CurrentPostion] = root.Value;
                    CurrentPostion++;
                    CountSwap++;
                    TraversalTree(root.Right);
                }
            }


            public static void Show()
            {
                Console.WriteLine("\n");
                foreach (int element in Mas)
                {
                    Console.Write("{0} ", element);
                }
                Console.WriteLine();
            }

            public static int[] Bucketsort(int[] array, out int comparisions, out int moves)
            {
                moves = comparisions = 0;

                if (array.Length == 1)
                    return array;

                // Поиск элементов с максимальным и минимальным значениями
                int maxNumber = array[0];
                int minNumber = array[0];

                for (int i = 1; i < array.Length; i++)
                {
                    comparisions++;
                    if (array[i] > maxNumber)
                        maxNumber = array[i];

                    comparisions++;
                    if (array[i] < minNumber)
                        minNumber = array[i];
                }

                //Массив карманов
                List<int>[] bucket = new List<int>[maxNumber - minNumber + 1];

                for (int i = 0; i < bucket.Length; i++)
                {
                    bucket[i] = new List<int>();
                }

                // Занесение значений в пакеты
                for (int i = 0; i < array.Length; i++)
                {
                    moves++;
                    bucket[array[i] - minNumber].Add(array[i]);
                }

                // Восстановление элементов в исходный массив
                // из карманов в порядке возрастания значений
                int position = 0;
                for (int i = 0; i < bucket.Length; i++)
                {
                    if (bucket[i].Count > 0)
                    {
                        for (int j = 0; j < bucket[i].Count; j++)
                        {
                            moves++;
                            array[position] = bucket[i][j];
                            position++;
                        }
                    }
                }

                return array;
            }
            public static void Main(string[] args)
            {
                for (int index = 0; index < Mas.Length; index++)
                {
                    Mas[index] = Functions.Rnd.Next(-100, 100);
                }

                Console.WriteLine("\n\tМассив до сортировки:");
                Show();
                Console.WriteLine("\n\tБыстрая сортировка");
                Bucketsort(Mas, Mas.Length, 0, Mas.Length - 1);
                Console.WriteLine("\n\tКол-во сравнений: {0}", CountComparison);
                Console.WriteLine("\n\tКол-во перестановок: {0}", CountSwap);
                Console.WriteLine("\n\tОтсортированный массив: ");
                Show();
                for (int index = 0; index < Mas.Length; index++)
                {
                    Mas[index] = Functions.Rnd.Next(-100, 100);
                }

                Console.WriteLine("\n\tМассив до сортировки:");
                Show();
                Console.WriteLine("\n\tДвоичное дерево");
                BinarySort();
                Console.WriteLine("\n\tКол-во сравнений: {0}", CountComparison);
                Console.WriteLine("\n\tКол-во перестановок: {0}", CountSwap);
                Console.WriteLine("\n\tОтсортированный массив: ");
                Show();
                for (int index = 0; index < Mas.Length; index++)
                {
                    Mas[index] = index + 1;
                }

                Console.WriteLine("\n\tМассив до сортировки:");
                Show();
                Console.WriteLine("\n\tБыстрая сортировка");
                Bucketsort(Mas, Mas.Length, 0, Mas.Length - 1);
                Console.WriteLine("\n\tКол-во сравнений: {0}", CountComparison);
                Console.WriteLine("\n\tКол-во перестановок: {0}", CountSwap);
                Console.WriteLine("\n\tОтсортированный массив: ");
                Show();
                for (int index = 0; index < Mas.Length; index++)
                {
                    Mas[index] = index + 1;
                }

                Console.WriteLine("\n\tМассив до сортировки:");
                Show();
                Console.WriteLine("\n\tДвоичное дерево");
                BinarySort();
                Console.WriteLine("\n\tКол-во сравнений: {0}", CountComparison);
                Console.WriteLine("\n\tКол-во перестановок: {0}", CountSwap);
                Console.WriteLine("\n\tОтсортированный массив: ");
                Show();
                for (int index = 0; index < Mas.Length; index++)
                {
                    Mas[index] = Mas.Length - index;
                }

                Console.WriteLine("\n\tМассив до сортировки:");
                Show();
                Console.WriteLine("\n\tБыстрая сортировка");
                Bucketsort(Mas, Mas.Length, 0, Mas.Length - 1);
                Console.WriteLine("\n\tКол-во сравнений: {0}", CountComparison);
                Console.WriteLine("\n\tКол-во перестановок: {0}", CountSwap);
                Console.WriteLine("\n\tОтсортированный массив: ");
                Show();
                for (int index = 0; index < Mas.Length; index++)
                {
                    Mas[index] = Mas.Length - index;
                }

                Console.WriteLine("\n\tМассив до сортировки:");
                Show();
                Console.WriteLine("\n\tДвоичное дерево");
                BinarySort();
                Console.WriteLine("\n\tКол-во сравнений: {0}", CountComparison);
                Console.WriteLine("\n\tКол-во перестановок: {0}", CountSwap);
                Console.WriteLine("\n\tОтсортированный массив: ");
                Show();
                Console.WriteLine("\n\tДля завершения работы нажмите на любую клавишу . . .");
                Console.ReadKey();

            }
        }
    }
}
