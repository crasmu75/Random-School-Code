using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
	class Tiger : Feline
	{
		public Tiger(bool male) : base(male){}

		public override bool CatchPrey(String prey)
		{
			Console.WriteLine("{0} got away.. :(", prey);
			return false;
		}
	}
}
