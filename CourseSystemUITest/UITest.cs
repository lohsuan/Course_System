using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CourseSystemUITest
{
    /// <summary>
    /// Summary description for CourseSystemUITest
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

        // StartUpForm
        [TestMethod]
        public void StartUpFormButtonControlTest()
        {
            Robot.ClickButton("Course Selecting System");
            Robot.AssertButtonEnable("Course Selecting System", false);

            Robot.CloseWindow("CourseSelectingForm");
            Robot.AssertButtonEnable("Course Selecting System", true);

            Robot.ClickButton("Course Management System");
            Robot.AssertOtherFormButtonEnable("StartUpForm", "Course Management System", false);

            Robot.CloseWindow("CourseManagementForm");
            Robot.AssertButtonEnable("Course Management System", true);
        }

        [TestMethod]
        public void CourseSelectingFormTest()
        {
            Robot.ClickButton("Course Selecting System");
            Robot.SetForm("CourseSelectingForm");
            
            Robot.AssertButtonEnable("確認送出", false);
            Robot.AssertButtonEnable("查看選課結果", true);

            //Robot.SetCheckBox("選 資料列 9", true);

            //Robot.AssertButtonEnable("確認送出", true);

            Robot.AssertDataItemsInDataGridView("DataGridView", 12);

            Robot.ClickTabControl("電子三甲");
            Robot.SetCheckBox("選 資料列 3", true);
            
            Robot.ClickButton("查看選課結果");
            Robot.AssertButtonEnable("查看選課結果", false);

            Robot.ClickButton("確認送出");

            Robot.AssertButtonEnable("確認送出", false);
            //Robot.CloseWindow("");

            //Robot.AssertText("加選成功\n");
            //Robot.SendKeyEnterToMessageBox();

            //Robot.CloseWindow("CourseSelectingForm");
            //Robot.AssertButtonEnable("Course Selecting System", true);

            //Robot.ClickButton("Course Management System");
            //Robot.AssertOtherFormButtonEnable("StartUpForm", "Course Management System", false);

            //Robot.CloseWindow("CourseManagementForm");
            //Robot.AssertButtonEnable("Course Management System", true);
        }

        // Cleanup
        [TestCleanup()]
        public void Cleanup()
        {
            Robot.CleanUp();
        }

    }
}