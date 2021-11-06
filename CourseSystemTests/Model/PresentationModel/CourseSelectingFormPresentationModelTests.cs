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
    public class CourseSelectingFormPresentationModelTests
    {
        CourseSelectingFormPresentationModel _viewModel;
        PrivateObject _viewmodelPrivate;

        // TestInitialize
        [TestInitialize]
        public void Initialize()
        {
            Model model = new Model();
            _viewModel = new CourseSelectingFormPresentationModel(model);
            _viewmodelPrivate = new PrivateObject(_viewModel);
        }

        // CourseSelectingFormPresentationModelTest
        [TestMethod()]
        public void CourseSelectingFormPresentationModelTest()
        {
            Assert.IsNotNull(_viewModel);
        }

        // GetCourseInfoTest
        [TestMethod()]
        public void GetCourseInfoTest()
        {
            Assert.AreEqual(12, _viewModel.GetCourseInfo(0).Count);
        }

        // GetDepartmentNameTest
        [TestMethod()]
        public void GetDepartmentNameTest()
        {
            Assert.AreEqual("資工三", _viewModel.GetDepartmentName(0));
            Assert.AreEqual("電子三甲", _viewModel.GetDepartmentName(1));
        }

        // GetCourseHeaderTest
        [TestMethod()]
        public void GetCourseHeaderTest()
        {
            string[] _courseHeaderKeys = { CourseHeaderConstant.NUMBER_HEADER_KEY, CourseHeaderConstant.NAME_HEADER_KEY, CourseHeaderConstant.STAGE_HEADER_KEY, CourseHeaderConstant.CREDIT_HEADER_KEY, CourseHeaderConstant.HOUR_HEADER_KEY, CourseHeaderConstant.REQUIRED_TYPE_HEADER_KEY, CourseHeaderConstant.TEACHER_HEADER_KEY, CourseHeaderConstant.CLASSROOM_HEADER_KEY, CourseHeaderConstant.NUMBER_OF_STUDENT_HEADER_KEY, CourseHeaderConstant.NOTE_HEADER_KEY, CourseHeaderConstant.NUMBER_OF_DROP_STUDENT_HEADER_KEY, CourseHeaderConstant.TEACHER_ASSISTANT_HEADER_KEY, CourseHeaderConstant.LANGUAGE_HEADER_KEY, CourseHeaderConstant.SYLLABUS_HEADER_KEY, CourseHeaderConstant.AUDIT_HEADER_KEY, CourseHeaderConstant.EXPERIMENT_HEADER_KEY, CourseHeaderConstant.CLASS_TIME_SUNDAY_HEADER_KEY, CourseHeaderConstant.CLASS_TIME_MONDAY_HEADER_KEY, CourseHeaderConstant.CLASS_TIME_TUESDAY_HEADER_KEY, CourseHeaderConstant.CLASS_TIME_WEDNESDAY_HEADER_KEY, CourseHeaderConstant.CLASS_TIME_THURSDAY_HEADER_KEY, CourseHeaderConstant.CLASS_TIME_FRIDAY_HEADER_KEY, CourseHeaderConstant.CLASS_TIME_SATURDAY_HEADER_KEY };
            Dictionary<string, string> header = _viewModel.GetCourseHeader();
            foreach (string key in _courseHeaderKeys)
            {
                Assert.IsTrue(header.ContainsKey(key));
            }
        }

        // UpdateCourseCheckedTest
        [TestMethod()]
        public void UpdateCourseCheckedTest()
        {
            Assert.Fail();
        }

        // IsAnyCourseCheckedTest
        [TestMethod()]
        public void IsAnyCourseCheckedTest()
        {
            Assert.Fail();
        }

        // CheckCoursesValidMessageTest
        [TestMethod()]
        public void CheckCoursesValidMessageTest()
        {
            Assert.Fail();
        }

        // IsAddCourseSuccessTest
        [TestMethod()]
        public void IsAddCourseSuccessTest()
        {
            Assert.Fail();
        }

        // SelectCheckedCourseTest
        [TestMethod()]
        public void SelectCheckedCourseTest()
        {
            Assert.Fail();
        }

        // GetNotSelectedCourseTest
        [TestMethod()]
        public void GetNotSelectedCourseTest()
        {
            Assert.Fail();
        }
    }
}