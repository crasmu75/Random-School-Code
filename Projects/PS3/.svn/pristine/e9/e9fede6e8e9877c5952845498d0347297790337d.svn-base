// Skeleton written by Joe Zachary for CS 3500, September 2013
// Read the entire skeleton carefully and completely before you
// do anything else!

// Version 1.1 (9/22/13 11:45 a.m.)

// Change log:
//  (Version 1.1) Repaired mistake in GetTokens
//  (Version 1.1) Changed specification of second constructor to
//                clarify description of how validation works
//
// Skeleton completed and implemented by Camille Rasmussen for 
// PS3 in CS 3500 September 26, 2014
// UID: u0717763

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace SpreadsheetUtilities
{
    /// <summary>
    /// Represents formulas written in standard infix notation using standard precedence
    /// rules.  The allowed symbols are non-negative numbers written using double-precision 
    /// floating-point syntax; variables that consist of a letter or underscore followed by 
    /// zero or more letters, underscores, or digits; parentheses; and the four operator 
    /// symbols +, -, *, and /.  
    /// 
    /// Spaces are significant only insofar that they delimit tokens.  For example, "xy" is
    /// a single variable, "x y" consists of two variables "x" and y; "x23" is a single variable; 
    /// and "x 23" consists of a variable "x" and a number "23".
    /// 
    /// Associated with every formula are two delegates:  a normalizer and a validator.  The
    /// normalizer is used to convert variables into a canonical form, and the validator is used
    /// to add extra restrictions on the validity of a variable (beyond the standard requirement 
    /// that it consist of a letter or underscore followed by zero or more letters, underscores,
    /// or digits.)  Their use is described in detail in the constructor and method comments.
    /// </summary>
    public class Formula
    {
        private string formula;
		private IEnumerable<string> tokens;

		private static Stack<double> values;
		private static Stack<string> operators;
        
        /// <summary>
        /// Creates a Formula from a string that consists of an infix expression written as
        /// described in the class comment.  If the expression is syntactically invalid,
        /// throws a FormulaFormatException with an explanatory Message.
        /// 
        /// The associated normalizer is the identity function, and the associated validator
        /// maps every string to true.  
        /// </summary>
        public Formula(String formula) :
            this(formula, s => s, s => true)
        {
			this.formula = formula;
			this.tokens = GetTokens(this.formula);
			this.ValidateExpression(s => s, s => true);
        }

        /// <summary>
        /// Creates a Formula from a string that consists of an infix expression written as
        /// described in the class comment.  If the expression is syntactically incorrect,
        /// throws a FormulaFormatException with an explanatory Message.
        /// 
        /// The associated normalizer and validator are the second and third parameters,
        /// respectively.  
        /// 
        /// If the formula contains a variable v such that normalize(v) is not a legal variable, 
        /// throws a FormulaFormatException with an explanatory message. 
        /// 
        /// If the formula contains a variable v such that isValid(normalize(v)) is false,
        /// throws a FormulaFormatException with an explanatory message.
        /// 
        /// Suppose that N is a method that converts all the letters in a string to upper case, and
        /// that V is a method that returns true only if a string consists of one letter followed
        /// by one digit.  Then:
        /// 
        /// new Formula("x2+y3", N, V) should succeed
        /// new Formula("x+y3", N, V) should throw an exception, since V(N("x")) is false
        /// new Formula("2x+y3", N, V) should throw an exception, since "2x+y3" is syntactically incorrect.
        /// </summary>
        public Formula(String formula, Func<string, string> normalize, Func<string, bool> isValid)
        {
            this.formula = normalize(formula);
			this.tokens = GetTokens(this.formula);
            this.ValidateExpression(normalize, isValid);
        }

        /// <summary>
        /// Evaluates this Formula, using the lookup delegate to determine the values of
        /// variables.  When a variable symbol v needs to be determined, it should be looked up
        /// via lookup(normalize(v)). (Here, normalize is the normalizer that was passed to 
        /// the constructor.)
        /// 
        /// For example, if L("x") is 2, L("X") is 4, and N is a method that converts all the letters 
        /// in a string to upper case:
        /// 
        /// new Formula("x+7", N, s => true).Evaluate(L) is 11
        /// new Formula("x+7").Evaluate(L) is 9
        /// 
        /// Given a variable symbol as its parameter, lookup returns the variable's value 
        /// (if it has one) or throws an ArgumentException (otherwise).
        /// 
        /// If no undefined variables or divisions by zero are encountered when evaluating 
        /// this Formula, the value is returned.  Otherwise, a FormulaError is returned.  
        /// The Reason property of the FormulaError should have a meaningful explanation.
        ///
        /// This method should never throw an exception.
        /// </summary>
        public object Evaluate(Func<string, double> lookup)
        {
			values = new Stack<double>();
			operators = new Stack<string>();

			//sort to appropriate stacks and check for errors
			object isThisAnError = SortToStacks(lookup);

			if (isThisAnError is FormulaError)
				return isThisAnError;

			//get result
			return values.Pop();
        }

        /// <summary>
        /// Enumerates the normalized versions of all of the variables that occur in this 
        /// formula.  No normalization may appear more than once in the enumeration, even 
        /// if it appears more than once in this Formula.
        /// 
        /// For example, if N is a method that converts all the letters in a string to upper case:
        /// 
        /// new Formula("x+y*z", N, s => true).GetVariables() should enumerate "X", "Y", and "Z"
        /// new Formula("x+X*z", N, s => true).GetVariables() should enumerate "X" and "Z".
        /// new Formula("x+X*z").GetVariables() should enumerate "x", "X", and "z".
        /// </summary>
        public IEnumerable<String> GetVariables()
        {
			List<String> variables = new List<String>();
			Regex varPattern = new Regex(@"[a-zA-Z_](?: [a-zA-Z_]|\d)*");
			foreach (string token in tokens)
			{
				if (varPattern.IsMatch(token))
				{
					variables.Add(token);
				}
			}
			return variables.Distinct();
        }

        /// <summary>
        /// Returns a string containing no spaces which, if passed to the Formula
        /// constructor, will produce a Formula f such that this.Equals(f).  All of the
        /// variables in the string should be normalized.
        /// 
        /// For example, if N is a method that converts all the letters in a string to upper case:
        /// 
        /// new Formula("x + y", N, s => true).ToString() should return "X+Y"
        /// new Formula("x + Y").ToString() should return "x+Y"
        /// </summary>
        public override string ToString()
        {
			string stringRep = "";
			foreach (string token in tokens)
			{
				try
				{
					double doub = Convert.ToDouble(token);
					stringRep += doub.ToString();
				}
				catch(FormatException e)
				{
					stringRep += token;
				}
			}
			return stringRep;
        }

        /// <summary>
        /// If obj is null or obj is not a Formula, returns false.  Otherwise, reports
        /// whether or not this Formula and obj are equal.
        /// 
        /// Two Formulae are considered equal if they consist of the same tokens in the
        /// same order.  To determine token equality, all tokens are compared as strings 
        /// except for numeric tokens, which are compared as doubles, and variable tokens,
        /// whose normalized forms are compared as strings.
        /// 
        /// For example, if N is a method that converts all the letters in a string to upper case:
        ///  
        /// new Formula("x1+y2", N, s => true).Equals(new Formula("X1  +  Y2")) is true
        /// new Formula("x1+y2").Equals(new Formula("X1+Y2")) is false
        /// new Formula("x1+y2").Equals(new Formula("y2+x1")) is false
        /// new Formula("2.0 + x7").Equals(new Formula("2.000 + x7")) is true
        /// </summary>
        public override bool Equals(object obj)
        {
			if (obj == null)
				return false;
			if (obj is Formula) ;
			else
				return false;

			if (this.ToString() == obj.ToString())
				return true;
			else
				return false;
        }

        /// <summary>
        /// Reports whether f1 == f2, using the notion of equality from the Equals method.
        /// Note that if both f1 and f2 are null, this method should return true.  If one is
        /// null and one is not, this method should return false.
        /// </summary>
        public static bool operator ==(Formula f1, Formula f2)
        {
			if (f1 == null)
			{
				if (f2 == null)
					return true;
				else
					return false;
			}
			if (f2 == null)
			{
				if (f1 == null)
					return true;
				else
					return false;
			}
            return f1.Equals(f2);
        }

        /// <summary>
        /// Reports whether f1 != f2, using the notion of equality from the Equals method.
        /// Note that if both f1 and f2 are null, this method should return false.  If one is
        /// null and one is not, this method should return true.
        /// </summary>
        public static bool operator !=(Formula f1, Formula f2)
        {
			if (f1 == f2)
				return false;
			else
				return true;
        }

        /// <summary>
        /// Returns a hash code for this Formula.  If f1.Equals(f2), then it must be the
        /// case that f1.GetHashCode() == f2.GetHashCode().  Ideally, the probability that two 
        /// randomly-generated unequal Formulae have the same hash code should be extremely small.
        /// </summary>
        public override int GetHashCode()
        {
            return 0;
        }

        /// <summary>
        /// Given an expression, enumerates the tokens that compose it.  Tokens are left paren;
        /// right paren; one of the four operator symbols; a string consisting of a letter or underscore
        /// followed by zero or more letters, digits, or underscores; a double literal; and anything that doesn't
        /// match one of those patterns.  There are no empty tokens, and no token contains white space.
        /// </summary>
        public static IEnumerable<string> GetTokens(String formula) //change this back to private once it starts working!
        {
            // Patterns for individual tokens
            String lpPattern = @"\(";
            String rpPattern = @"\)";
            String opPattern = @"[\+\-*/]";
            String varPattern = @"[a-zA-Z_](?: [a-zA-Z_]|\d)*";
            String doublePattern = @"(?: \d+\.\d* | \d*\.\d+ | \d+ ) (?: [eE][\+-]?\d+)?";
            String spacePattern = @"\s+";

            // Overall pattern
            String pattern = String.Format("({0}) | ({1}) | ({2}) | ({3}) | ({4}) | ({5})",
                                            lpPattern, rpPattern, opPattern, varPattern, doublePattern, spacePattern);

            // Enumerate matching tokens that don't consist solely of white space.
            foreach (String s in Regex.Split(formula, pattern, RegexOptions.IgnorePatternWhitespace))
            {
                if (!Regex.IsMatch(s, @"^\s*$", RegexOptions.Singleline))
                    yield return s;
            }

        }

		/// <summary>
		/// Helper method. Completes Validation for current formula. Checks 
		/// for invalid syntax.
		/// </summary>
		/// <param name="normalize"></param>
		/// <param name="isValid"></param>
        private void ValidateExpression(Func<string, string> normalize, Func<string, bool> isValid)
        {
			int numOpenParen = 0;
			int numCloseParen = 0;

            // if the string is empty
            if (GetTokens(formula).Count() == 0) 
                throw new FormulaFormatException("Sorry, there must be at least something in the expressino!");
            
            string prevToken = "";
            Regex regExOperators = new Regex("(\\()|(\\))|(-)|(\\+)|(\\*)|(/)");

            foreach (string token in GetTokens(formula))
            {
                try
                {

                    // check if current token is double
                    double.Parse(token);
                    if (prevToken == "Variable" || prevToken == "Double")
                        throw new FormulaFormatException("Invalid syntax in expression. A variable/double follows another variable/double.");
                    else
                        // set previous token accordingly and advance
                        prevToken = "Double";
                }
                // FormatException is thrown - not a double. 
                catch (FormatException e)
                {
                    // check if current token is an operator
					if (regExOperators.IsMatch(token))
					{
						// current token is right parenthasis
						if (token == "(")
						{
							if (prevToken != "Operator" || prevToken == "Left Parenthasis")
							{
								if (prevToken != "")
									throw new FormulaFormatException("Invalid syntax in expression. An operator or right parenthasis must precede a right parenthasis.");
								else
								{
									prevToken = "Right Parenthasis";
									numOpenParen++;
								}
							}
							else
							{
								prevToken = "Right Parenthasis";
								numOpenParen++;
							}
						}
						// current token is left parenthasis
						if (token == ")")
						{
							if (prevToken == "Right Parenthasis" || prevToken == "Operator")
								throw new FormulaFormatException("Invalid syntax in expression. An operator or right parenthasis cannot directly precede a left parenthasis.");
							if (prevToken == "")
								throw new FormulaFormatException("Invalid syntax in expression. Cannot begin with left parenthesis.");
							else
							{
								numCloseParen++;
								if (numCloseParen > numOpenParen)
									throw new FormulaFormatException("Invalid syntax in expression. Mismatched parenthases.");
								prevToken = "Left Parenthasis";
							}
						}
						// any other operator
						else
						{
							if (prevToken == "Operator" && prevToken != "Left Parenthasis")
								throw new FormulaFormatException("Invalid syntax in expression. An operator follows another operator.");
							if (prevToken == "")
								throw new FormulaFormatException("Invalid syntax in expression. Cannot begin with operator.");
							else
								prevToken = "Operator";
						}
					}
					// current token must be variable or invalid
					else if (!ValidateVariable(normalize(token)) || !isValid(normalize(token)))
						throw new FormulaFormatException("Invalid syntax on variable or invalid symbols used.");
					else if (prevToken == "Variable" || prevToken == "Double")
						throw new FormulaFormatException("Invalid syntax in expression. A variable/double follows another variable/double.");
					else
						prevToken = "Variable";
                }
            }
			if (numOpenParen != numCloseParen)
				throw new FormulaFormatException("Invalid syntax in expression. Number of open parentheses does not equal number of closed parenthases.");
        }

		/// <summary>
		/// Another helper method. Is invoked to check for standard variable
		/// validation and proper syntax. (This does not have association with
		/// the isValid delegate.)
		/// </summary>
		/// <param name="variable"></param>
		/// <returns></returns>
        private bool ValidateVariable(string variable)
        {
            if (Char.IsLetter(variable[0]) || variable[0].Equals("_"))
            {
                if (variable.Length > 1)
                {
                    for (int i = 1; i < variable.Length; i++)
                    {
                        if (!Char.IsLetterOrDigit(variable[i]) && !variable[i].Equals("_"))
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

		/// <summary>
		/// Another helper method. Checks tokens for validity and sorts them into their
		/// appropriate stacks at appropriate times, while calling Infix() to process them.
		/// </summary>
		/// <param name="lookup"></param>
		/// <returns></returns>
		private object SortToStacks(Func<string, double> lookup)
		{
			// Patterns for individual tokens
			Regex lpPattern = new Regex(@"\(");
			Regex rpPattern = new Regex(@"\)");
			Regex opPattern = new Regex(@"[\+\-*/]");
			Regex varPattern = new Regex(@"[a-zA-Z_](?: [a-zA-Z_]|\d)*");
			Regex doublePattern = new Regex(@"(?: \d+\.\d* | \d*\.\d+ | \d+ ) (?: [eE][\+-]?\d+)?");

			foreach (String character in tokens)
			{

				try
				{// token is integer
					Convert.ToDouble(character);
						object isThisAnError = Infix(character, "intorvar");
						if (isThisAnError is FormulaError)
							return isThisAnError;
					
				}
				// token is variable
				catch (FormatException e)
				{
					if (varPattern.IsMatch(character))
					{
						object isThisAnError = Infix(Convert.ToString(lookup(character)), "intorvar");
						if (isThisAnError is FormulaError)
							return isThisAnError;
					}
					// token is operator, (, or )
					if (opPattern.IsMatch(character) || rpPattern.IsMatch(character) || lpPattern.IsMatch(character))
					{
						object isThisAnError = Infix(character, "operator");
						if (isThisAnError is FormulaError)
							return isThisAnError;
					}
				}
			}
			//End of the line
			if (operators.Count != 0)
			{
				object IsThisAnError = PerformOperation(operators.Pop(), values.Pop(), values.Pop());
				if (IsThisAnError is FormulaError)
					return IsThisAnError;
				else
					values.Push(Convert.ToDouble(IsThisAnError));
			}
			return null;
		}

		/// <summary>
		/// Another helper method. Processes tokens to evaluate using standard infix notation.
		/// Respects the usual prescedence rules.
		/// </summary>
		/// <param name="token"></param>
		/// <param name="type"></param>
		private object Infix(String token, String type)
		{
			if (type == "intorvar")
			{
				if (operators.Count != 0)
				{
					if (operators.Peek() == "*" || operators.Peek() == "/")
					{
						object IsThisAnError = PerformOperation(operators.Pop(), values.Pop(), Convert.ToDouble(token));
						if (IsThisAnError is FormulaError)
							return IsThisAnError;
						else
							values.Push(Convert.ToDouble(IsThisAnError));
					}
					else
						values.Push(Convert.ToDouble(token));
				}
				else
					values.Push(Convert.ToDouble(token));
			}
			if (type == "operator")
			{
				if (token == "+" || token == "-")
				{
					if (operators.Count != 0)
						if (operators.Peek() == "+" || operators.Peek() == "-")
						{
							object IsThisAnError = PerformOperation(operators.Pop(), values.Pop(), values.Pop());
							if (IsThisAnError is FormulaError)
								return IsThisAnError;
							else
								values.Push(Convert.ToDouble(IsThisAnError));
						}
					operators.Push(token);
				}
				if (token == "*" || token == "/" || token == "(")
					operators.Push(token);
				if (token == ")")
				{
					if (operators.Count != 0)
					{
						if (operators.Peek() == "+" || operators.Peek() == "-")
						{
							object IsThisAnError = PerformOperation(operators.Pop(), values.Pop(), values.Pop());
							if (IsThisAnError is FormulaError)
								return IsThisAnError;
							else
								values.Push(Convert.ToDouble(IsThisAnError));
						}
					}
					if (operators.Count != 0)
					{
						operators.Pop();
					}
					if (operators.Count != 0)
					{
						if (operators.Peek() == "*" || operators.Peek() == "/")
						{
							object IsThisAnError = PerformOperation(operators.Pop(), values.Pop(), values.Pop());
							if (IsThisAnError is FormulaError)
								return IsThisAnError;
							else
								values.Push(Convert.ToDouble(IsThisAnError));
						}
					}
				}
			}
			return null;
		}

		/// <summary>
		/// Another helper method. Operators and left and right operands are passed in for the operations.
		/// This method checks for division by 0 and throws an exception should it occur.
		/// </summary>
		/// <param name="operation"></param>
		/// <param name="leftOperand"></param>
		/// <param name="rightOperand"></param>
		/// <returns></returns>
		private object PerformOperation(String operation, double leftOperand, double rightOperand)
		{
			double result = 0.0;
			if (operation == "*")
				result = leftOperand * rightOperand;
			if (operation == "/")
			{
				if (rightOperand == 0)
					return new FormulaError("Cannot divide by zero.");
				else
					result = leftOperand / rightOperand;
			}
			if (operation == "+")
				result = leftOperand + rightOperand;
			if (operation == "-")
				result = rightOperand - leftOperand;
			return result;
		}

    }

    /// <summary>
    /// Used to report syntactic errors in the argument to the Formula constructor.
    /// </summary>
    public class FormulaFormatException : Exception
    {
        /// <summary>
        /// Constructs a FormulaFormatException containing the explanatory message.
        /// </summary>
        public FormulaFormatException(String message)
            : base(message)
        {
        }
    }

    /// <summary>
    /// Used as a possible return value of the Formula.Evaluate method.
    /// </summary>
    public struct FormulaError
    {
        /// <summary>
        /// Constructs a FormulaError containing the explanatory reason.
        /// </summary>
        /// <param name="reason"></param>
        public FormulaError(String reason)
            : this()
        {
            Reason = reason;
        }

        /// <summary>
        ///  The reason why this FormulaError was created.
        /// </summary>
        public string Reason { get; private set; }
    }
}

