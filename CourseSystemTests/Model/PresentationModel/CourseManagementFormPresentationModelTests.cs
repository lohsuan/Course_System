using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CourseSystem.Tests
{
    /// <summary>
    /// Total Test amount: 38
    /// </summary>
    [TestClass()]
    public class CourseManagementFormPresentationModelTests
    {
        CourseManagementFormPresentationModel _viewModel;

        // TestInitialize
        [TestInitialize]
        public void Initialize()
        {
            Model model = new Model();
            _viewModel = new CourseManagementFormPresentationModel(model);
        }

        // CourseManagementFormPresentationModelTest
        [TestMethod()]
        public void CourseManagementFormPresentationModelTest()
        {
            Assert.IsNotNull(_viewModel);
        }

        // GetAllCourseNameTest
        [TestMethod()]
        public void GetAllCourseNameTest()
        {
            Assert.AreEqual("班週會及導師時間", _viewModel.GetAllCourseName()[0]);
            Assert.AreEqual("機器學習", _viewModel.GetAllCourseName()[_viewModel.GetAllCourseName().Count-1]);
        }

        // UpdateSelectedCourseTest
        [TestMethod()]
        public void UpdateSelectedCourseTest()
        {
            _viewModel.UpdateSelectedCourse(0);
            Assert.AreEqual("班週會及導師時間", _viewModel.GetName());

            _viewModel.UpdateSelectedCourse(_viewModel.GetAllCourseName().Count - 1);
            Assert.AreEqual("機器學習", _viewModel.GetName());
        }

        // IsNumberInputTest
        [TestMethod()]
        public void IsNumberInputTest()
        {
            Assert.IsTrue(_viewModel.IsNumberInput('1'));
            Assert.IsTrue(_viewModel.IsNumberInput('.'));
            Assert.IsFalse(_viewModel.IsNumberInput('k'));
        }

        // IsSaveButtonEnableTest
        [TestMethod()]
        public void IsSaveButtonEnableTest()
        {
            _viewModel.UpdateSelectedCourse(4);
            _viewModel.UpdateCheckedCourse(true);
            _viewModel.SetCourseEditNumber("");

            Assert.IsFalse(_viewModel.IsSaveButtonEnable(3));

            _viewModel.SetCourseEditNumber("123");
            Assert.IsFalse(_viewModel.IsSaveButtonEnable(3));

            _viewModel.UpdateCheckedCourse(true);
            _viewModel.UpdateCheckedCourse(true);
            Assert.IsTrue(_viewModel.IsSaveButtonEnable(3));
        }

        // IsCourseInfoMeetNotNullRequireTest
        [TestMethod()]
        public void IsCourseInfoMeetNotNullRequireTest()
        {
            _viewModel.UpdateSelectedCourse(4);
            _viewModel.SetCourseEditNumber("");
            Assert.IsFalse(_viewModel.IsCourseInfoMeetNotNullRequire());
            _viewModel.SetCourseEditNumber("123");
            Assert.IsTrue(_viewModel.IsCourseInfoMeetNotNullRequire());
        }

        // IsCheckedClassTimeEqualToHourTest
        [TestMethod()]
        public void IsCheckedClassTimeEqualToHourTest()
        {
            _viewModel.UpdateSelectedCourse(0);
            _viewModel.GetClassTime();
            _viewModel.UpdateCheckedCourse(true);
            Assert.IsFalse(_viewModel.IsCheckedClassTimeEqualToHour(2));

            _viewModel.UpdateCheckedCourse(false);
            Assert.IsTrue(_viewModel.IsCheckedClassTimeEqualToHour(2));
        }

        // GetNumberTest
        [TestMethod()]
        public void GetCourseStatusTest()
        {
            _viewModel.UpdateSelectedCourse(4);
            Assert.AreEqual(0, _viewModel.GetCourseStatus());
        }

        // GetNumberTest
        [TestMethod()]
        public void GetNumberTest()
        {
            _viewModel.UpdateSelectedCourse(4);
            Assert.AreEqual("291705", _viewModel.GetNumber());
        }

        // GetNameTest
        [TestMethod()]
        public void GetNameTest()
        {
            _viewModel.UpdateSelectedCourse(4);
            Assert.AreEqual("資料庫系統", _viewModel.GetName());
        }

        // GetStageTest
        [TestMethod()]
        public void GetStageTest()
        {
            _viewModel.UpdateSelectedCourse(4);
            Assert.AreEqual("1", _viewModel.GetStage());
        }

        // GetCreditTest
        [TestMethod()]
        public void GetCreditTest()
        {
            _viewModel.UpdateSelectedCourse(4);
            Assert.AreEqual("3.0", _viewModel.GetCredit());
        }

        // GetTeacherTest
        [TestMethod()]
        public void GetTeacherTest()
        {
            _viewModel.UpdateSelectedCourse(4);
            Assert.AreEqual("劉建宏", _viewModel.GetTeacher());
        }

        // GetRequireTypeTest
        [TestMethod()]
        public void GetRequireTypeTest()
        {
            _viewModel.UpdateSelectedCourse(4);
            Assert.AreEqual("▲", _viewModel.GetRequireType());
        }

        // GetTeacherAssistantTest
        [TestMethod()]
        public void GetTeacherAssistantTest()
        {
            _viewModel.UpdateSelectedCourse(4);
            Assert.AreEqual("", _viewModel.GetTeacherAssistant());
        }

        // GetLanguageTest
        [TestMethod()]
        public void GetLanguageTest()
        {
            _viewModel.UpdateSelectedCourse(4);
            Assert.AreEqual("", _viewModel.GetLanguage());
        }

        // GetSyllabusTest
        [TestMethod()]
        public void GetSyllabusTest()
        {
            _viewModel.UpdateSelectedCourse(4);
            Assert.AreEqual("◎", _viewModel.GetSyllabus());
        }

        // GetHourTest
        [TestMethod()]
        public void GetHourTest()
        {
            _viewModel.UpdateSelectedCourse(4);
            Assert.AreEqual("3", _viewModel.GetHour());
        }

        // GetClassTest
        [TestMethod()]
        public void GetClassTest()
        {
            _viewModel.UpdateSelectedCourse(4);
            Assert.AreEqual("資工三", _viewModel.GetClass());
        }

        // GetClassTimeTest
        [TestMethod()]
        public void GetAllClassNameTest()
        {
            Assert.AreEqual("資工三", _viewModel.GetAllClassName()[0]);
            Assert.AreEqual("電子三甲", _viewModel.GetAllClassName()[1]);
        }

        // GetClassTimeTest
        [TestMethod()]
        public void GetClassTimeTest()
        {
            _viewModel.UpdateSelectedCourse(4);
            Assert.AreEqual("2 7", _viewModel.GetClassTime()[0]);
            Assert.AreEqual("3 8", _viewModel.GetClassTime()[1]);
            Assert.AreEqual("3 9", _viewModel.GetClassTime()[2]);
        }

        // UpdateCheckedCourseTest
        [TestMethod()]
        public void UpdateCheckedCourseTest()
        {
            _viewModel.UpdateSelectedCourse(4);
            var temp = _viewModel.GetClassTime();
            _viewModel.UpdateCheckedCourse(true);
            Assert.IsFalse(_viewModel.IsCheckedClassTimeEqualToHour(3));

            _viewModel.UpdateCheckedCourse(false);
            Assert.IsTrue(_viewModel.IsCheckedClassTimeEqualToHour(3));

            _viewModel.UpdateCheckedCourse(true);
            Assert.IsFalse(_viewModel.IsCheckedClassTimeEqualToHour(3));
        }

        // SetCourseEditClassTimeTest
        [TestMethod()]
        public void SetCourseEditClassTimeTest()
        {
            _viewModel.UpdateSelectedCourse(4);
            string[] classTime = { "", "3 4", "1", "", "", "", "" };
            _viewModel.SetCourseEditClassTime(classTime);
            _viewModel.UpdateOrAddCourse();
            Assert.AreEqual("1 3", _viewModel.GetClassTime()[0]);
            Assert.AreEqual("1 4", _viewModel.GetClassTime()[1]);
            Assert.AreEqual("2 1", _viewModel.GetClassTime()[2]);
        }

        // SetCourseEditNumberTest
        [TestMethod()]
        public void SetCourseEditCourseStatusTest()
        {
            _viewModel.UpdateSelectedCourse(4);
            _viewModel.SetCourseEditCourseStatus(1);
            _viewModel.UpdateOrAddCourse();
            Assert.AreEqual(1, _viewModel.GetCourseStatus());
        }

        // SetCourseEditNumberTest
        [TestMethod()]
        public void SetCourseEditNumberTest()
        {
            _viewModel.UpdateSelectedCourse(4);
            _viewModel.SetCourseEditNumber("123456");
            _viewModel.UpdateOrAddCourse();
            Assert.AreEqual("123456", _viewModel.GetNumber());
        }

        // SetCourseEditNameTest
        [TestMethod()]
        public void SetCourseEditNameTest()
        {
            _viewModel.UpdateSelectedCourse(4);
            _viewModel.SetCourseEditName("程式設計");
            _viewModel.UpdateOrAddCourse();
            Assert.AreEqual("程式設計", _viewModel.GetName());
        }

        // SetCourseEditStageTest
        [TestMethod()]
        public void SetCourseEditStageTest()
        {
            _viewModel.UpdateSelectedCourse(4);
            _viewModel.SetCourseEditStage("2");
            _viewModel.UpdateOrAddCourse();
            Assert.AreEqual("2", _viewModel.GetStage());
        }

        // SetCourseEditCreditTest
        [TestMethod()]
        public void SetCourseEditCreditTest()
        {
            _viewModel.UpdateSelectedCourse(4);
            _viewModel.SetCourseEditCredit("2.0");
            _viewModel.UpdateOrAddCourse();
            Assert.AreEqual("2.0", _viewModel.GetCredit());
        }

        // SetCourseEditTeacherTest
        [TestMethod()]
        public void SetCourseEditTeacherTest()
        {
            _viewModel.UpdateSelectedCourse(4);
            _viewModel.SetCourseEditTeacher("老師");
            _viewModel.UpdateOrAddCourse();
            Assert.AreEqual("老師", _viewModel.GetTeacher());
        }

        // SetCourseEditRequireTypeTest
        [TestMethod()]
        public void SetCourseEditRequireTypeTest()
        {
            _viewModel.UpdateSelectedCourse(4);
            _viewModel.SetCourseEditRequireType("★");
            _viewModel.UpdateOrAddCourse();
            Assert.AreEqual("★", _viewModel.GetRequireType());
        }

        // SetCourseEditTeacherAssistantTest
        [TestMethod()]
        public void SetCourseEditTeacherAssistantTest()
        {
            _viewModel.UpdateSelectedCourse(4);
            _viewModel.SetCourseEditTeacherAssistant("assistant");
            _viewModel.UpdateOrAddCourse();
            Assert.AreEqual("assistant", _viewModel.GetTeacherAssistant());
        }

        // SetCourseEditLanguageTest
        [TestMethod()]
        public void SetCourseEditLanguageTest()
        {
            _viewModel.UpdateSelectedCourse(4);
            _viewModel.SetCourseEditLanguage("英語");
            _viewModel.UpdateOrAddCourse();
            Assert.AreEqual("英語", _viewModel.GetLanguage());
        }

        // SetCourseEditSyllabusTest
        [TestMethod()]
        public void SetCourseEditSyllabusTest()
        {
            _viewModel.UpdateSelectedCourse(4);
            _viewModel.SetCourseEditSyllabus("123");
            _viewModel.UpdateOrAddCourse();
            Assert.AreEqual("123", _viewModel.GetSyllabus());
        }

        // SetCourseEditHourTest
        [TestMethod()]
        public void SetCourseEditHourTest()
        {
            _viewModel.UpdateSelectedCourse(4);
            _viewModel.SetCourseEditHour("1");
            _viewModel.UpdateOrAddCourse();
            Assert.AreEqual("1", _viewModel.GetHour());
        }

        // SetCourseEditClassTest
        [TestMethod()]
        public void SetCourseEditClassTest()
        {
            _viewModel.UpdateSelectedCourse(4);
            _viewModel.SetCourseEditClass("電子三甲");
            _viewModel.UpdateOrAddCourse();
            Assert.AreEqual("電子三甲", _viewModel.GetClass());
        }

        // UpdateOrAddCourseTest
        [TestMethod()]
        public void UpdateOrAddCourseTest()
        {
            _viewModel.UpdateSelectedCourse(4);
            _viewModel.SetCourseEditClass("電子三甲");
            _viewModel.UpdateOrAddCourse();
            Assert.AreEqual("電子三甲", _viewModel.GetClass());

            _viewModel.AddCourseMode();
            _viewModel.SetCourseEditNumber("123456");
            _viewModel.SetCourseEditName("程式設計");
            _viewModel.SetCourseEditStage("2");
            _viewModel.SetCourseEditTeacher("老師");
            _viewModel.SetCourseEditRequireType("★");
            _viewModel.SetCourseEditClass("電子三甲");
            _viewModel.UpdateOrAddCourse();
            Assert.AreEqual("程式設計", _viewModel.GetAllCourseName()[_viewModel.GetAllCourseName().Count - 1]);
        }

        // SetCourseEditClassTest
        [TestMethod()]
        public void GetDepartmentNameTest()
        {
            CourseInfoDto courseInfoDto = new CourseInfoDto();
            Assert.AreEqual(null, _viewModel.GetDepartmentName(courseInfoDto));
        }

        // AddCourseModeTest
        [TestMethod()]
        public void AddCourseModeTest()
        {
            _viewModel.AddCourseMode();
            Assert.AreEqual(null, _viewModel.GetNumber());
            Assert.AreEqual(null, _viewModel.GetName());
            Assert.AreEqual(null, _viewModel.GetStage());
            Assert.AreEqual(null, _viewModel.GetCredit());
            Assert.AreEqual(null, _viewModel.GetTeacher());
            Assert.AreEqual(null, _viewModel.GetRequireType());
            Assert.AreEqual(null, _viewModel.GetTeacherAssistant());
            Assert.AreEqual(null, _viewModel.GetLanguage());
            Assert.AreEqual(null, _viewModel.GetSyllabus());
            Assert.AreEqual(null, _viewModel.GetHour());
            Assert.AreEqual(null, _viewModel.GetClass());
        }
    }
}