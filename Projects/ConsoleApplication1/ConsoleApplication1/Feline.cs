using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
	public abstract class Feline
	{
		private bool male;

		public Feline(bool male)
		{
			this.male = male;
		}

		protected void Hide()
		{

		}

		protected void Run()
		{

		}
		public abstract bool CatchPrey(String Prey);
	}
}
