
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StupidRegExExample
{
	class Class1
	{
		public static void Main(string[] args)
		{
			Console.WriteLine("Hi");
			Formula testFormula = new Formula("5.0", x => x.ToUpper(), x => true);
			Console.WriteLine(testFormula.Evaluate(x => 0));
			foreach(Console.WriteLine();
		}
	}
}
