using System;
using System.Collections.Generic;

namespace CourseSystem
{
    public class Model
    {
        private string[] _coursePathes = { CourseConstant.COMPUTER_SCIENCE_JUNIOR_CLASS_URL, CourseConstant.ELECTRIC_ENGINEERING_JUNIOR_CLASS_URL };
        List<Department> _departments = new List<Department>(); // read only, storing each department's course
        Curriculum _curriculum = new Curriculum(); // storing selected course
        List<CourseInfoDto> _courses = new List<CourseInfoDto>(); // storing all departments' courses

        // get parsed course information
        public List<CourseInfoDto> GetCourseInfo(int classIndex)
        {
            Course course = new Course();
            List<CourseInfoDto> courseInfoDtos = course.CourseInfoCrawler(_coursePathes[classIndex]);
            _departments.Add(new Department(course.GetDepartmentName(), courseInfoDtos));
            _courses.AddRange(courseInfoDtos);
            return courseInfoDtos;
        }

        // GetCourseByIndex
        internal CourseInfoDto GetCourseByIndex(int selectedIndex)
        {
            return _courses[selectedIndex];
        }

        // get department by index
        internal List<CourseInfoDto> GetDepartment(int tabIndex)
        {
            return _departments[tabIndex].GetCourseInfoDtos();
        }

        // get departments
        internal List<Department> GetDepartments()
        {
            return _departments;
        }

        // get department name
        public string GetDepartmentName(int index)
        {
            return _departments[index].GetDepartmentName();
        }

        // get course header text of school timetable
        public Dictionary<string, string> GetCourseHeader()
        {
            Course course = new Course();
            return course.GetCourseHeader();
        }

        // add checked course to curriculum
        internal void SelectCheckedCourseToCurriculum(List<CourseInfoDto> checkedCourses)
        {
            _curriculum.AddCourse(checkedCourses);
        }

        // unselect course from curriculum
        internal void CancelSelectCourseFromCurriculum(string id)
        {
            _curriculum.RemoveCourse(id);
        }

        // get curriculum(selected course)
        internal List<CourseInfoDto> GetCurriculum()
        {
            return _curriculum.GetCurriculum();
        }

        // get all course
        internal List<CourseInfoDto> GetAllCourses()
        {
            return _courses;
        }

    }
}