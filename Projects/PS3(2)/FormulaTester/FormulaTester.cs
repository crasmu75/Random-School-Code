﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SpreadsheetUtilities;
using System.Collections.Generic;
using System.Linq;

namespace FormulaTester
{
    /// <summary>
    /// 
    /// </summary>
    [TestClass]
    public class FormulaTester
    {
        /// <summary>
        /// Message should say "Sorry, there must be at least something in the expression!"
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(FormulaFormatException))]
        public void Invalid_Expression_1()
        {
            Formula testFormula = new Formula(" ", x => x.ToUpper(), x => true);
        }

        /// <summary>
        /// Message should say "Invalid syntax in expression. A variable/double follows another variable/double."
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(FormulaFormatException))]
        public void Invalid_Expression_2()
        {
            Formula testFormula = new Formula("x2 0.2 + 3", x => x.ToUpper(), x => true);
        }

        /// <summary>
        /// Message should say "Invalid syntax in expression. An operator follows another operator."
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(FormulaFormatException))]
        public void Invalid_Expression_3()
        {
            Formula testFormula = new Formula("y2 + - 6.876", x => x.ToUpper(), x => true);
        }

        /// <summary>
        /// Message should say "Invalid syntax on variable or invalid symbols used."
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(FormulaFormatException))]
        public void Invalid_Expression_4()
        {
            Formula testFormula = new Formula("_&3 / 16.07", x => x.ToUpper(), x => true);
        }

        /// <summary>
        /// Message should say "Invalid syntax in expression. A variable/double follows another variable/double."
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(FormulaFormatException))]
        public void Invalid_Expression_5()
        {
            Formula testFormula = new Formula("2x +y3", x => x.ToUpper(), x => true);
        }

		/// <summary>
		/// Message should say "Invalid syntax in expression. Number of open parentheses does not equal number of closed parenthases."
		/// </summary>
		[TestMethod]
		[ExpectedException(typeof(FormulaFormatException))]
		public void Invalid_Expression_6()
		{
			Formula testFormula = new Formula("(8 * 9.44))", x => x.ToUpper(), x => true);
		}

		/// <summary>
		/// Message should say "Invalid syntax in expression. Number of open parentheses does not equal number of closed parenthases."
		/// </summary>
		[TestMethod]
		[ExpectedException(typeof(FormulaFormatException))]
		public void Invalid_Expression_7()
		{
			Formula testFormula = new Formula("((8.4 + (67.2907 * 0)", x => x.ToUpper(), x => true);
		}

		/// <summary>
		/// Message should say "Invalid syntax in expression. Mismatched parenthases."
		/// </summary>
		[TestMethod]
		[ExpectedException(typeof(FormulaFormatException))]
		public void Invalid_Expression_8()
		{
			Formula testFormula = new Formula("(34.77 / 9)))((", x => x.ToUpper(), x => true);
		}

		/// <summary>
		/// Message should say "Invalid syntax in expression. An operator or right parenthasis cannot directly precede a left parenthasis."
		/// </summary>
		[TestMethod]
		[ExpectedException(typeof(FormulaFormatException))]
		public void Invalid_Expression_9()
		{
			Formula testFormula = new Formula("(5 +)", x => x.ToUpper(), x => true);
		}

		/// <summary>
		/// Message should say "Invalid syntax in expression. An operator or right parenthasis cannot directly precede a left parenthasis."
		/// </summary>
		[TestMethod]
		[ExpectedException(typeof(FormulaFormatException))]
		public void Invalid_Expression_10()
		{
			Formula testFormula = new Formula("() - 100.057", x => x.ToUpper(), x => true);
		}

		/// <summary>
		/// Message should say "Invalid syntax in expression. Cannot begin with operator."
		/// </summary>
		[TestMethod]
		[ExpectedException(typeof(FormulaFormatException))]
		public void Invalid_Expression_11()
		{
			Formula testFormula = new Formula("+ 9.33", x => x.ToUpper(), x => true);
		}

		/// <summary>
		/// Message should say "Invalid syntax in expression. Cannot begin with left parenthasis."
		/// </summary>
		[TestMethod]
		[ExpectedException(typeof(FormulaFormatException))]
		public void Invalid_Expression_12()
		{
			Formula testFormula = new Formula(") 7 - 9.33)", x => x.ToUpper(), x => true);
		}

		/// <summary>
		/// 
		/// </summary>
		[TestMethod]
		public void Valid_Expression_1()
		{
			Formula testFormula = new Formula("5", x => x.ToUpper(), x => true);
			Assert.AreEqual(5.0, testFormula.Evaluate(s => 0));
		}

		/// <summary>
		/// 
		/// </summary>
		[TestMethod]
		public void Valid_Expression_2()
		{
			Formula testFormula = new Formula("X5", x => x.ToUpper(), x => true);
			Assert.AreEqual(13.0, testFormula.Evaluate(s => 13));
		}

		/// <summary>
		/// 
		/// </summary>
		[TestMethod]
		public void Valid_Expression_3()
		{
			Formula testFormula = new Formula("5.3+3", x => x.ToUpper(), x => true);
			Assert.AreEqual(8.3, testFormula.Evaluate(s => 0));
		}

		/// <summary>
		/// 
		/// </summary>
		[TestMethod]
		public void Valid_Expression_4()
		{
			Formula testFormula = new Formula("18.97- 10.9", x => x.ToUpper(), x => true);
			Assert.AreEqual(8.07, (double) testFormula.Evaluate(s => 0), 0.000000001);
		}

		/// <summary>
		/// 
		/// </summary>
		[TestMethod]
		public void Valid_Expression_5()
		{
			Formula testFormula = new Formula("2.338 * 4.5", x => x.ToUpper(), x => true);
			Assert.AreEqual(10.521, (double)testFormula.Evaluate(s => 0), 0.000000001);
		}

		/// <summary>
		/// 
		/// </summary>
		[TestMethod]
		public void Valid_Expression_6()
		{
			Formula testFormula = new Formula("16.7/2.004", x => x.ToUpper(), x => true);
			Assert.AreEqual(8.33333333333333, (double)testFormula.Evaluate(s => 0), 0.000000001);
		}

		/// <summary>
		/// 
		/// </summary>
		[TestMethod]
		public void Valid_Expression_7()
		{
			Formula testFormula = new Formula("2.3+X1", x => x.ToUpper(), x => true);
			Assert.AreEqual(6.3, (double)testFormula.Evaluate(s => 4), 0.000000001);
		}

		/// <summary>
		/// 
		/// </summary>
		[TestMethod]
		public void Valid_Expression_8()
		{
			Formula testFormula = new Formula("2.3*6+A", x => x.ToUpper(), x => true);
			Assert.AreEqual(17.3, (double)testFormula.Evaluate(s => 3.5), 0.000000001);
		}

		/// <summary>
		/// 
		/// </summary>
		[TestMethod]
		public void Valid_Expression_9()
		{
			Formula testFormula = new Formula("2.1*(3.889+9.0)", x => x.ToUpper(), x => true);
			Assert.AreEqual(27.0669, (double)testFormula.Evaluate(s => 0), 0.000000001);
		}

		
		/// <summary>
		/// 
		/// </summary>
		[TestMethod]
		public void Get_Variables_1()
		{
			Formula testFormula = new Formula("x+y*z", s => s.ToUpper(), s => true);
			Assert.AreEqual("X", testFormula.GetVariables().ToList().ElementAt(0));
			Assert.AreEqual("Y", testFormula.GetVariables().ToList().ElementAt(1));
			Assert.AreEqual("Z", testFormula.GetVariables().ToList().ElementAt(2));
		}

		/// <summary>
		/// 
		/// </summary>
		[TestMethod]
		public void Get_Variables_2()
		{
			Formula testFormula = new Formula("x+y*Y/z", s => s.ToUpper(), s => true);
			Assert.AreEqual("X", testFormula.GetVariables().ToList().ElementAt(0));
			Assert.AreEqual("Y", testFormula.GetVariables().ToList().ElementAt(1));
			Assert.AreEqual("Z", testFormula.GetVariables().ToList().ElementAt(2));
		}

		/// <summary>
		/// 
		/// </summary>
		[TestMethod]
		public void Get_Variables_3()
		{
			Formula testFormula = new Formula("x+X*z");
			Assert.AreEqual("x", testFormula.GetVariables().ToList().ElementAt(0));
			Assert.AreEqual("X", testFormula.GetVariables().ToList().ElementAt(1));
			Assert.AreEqual("z", testFormula.GetVariables().ToList().ElementAt(2));
		}

		/// <summary>
		/// 
		/// </summary>
		[TestMethod]
		public void ToString_1()
		{
			Assert.AreEqual("X+Y", new Formula("x + y", s => s.ToUpper(), s => true).ToString());
		}

		/// <summary>
		/// 
		/// </summary>
		[TestMethod]
		public void ToString_2()
		{
			Assert.AreEqual("x+Y", new Formula("x + Y").ToString());
		}
		
		/// <summary>
		/// 
		/// </summary>
		[TestMethod]
		public void EqualsMethod_1()
		{
			Assert.AreEqual(true, new Formula("x1+y2", s => s.ToUpper(), s => true).Equals(new Formula("X1  +  Y2")));
		}

		/// <summary>
		/// 
		/// </summary>
		[TestMethod]
		public void EqualsMethod_2()
		{
			Assert.AreEqual(false, new Formula("x1+y2").Equals(new Formula("X1+Y2")));
		}

		/// <summary>
		/// 
		/// </summary>
		[TestMethod]
		public void EqualsMethod_3()
		{
			Assert.AreEqual(false, new Formula("x1+y2").Equals(new Formula("y2+x1")));
		}

		/// <summary>
		/// 
		/// </summary>
		[TestMethod]
		public void EqualsMethod_4()
		{
			Assert.AreEqual(true, new Formula("2.0 + x7").Equals(new Formula("2.000 + x7")));
		}

		/// <summary>
		/// 
		/// </summary>
		[TestMethod]
		public void EqualsMethod_5()
		{
			Assert.AreEqual(false, new Formula("2.0 + x7").Equals(null));
		}

		/// <summary>
		/// 
		/// </summary>
		[TestMethod]
		public void EqualsMethod_6()
		{
			Boolean tester = new Boolean();
			Assert.AreEqual(false, new Formula("2.0 + x7").Equals(tester));
		}

    }
}
