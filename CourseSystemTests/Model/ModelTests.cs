using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace CourseSystem.Tests
{
    /// <summary>
    ///  Number of all test method for Course System: 112
    /// </summary>

    /// <summary>
    ///  Number of test method in ModelTest: 19
    /// </summary>

    [TestClass()]
    public class ModelTests
    {
        Model _model;
        int _event;
        PrivateObject _modelPrivate;

        // TestInitialize
        [TestInitialize]
        public void TestInitialize()
        {
            _model = new Model();
            _modelPrivate = new PrivateObject(_model);
        }

        // MockEventHandler
        private void MockEventHandler()
        {
            _event += 1;
        }

        // ModelTest
        [TestMethod()]
        public void ModelTest()
        {
            Assert.IsNotNull(_model.GetAllCourses());
        }

        // on course created
        [TestMethod()]
        public void NotifyCourseCreatedTest()
        {
            _event = 0;
            _model._courseDataCreateEvent += MockEventHandler;
         
            _model.NotifyCourseCreated();
            Assert.AreEqual(1, _event);
            _model.NotifyCourseCreated();
            Assert.AreEqual(2, _event);
        }

        // on course update
        [TestMethod()]
        public void NotifyCourseUpdatedTest()
        {
            _event = 0;
            _model._courseDataUpdateEvent += MockEventHandler;

            _model.NotifyCourseUpdated();
            Assert.AreEqual(1, _event);
            _model.NotifyCourseUpdated();
            Assert.AreEqual(2, _event);
        }

        // on course Select
        [TestMethod()]
        public void NotifyCourseSelectTest()
        {
            _event = 0;
            _model._courseSelectEvent += MockEventHandler;

            _model.NotifyCourseSelect();
            Assert.AreEqual(1, _event);
            _model.NotifyCourseSelect();
            Assert.AreEqual(2, _event);
        }

        // on course Cancel Select
        [TestMethod()]
        public void NotifyCourseCancelSelectTest()
        {
            _event = 0;
            _model._courseCancelSelectEvent += MockEventHandler;

            _model.NotifyCourseCancelSelect();
            Assert.AreEqual(1, _event);
            _model.NotifyCourseCancelSelect();
            Assert.AreEqual(2, _event);
        }

        // on course Cancel Select
        [TestMethod()]
        public void NotifyCourseImportTest()
        {
            _event = 0;
            _model._courseImportEvent += MockEventHandler;

            _model.NotifyCourseImport();
            Assert.AreEqual(1, _event);
            _model.NotifyCourseImport();
            Assert.AreEqual(2, _event);
        }

        // on class add
        [TestMethod()]
        public void NotifyClassAddTest()
        {
            _event = 0;
            _model._classAddEvent += MockEventHandler;

            _model.NotifyClassAdd();
            Assert.AreEqual(1, _event);
            _model.NotifyClassAdd();
            Assert.AreEqual(2, _event);
        }

        // GetCourseInfoTest
        [TestMethod()]
        public void GetCourseInfoTest()
        {
            List<CourseInfoDto> courses = _model.GetCourseInfo(0);

            Assert.AreEqual("班週會及導師時間", courses[0].Name);
            Assert.AreEqual("", courses[0].Number);
            Assert.AreEqual("3 4", courses[0].ClassTimeTuesday);
            Assert.AreEqual("", courses[0].ClassTimeWednesday);
        }

        // GetCourseByIndexTest
        [TestMethod()]
        public void GetCourseByIndexTest()
        {
            CourseInfoDto course = _model.GetCourseByIndex(4);
            Assert.AreEqual("291705", course.Number);
            Assert.AreEqual("資料庫系統", course.Name);
            Assert.AreEqual("1", course.Stage);
            Assert.AreEqual("1", course.Stage);
            Assert.AreEqual("3.0", course.Credit);
            Assert.AreEqual("▲", course.RequiredType);
            Assert.AreEqual("劉建宏", course.Teacher);
            Assert.AreEqual("", course.ClassTimeSunday);
            Assert.AreEqual("", course.ClassTimeMonday);
            Assert.AreEqual("7", course.ClassTimeTuesday);
            Assert.AreEqual("8 9", course.ClassTimeWednesday);
            Assert.AreEqual("", course.ClassTimeThursday);
            Assert.AreEqual("", course.ClassTimeFriday);
            Assert.AreEqual("", course.ClassTimeSaturday);
            Assert.AreEqual("六教327(e)", course.Classroom);
        }

        // GetAllDepartmentName
        [TestMethod()]
        public void GetAllDepartmentNameTest()
        {
            Assert.AreEqual("資工三", _model.GetAllDepartmentName()[0]);
            Assert.AreEqual("電子三甲", _model.GetAllDepartmentName()[1]);
        }

        // GetDepartmentTest
        [TestMethod()]
        public void GetDepartmentCourseTest()
        {
            Assert.AreEqual("291705", _model.GetDepartmentCourse(0)[4].Number);
        }

        // GetDepartmentsTest
        [TestMethod()]
        public void GetDepartmentsTest()
        {
            Assert.AreEqual("資工三", _model.GetDepartments()[0].GetDepartmentName());
            Assert.AreEqual("電子三甲", _model.GetDepartments()[1].GetDepartmentName());
        }

        // GetDepartmentNameTest
        [TestMethod()]
        public void GetDepartmentNameTest()
        {
            Assert.AreEqual("資工三", _model.GetDepartmentName(0));
            Assert.AreEqual("電子三甲", _model.GetDepartmentName(1));
        }

        // GetCourseHeaderTest
        [TestMethod()]
        public void GetCourseHeaderTest()
        {
            Assert.IsNotNull(_model.GetCourseHeader());
            Assert.AreEqual(CourseHeaderConstant.NUMBER_HEADER_VALUE, _model.GetCourseHeader()[CourseHeaderConstant.NUMBER_HEADER_KEY]);
            Assert.AreEqual(CourseHeaderConstant.CLASS_TIME_SATURDAY_HEADER_VALUE, _model.GetCourseHeader()[CourseHeaderConstant.CLASS_TIME_SATURDAY_HEADER_KEY]);
        }

        // SelectCheckedCourseToCurriculumTest
        [TestMethod()]
        public void SelectCheckedCourseToCurriculumTest()
        {
            List<CourseInfoDto> courses = _model.GetDepartmentCourse(0);
            _model.SelectCheckedCourseToCurriculum(courses);

            Assert.IsNotNull(_model.GetCurriculum());
            Assert.AreEqual(courses.Count, _model.GetCurriculum().Count);
        }

        // CancelSelectCourseFromCurriculumTest
        [TestMethod()]
        public void CancelSelectCourseFromCurriculumTest()
        {
            List<CourseInfoDto> courses = _model.GetDepartmentCourse(0);
            _model.SelectCheckedCourseToCurriculum(courses);
            Assert.IsNotNull(_model.GetCurriculum());
            _model.CancelSelectCourseFromCurriculum(courses[0].Id);
            Assert.AreEqual(_model.GetCourseByIndex(1), _model.GetCurriculum()[0]);
        }

        // GetCurriculumTest
        [TestMethod()]
        public void GetCurriculumTest()
        {
            Assert.AreEqual(0, _model.GetCurriculum().Count);
            List<CourseInfoDto> courses = _model.GetDepartmentCourse(0);
            _model.SelectCheckedCourseToCurriculum(courses);
            Assert.IsNotNull(_model.GetCurriculum());
            Assert.AreEqual(courses.Count, _model.GetCurriculum().Count);
        }

        // GetAllCoursesTest
        [TestMethod()]
        public void GetAllCoursesTest()
        {
            Assert.IsNotNull(_model.GetAllCourses());
            Assert.AreEqual("291705", _model.GetAllCourses()[4].Number);
            Assert.AreEqual("資料庫系統", _model.GetAllCourses()[4].Name);
        }

        // ChangeCourseClassTest
        [TestMethod()]
        public void ChangeCourseClassTest()
        {
            CourseInfoDto courseInfoDto = _model.GetCourseByIndex(1);
            _model.ChangeCourseClass(courseInfoDto, "資工三", "電子三甲");
            Assert.AreEqual(0, _model.GetDepartments()[0].GetCourseInfoDtos().FindAll(x => x == courseInfoDto).Count);
            Assert.AreEqual(1, _model.GetDepartments()[1].GetCourseInfoDtos().FindAll(x => x == courseInfoDto).Count);
        }

        // AddCourseTest
        [TestMethod()]
        public void AddCourseTest()
        {
            CourseInfoDto newCourse = new CourseInfoDto(_model.GetAllCourses()[4]);
            _model.AddCourse(newCourse);
            Assert.AreEqual(newCourse.Number, _model.GetAllCourses()[_model.GetAllCourses().Count - 1].Number);
        }

        // AddCourseTest
        [TestMethod()]
        public void ImportClassTest()
        {
            _model.ImportClass("https://aps.ntut.edu.tw/course/tw/Subj.jsp?format=-4&year=110&sem=1&code=2433");
            Assert.AreEqual(2, _model.GetDepartmentAmount());

            _model.ImportClass("https://aps.ntut.edu.tw/course/tw/Subj.jsp?format=-4&year=110&sem=1&code=2676");
            Assert.AreEqual(3, _model.GetDepartmentAmount());
        }


        // AddNotDuplicateNumberCourseTest
        [TestMethod()]
        public void AddNotDuplicateNumberCourseTest()
        {
            List<CourseInfoDto> courseInfoDtos = new List<CourseInfoDto>();
            List<CourseInfoDto> allCourses = _model.GetAllCourses();
            courseInfoDtos.Add(allCourses[1]);
            _modelPrivate.Invoke("AddNotDuplicateNumberCourse", new object[] { courseInfoDtos });
            Assert.AreEqual(37, _model.GetAllCourses().Count);

            CourseInfoDto courseInfoDto = new CourseInfoDto();
            courseInfoDto.Number = "";
            courseInfoDtos.Add(courseInfoDto);
            _modelPrivate.Invoke("AddNotDuplicateNumberCourse", new object[] { courseInfoDtos });
            Assert.AreEqual(38, _model.GetAllCourses().Count);
        }

        // GetNumberTest
        [TestMethod()]
        public void GetNumberTest()
        {
            CourseInfoDto courseInfoDto = new CourseInfoDto();
            courseInfoDto.Number = "1234";
            Assert.AreEqual("1234", _modelPrivate.Invoke("GetNumber", new object[] { courseInfoDto }));
        }

        // GetDepartmentAmountTest
        [TestMethod()]
        public void GetDepartmentAmountTest()
        {
            Assert.AreEqual(2, _model.GetDepartmentAmount());
        }

        // GetClassCourseByDepartmentIndexTest
        [TestMethod()]
        public void GetClassCourseByDepartmentIndexTest()
        {
            List<string> courseNames = _model.GetClassCourseByDepartmentIndex(0);
            Assert.AreEqual("班週會及導師時間", courseNames[0]);
            Assert.AreEqual("體育", courseNames[1]);
            Assert.AreEqual("博雅選修課程", courseNames[2]);
        }

        // AddClassTest
        [TestMethod()]
        public void AddClassTest()
        {
            _model.AddClass("new class");
            Assert.AreEqual(3, _model.GetDepartments().Count);
            Assert.AreEqual("new class", _model.GetDepartmentName(2));
        }
    }
}