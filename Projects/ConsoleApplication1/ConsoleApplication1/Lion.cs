using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
	class Lion : Feline
	{
		private int weight;

		public Lion(bool male, int weight) : base(male)
		{
			this.weight = weight;
		}

		public override bool CatchPrey(String prey)
		{
			Console.WriteLine("{0} has been caught!!!", prey);
			return true;
		}
	}
}
