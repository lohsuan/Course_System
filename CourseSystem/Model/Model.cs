using System;
using System.Collections.Generic;
using System.Threading;

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
        public event OnCourseImportEventHandler _courseImportEvent;
        public delegate void OnCourseImportEventHandler();

        private List<string> _departmentPathes = new List<string>();
        private List<string> _departmentNames = new List<string>();

        List<Department> _departments = new List<Department>(); // read only, storing each department's course
        Curriculum _curriculum = new Curriculum(); // storing selected course
        List<CourseInfoDto> _courses = new List<CourseInfoDto>(); // storing all departments' courses

        // initial parsed course information
        public Model()
        {
            _departmentPathes = new List<string>()
            {
                CourseConstant.COMPUTER_SCIENCE_JUNIOR_CLASS_URL, CourseConstant.ELECTRIC_ENGINEERING_JUNIOR_CLASS_URL
            };
            _departmentNames = new List<string> 
            {
                CourseConstant.COMPUTER_SCIENCE_JUNIOR, CourseConstant.ELECTRIC_ENGINEERING_JUNIOR 
            };
            Course course = new Course();
            for (int i = 0; i < _departmentPathes.Count; i++)
            {
                List<CourseInfoDto> courseInfoDtos = course.CourseInfoCrawler(_departmentPathes[i]);
                _departments.Add(new Department(course.GetDepartmentName(), courseInfoDtos));
                _courses.AddRange(courseInfoDtos);
            }
        }

        // on course created
        public void NotifyCourseCreated()
        {
            if (_courseDataCreateEvent != null)
                _courseDataCreateEvent();
        }

        // on course update
        public void NotifyCourseUpdated()
        {
            if (_courseDataUpdateEvent != null)
                _courseDataUpdateEvent();
        }

        // on course Select
        public void NotifyCourseSelect()
        {
            if (_courseSelectEvent != null)
                _courseSelectEvent();
        }

        // on course Cancel Select
        public void NotifyCourseCancelSelect()
        {
            if (_courseCancelSelectEvent != null)
                _courseCancelSelectEvent();
        }

        // on course Imort
        public void NotifyCourseImport()
        {
            if (_courseImportEvent != null)
                _courseImportEvent();
        }

        // get parsed course information
        public List<CourseInfoDto> GetCourseInfo(int classIndex)
        {
            return _departments[classIndex].GetCourseInfoDtos();
        }

        // GetCourseByIndex
        public CourseInfoDto GetCourseByIndex(int selectedIndex)
        {
            return _courses[selectedIndex];
        }

        // GetAllDepartmentName
        public string[] GetAllDepartmentName()
        {
            return _departmentNames.ToArray();
        }

        // get department by index
        public List<CourseInfoDto> GetDepartmentCourse(int tabIndex)
        {
            return _departments[tabIndex].GetCourseInfoDtos();
        }

        // get departments
        public List<Department> GetDepartments()
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
        public void SelectCheckedCourseToCurriculum(List<CourseInfoDto> checkedCourses)
        {
            _curriculum.AddCourse(checkedCourses);
        }

        // unselect course from curriculum
        public void CancelSelectCourseFromCurriculum(string id)
        {
            _curriculum.RemoveCourse(id);
        }

        // get curriculum(selected course)
        public List<CourseInfoDto> GetCurriculum()
        {
            return _curriculum.GetCurriculum();
        }

        // get all course
        public List<CourseInfoDto> GetAllCourses()
        {
            return _courses;
        }

        // ChangeCourseClass 
        public void ChangeCourseClass(CourseInfoDto courseInfoDto, string oldDepartment, string newDepartment)
        {
            int oldDepartmentIndex = _departmentNames.FindIndex(x => x == oldDepartment);
            int newDepartmentIndex = _departmentNames.FindIndex(x => x == newDepartment);

            _departments[oldDepartmentIndex].RemoveCourse(courseInfoDto);
            _departments[newDepartmentIndex].AddCourse(courseInfoDto);
        }

        // AddCourse
        public void AddCourse(CourseInfoDto editedCourse)
        {
            CourseInfoDto newCourse = new CourseInfoDto(editedCourse);
            _courses.Add(newCourse);
            _departments[_departmentNames.FindIndex(x => x == newCourse.GetDepartmentName())].AddCourse(newCourse);
        }

        // ImportClass
        public void ImportClass(string coursePath)
        {
            Course course = new Course();
            if (_departmentPathes.Find(x => x.Equals(coursePath)) != null)
                return;
            List<CourseInfoDto> courseInfoDtos = course.CourseInfoCrawler(coursePath);
            _departments.Add(new Department(course.GetDepartmentName()));
            _departmentNames.Add(course.GetDepartmentName());
            _departmentPathes.Add(coursePath);
            AddNotDuplicateNumberCourse(courseInfoDtos);
        }

        // AddNotDuplicateNumberCourse
        private void AddNotDuplicateNumberCourse(List<CourseInfoDto> courseInfoDtos)
        {
            foreach (CourseInfoDto courseInfoDto in courseInfoDtos)
            {
                if (GetNumber(courseInfoDto) == "" || _courses.FindAll(x => x.Number.Equals(GetNumber(courseInfoDto))).Count == 0)
                {
                    _courses.Add(courseInfoDto);
                    _departments[_departments.Count - 1].AddCourse(courseInfoDto);
                }
            }
        }

        // GetNumber
        private string GetNumber(CourseInfoDto courseInfoDto)
        {
            return courseInfoDto.Number;
        }

        // get department amount
        public int GetDepartmentAmount()
        {
            return _departments.Count;
        }
    }
}