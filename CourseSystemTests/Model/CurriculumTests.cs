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
    /// Total Test amount: 3
    /// </summary>
    [TestClass()]
    public class CurriculumTests
    {
        Curriculum _curriculum;

        // TestInitialize
        [TestInitialize]
        public void Initialize()
        {
            _curriculum = new Curriculum();
        }

        // GetCurriculumTest
        [TestMethod()]
        public void GetCurriculumTest()
        {
            Assert.AreEqual(0, _curriculum.GetCurriculum().Count);
        }

        // AddCourseTest
        [TestMethod()]
        public void AddCourseTest()
        {
            CourseInfoDto courseInfo = new CourseInfoDto();
            courseInfo.Name = "course name";
            List<CourseInfoDto> courseInfoDtos = new List<CourseInfoDto>();
            courseInfoDtos.Add(courseInfo);
            _curriculum.AddCourse(courseInfoDtos);
            Assert.AreEqual(1, _curriculum.GetCurriculum().Count);
            Assert.AreEqual("course name", _curriculum.GetCurriculum()[0].Name);

        }

        // RemoveCourseTest
        [TestMethod()]
        public void RemoveCourseTest()
        {
            CourseInfoDto courseInfo = new CourseInfoDto();
            courseInfo.Id = "12345";
            courseInfo.Name = "course name";
            List<CourseInfoDto> courseInfoDtos = new List<CourseInfoDto>();
            courseInfoDtos.Add(courseInfo);
            _curriculum.AddCourse(courseInfoDtos);
            Assert.AreEqual(1, _curriculum.GetCurriculum().Count);
            Assert.AreEqual("course name", _curriculum.GetCurriculum()[0].Name);

            _curriculum.RemoveCourse(courseInfo.Id);
            Assert.AreEqual(0, _curriculum.GetCurriculum().Count);
        }
    }
}