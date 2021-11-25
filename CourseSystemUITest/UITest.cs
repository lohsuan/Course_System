using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading;

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
        // StartUpFormButtonControlTest
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

        // OpenCourseSelectingSystemScript
        private static void OpenCourseSelectingSystemScript()
        {
            Robot.ClickButton("Course Selecting System");
            Robot.SetForm("CourseSelectingForm");

            Robot.AssertNumberOfRowInDataGridView("DataGridView", 12);
            Robot.AssertButtonEnable("查看選課結果", true);

            Robot.ClickButton("查看選課結果");
            Robot.AssertButtonEnable("查看選課結果", false);
            Robot.AssertButtonEnable("確認送出", false);
        }

        // OpenCourseManagementSystemScript
        private static void OpenCourseManagementSystemScript()
        {
            Robot.ClickButton("Course Management System");
            Robot.SetForm("CourseManagementForm");

            Robot.AssertButtonEnable("新增課程", true);
            Robot.AssertButtonEnable("匯入資工系全部課程", true);
            Robot.AssertButtonEnable("儲存", false);
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

            Robot.ClickFirstCellOfRowInDataGridViewByRowOrder("DataGridView", "10");
            Robot.AssertButtonEnable("確認送出", true);

            Robot.ClickTabControl("電子三甲");
            Robot.AssertNumberOfRowInDataGridView("DataGridView", 25);

            Robot.ClickFirstCellOfRowInDataGridViewByRowOrder("DataGridView", "4");
            Robot.ClickButton("確認送出");
            Robot.AssertButtonEnable("確認送出", false);
            Thread.Sleep(2000);
            //Robot.AssertText("加選成功", "加選成功");
            Robot.SendKeyEnterToMessageBox();

            Robot.AssertNumberOfRowInDataGridView("DataGridView", 24);
            Robot.AssertDataGridViewDoesNotContainClass("DataGridView", 24, "通訊系統實習");

            Robot.ClickTabControl("資工三");
            Robot.AssertNumberOfRowInDataGridView("DataGridView", 11);
            Robot.AssertDataGridViewDoesNotContainClass("DataGridView", 11, "視窗程式設計");

            Robot.SetForm("CourseSelectionResultForm");
            Robot.AssertNumberOfRowInDataGridView("DataGridView", 2);
            Robot.AssertDataGridViewContainsClass("DataGridView", 2, "通訊系統實習");
            Robot.AssertDataGridViewContainsClass("DataGridView", 2, "視窗程式設計");

        }

        // DropClassScript
        private static void DropClassScript()
        {
            Robot.SetForm("CourseSelectionResultForm");

            Robot.ClickFirstCellOfRowInDataGridViewByRowOrder("DataGridView", "2");
            Robot.ClickFirstCellOfRowInDataGridViewByRowOrder("DataGridView", "1");
            Robot.AssertNumberOfRowInDataGridView("DataGridView", 0);

            Robot.SetForm("CourseSelectingForm");
            Robot.ClickTabControl("資工三");
            Robot.AssertNumberOfRowInDataGridView("DataGridView", 12);
            Robot.ClickTabControl("電子三甲");
            Robot.AssertNumberOfRowInDataGridView("DataGridView", 25);
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

            Robot.ClickTabControl("電子三甲");
            Robot.AssertNumberOfRowInDataGridView("DataGridView", 25);

            Robot.ClickFirstCellOfRowInDataGridViewByRowOrder("DataGridView", "5");
            Robot.ClickFirstCellOfRowInDataGridViewByRowOrder("DataGridView", "9");
            Robot.ClickFirstCellOfRowInDataGridViewByRowOrder("DataGridView", "13");
            Robot.ClickButton("確認送出");
            
            Thread.Sleep(2000);
            //Robot.AssertText("", "加選失敗\n\n衝堂 : 「291702-體育」、「291703-博雅選修課程」\n");
            Robot.SendKeyEnterToMessageBox();

            Robot.AssertNumberOfRowInDataGridView("DataGridView", 25);

            Robot.ClickTabControl("資工三");
            Robot.AssertNumberOfRowInDataGridView("DataGridView", 12);

            Robot.SetForm("CourseSelectionResultForm");
            Robot.AssertNumberOfRowInDataGridView("DataGridView", 0);
        }

        // SelectCourseFailDueToDuplicatedNameScript
        private static void SelectCourseFailDueToDuplicatedNameScript()
        {
            OpenCourseSelectingSystemScript();

            Robot.AssertNumberOfRowInDataGridView("DataGridView", 12);

            Robot.ClickFirstCellOfRowInDataGridViewByRowOrder("DataGridView", "3");
            Robot.ClickFirstCellOfRowInDataGridViewByRowOrder("DataGridView", "4");
            Robot.ClickFirstCellOfRowInDataGridViewByRowOrder("DataGridView", "5");
            Robot.ClickButton("確認送出");

            Thread.Sleep(2000);
            //Robot.AssertText("", "加選失敗\n\n衝堂 : 「291702-體育」、「291703-博雅選修課程」\n");
            Robot.SendKeyEnterToMessageBox();

            Robot.ClickTabControl("資工三");
            Robot.AssertNumberOfRowInDataGridView("DataGridView", 12);

            Robot.SetForm("CourseSelectionResultForm");
            Robot.AssertNumberOfRowInDataGridView("DataGridView", 0);
        }

        // CourseManagementForm
        // Scenario 1
        [TestMethod]
        public void CourseManagementFormBasicControlTest()
        {
            OpenCourseManagementSystemScript();
            Robot.ClickListViewByValue("CourseManagementForm", "資料庫系統");
            Robot.SetEdit("課號(*)", "12345");
            Robot.AssertButtonEnable("儲存", true);

            Robot.SetEdit("課號(*)", "");
            Robot.AssertButtonEnable("儲存", false);
        }

        // Scenario 2
        [TestMethod]
        public void CourseManagementFormBasicControlTest2()
        {
            OpenCourseManagementSystemScript();
            Robot.ClickListViewByValue("CourseManagementForm", "視窗程式設計");
            Robot.ClickDataGridViewCellByRowOrderAndColumnIndex("DataGridView", "7", 5);
            Robot.ClickDataGridViewCellByRowOrderAndColumnIndex("DataGridView", "6", 5);
            Robot.AssertButtonEnable("儲存", true);

            Robot.ClickDataGridViewCellByRowOrderAndColumnIndex("DataGridView", "7", 5);
            Robot.AssertButtonEnable("儲存", false);
        }

        // Scenario 3: assert sellecting form after editting course
        [TestMethod]
        public void CourseManagementFormBasicControlTest3()
        {
            OpenCourseManagementSystemScript();
            Robot.SetForm("StartUpForm");
            OpenCourseSelectingSystemScript();

            Robot.SetForm("CourseManagementForm");
            EditWindowsProgrammingCourse();
            Robot.AssertListViewContainsValue("CourseManagementForm", "物件導向分析與設計");

            Robot.SetForm("CourseSelectingForm");
            Robot.AssertNumberOfRowInDataGridView("DataGridView", 11);
            Robot.AssertDataGridViewDoesNotContainClass("DataGridView", 11, "視窗程式設計");
            Robot.AssertDataGridViewDoesNotContainClass("DataGridView", 11, "物件導向分析與設計");

            Robot.ClickTabControl("電子三甲");
            Robot.AssertNumberOfRowInDataGridView("DataGridView", 26);
            Robot.AssertDataGridViewContainsClass("DataGridView", 26, "物件導向分析與設計");

            Robot.AssertDataGridViewCell("DataGridView", 26, 1, "270915");
            Robot.AssertDataGridViewCell("DataGridView", 26, 2, "物件導向分析與設計");
            Robot.AssertDataGridViewCell("DataGridView", 26, 4, "2");
            Robot.AssertDataGridViewCell("DataGridView", 26, 5, "2");
            Robot.AssertDataGridViewCell("DataGridView", 26, 9, "3");
            Robot.AssertDataGridViewCell("DataGridView", 26, 10, "3");
        }

        // Scenario 4: select course and assert result form after editting course
        [TestMethod]
        public void CourseManagementFormBasicControlTest4()
        {
            OpenCourseManagementSystemScript();
            Robot.SetForm("StartUpForm");
            OpenCourseSelectingSystemScript();
            
            Robot.ClickFirstCellOfRowInDataGridViewByRowOrder("DataGridView", "10");
            Robot.ClickButton("確認送出");
            Thread.Sleep(2000);
            Robot.SendKeyEnterToMessageBox();

            Robot.SetForm("CourseManagementForm");
            EditWindowsProgrammingCourse();
            Robot.AssertListViewContainsValue("CourseManagementForm", "物件導向分析與設計");

            Robot.SetForm("CourseSelectionResultForm");
            Robot.AssertDataGridViewCell("DataGridView", 1, 1, "270915");
            Robot.AssertDataGridViewCell("DataGridView", 1, 2, "物件導向分析與設計");
            Robot.AssertDataGridViewCell("DataGridView", 1, 4, "2");
            Robot.AssertDataGridViewCell("DataGridView", 1, 5, "2");
            Robot.AssertDataGridViewCell("DataGridView", 1, 9, "3");
            Robot.AssertDataGridViewCell("DataGridView", 1, 10, "3");
        }

        // EditWindowsProgrammingCourse
        private static void EditWindowsProgrammingCourse()
        {
            Robot.ClickListViewByValue("CourseManagementForm", "視窗程式設計");
            Robot.SetEdit("課號(*)", "270915");
            Robot.SetEdit("課程名稱(*)", "物件導向分析與設計");
            Robot.SetEdit("學分(*)", "2");
            Robot.SetComboBox("時數", "2");
            Robot.SetComboBox("班級", "電子三甲");
            Robot.CleanCache();
            Robot.ClickDataGridViewCellByRowOrderAndColumnIndex("DataGridView", "3", 5);
            Robot.ClickDataGridViewCellByRowOrderAndColumnIndex("DataGridView", "4", 5);
            Robot.ClickDataGridViewCellByRowOrderAndColumnIndex("DataGridView", "7", 5);
            Robot.ClickDataGridViewCellByRowOrderAndColumnIndex("DataGridView", "3", 2);
            Robot.ClickDataGridViewCellByRowOrderAndColumnIndex("DataGridView", "3", 3);
            Robot.ClickButton("儲存");
        }

        // add course test
        [TestMethod]
        public void CourseManagementFormAddCourseTest()
        {
            OpenCourseManagementSystemScript();
            Robot.SetForm("StartUpForm");
            OpenCourseSelectingSystemScript();

            Robot.SetForm("CourseManagementForm");
            Robot.ClickButton("新增課程");
            Robot.AssertButtonEnable("新增", false);
            Robot.AssertButtonEnable("新增課程", false);

            Robot.SetEdit("課號(*)", "270915");
            Robot.SetEdit("課程名稱(*)", "物件導向分析與設計");
            Robot.SetEdit("階段(*)", "1");
            Robot.SetEdit("學分(*)", "2.0");
            Robot.SetEdit("教師(*)", "教師");
            Robot.SetComboBox("時數", "2");
            Robot.ClickDataGridViewCellByRowOrderAndColumnIndex("DataGridView", "3", 2);
            Robot.ClickDataGridViewCellByRowOrderAndColumnIndex("DataGridView", "3", 3);
            Robot.AssertButtonEnable("新增", true);
            Robot.ClickButton("新增");
            
            Robot.AssertListViewContainsValue("CourseManagementForm", "物件導向分析與設計");

            Robot.SetForm("CourseSelectingForm");
            Robot.AssertDataGridViewCell("DataGridView", 13, 1, "270915");
            Robot.AssertDataGridViewCell("DataGridView", 13, 2, "物件導向分析與設計");
            Robot.AssertDataGridViewCell("DataGridView", 13, 3, "1");
            Robot.AssertDataGridViewCell("DataGridView", 13, 4, "2.0");
            Robot.AssertDataGridViewCell("DataGridView", 13, 5, "2");
            Robot.AssertDataGridViewCell("DataGridView", 13, 7, "教師");
            Robot.AssertDataGridViewCell("DataGridView", 13, 9, "3");
            Robot.AssertDataGridViewCell("DataGridView", 13, 10, "3");
        }

        // import course test
        [TestMethod]
        public void CourseManagementFormImportCourseTest()
        {
            OpenCourseManagementSystemScript();
            Robot.SetForm("StartUpForm");
            OpenCourseSelectingSystemScript();

            Robot.SetForm("CourseManagementForm");
            Robot.SetDelayBetweenActions(5500);
            Robot.ClickButton("匯入資工系全部課程");
            Robot.SetDelayBetweenActions(500);

            Robot.AssertListViewContainsValue("CourseManagementForm", "物理");
            Robot.AssertListViewContainsValue("CourseManagementForm", "網路程式設計");
            Robot.ClickListViewByValue("CourseManagementForm", "網路程式設計");
            Robot.AssertListViewContainsValue("CourseManagementForm", "社群媒體與對話機器人系統設計");

            Robot.SetForm("CourseSelectingForm");
            Robot.ClickTabControl("資工一");
            Robot.AssertNumberOfRowInDataGridView("DataGridView", 13);
            Robot.ClickTabControl("資工二");
            Robot.AssertNumberOfRowInDataGridView("DataGridView", 12);
            Robot.ClickTabControl("資工四");
            Robot.AssertNumberOfRowInDataGridView("DataGridView", 12);
            Robot.ClickTabControl("資工所");
            Robot.AssertNumberOfRowInDataGridView("DataGridView", 18);
        }

        // add class test
        [TestMethod]
        public void CourseManagementFormAddClassTest()
        {
            OpenCourseManagementSystemScript();
            Robot.SetForm("StartUpForm");
            OpenCourseSelectingSystemScript();

            Robot.SetForm("CourseManagementForm");
            Robot.ClickTabControl("班級管理");
            Robot.CleanCache();
            Robot.ClickListViewByValue("CourseManagementForm", "資工三");
            Robot.AssertEdit("班級名稱(*)", "資工三");
            Robot.AssertButtonEnable("新增班級", true);
            Robot.ClickButton("新增班級");
            Robot.AssertButtonEnable("新增", false);

            Robot.SetEdit("班級名稱(*)", "電資三");
            Robot.AssertButtonEnable("新增", true);

            Robot.ClickButton("新增");

            Robot.AssertButtonEnable("新增班級", true);
            Robot.AssertButtonEnable("新增", false);
            Robot.ClickListViewByValue("CourseManagementForm", "資工三");
            Robot.AssertButtonEnable("新增班級", true);
            Robot.AssertListViewContainsValue("CourseManagementForm", "電資三");

            Robot.SetForm("CourseSelectingForm");
            Robot.ClickTabControl("電資三");
        }

        // Cleanup
        [TestCleanup()]
        public void Cleanup()
        {
            Robot.CleanUp();
        }

    }
}