using Microsoft.VisualStudio.TestTools.UnitTesting;
using CourseSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseSystem.Tests
{
    /// <summary>
    /// Number of test method: 8
    /// </summary>
    [TestClass()]
    public class CourseInfoDtoTests
    {
        CourseInfoDto _courseInfoDto;

        // TestInitialize
        [TestInitialize]
        public void Initialize()
        {
            _courseInfoDto = new CourseInfoDto("number", "name", "stage", "credit", "hour", "", "", "", "", "",
            "", "", "", "", "", "", "", "", "", "", "", "", "", "");
        }

        // CourseInfoDto
        [TestMethod()]
        public void CourseInfoDtoTest()
        {
            Assert.AreEqual("number", _courseInfoDto.Number);
            Assert.AreEqual("name", _courseInfoDto.Name);
        }

        // UpdateCourseTest
        [TestMethod()]
        public void UpdateCourseTest()
        {
            CourseInfoDto updateCourse = new CourseInfoDto("123", "new", "stage", "credit", "hour", "", "", "", "", "",
            "", "", "", "", "", "", "", "", "", "", "", "", "", "");
            string oldId = _courseInfoDto.Id;
            _courseInfoDto.UpdateCourse(updateCourse);
            Assert.AreEqual("123", _courseInfoDto.Number);
            Assert.AreEqual("new", _courseInfoDto.Name);
            Assert.AreEqual(oldId, _courseInfoDto.Id);
        }

        // IsCourseInfoMeetNotNullRequireTest
        [TestMethod()]
        public void IsCourseInfoMeetNotNullRequireTest()
        {
            Assert.IsFalse(_courseInfoDto.IsCourseInfoMeetNotNullRequire());
            _courseInfoDto.Teacher = "teacher";

            Assert.IsTrue(_courseInfoDto.IsCourseInfoMeetNotNullRequire());
        }

        // GetCourseInfoDtoDataTest
        [TestMethod()]
        public void GetCourseInfoDtoDataTest()
        {
            List<string> result = _courseInfoDto.GetCourseInfoDtoData();
            Assert.AreEqual("number", result[1]);
            Assert.AreEqual("name", result[2]);
        }

        // EqualsTest
        [TestMethod()]
        public void EqualsTest()
        {
            CourseInfoDto newCourse = new CourseInfoDto();
            newCourse.Id = "123";
            _courseInfoDto.Id = "123";
            Assert.IsTrue(_courseInfoDto.Equals(newCourse));
        }

        // GetClassTimeTest
        [TestMethod()]
        public void GetClassTimeTest()
        {
            _courseInfoDto.ClassTimeSunday = "1 2";
            _courseInfoDto.ClassTimeMonday = "3 4";
            List<string> result = _courseInfoDto.GetClassTime();
            Assert.AreEqual("1 2", result[0]);
            Assert.AreEqual("3 4", result[1]);
            Assert.AreEqual("", result[2]);
        }

        // SetCourseStatusTest
        [TestMethod()]
        public void SetCourseStatusTest()
        {
            _courseInfoDto.SetCourseStatus(1);
            Assert.AreEqual(1, _courseInfoDto.GetCourseStatus());
            _courseInfoDto.SetCourseStatus(0);
            Assert.AreEqual(0, _courseInfoDto.GetCourseStatus());
        }

        // GetCourseStatusTest
        [TestMethod()]
        public void GetCourseStatusTest()
        {
            _courseInfoDto.SetCourseStatus(1);
            Assert.AreEqual(1, _courseInfoDto.GetCourseStatus());
            _courseInfoDto.SetCourseStatus(0);
            Assert.AreEqual(0, _courseInfoDto.GetCourseStatus());
        }
    }
}