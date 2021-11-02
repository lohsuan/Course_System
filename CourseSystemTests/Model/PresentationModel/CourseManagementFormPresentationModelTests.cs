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
        
        //init
        [TestInitialize]
        public void Initialize()
        {
            Model model = new Model();
            _viewmodel = new CourseManagementFormPresentationModel(model);
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
            Assert.Fail();
        }

        // SetCourseEditNumberTest
        [TestMethod()]
        public void SetCourseEditNumberTest()
        {
            Assert.Fail();
        }

        // SetCourseEditNameTest
        [TestMethod()]
        public void SetCourseEditNameTest()
        {
            Assert.Fail();
        }

        // SetCourseEditStageTest
        [TestMethod()]
        public void SetCourseEditStageTest()
        {
            Assert.Fail();
        }

        // SetCourseEditCreditTest
        [TestMethod()]
        public void SetCourseEditCreditTest()
        {
            Assert.Fail();
        }

        // SetCourseEditTeacherTest
        [TestMethod()]
        public void SetCourseEditTeacherTest()
        {
            Assert.Fail();
        }

        // SetCourseEditRequireTypeTest
        [TestMethod()]
        public void SetCourseEditRequireTypeTest()
        {
            Assert.Fail();
        }

        // SetCourseEditTeacherAssistantTest
        [TestMethod()]
        public void SetCourseEditTeacherAssistantTest()
        {
            Assert.Fail();
        }

        // SetCourseEditLanguageTest
        [TestMethod()]
        public void SetCourseEditLanguageTest()
        {
            Assert.Fail();
        }

        // SetCourseEditSyllabusTest
        [TestMethod()]
        public void SetCourseEditSyllabusTest()
        {
            Assert.Fail();
        }

        // SetCourseEditHourTest
        [TestMethod()]
        public void SetCourseEditHourTest()
        {
            Assert.Fail();
        }

        // SetCourseEditClassTest
        [TestMethod()]
        public void SetCourseEditClassTest()
        {
            Assert.Fail();
        }

        // UpdateOrAddCourseTest
        [TestMethod()]
        public void UpdateOrAddCourseTest()
        {
            Assert.Fail();
        }

        // AddCourseModeTest
        [TestMethod()]
        public void AddCourseModeTest()
        {
            Assert.Fail();
        }
    }
}