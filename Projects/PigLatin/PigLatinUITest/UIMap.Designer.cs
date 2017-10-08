﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by coded UI test builder.
//      Version: 12.0.0.0
//
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------

namespace PigLatinUITest
{
    using System;
    using System.CodeDom.Compiler;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Text.RegularExpressions;
    using System.Windows.Input;
    using Microsoft.VisualStudio.TestTools.UITest.Extension;
    using Microsoft.VisualStudio.TestTools.UITesting;
    using Microsoft.VisualStudio.TestTools.UITesting.WinControls;
    using Microsoft.VisualStudio.TestTools.UITesting.WpfControls;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Keyboard = Microsoft.VisualStudio.TestTools.UITesting.Keyboard;
    using Mouse = Microsoft.VisualStudio.TestTools.UITesting.Mouse;
    using MouseButtons = System.Windows.Forms.MouseButtons;
    
    
    [GeneratedCode("Coded UITest Builder", "12.0.30501.0")]
    public partial class UIMap
    {
        
        /// <summary>
        /// open and closing
        /// </summary>
        public void OpenAndClose()
        {
            #region Variable Declarations
            WpfEdit uIOriginalTbEdit = this.UIPigLatinWindow1.UIOriginalTbEdit;
            WinButton uICloseButton = this.UIPigLatinWindow.UICloseButton;
            #endregion

            // Launch '%USERPROFILE%\Desktop\AssignmentPigLatin.exe'
            ApplicationUnderTest uIPigLatinWindow = ApplicationUnderTest.Launch(this.OpenAndCloseParams.UIPigLatinWindowExePath, this.OpenAndCloseParams.UIPigLatinWindowAlternateExePath);

            // Click 'OriginalTb' text box
            Mouse.Click(uIOriginalTbEdit, new Point(202, 52));

            // Click 'Close' button
            Mouse.Click(uICloseButton, new Point(5, 14));
        }
        
        /// <summary>
        /// input hello and get ellohay
        /// </summary>
        public void InputHello()
        {
            #region Variable Declarations
            WpfEdit uIOriginalTbEdit = this.UIPigLatinWindow1.UIOriginalTbEdit;
            WpfButton uITranslateButton = this.UIPigLatinWindow1.UITranslateButton;
            #endregion

            // Launch '%USERPROFILE%\Desktop\AssignmentPigLatin.exe'
            ApplicationUnderTest uIPigLatinWindow1 = ApplicationUnderTest.Launch(this.InputHelloParams.UIPigLatinWindow1ExePath, this.InputHelloParams.UIPigLatinWindow1AlternateExePath);

            // Type 'Hello' in 'OriginalTb' text box
            uIOriginalTbEdit.Text = this.InputHelloParams.UIOriginalTbEditText;

            // Click 'Translate' button
            Mouse.Click(uITranslateButton, new Point(41, 12));
        }
        
        /// <summary>
        /// make sure hello becomes ellohay
        /// </summary>
        public void AssertOnHello()
        {
            #region Variable Declarations
            WpfEdit uIPigLatinTbEdit = this.UIPigLatinWindow1.UIPigLatinTbEdit;
            #endregion

            // Verify that the 'Text' property of 'PigLatinTb' text box equals 'Ellohay'
            Assert.AreEqual(this.AssertOnHelloExpectedValues.UIPigLatinTbEditText, uIPigLatinTbEdit.Text, "Expected Ellohay, got Hi");
        }
        
        #region Properties
        public virtual OpenAndCloseParams OpenAndCloseParams
        {
            get
            {
                if ((this.mOpenAndCloseParams == null))
                {
                    this.mOpenAndCloseParams = new OpenAndCloseParams();
                }
                return this.mOpenAndCloseParams;
            }
        }
        
        public virtual InputHelloParams InputHelloParams
        {
            get
            {
                if ((this.mInputHelloParams == null))
                {
                    this.mInputHelloParams = new InputHelloParams();
                }
                return this.mInputHelloParams;
            }
        }
        
        public virtual AssertOnHelloExpectedValues AssertOnHelloExpectedValues
        {
            get
            {
                if ((this.mAssertOnHelloExpectedValues == null))
                {
                    this.mAssertOnHelloExpectedValues = new AssertOnHelloExpectedValues();
                }
                return this.mAssertOnHelloExpectedValues;
            }
        }
        
        public UIPigLatinWindow UIPigLatinWindow
        {
            get
            {
                if ((this.mUIPigLatinWindow == null))
                {
                    this.mUIPigLatinWindow = new UIPigLatinWindow();
                }
                return this.mUIPigLatinWindow;
            }
        }
        
        public UIPigLatinWindow1 UIPigLatinWindow1
        {
            get
            {
                if ((this.mUIPigLatinWindow1 == null))
                {
                    this.mUIPigLatinWindow1 = new UIPigLatinWindow1();
                }
                return this.mUIPigLatinWindow1;
            }
        }
        #endregion
        
        #region Fields
        private OpenAndCloseParams mOpenAndCloseParams;
        
        private InputHelloParams mInputHelloParams;
        
        private AssertOnHelloExpectedValues mAssertOnHelloExpectedValues;
        
        private UIPigLatinWindow mUIPigLatinWindow;
        
        private UIPigLatinWindow1 mUIPigLatinWindow1;
        #endregion
    }
    
    /// <summary>
    /// Parameters to be passed into 'OpenAndClose'
    /// </summary>
    [GeneratedCode("Coded UITest Builder", "12.0.30501.0")]
    public class OpenAndCloseParams
    {
        
