using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CourseSystemUITest
{
    /// <summary>
    /// Summary description for MainFormUITest
    /// </summary>
    [CodedUITest]
    public class UITest
    {
        const string FILE_PATH = @"..\\..\\..\\CourseSystem\\bin\\Debug\\CourseSystem.exe";
        private const string APP_TITLE = "StartUpForm";

        // Initialize
        [TestInitialize()]
        public void Initialize()
        {
            Robot.Initialize(FILE_PATH, APP_TITLE);
        }

        [TestMethod]
        public void TestAdd()
        {
            Robot.ClickButton("Course Selecting System");
            Robot.AssertButtonEnable("Course Selecting System", false);
        }

        // Cleanup
        [TestCleanup()]
        public void Cleanup()
        {
            Robot.CleanUp();
        }

    }
}