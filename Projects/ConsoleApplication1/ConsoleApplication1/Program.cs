using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;

namespace ConsoleApplication1
{
	class Program
	{
		static List<String> words, accepted, rejected;
		static List<Feline> cats;

		static void Main(string[] args)
		{
			words = new List<String>();
			accepted = new List<String>();
			rejected = new List<String>();
			cats = new List<Feline>();

			words.Add(Console.ReadLine());
			words.Add(Console.ReadLine());
			words.Add(Console.ReadLine());
			words.Add(Console.ReadLine());

			foreach (String word in words)
			{
				char[] a = word.ToCharArray();
				Array.Sort(a);
				String sorted = new String(a);
				if (accepted.Contains(sorted))
				{
					accepted.Remove(sorted);
					rejected.Add(sorted);
				}
				else if (!rejected.Contains(sorted))
					accepted.Add(sorted);
			}

			Console.WriteLine(accepted.Count);


			//if (two == 2)
				//Console.WriteLine("good");
			//else
				//Console.WriteLine("bad");
			Feline lion = new Lion(true, 200);
			Feline tiger = new Tiger(false);

			cats.Add(lion);
			cats.Add(tiger);

			foreach (Feline cat in cats)
				cat.CatchPrey("Mouse");
		}

	}
}
