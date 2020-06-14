using System;
using System.Reflection.Metadata.Ecma335;
using System.Security;

namespace task_11
{
    class Program
    {
        static string Shifrovanie(string text, int[] k)
        {
            string str = "";
            while (text.Length >= k.Length)
            {
                string newstr = "";
                string sstr = text.Substring(0, k.Length);
                char[] array = sstr.ToCharArray();
                for (int i = 0; i < k.Length; i++)
                {
                    newstr = newstr + array[k[i]];
                }
                str = str + newstr;
                text = text.Remove(0, k.Length);
            }
            if (text != "")
            {
                int difference = k.Length - text.Length;
                string sstr = text;
                for (int i = 0; i < difference; i++)
                    sstr = sstr + "";
                char[] array = sstr.ToCharArray();
                string newstr = "";
                for (int i = 0; i < k.Length; i++)
                {
                    newstr = newstr + array[k[i]];
                }
                str = str + newstr;

            }
            return str;

        }
        static void Main(string[] args)
        {

        }

        static string deShifr(string text, int[] k)
        {
            string str = "";
            while (text.Length >= k.Length)
            {
                string sstr = text.Substring(0, k.Length);
                char[] array = new char[k.Length];
                for (int i = 0; i < k.Length; i++)
                {
                    array[k[i]] = sstr[i];
                }
                string newstr = new string(array);
                str = str + newstr;
                text = text.Remove(0, k.Length);
            }
            return str;
        }
    }
}   

