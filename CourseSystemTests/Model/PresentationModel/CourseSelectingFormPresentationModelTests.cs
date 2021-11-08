using Microsoft.VisualStudio.TestTools.UnitTesting;
using CourseSystem;
using System;
using System.Collections.Generic;

namespace CourseSystem.Tests
{
    /// <summary>
    /// Number of test method: 19
    /// </summary>
    [TestClass()]
    public class CourseSelectingFormPresentationModelTests
    {
        Model _model;
        CourseSelectingFormPresentationModel _viewModel;
        PrivateObject _viewModelPrivate;

        // TestInitialize
        [TestInitialize]
        public void Initialize()
        {
            _model = new Model();
            _viewModel = new CourseSelectingFormPresentationModel(_model);
            _viewModelPrivate = new PrivateObject(_viewModel);
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
            List<CourseInfoDto> courseInfoDtos = _viewModel.GetCourseInfo(0);

            _viewModel.UpdateCourseChecked(0, courseInfoDtos[1].Id);
            Assert.IsTrue(_viewModel.IsAnyCourseChecked());

            _viewModel.UpdateCourseChecked(0, courseInfoDtos[1].Id);
            Assert.IsFalse(_viewModel.IsAnyCourseChecked());
        }

        // UpdateCourseCheckedTest
        [TestMethod()]
        public void GetDepartmentAmountTest()
        {
            Assert.AreEqual(2, _viewModel.GetDepartmentAmount());
        }

        // IsAnyCourseCheckedTest
        [TestMethod()]
        public void IsAnyCourseCheckedTest()
        {
            Assert.IsFalse(_viewModel.IsAnyCourseChecked());
            List<CourseInfoDto> courseInfoDtos = _viewModel.GetCourseInfo(0);

            _viewModel.UpdateCourseChecked(0, courseInfoDtos[1].Id);
            Assert.IsTrue(_viewModel.IsAnyCourseChecked());
            
            _viewModel.UpdateCourseChecked(0, courseInfoDtos[1].Id);
            Assert.IsFalse(_viewModel.IsAnyCourseChecked());
        }

        // CheckCoursesValidMessageTest
        [TestMethod()]
        public void CheckCoursesValidMessageTest()
        {
            List<CourseInfoDto> courseInfoDtos = _viewModel.GetCourseInfo(0);
            courseInfoDtos[1].ClassTimeMonday = "1";
            courseInfoDtos[2].ClassTimeMonday = "1";
            _viewModel.UpdateCourseChecked(0, courseInfoDtos[1].Id);
            Assert.AreEqual("加選成功\n", _viewModel.CheckCoursesValidMessage());
            _viewModel.UpdateCourseChecked(0, courseInfoDtos[2].Id);
            Assert.AreEqual("加選失敗\n\n衝堂 : 「291702-體育」、「291703-博雅選修課程」\n", _viewModel.CheckCoursesValidMessage());
        }

        // CheckAnyCourseOverlapMessageTest
        [TestMethod()]
        public void CheckAnyCourseOverlapMessageTest()
        {
            List<CourseInfoDto> courseInfoDtos = _viewModel.GetCourseInfo(0);
            courseInfoDtos[1].ClassTimeMonday = "1";
            courseInfoDtos[2].ClassTimeMonday = "1";
            _viewModel.UpdateCourseChecked(0, courseInfoDtos[1].Id);
            Assert.AreEqual("", _viewModelPrivate.Invoke("CheckAnyCourseOverlapMessage").ToString());
            _viewModel.UpdateCourseChecked(0, courseInfoDtos[2].Id);
            Assert.IsFalse("" == _viewModelPrivate.Invoke("CheckAnyCourseOverlapMessage").ToString());
        }

