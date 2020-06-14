using System;
using System.IO;
using Library1;

namespace task_10
{
    class Program
    {
        static void Main()
        {
            try
            {
                var one = ReadFile("PowerOne.txt", "CoefOne.txt");
                var two = ReadFile("PowerTwo.txt", "CoefTwo.txt");

                var sum = one + two;

                WriteFile("output.txt", sum);
            }
            catch (Exception e)
            {
                WriteEx("output.txt", e);
            }
        }

        static Polinom ReadFile(string pathPow, string pathCoef)
        {
            var readerPow = new StreamReader(pathPow);
            var readerCoef = new StreamReader(pathCoef);

            var curPow = readerPow.ReadLine();
            var curCoef = readerCoef.ReadLine();
            var polynom = new Polinom();

            while (!string.IsNullOrEmpty(curPow) && !string.IsNullOrEmpty(curCoef))
            {
                polynom.Add(new Variable(curCoef, curPow));
                curPow = readerPow.ReadLine();
                curCoef = readerCoef.ReadLine();
            }

            readerPow.Close();
            readerCoef.Close();

            return polynom;
        }
        static void WriteFile(string path, Polinom poly)
        {
            var writer = new StreamWriter(path);
            var root = poly.Root;

            while (root != null)
            {
                writer.WriteLine(root.Power + " " + root.Coefficient);
                root = root.next;
            }

            writer.Close();
        }
        static void WriteEx(string path, Exception e)
        {
            var writer = new StreamWriter(path);
            writer.WriteLine(e.Message);
            writer.Close();
        }
        class Polinom
        {
            public Variable Root { get; set; }
            public Polinom(Variable root)
            {
                Root = root;
            }
            public Polinom()
            {
                Root = null;
            }

            public void Add(Variable variable)
            {
                if (Root == null)
                {
                    Root = variable;
                    return;
                }

                var cur = Root;
                Variable prev = null;

                while (cur != null)
                {
                    if (variable.Power > cur.Power)
                    {
                        variable.next = cur;
                        if (prev != null)
                            prev.next = variable;
                        else
                            Root = variable;
                        break;
                    }
                    else if (variable.Power == cur.Power)
                    {
                        cur.Coefficient += variable.Coefficient;
                        if (cur.Coefficient == 0)
                        {
                            if (prev != null)
                                prev.next = cur.next;
                            else
                                Root = Root.next;
                        }

                        break;
                    }

                    prev = cur;
                    cur = cur.next;
                }
            }

            public static Polinom operator +(Polinom one, Polinom two)
            {
                var answ = new Polinom();
                Transact(one, answ);
                Transact(two, answ);

                return answ;
            }

            public static void Transact(Polinom from, Polinom to)
            {
                var cur = from.Root;
                Variable next = null;
                if (cur != null) next = cur.next;
                to.Add(cur);

                while (next != null)
                {
                    cur = next;
                    next = next.next;
                    to.Add(cur);
                }
            }

            public override string ToString()
            {
                return Root.ToString() + " + ...";
            }
        }

        class Variable
        {
            public int Coefficient { get; set; }
            public int Power { get; set; }
            public Variable next { get; set; }

            public Variable(int coefficient, int power)
            {
                Coefficient = coefficient;
                Power = power;
            }
            public Variable(string coefficient, string power)
            {
                Coefficient = Int32.Parse(coefficient);
                Power = Int32.Parse(power);
            }
            public override string ToString()
            {
                return "(" + Coefficient + "x^" + Power + ")";
            }
        }
    }
}
