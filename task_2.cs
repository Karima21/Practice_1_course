using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace поле_чудес
{
    class Program
    {
		private static int[] a;
		private static int n;
		private static bool check(int s)
		{
			int i = 0;
			while ((a[i] == a[i % s]) && (i < n))
			{
				i++;
			}
			if (i == n)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		static int Main()
		{
			n = int.Parse(ConsoleInput.ReadToWhiteSpace(true));
			a = new int[n];
			for (int i = 0; i < n; ++i)
			{
				a[i] = int.Parse(ConsoleInput.ReadToWhiteSpace(true));
			}
			n--;
			int r = n;
			for (int i = 1; i < n; ++i)
			{
				if ((n % i) == 0)
				{
					if (check(i))
					{
						r = i;
						break;
					}
				}
			}
			Console.Write(r);
			a = null;
			return 0;
		}
		internal static class ConsoleInput
		{
			private static bool goodLastRead = false;
			public static bool LastReadWasGood
			{
				get
				{
					return goodLastRead;
				}
			}

			public static string ReadToWhiteSpace(bool skipLeadingWhiteSpace)
			{
				string input = "";

				char nextChar;
				while (char.IsWhiteSpace(nextChar = (char)System.Console.Read()))
				{
					if (!skipLeadingWhiteSpace)
						input += nextChar;
				}
				input += nextChar;

				while (!char.IsWhiteSpace(nextChar = (char)System.Console.Read()))
				{
					input += nextChar;
				}

				goodLastRead = input.Length > 0;
				return input;
			}

			public static string ScanfRead(string unwantedSequence = null, int maxFieldLength = -1)
			{
				string input = "";

				char nextChar;
				if (unwantedSequence != null)
				{
					nextChar = '\0';
					for (int charIndex = 0; charIndex < unwantedSequence.Length; charIndex++)
					{
						if (char.IsWhiteSpace(unwantedSequence[charIndex]))
						{
							while (char.IsWhiteSpace(nextChar = (char)System.Console.Read()))
							{
							}
						}
						else
						{
							nextChar = (char)System.Console.Read();
							if (nextChar != unwantedSequence[charIndex])
								return null;
						}
					}

					input = nextChar.ToString();
					if (maxFieldLength == 1)
						return input;
				}

				while (!char.IsWhiteSpace(nextChar = (char)System.Console.Read()))
				{
					input += nextChar;
					if (maxFieldLength == input.Length)
						return input;
				}

				return input;
			}
		}

	}
}
