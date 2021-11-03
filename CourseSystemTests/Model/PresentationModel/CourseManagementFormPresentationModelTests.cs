using Microsoft.VisualStudio.TestTools.UnitTesting;
using CourseSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseSystem.Tests
{
    [TestClass()]
    public class CourseManagementFormPresentationModelTests
    {
        CourseManagementFormPresentationModel _viewmodel;
        PrivateObject _viewmodelPrivate;

        //init
        [TestInitialize]
        public void Initialize()
        {
            Model model = new Model();
            _viewmodel = new CourseManagementFormPresentationModel(model);
            _viewmodelPrivate = new PrivateObject(_viewmodel);
        }

        // CourseManagementFormPresentationModelTest
        [TestMethod()]
        public void CourseManagementFormPresentationModelTest()
        {
            Assert.IsNotNull(_viewmodel);
        }

        // GetAllCourseNameTest
        [TestMethod()]
        public void GetAllCourseNameTest()
        {
            Assert.AreEqual("班週會及導師時間", _viewmodel.GetAllCourseName()[0]);
            Assert.AreEqual("機器學習", _viewmodel.GetAllCourseName()[_viewmodel.GetAllCourseName().Count-1]);
        }

        // UpdateSelectedCourseTest
        [TestMethod()]
        public void UpdateSelectedCourseTest()
        {
            _viewmodel.UpdateSelectedCourse(0);
            Assert.AreEqual("班週會及導師時間", _viewmodel.GetName());

            _viewmodel.UpdateSelectedCourse(_viewmodel.GetAllCourseName().Count - 1);
            Assert.AreEqual("機器學習", _viewmodel.GetName());
        }

        // IsNumberInputTest
        [TestMethod()]
        public void IsNumberInputTest()
        {
            Assert.IsTrue(_viewmodel.IsNumberInput('1'));
            Assert.IsTrue(_viewmodel.IsNumberInput('.'));
            Assert.IsFalse(_viewmodel.IsNumberInput('k'));
        }

        // IsSaveButtonEnableTest
        [TestMethod()]
        public void IsSaveButtonEnableTest()
        {
            _viewmodel.UpdateSelectedCourse(4);
            _viewmodel.UpdateCheckedCourse(true);
            _viewmodel.SetCourseEditNumber("");

            Assert.IsFalse(_viewmodel.IsSaveButtonEnable(3));

            _viewmodel.SetCourseEditNumber("123");
            Assert.IsFalse(_viewmodel.IsSaveButtonEnable(3));

            _viewmodel.UpdateCheckedCourse(true);
            _viewmodel.UpdateCheckedCourse(true);
            Assert.IsTrue(_viewmodel.IsSaveButtonEnable(3));
        }

        // IsCourseInfoMeetNotNullRequireTest
        [TestMethod()]
        public void IsCourseInfoMeetNotNullRequireTest()
        {
            _viewmodel.UpdateSelectedCourse(4);
            _viewmodel.SetCourseEditNumber("");
            Assert.IsFalse(_viewmodel.IsCourseInfoMeetNotNullRequire());
            _viewmodel.SetCourseEditNumber("123");
            Assert.IsTrue(_viewmodel.IsCourseInfoMeetNotNullRequire());
        }

        // IsCheckedClassTimeEqualToHourTest
        [TestMethod()]
        public void IsCheckedClassTimeEqualToHourTest()
        {
            _viewmodel.UpdateSelectedCourse(0);
            _viewmodel.GetClassTime();
            _viewmodel.UpdateCheckedCourse(true);
            Assert.IsFalse(_viewmodel.IsCheckedClassTimeEqualToHour(2));

            _viewmodel.UpdateCheckedCourse(false);
            Assert.IsTrue(_viewmodel.IsCheckedClassTimeEqualToHour(2));
        }

        // GetNumberTest
        [TestMethod()]
        public void GetNumberTest()
        {
            _viewmodel.UpdateSelectedCourse(4);
            Assert.AreEqual("291705", _viewmodel.GetNumber());
        }

        // GetNameTest
        [TestMethod()]
        public void GetNameTest()
        {
            _viewmodel.UpdateSelectedCourse(4);
            Assert.AreEqual("資料庫系統", _viewmodel.GetName());
        }

        // GetStageTest
        [TestMethod()]
        public void GetStageTest()
        {
            _viewmodel.UpdateSelectedCourse(4);
            Assert.AreEqual("1", _viewmodel.GetStage());
        }

        // GetCreditTest
        [TestMethod()]
        public void GetCreditTest()
        {
            _viewmodel.UpdateSelectedCourse(4);
            Assert.AreEqual("3.0", _viewmodel.GetCredit());
        }

        // GetTeacherTest
        [TestMethod()]
        public void GetTeacherTest()
        {
            _viewmodel.UpdateSelectedCourse(4);
            Assert.AreEqual("劉建宏", _viewmodel.GetTeacher());
        }

        // GetRequireTypeTest
        [TestMethod()]
        public void GetRequireTypeTest()
        {
            _viewmodel.UpdateSelectedCourse(4);
            Assert.AreEqual("▲", _viewmodel.GetRequireType());
        }

        // GetTeacherAssistantTest
        [TestMethod()]
        public void GetTeacherAssistantTest()
        {
            _viewmodel.UpdateSelectedCourse(4);
            Assert.AreEqual("", _viewmodel.GetTeacherAssistant());
        }

        // GetLanguageTest
        [TestMethod()]
        public void GetLanguageTest()
        {
            _viewmodel.UpdateSelectedCourse(4);
            Assert.AreEqual("", _viewmodel.GetLanguage());
        }

        // GetSyllabusTest
        [TestMethod()]
        public void GetSyllabusTest()
        {
            _viewmodel.UpdateSelectedCourse(4);
            Assert.AreEqual("◎", _viewmodel.GetSyllabus());
        }

        // GetHourTest
        [TestMethod()]
        public void GetHourTest()
        {
            _viewmodel.UpdateSelectedCourse(4);
            Assert.AreEqual("3", _viewmodel.GetHour());
        }

        // GetClassTest
        [TestMethod()]
        public void GetClassTest()
        {
            _viewmodel.UpdateSelectedCourse(4);
            Assert.AreEqual("資工三", _viewmodel.GetClass());
        }

        // GetClassTimeTest
        [TestMethod()]
        public void GetClassTimeTest()
        {
            _viewmodel.UpdateSelectedCourse(4);
            Assert.AreEqual("2 7", _viewmodel.GetClassTime()[0]);
            Assert.AreEqual("3 8", _viewmodel.GetClassTime()[1]);
            Assert.AreEqual("3 9", _viewmodel.GetClassTime()[2]);
        }

        // UpdateCheckedCourseTest
        [TestMethod()]
        public void UpdateCheckedCourseTest()
        {
            _viewmodel.UpdateSelectedCourse(4);
            var temp = _viewmodel.GetClassTime();
            _viewmodel.UpdateCheckedCourse(true);
            Assert.IsFalse(_viewmodel.IsCheckedClassTimeEqualToHour(3));

            _viewmodel.UpdateCheckedCourse(false);
            Assert.IsTrue(_viewmodel.IsCheckedClassTimeEqualToHour(3));

            _viewmodel.UpdateCheckedCourse(true);
            Assert.IsFalse(_viewmodel.IsCheckedClassTimeEqualToHour(3));
        }

        // SetCourseEditClassTimeTest
        [TestMethod()]
        public void SetCourseEditClassTimeTest()
        {
            _viewmodel.UpdateSelectedCourse(4);
            string[] classTime = { "", "3 4", "1", "", "", "", "" };
            _viewmodel.SetCourseEditClassTime(classTime);
            _viewmodel.UpdateOrAddCourse();
            Assert.AreEqual("1 3", _viewmodel.GetClassTime()[0]);
            Assert.AreEqual("1 4", _viewmodel.GetClassTime()[1]);
            Assert.AreEqual("2 1", _viewmodel.GetClassTime()[2]);
        }

        // SetCourseEditNumberTest
        [TestMethod()]
        public void SetCourseEditNumberTest()
        {
            _viewmodel.UpdateSelectedCourse(4);
            _viewmodel.SetCourseEditNumber("123456");
            _viewmodel.UpdateOrAddCourse();
            Assert.AreEqual("123456", _viewmodel.GetNumber());
        }

        // SetCourseEditNameTest
        [TestMethod()]
        public void SetCourseEditNameTest()
        {
            _viewmodel.UpdateSelectedCourse(4);
            _viewmodel.SetCourseEditName("程式設計");
            _viewmodel.UpdateOrAddCourse();
            Assert.AreEqual("程式設計", _viewmodel.GetName());
        }

        // SetCourseEditStageTest
        [TestMethod()]
        public void SetCourseEditStageTest()
        {
            _viewmodel.UpdateSelectedCourse(4);
            _viewmodel.SetCourseEditStage("2");
            _viewmodel.UpdateOrAddCourse();
            Assert.AreEqual("2", _viewmodel.GetStage());
        }

        // SetCourseEditCreditTest
        [TestMethod()]
        public void SetCourseEditCreditTest()
        {
            _viewmodel.UpdateSelectedCourse(4);
            _viewmodel.SetCourseEditCredit("2.0");
            _viewmodel.UpdateOrAddCourse();
            Assert.AreEqual("2.0", _viewmodel.GetCredit());
        }

        // SetCourseEditTeacherTest
        [TestMethod()]
        public void SetCourseEditTeacherTest()
        {
            _viewmodel.UpdateSelectedCourse(4);
            _viewmodel.SetCourseEditTeacher("老師");
            _viewmodel.UpdateOrAddCourse();
            Assert.AreEqual("老師", _viewmodel.GetTeacher());
        }

        // SetCourseEditRequireTypeTest
        [TestMethod()]
        public void SetCourseEditRequireTypeTest()
        {
            _viewmodel.UpdateSelectedCourse(4);
            _viewmodel.SetCourseEditRequireType("★");
            _viewmodel.UpdateOrAddCourse();
            Assert.AreEqual("★", _viewmodel.GetRequireType());
        }

        // SetCourseEditTeacherAssistantTest
        [TestMethod()]
        public void SetCourseEditTeacherAssistantTest()
        {
            _viewmodel.UpdateSelectedCourse(4);
            _viewmodel.SetCourseEditTeacherAssistant("assistant");
            _viewmodel.UpdateOrAddCourse();
            Assert.AreEqual("assistant", _viewmodel.GetTeacherAssistant());
        }

        // SetCourseEditLanguageTest
        [TestMethod()]
        public void SetCourseEditLanguageTest()
        {
            _viewmodel.UpdateSelectedCourse(4);
            _viewmodel.SetCourseEditLanguage("英語");
            _viewmodel.UpdateOrAddCourse();
            Assert.AreEqual("英語", _viewmodel.GetLanguage());
        }

        // SetCourseEditSyllabusTest
        [TestMethod()]
        public void SetCourseEditSyllabusTest()
        {
            _viewmodel.UpdateSelectedCourse(4);
            _viewmodel.SetCourseEditSyllabus("123");
            _viewmodel.UpdateOrAddCourse();
            Assert.AreEqual("123", _viewmodel.GetSyllabus());
        }

        // SetCourseEditHourTest
        [TestMethod()]
        public void SetCourseEditHourTest()
        {
            _viewmodel.UpdateSelectedCourse(4);
            _viewmodel.SetCourseEditHour("1");
            _viewmodel.UpdateOrAddCourse();
            Assert.AreEqual("1", _viewmodel.GetHour());
        }

        // SetCourseEditClassTest
        [TestMethod()]
        public void SetCourseEditClassTest()
        {
            _viewmodel.UpdateSelectedCourse(4);
            _viewmodel.SetCourseEditClass("電子三甲");
            _viewmodel.UpdateOrAddCourse();
            Assert.AreEqual("電子三甲", _viewmodel.GetClass());
        }

        // UpdateOrAddCourseTest
        [TestMethod()]
        public void UpdateOrAddCourseTest()
        {
            _viewmodel.UpdateSelectedCourse(4);
            _viewmodel.SetCourseEditClass("電子三甲");
            _viewmodel.UpdateOrAddCourse();
            Assert.AreEqual("電子三甲", _viewmodel.GetClass());

            _viewmodel.AddCourseMode();
            _viewmodel.SetCourseEditNumber("123456");
            _viewmodel.SetCourseEditName("程式設計");
            _viewmodel.SetCourseEditStage("2");
            _viewmodel.SetCourseEditTeacher("老師");
            _viewmodel.SetCourseEditRequireType("★");
            _viewmodel.SetCourseEditClass("電子三甲");
            _viewmodel.UpdateOrAddCourse();
            Assert.AreEqual("程式設計", _viewmodel.GetAllCourseName()[_viewmodel.GetAllCourseName().Count - 1]);
        }

        // AddCourseModeTest
        [TestMethod()]
        public void AddCourseModeTest()
        {
            _viewmodel.AddCourseMode();
            Assert.AreEqual(null, _viewmodel.GetNumber());
            Assert.AreEqual(null, _viewmodel.GetName());
            Assert.AreEqual(null, _viewmodel.GetStage());
            Assert.AreEqual(null, _viewmodel.GetCredit());
            Assert.AreEqual(null, _viewmodel.GetTeacher());
            Assert.AreEqual(null, _viewmodel.GetRequireType());
            Assert.AreEqual(null, _viewmodel.GetTeacherAssistant());
            Assert.AreEqual(null, _viewmodel.GetLanguage());
            Assert.AreEqual(null, _viewmodel.GetSyllabus());
            Assert.AreEqual(null, _viewmodel.GetHour());
            Assert.AreEqual(null, _viewmodel.GetClass());
        }
    }
}