        // CheckCheckedCourseOverlapMessageTest
        [TestMethod()]
        public void CheckCheckedCourseOverlapMessageTest()
        {
            List<CourseInfoDto> courseInfoDtos = _viewModel.GetCourseInfo(0);
            courseInfoDtos[1].ClassTimeMonday = "1";
            courseInfoDtos[1].ClassTimeFriday = "";
            courseInfoDtos[2].ClassTimeMonday = "1";
            Dictionary<string, string> classMap = new Dictionary<string, string>();

            _viewModel.UpdateCourseChecked(0, courseInfoDtos[1].Id);
            Assert.AreEqual("", _viewModelPrivate.Invoke("CheckCheckedCourseOverlapMessage",
                new object[] { courseInfoDtos[1], classMap }).ToString());
           
            _viewModel.UpdateCourseChecked(0, courseInfoDtos[2].Id);
            Assert.IsFalse("" == _viewModelPrivate.Invoke("CheckCheckedCourseOverlapMessage",
                new object[] { courseInfoDtos[2], classMap }).ToString());
        }


        // PrepareCourseOverlapMessageTest
        [TestMethod()]
        public void PrepareCourseOverlapMessageTest()
        {
            List<CourseInfoDto> courseInfoDtos = _viewModel.GetCourseInfo(0);
            courseInfoDtos[1].ClassTimeMonday = "1";
            courseInfoDtos[1].ClassTimeFriday = "";
            courseInfoDtos[2].ClassTimeMonday = "1";
            _viewModel.UpdateCourseChecked(0, courseInfoDtos[1].Id);
            _viewModel.UpdateCourseChecked(0, courseInfoDtos[2].Id);

            Dictionary<string, string> classMap = new Dictionary<string, string>();
            classMap.Add("1 1", "291702-體育");

            Assert.AreEqual("「291702-體育」、「291703-博雅選修課程」", 
                _viewModelPrivate.Invoke("PrepareCourseOverlapMessage", new object[] { courseInfoDtos[2], classMap, "1 1" }).ToString());
        }

        // CheckAnyCourseHasTheSameNameMessageTest
        [TestMethod()]
        public void CheckAnyCourseHasTheSameNameMessageTest()
        {
            List<CourseInfoDto> courseInfoDtos = _viewModel.GetCourseInfo(0);
            courseInfoDtos[1].Name = "123";
            courseInfoDtos[2].Name = "123";
            _viewModel.UpdateCourseChecked(0, courseInfoDtos[1].Id);
            Assert.AreEqual("", _viewModelPrivate.Invoke("CheckAnyCourseHasTheSameNameMessage").ToString());
            _viewModel.UpdateCourseChecked(0, courseInfoDtos[2].Id);
            Assert.IsFalse("" == _viewModelPrivate.Invoke("CheckAnyCourseHasTheSameNameMessage").ToString());
        }

        // IsAddCourseSuccessTest
        [TestMethod()]
        public void IsAddCourseSuccessTest()
        {
            List<CourseInfoDto> courseInfoDtos = _viewModel.GetCourseInfo(0);
            courseInfoDtos[1].ClassTimeMonday = "1";
            courseInfoDtos[2].ClassTimeMonday = "1";
            _viewModel.UpdateCourseChecked(0, courseInfoDtos[1].Id);
            _viewModel.CheckCoursesValidMessage();
            Assert.IsTrue(_viewModel.IsAddCourseSuccess());

            _viewModel.UpdateCourseChecked(0, courseInfoDtos[2].Id);
            _viewModel.CheckCoursesValidMessage();
            Assert.IsFalse(_viewModel.IsAddCourseSuccess());
        }

        // GetCourseNameTest
        [TestMethod()]
        public void GetCourseNameTest()
        {
            CourseInfoDto courseInfoDto = new CourseInfoDto();
            courseInfoDto.Name = "Hiii";
            Assert.AreEqual("Hiii", _viewModelPrivate.Invoke("GetCourseName", new object[] { courseInfoDto }));
        }

        // GetCourseNumberTest
        [TestMethod()]
        public void GetCourseNumberTest()
        {
            CourseInfoDto courseInfoDto = new CourseInfoDto();
            courseInfoDto.Number = "1234";
            Assert.AreEqual("1234", _viewModelPrivate.Invoke("GetCourseNumber", new object[] { courseInfoDto }));
        }

