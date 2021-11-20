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
    /// Total Test amount: 7
    /// </summary>
    [TestClass()]
    public class DepartmentTests
    {
        Department _department;

        // TestInitialize
        [TestInitialize]
        public void Initialize()
        {
            _department = new Department("資工三");
        }

        // DepartmentWithCoursesTest
        [TestMethod()]
        public void DepartmentWithCoursesTest()
        {
            CourseInfoDto courseInfo = new CourseInfoDto();
            courseInfo.Name = "course name";
            List<CourseInfoDto> courseInfoDtos = new List<CourseInfoDto>();
            courseInfoDtos.Add(courseInfo);

            _department = new Department("資工二", courseInfoDtos);

            Assert.AreEqual("資工二", _department.GetDepartmentName());
            Assert.AreEqual(1, _department.GetCourseInfoDtos().Count);
        }

        // DepartmentWithDepartmentNameTest
        [TestMethod()]
        public void DepartmentWithDepartmentNameTest()
        {
            Assert.AreEqual("資工三", _department.GetDepartmentName());
        }

        // GetCourseInfoDtosTest
        [TestMethod()]
        public void GetCourseInfoDtosTest()
        {
            CourseInfoDto courseInfo = new CourseInfoDto();
            courseInfo.Name = "course name";
            List<CourseInfoDto> courseInfoDtos = new List<CourseInfoDto>();
            courseInfoDtos.Add(courseInfo);

            _department = new Department("資工二", courseInfoDtos);

            Assert.AreEqual(1, _department.GetCourseInfoDtos().Count);
            Assert.AreEqual("course name", _department.GetCourseInfoDtos()[0].Name);
        }

        // GetDepartmentNameTest
        [TestMethod()]
        public void GetDepartmentNameTest()
        {
            Assert.AreEqual("資工三", _department.GetDepartmentName());
        }

        // AddCourseTest
        [TestMethod()]
        public void AddCourseTest()
        {
            CourseInfoDto courseInfo = new CourseInfoDto();
            courseInfo.Name = "course name";

            _department.AddCourse(courseInfo);

            Assert.AreEqual(1, _department.GetCourseInfoDtos().Count);
            Assert.AreEqual("course name", _department.GetCourseInfoDtos()[0].Name);
        }

        // RemoveCourseTest
        [TestMethod()]
        public void RemoveCourseTest()
        {
            CourseInfoDto courseInfo = new CourseInfoDto();
            courseInfo.Name = "course name";

            _department.AddCourse(courseInfo);
            _department.RemoveCourse(courseInfo);

            Assert.AreEqual(0, _department.GetCourseInfoDtos().Count);
        }

        // GetCoursesNameTest
        [TestMethod()]
        public void GetCoursesNameTest()
        {
            CourseInfoDto courseInfo = new CourseInfoDto();
            CourseInfoDto courseInfo1 = new CourseInfoDto();
            courseInfo.Name = "course name";
            courseInfo1.Name = "course1 name";

            _department.AddCourse(courseInfo);
            _department.AddCourse(courseInfo1);

            Assert.AreEqual(2, _department.GetCoursesName().Count);
            Assert.AreEqual("course name", _department.GetCoursesName()[0]);
            Assert.AreEqual("course1 name", _department.GetCoursesName()[1]);
        }
    }
}