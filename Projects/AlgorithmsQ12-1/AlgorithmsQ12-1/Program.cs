using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsQ12_1
{
	class Program
	{
		static void Main(string[] args)
		{
			String s = "AABCDACBBADDABDDG";
			HashSet<String> dict = new HashSet<String>(new String[] {"A", "AABC", "AA", "CDA", "D", "ACBB", "AD", "AB", "DD", "G"});

			if (Decompose(s, dict) != null)
				Console.WriteLine(s == String.Join("", Decompose(s, dict)));
			else
				Console.WriteLine("Couldn't find match!");
		}

		public static List<String> Decompose(String s, HashSet<String> dictionary)
		{
			List<String> st = new List<String>(new String[] { s });
			List<String> sub = new List<String>();

			if (dictionary.Contains(s))
				return st;

			String temp = s;
			while(temp.Length > 0)
			{
				temp = temp.Substring(0, temp.Length - 1);
				if (dictionary.Contains(temp))
				{
					sub = Decompose(s.Substring(temp.Length, s.Length - temp.Length), dictionary);
					if (sub != null)
					{
						st.Concat(sub);
						return st;
					}
				}
			}
			return null;
		}
	}
}