        // GetClassTimeTest
        [TestMethod()]
        public void GetClassTimeTest()
        {
            CourseInfoDto courseInfoDto = new CourseInfoDto();
            courseInfoDto.ClassTimeSunday = "1";
            courseInfoDto.ClassTimeMonday= "2";
            courseInfoDto.ClassTimeTuesday = "3";
            courseInfoDto.ClassTimeWednesday = "4";
            courseInfoDto.ClassTimeThursday = "";
            courseInfoDto.ClassTimeFriday = "";
            courseInfoDto.ClassTimeSaturday = "";
            List<string> result = (List<string>) _viewModelPrivate.Invoke("GetClassTime", new object[] { courseInfoDto });
            Assert.AreEqual("1", result[0]);
            Assert.AreEqual("2", result[1]);
            Assert.AreEqual("3", result[2]);
            Assert.AreEqual("4", result[3]);
            Assert.AreEqual("", result[4]);
            Assert.AreEqual("", result[5]);
            Assert.AreEqual("", result[6]);
        }

        // SelectCheckedCourseTest
        [TestMethod()]
        public void SelectCheckedCourseTest()
        {
            List<CourseInfoDto> courseInfoDtos = _viewModel.GetCourseInfo(0);
            _viewModel.UpdateCourseChecked(0, courseInfoDtos[1].Id);
            _viewModel.UpdateCourseChecked(0, courseInfoDtos[2].Id);
            _viewModel.SelectCheckedCourse();
            Assert.AreEqual(0, _viewModel.GetNotSelectedCourse()[0].FindAll(x => x.Id == courseInfoDtos[1].Id).Count);
            Assert.AreEqual(0, _viewModel.GetNotSelectedCourse()[0].FindAll(x => x.Id == courseInfoDtos[2].Id).Count);
        }

        // GetNotSelectedCourseTest
        [TestMethod()]
        public void GetNotSelectedCourseTest()
        {
            List<CourseInfoDto> courseInfoDtos = _viewModel.GetCourseInfo(0);
            _viewModel.UpdateCourseChecked(0, courseInfoDtos[1].Id);
            _viewModel.UpdateCourseChecked(0, courseInfoDtos[2].Id);
            _viewModel.SelectCheckedCourse();

            Assert.AreEqual(1, _viewModel.GetNotSelectedCourse()[0].FindAll(x => x.Id == courseInfoDtos[0].Id).Count);
            Assert.AreEqual(0, _viewModel.GetNotSelectedCourse()[0].FindAll(x => x.Id == courseInfoDtos[1].Id).Count);
            Assert.AreEqual(0, _viewModel.GetNotSelectedCourse()[0].FindAll(x => x.Id == courseInfoDtos[2].Id).Count);
            Assert.AreEqual(1, _viewModel.GetNotSelectedCourse()[0].FindAll(x => x.Id == courseInfoDtos[3].Id).Count);
        }

        // GetDepartmentNotSelectedCourseTest
        [TestMethod()]
        public void GetDepartmentNotSelectedCourseTest()
        {
            List<CourseInfoDto> curriculum = _model.GetCurriculum();
            List<Department> departments = _model.GetDepartments();
            List<List<CourseInfoDto>> result = new List<List<CourseInfoDto>>();

            List<CourseInfoDto> courseInfoDtos = _viewModel.GetCourseInfo(0);
            _viewModel.UpdateCourseChecked(0, courseInfoDtos[1].Id);
            _viewModel.UpdateCourseChecked(0, courseInfoDtos[2].Id);
            _viewModel.SelectCheckedCourse();
            _viewModelPrivate.Invoke("GetDepartmentNotSelectedCourse", new object[] { curriculum, result, departments[0] });
            
            Assert.AreEqual(1, result[0].FindAll(x => x.Id == courseInfoDtos[0].Id).Count);
            Assert.AreEqual(0, result[0].FindAll(x => x.Id == courseInfoDtos[1].Id).Count);
            Assert.AreEqual(0, result[0].FindAll(x => x.Id == courseInfoDtos[2].Id).Count);
        }
    }
}