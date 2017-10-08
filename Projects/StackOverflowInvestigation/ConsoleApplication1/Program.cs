using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpreadsheetUtilities
{
	class Program
	{
		private static List<Cell> referencedCells;
		private static string hey = "F_";


		static void Main(string[] args)
		{
			Console.WriteLine(ValidateVariableName(hey));
		}

		private bool ValidateVariable(string variable)
		{
			if (Char.IsLetter(variable[0]) || variable[0].Equals('_'))
			{
				if (variable.Length > 1)
				{
					for (int i = 1; i < variable.Length; i++)
					{
						if (!Char.IsLetterOrDigit(variable[i]))
							if (variable[i] != '_')
								throw new FormulaFormatException("Invalid syntax on variable or invalid symbols used.");
					}
					return true;
				}
				else
					return true;
			}
			else
				throw new FormulaFormatException("Invalid syntax on variable or invalid symbols used.");
		}

		private static bool ValidateVariableName(string name)
		{
			if (Char.IsLetter(name[0]) || name[0] == '_')
			{
				if (name.Length > 1)
				{
					for (int i = 1; i < name.Length; i++)
					{
						if (!Char.IsLetterOrDigit(name[i]))
							if (name[i] != '_')
								throw new Exception();
					}
					return true;
				}
				else
					return true;
			}
			else
				throw new Exception();
		}
	}
	

}


