using System;
using System.Collections.Generic;

namespace CourseSystem
{
    public class Model
    {
        public event OnCourseDataCreateEventHandler _courseDataCreateEvent;
        public delegate void OnCourseDataCreateEventHandler();
        public event OnCourseDataUpdateEventHandler _courseDataUpdateEvent;
        public delegate void OnCourseDataUpdateEventHandler();
        public event OnCourseSelectEventHandler _courseSelectEvent;
        public delegate void OnCourseSelectEventHandler();
        public event OnCourseCancelSelectEventHandler _courseCancelSelectEvent;
        public delegate void OnCourseCancelSelectEventHandler();

        private const string COMPUTER_SCIENCE_JUNIOR = "資工三";
        private const string ELECTRIC_ENGINEERING_JUNIOR = "電子三甲";
        private string[] _departmentPathes = { CourseConstant.COMPUTER_SCIENCE_JUNIOR_CLASS_URL, CourseConstant.ELECTRIC_ENGINEERING_JUNIOR_CLASS_URL };
        string[] _departmentNames = { COMPUTER_SCIENCE_JUNIOR, ELECTRIC_ENGINEERING_JUNIOR };
        List<Department> _departments = new List<Department>(); // read only, storing each department's course
        Curriculum _curriculum = new Curriculum(); // storing selected course
        List<CourseInfoDto> _courses = new List<CourseInfoDto>(); // storing all departments' courses

        // on course created
        internal void NotifyCourseCreated()
        {
            if (_courseDataCreateEvent != null)
                _courseDataCreateEvent();
        }

        // on course update
        internal void NotifyCourseUpdated()
        {
            if (_courseDataUpdateEvent != null)
                _courseDataUpdateEvent();
        }

        // on course Select
        internal void NotifyCourseSelect()
        {
            if (_courseSelectEvent != null)
                _courseSelectEvent();
        }

        // on course Cancel Select
        internal void NotifyCourseCancelSelect()
        {
            if (_courseCancelSelectEvent != null)
                _courseCancelSelectEvent();
        }

        // initial parsed course information
        public void CrawlCourseInfoFromWeb()
        {
            Course course = new Course();
            for (int i = 0; i < _departmentPathes.Length; i++)
            {
                List<CourseInfoDto> courseInfoDtos = course.CourseInfoCrawler(_departmentPathes[i]);
                _departments.Add(new Department(course.GetDepartmentName(), courseInfoDtos));
                _courses.AddRange(courseInfoDtos);
            }
        }

        // get parsed course information
        public List<CourseInfoDto> GetCourseInfo(int classIndex)
        {
            return _departments[classIndex].GetCourseInfoDtos();
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

        // AddCourse
        internal void AddCourse(CourseInfoDto editedCourse)
        {
            CourseInfoDto newCourse = new CourseInfoDto(editedCourse);
            _courses.Add(newCourse);
            _departments[Array.IndexOf(_departmentNames, newCourse.GetDepartmentName())].AddCourse(newCourse);
        }
    }
}