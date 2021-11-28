using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading;

namespace CourseSystemUITest
{
    /// <summary>
    /// Please change display of the computer to 100% to execute codeing ui test
    /// Summary description for CourseSystemUITest
    /// number of total ui test: 11
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
            RobotTest.Initialize(FILE_PATH, APP_TITLE);
        }

        // StartUpForm
        // StartUpFormButtonControlTest
        [TestMethod]
        public void StartUpFormButtonControlTest()
        {
            RobotTest.ClickButton("Course Selecting System");
            RobotTest.AssertButtonEnable("Course Selecting System", false);

            RobotTest.CloseWindow("CourseSelectingForm");
            RobotTest.AssertButtonEnable("Course Selecting System", true);

            RobotTest.ClickButton("Course Management System");
            RobotTest.AssertOtherFormButtonEnable("StartUpForm", "Course Management System", false);

            RobotTest.CloseWindow("CourseManagementForm");
            RobotTest.AssertButtonEnable("Course Management System", true);
        }

        // OpenCourseSelectingSystemScript
        private static void OpenCourseSelectingSystemScript()
        {
            RobotTest.ClickButton("Course Selecting System");
            RobotTest.SetForm("CourseSelectingForm");

            RobotTest.AssertNumberOfRowInDataGridView("DataGridView", 12);
            RobotTest.AssertButtonEnable("查看選課結果", true);

            RobotTest.ClickButton("查看選課結果");
            RobotTest.AssertButtonEnable("查看選課結果", false);
            RobotTest.AssertButtonEnable("確認送出", false);
        }

        // OpenCourseManagementSystemScript
        private static void OpenCourseManagementSystemScript()
        {
            RobotTest.ClickButton("Course Management System");
            RobotTest.SetForm("CourseManagementForm");

            RobotTest.AssertButtonEnable("新增課程", true);
            RobotTest.AssertButtonEnable("匯入資工系全部課程", true);
            RobotTest.AssertButtonEnable("儲存", false);
        }

        // CourseSelectingForm
        // CourseSelectingFormSelectDropSuccessTest
        [TestMethod]
        public void CourseSelectingFormSelectDropSuccessTest()
        {
            SelectTwoCourseSuccessScript();
            DropClassScript();
        }

        // SelectTwoCourseSuccessScript
        private static void SelectTwoCourseSuccessScript()
        {
            OpenCourseSelectingSystemScript();

            RobotTest.ClickFirstCellOfRowInDataGridViewByRowOrder("DataGridView", "10");
            RobotTest.AssertButtonEnable("確認送出", true);

            RobotTest.ClickTabControl("電子三甲");
            RobotTest.AssertNumberOfRowInDataGridView("DataGridView", 25);

            RobotTest.ClickFirstCellOfRowInDataGridViewByRowOrder("DataGridView", "4");
            RobotTest.ClickButton("確認送出");
            RobotTest.AssertButtonEnable("確認送出", false);
            Thread.Sleep(2000);
            RobotTest.SendKeyEnterToMessageBox();

            RobotTest.AssertNumberOfRowInDataGridView("DataGridView", 24);
            RobotTest.AssertDataGridViewDoesNotContainClass("DataGridView", 24, "通訊系統實習");

            RobotTest.ClickTabControl("資工三");
            RobotTest.AssertNumberOfRowInDataGridView("DataGridView", 11);
            RobotTest.AssertDataGridViewDoesNotContainClass("DataGridView", 11, "視窗程式設計");

            RobotTest.SetForm("CourseSelectionResultForm");
            RobotTest.AssertNumberOfRowInDataGridView("DataGridView", 2);
            RobotTest.AssertDataGridViewContainsClass("DataGridView", 2, "通訊系統實習");
            RobotTest.AssertDataGridViewContainsClass("DataGridView", 2, "視窗程式設計");

        }

        // DropClassScript
        private static void DropClassScript()
        {
            RobotTest.SetForm("CourseSelectionResultForm");

            RobotTest.ClickFirstCellOfRowInDataGridViewByRowOrder("DataGridView", "2");
            RobotTest.ClickFirstCellOfRowInDataGridViewByRowOrder("DataGridView", "1");
            RobotTest.AssertNumberOfRowInDataGridView("DataGridView", 0);

            RobotTest.SetForm("CourseSelectingForm");
            RobotTest.ClickTabControl("資工三");
            RobotTest.AssertNumberOfRowInDataGridView("DataGridView", 12);
            RobotTest.ClickTabControl("電子三甲");
            RobotTest.AssertNumberOfRowInDataGridView("DataGridView", 25);
        }

        // CourseSelectingFormSelectFailOverlapTimeTest
        [TestMethod]
        public void CourseSelectingFormSelectFailOverlapTimeTest()
        {
            SelectCourseFailDueToOverlapTimeScript();
        }

        // CourseSelectingFormSelectFailDuplicatedNameTest
        [TestMethod]
        public void CourseSelectingFormSelectFailDuplicatedNameTest()
        {
            SelectCourseFailDueToDuplicatedNameScript();
        }

        // SelectCourseFailDueToOverlapTimeScript
        private static void SelectCourseFailDueToOverlapTimeScript()
        {
            OpenCourseSelectingSystemScript();

            RobotTest.ClickTabControl("電子三甲");
            RobotTest.AssertNumberOfRowInDataGridView("DataGridView", 25);

            RobotTest.ClickFirstCellOfRowInDataGridViewByRowOrder("DataGridView", "5");
            RobotTest.ClickFirstCellOfRowInDataGridViewByRowOrder("DataGridView", "9");
            RobotTest.ClickFirstCellOfRowInDataGridViewByRowOrder("DataGridView", "13");
            RobotTest.ClickButton("確認送出");
            
            Thread.Sleep(2000);
            RobotTest.SendKeyEnterToMessageBox();

            RobotTest.AssertNumberOfRowInDataGridView("DataGridView", 25);

            RobotTest.ClickTabControl("資工三");
            RobotTest.AssertNumberOfRowInDataGridView("DataGridView", 12);

            RobotTest.SetForm("CourseSelectionResultForm");
            RobotTest.AssertNumberOfRowInDataGridView("DataGridView", 0);
        }

        // SelectCourseFailDueToDuplicatedNameScript
        private static void SelectCourseFailDueToDuplicatedNameScript()
        {
            OpenCourseSelectingSystemScript();

            RobotTest.AssertNumberOfRowInDataGridView("DataGridView", 12);

            RobotTest.ClickFirstCellOfRowInDataGridViewByRowOrder("DataGridView", "3");
            RobotTest.ClickFirstCellOfRowInDataGridViewByRowOrder("DataGridView", "4");
            RobotTest.ClickFirstCellOfRowInDataGridViewByRowOrder("DataGridView", "5");
            RobotTest.ClickButton("確認送出");

            Thread.Sleep(2000);
            RobotTest.SendKeyEnterToMessageBox();

            RobotTest.ClickTabControl("資工三");
            RobotTest.AssertNumberOfRowInDataGridView("DataGridView", 12);

            RobotTest.SetForm("CourseSelectionResultForm");
            RobotTest.AssertNumberOfRowInDataGridView("DataGridView", 0);
        }

        // CourseManagementForm
        // Scenario 1
        [TestMethod]
        public void CourseManagementFormBasicControlTest()
        {
            OpenCourseManagementSystemScript();
            RobotTest.ClickListViewByValue("CourseManagementForm", "資料庫系統");
            RobotTest.SetEdit("課號(*)", "12345");
            RobotTest.AssertButtonEnable("儲存", true);

            RobotTest.SetEdit("課號(*)", "");
            RobotTest.AssertButtonEnable("儲存", false);
        }

        // Scenario 2
        [TestMethod]
        public void CourseManagementFormBasicControlTest2()
        {
            OpenCourseManagementSystemScript();
            RobotTest.ClickListViewByValue("CourseManagementForm", "視窗程式設計");
            RobotTest.ClickDataGridViewCellByRowOrderAndColumnIndex("DataGridView", "7", 5);
            RobotTest.ClickDataGridViewCellByRowOrderAndColumnIndex("DataGridView", "6", 5);
            RobotTest.AssertButtonEnable("儲存", true);

            RobotTest.ClickDataGridViewCellByRowOrderAndColumnIndex("DataGridView", "7", 5);
            RobotTest.AssertButtonEnable("儲存", false);
        }

        // Scenario 3: assert sellecting form after editting course
        [TestMethod]
        public void CourseManagementFormBasicControlTest3()
        {
            OpenCourseManagementSystemScript();
            RobotTest.SetForm("StartUpForm");
            OpenCourseSelectingSystemScript();

            RobotTest.SetForm("CourseManagementForm");
            EditWindowsProgrammingCourse();
            RobotTest.AssertListViewContainsValue("CourseManagementForm", "物件導向分析與設計");

            RobotTest.SetForm("CourseSelectingForm");
            RobotTest.AssertNumberOfRowInDataGridView("DataGridView", 11);
            RobotTest.AssertDataGridViewDoesNotContainClass("DataGridView", 11, "視窗程式設計");
            RobotTest.AssertDataGridViewDoesNotContainClass("DataGridView", 11, "物件導向分析與設計");

            RobotTest.ClickTabControl("電子三甲");
            RobotTest.AssertNumberOfRowInDataGridView("DataGridView", 26);
            RobotTest.AssertDataGridViewContainsClass("DataGridView", 26, "物件導向分析與設計");

            RobotTest.AssertDataGridViewCell("DataGridView", 26, 1, "270915");
            RobotTest.AssertDataGridViewCell("DataGridView", 26, 2, "物件導向分析與設計");
            RobotTest.AssertDataGridViewCell("DataGridView", 26, 4, "2");
            RobotTest.AssertDataGridViewCell("DataGridView", 26, 5, "2");
            RobotTest.AssertDataGridViewCell("DataGridView", 26, 9, "3");
            RobotTest.AssertDataGridViewCell("DataGridView", 26, 10, "3");
        }

        // Scenario 4: select course and assert result form after editting course
        [TestMethod]
        public void CourseManagementFormBasicControlTest4()
        {
            OpenCourseManagementSystemScript();
            RobotTest.SetForm("StartUpForm");
            OpenCourseSelectingSystemScript();
            
            RobotTest.ClickFirstCellOfRowInDataGridViewByRowOrder("DataGridView", "10");
            RobotTest.ClickButton("確認送出");
            Thread.Sleep(2000);
            RobotTest.SendKeyEnterToMessageBox();

            RobotTest.SetForm("CourseManagementForm");
            EditWindowsProgrammingCourse();
            RobotTest.AssertListViewContainsValue("CourseManagementForm", "物件導向分析與設計");

            RobotTest.SetForm("CourseSelectionResultForm");
            RobotTest.AssertDataGridViewCell("DataGridView", 1, 1, "270915");
            RobotTest.AssertDataGridViewCell("DataGridView", 1, 2, "物件導向分析與設計");
            RobotTest.AssertDataGridViewCell("DataGridView", 1, 4, "2");
            RobotTest.AssertDataGridViewCell("DataGridView", 1, 5, "2");
            RobotTest.AssertDataGridViewCell("DataGridView", 1, 9, "3");
            RobotTest.AssertDataGridViewCell("DataGridView", 1, 10, "3");
        }

        // EditWindowsProgrammingCourse
        private static void EditWindowsProgrammingCourse()
        {
            RobotTest.ClickListViewByValue("CourseManagementForm", "視窗程式設計");
            RobotTest.SetEdit("課號(*)", "270915");
            RobotTest.SetEdit("課程名稱(*)", "物件導向分析與設計");
            RobotTest.SetEdit("學分(*)", "2");
            RobotTest.SetComboBox("時數", "2");
            RobotTest.SetComboBox("班級", "電子三甲");
            RobotTest.CleanCache();
            RobotTest.ClickDataGridViewCellByRowOrderAndColumnIndex("DataGridView", "3", 5);
            RobotTest.ClickDataGridViewCellByRowOrderAndColumnIndex("DataGridView", "4", 5);
            RobotTest.ClickDataGridViewCellByRowOrderAndColumnIndex("DataGridView", "7", 5);
            RobotTest.ClickDataGridViewCellByRowOrderAndColumnIndex("DataGridView", "3", 2);
            RobotTest.ClickDataGridViewCellByRowOrderAndColumnIndex("DataGridView", "3", 3);
            RobotTest.ClickButton("儲存");
        }

        // add course test
        [TestMethod]
        public void CourseManagementFormAddCourseTest()
        {
            OpenCourseManagementSystemScript();
            RobotTest.SetForm("StartUpForm");
            OpenCourseSelectingSystemScript();

            RobotTest.SetForm("CourseManagementForm");
            RobotTest.ClickButton("新增課程");
            RobotTest.AssertButtonEnable("新增", false);
            RobotTest.AssertButtonEnable("新增課程", false);

            RobotTest.SetEdit("課號(*)", "270915");
            RobotTest.SetEdit("課程名稱(*)", "物件導向分析與設計");
            RobotTest.SetEdit("階段(*)", "1");
            RobotTest.SetEdit("學分(*)", "2.0");
            RobotTest.SetEdit("教師(*)", "教師");
            RobotTest.SetComboBox("時數", "2");
            RobotTest.ClickDataGridViewCellByRowOrderAndColumnIndex("DataGridView", "3", 2);
            RobotTest.ClickDataGridViewCellByRowOrderAndColumnIndex("DataGridView", "3", 3);
            RobotTest.AssertButtonEnable("新增", true);
            RobotTest.ClickButton("新增");
            
            RobotTest.AssertListViewContainsValue("CourseManagementForm", "物件導向分析與設計");

            RobotTest.SetForm("CourseSelectingForm");
            RobotTest.AssertDataGridViewCell("DataGridView", 13, 1, "270915");
            RobotTest.AssertDataGridViewCell("DataGridView", 13, 2, "物件導向分析與設計");
            RobotTest.AssertDataGridViewCell("DataGridView", 13, 3, "1");
            RobotTest.AssertDataGridViewCell("DataGridView", 13, 4, "2.0");
            RobotTest.AssertDataGridViewCell("DataGridView", 13, 5, "2");
            RobotTest.AssertDataGridViewCell("DataGridView", 13, 7, "教師");
            RobotTest.AssertDataGridViewCell("DataGridView", 13, 9, "3");
            RobotTest.AssertDataGridViewCell("DataGridView", 13, 10, "3");
        }

        // import course test
        [TestMethod]
        public void CourseManagementFormImportCourseTest()
        {
            OpenCourseManagementSystemScript();
            RobotTest.SetForm("StartUpForm");
            OpenCourseSelectingSystemScript();

            RobotTest.SetForm("CourseManagementForm");
            RobotTest.SetDelayBetweenActions(5500);
            RobotTest.ClickButton("匯入資工系全部課程");
            RobotTest.SetDelayBetweenActions(500);

            RobotTest.AssertListViewContainsValue("CourseManagementForm", "物理");
            RobotTest.AssertListViewContainsValue("CourseManagementForm", "網路程式設計");
            RobotTest.ClickListViewByValue("CourseManagementForm", "網路程式設計");
            RobotTest.AssertListViewContainsValue("CourseManagementForm", "社群媒體與對話機器人系統設計");

            RobotTest.SetForm("CourseSelectingForm");
            RobotTest.ClickTabControl("資工一");
            RobotTest.AssertNumberOfRowInDataGridView("DataGridView", 13);
            RobotTest.ClickTabControl("資工二");
            RobotTest.AssertNumberOfRowInDataGridView("DataGridView", 12);
            RobotTest.ClickTabControl("資工四");
            RobotTest.AssertNumberOfRowInDataGridView("DataGridView", 12);
            RobotTest.ClickTabControl("資工所");
            RobotTest.AssertNumberOfRowInDataGridView("DataGridView", 18);
        }

        // add class test
        [TestMethod]
        public void CourseManagementFormAddClassTest()
        {
            OpenCourseManagementSystemScript();
            RobotTest.SetForm("StartUpForm");
            OpenCourseSelectingSystemScript();

            RobotTest.SetForm("CourseManagementForm");
            RobotTest.ClickTabControl("班級管理");
            RobotTest.CleanCache();
            RobotTest.ClickListViewByValue("CourseManagementForm", "資工三");
            RobotTest.AssertEdit("班級名稱(*)", "資工三");
            RobotTest.AssertButtonEnable("新增班級", true);
            RobotTest.ClickButton("新增班級");
            RobotTest.AssertButtonEnable("新增", false);

            RobotTest.SetEdit("班級名稱(*)", "電資三");
            RobotTest.AssertButtonEnable("新增", true);

            RobotTest.ClickButton("新增");

            RobotTest.AssertButtonEnable("新增班級", true);
            RobotTest.AssertButtonEnable("新增", false);
            RobotTest.ClickListViewByValue("CourseManagementForm", "資工三");
            RobotTest.AssertButtonEnable("新增班級", true);
            RobotTest.AssertListViewContainsValue("CourseManagementForm", "電資三");

            RobotTest.SetForm("CourseSelectingForm");
            RobotTest.ClickTabControl("電資三");
        }

        // Cleanup
        [TestCleanup()]
        public void Cleanup()
        {
            RobotTest.CleanUp();
        }

    }
}