        #region Fields
        /// <summary>
        /// Launch '%USERPROFILE%\Desktop\AssignmentPigLatin.exe'
        /// </summary>
        public string UIPigLatinWindowExePath = "C:\\Users\\Camille\\Desktop\\AssignmentPigLatin.exe";
        
        /// <summary>
        /// Launch '%USERPROFILE%\Desktop\AssignmentPigLatin.exe'
        /// </summary>
        public string UIPigLatinWindowAlternateExePath = "%USERPROFILE%\\Desktop\\AssignmentPigLatin.exe";
        #endregion
    }
    
    /// <summary>
    /// Parameters to be passed into 'InputHello'
    /// </summary>
    [GeneratedCode("Coded UITest Builder", "12.0.30501.0")]
    public class InputHelloParams
    {
        
        #region Fields
        /// <summary>
        /// Launch '%USERPROFILE%\Desktop\AssignmentPigLatin.exe'
        /// </summary>
        public string UIPigLatinWindow1ExePath = "C:\\Users\\Camille\\Desktop\\AssignmentPigLatin.exe";
        
        /// <summary>
        /// Launch '%USERPROFILE%\Desktop\AssignmentPigLatin.exe'
        /// </summary>
        public string UIPigLatinWindow1AlternateExePath = "%USERPROFILE%\\Desktop\\AssignmentPigLatin.exe";
        
        /// <summary>
        /// Type 'Hello' in 'OriginalTb' text box
        /// </summary>
        public string UIOriginalTbEditText = "Hello";
        #endregion
    }
    
    /// <summary>
    /// Parameters to be passed into 'AssertOnHello'
    /// </summary>
    [GeneratedCode("Coded UITest Builder", "12.0.30501.0")]
    public class AssertOnHelloExpectedValues
    {
        
        #region Fields
        /// <summary>
        /// Verify that the 'Text' property of 'PigLatinTb' text box equals 'Ellohay'
        /// </summary>
        public string UIPigLatinTbEditText = "Ellohay";
        #endregion
    }
    
    [GeneratedCode("Coded UITest Builder", "12.0.30501.0")]
    public class UIPigLatinWindow : WinWindow
    {
        
        public UIPigLatinWindow()
        {
            #region Search Criteria
            this.SearchProperties[WinWindow.PropertyNames.Name] = "Pig Latin";
            this.SearchProperties.Add(new PropertyExpression(WinWindow.PropertyNames.ClassName, "HwndWrapper", PropertyExpressionOperator.Contains));
            this.WindowTitles.Add("Pig Latin");
            #endregion
        }
        
        #region Properties
        public WinButton UICloseButton
        {
            get
            {
                if ((this.mUICloseButton == null))
                {
                    this.mUICloseButton = new WinButton(this);
                    #region Search Criteria
                    this.mUICloseButton.SearchProperties[WinButton.PropertyNames.Name] = "Close";
                    this.mUICloseButton.WindowTitles.Add("Pig Latin");
                    #endregion
                }
                return this.mUICloseButton;
            }
        }
        #endregion
        
        #region Fields
        private WinButton mUICloseButton;
        #endregion
    }
    
    [GeneratedCode("Coded UITest Builder", "12.0.30501.0")]
    public class UIPigLatinWindow1 : WpfWindow
    {
        
        public UIPigLatinWindow1()
        {
            #region Search Criteria
            this.SearchProperties[WpfWindow.PropertyNames.Name] = "Pig Latin";
            this.SearchProperties.Add(new PropertyExpression(WpfWindow.PropertyNames.ClassName, "HwndWrapper", PropertyExpressionOperator.Contains));
            this.WindowTitles.Add("Pig Latin");
            #endregion
        }
        
        #region Properties
        public WpfEdit UIOriginalTbEdit
        {
            get
            {
                if ((this.mUIOriginalTbEdit == null))
                {
                    this.mUIOriginalTbEdit = new WpfEdit(this);
                    #region Search Criteria
                    this.mUIOriginalTbEdit.SearchProperties[WpfEdit.PropertyNames.AutomationId] = "OriginalTb";
                    this.mUIOriginalTbEdit.WindowTitles.Add("Pig Latin");
                    #endregion
                }
                return this.mUIOriginalTbEdit;
            }
        }
        
        public WpfButton UITranslateButton
        {
            get
            {
                if ((this.mUITranslateButton == null))
                {
                    this.mUITranslateButton = new WpfButton(this);
                    #region Search Criteria
                    this.mUITranslateButton.SearchProperties[WpfButton.PropertyNames.AutomationId] = "translateButton";
                    this.mUITranslateButton.WindowTitles.Add("Pig Latin");
                    #endregion
                }
                return this.mUITranslateButton;
            }
        }
        
        public WpfEdit UIPigLatinTbEdit
        {
            get
            {
                if ((this.mUIPigLatinTbEdit == null))
                {
                    this.mUIPigLatinTbEdit = new WpfEdit(this);
                    #region Search Criteria
                    this.mUIPigLatinTbEdit.SearchProperties[WpfEdit.PropertyNames.AutomationId] = "PigLatinTb";
                    this.mUIPigLatinTbEdit.WindowTitles.Add("Pig Latin");
                    #endregion
                }
                return this.mUIPigLatinTbEdit;
            }
        }
        #endregion
        
        #region Fields
        private WpfEdit mUIOriginalTbEdit;
        
        private WpfButton mUITranslateButton;
        
        private WpfEdit mUIPigLatinTbEdit;
        #endregion
    }
}
