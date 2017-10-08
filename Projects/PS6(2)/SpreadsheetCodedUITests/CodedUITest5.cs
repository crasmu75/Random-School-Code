using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Input;
using System.Windows.Forms;
using System.Drawing;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualStudio.TestTools.UITest.Extension;
using Keyboard = Microsoft.VisualStudio.TestTools.UITesting.Keyboard;


namespace SpreadsheetCodedUITests
{
	/// <summary>
	/// Summary description for CodedUITest5
	/// </summary>
	[CodedUITest]
	public class CodedUITest5
	{
		public CodedUITest5()
		{
		}

		[TestMethod]
		public void CodedUITestMethod1()
		{
			// To generate code for this test, select "Generate Code for Coded UI Test" from the shortcut menu and select one of the menu items.
			this.UIMap.CreateFormulaError();
			this.UIMap.ValueUpdatedToFormulaError1();
			this.UIMap.ContentsUpdatedCorrectly2();
			this.UIMap.ChangeContentsOfDependentCell();
			this.UIMap.ValueUpdatedCorrectly2();
			this.UIMap.ContentsUpdatedCorrectly3();
			this.UIMap.SelectA1();
			this.UIMap.FormulaErrorRemains();
			this.UIMap.CircularDependency();
			this.UIMap.ContentsNotUpdated2();
		}

		#region Additional test attributes

		// You can use the following additional attributes as you write your tests:

		////Use TestInitialize to run code before running each test 
		//[TestInitialize()]
		//public void MyTestInitialize()
		//{        
		//    // To generate code for this test, select "Generate Code for Coded UI Test" from the shortcut menu and select one of the menu items.
		//}

		////Use TestCleanup to run code after each test has run
		//[TestCleanup()]
		//public void MyTestCleanup()
		//{        
		//    // To generate code for this test, select "Generate Code for Coded UI Test" from the shortcut menu and select one of the menu items.
		//}

		#endregion

		/// <summary>
		///Gets or sets the test context which provides
		///information about and functionality for the current test run.
		///</summary>
		public TestContext TestContext
		{
			get
			{
				return testContextInstance;
			}
			set
			{
				testContextInstance = value;
			}
		}
		private TestContext testContextInstance;

		public UIMap UIMap
		{
			get
			{
				if ((this.map == null))
				{
					this.map = new UIMap();
				}

				return this.map;
			}
		}

		private UIMap map;
	}
}
