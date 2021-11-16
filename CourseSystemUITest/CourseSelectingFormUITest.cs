using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseSystemUITest
{
    [TestClass()]
    public class CourseSelectingFormUITest
    {
        private Robot _robot;
        private const string APP_NAME = "Microsoft.WindowsCalculator_8wekyb3d8bbwe!App";
        private const string CALCULATOR_TITLE = "小算盤";
        private const string EXPECTED_VALUE = "顯示是 444";
        private const string RESULT_CONTROL_NAME = "CalculatorResults";

        //private string targetAppPath;
        //private const string COURSE_SELECTING_FORM = "CourseSelectingForm";

        //// init
        //[TestInitialize]
        //public void Initialize()
        //{
        //    var projectName = "CourseSystem";
        //    string solutionPath = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\..\\"));
        //    targetAppPath = Path.Combine(solutionPath, projectName, "bin", "Debug", "CourseSystem.exe");
        //    _robot = new Robot(targetAppPath, COURSE_SELECTING_FORM);
        //}


        /// <summary>
        /// Launches the Calculator
        /// </summary>
        [TestInitialize()]
        public void Initialize()
        {
            _robot = new Robot(APP_NAME, CALCULATOR_TITLE);
        }


        /// <summary>
        /// Closes the launched program
        /// </summary>
        [TestCleanup()]
        public void Cleanup()
        {
            _robot.CleanUp();
        }

        private void RunScriptAdd()
        {
            _robot.ClickButton("清除");
            _robot.ClickButton("一");
            _robot.ClickButton("二");
            _robot.ClickButton("三");
            _robot.ClickButton("加");
            _robot.ClickButton("三");
            _robot.ClickButton("二");
            _robot.ClickButton("一");
            _robot.ClickButton("等於");
        }

        [TestMethod]
        public void TestAdd()
        {
            RunScriptAdd();
            _robot.AssertText(RESULT_CONTROL_NAME, EXPECTED_VALUE);
        }

    }

}
