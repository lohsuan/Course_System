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
    public class UITest
    {
        private Robot _robot;
        private string targetAppPath;
        //private const string START_UP_FORM = "StartUpForm";

        private const string START_UP_FORM = "CourseSelectingForm";

        // init
        [TestInitialize]
        public void Initialize()
        {
            var projectName = "CourseSystem";
            string solutionPath = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\..\\"));
            targetAppPath = Path.Combine(solutionPath, projectName, "bin", "Debug", "CourseSystem.exe");
            _robot = new Robot(targetAppPath, START_UP_FORM);
        }

        [TestCleanup()]
        public void Cleanup()
        {
            _robot.CleanUp();
        }

        [TestMethod]
        public void TestAdd()
        {
            _robot.ClickButton("Course Selecting System");
            _robot.AssertEnable("Course Selecting System", false);
        }

        [TestMethod]
        public void TestButtonControl()
        {
            _robot.ClickButton("Course Selecting System");
            _robot.AssertEnable("Course Selecting System", false);

            _robot.SwitchTo("StartUpForm");
            _robot.ClickButton("Course Management System");
            _robot.AssertEnable("Course Management System", false);

            _robot.SwitchTo("CourseSelectingForm");
            _robot.CloseWindow();
            _robot.AssertEnable("Course Selecting System", true);

            _robot.SwitchTo("CourseManagementForm");
            _robot.CloseWindow();
            _robot.AssertEnable("Course Management System", true);
        }
    }

}
