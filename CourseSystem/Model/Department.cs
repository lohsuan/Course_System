using System.Collections.Generic;

namespace CourseSystem
{
    public class Department
    {
        private List<CourseInfoDto> _courseInfoDtos = new List<CourseInfoDto>();
        private string _departmentName = "";

        public Department(string departmentName, List<CourseInfoDto> courseInfoDtos)
        {
            _departmentName = departmentName;
            _courseInfoDtos = courseInfoDtos;
        }

        public Department(string departmentName)
        {
            _departmentName = departmentName;
        }

        // get class' course
        public List<CourseInfoDto> GetCourseInfoDtos()
        {
            return _courseInfoDtos;
        }

        // get department name
        public string GetDepartmentName()
        {
            return _departmentName;
        }

        // AddCourse
        public void AddCourse(CourseInfoDto newCourse)
        {
            _courseInfoDtos.Add(newCourse);
        }

        // RemoveCourse
        public void RemoveCourse(CourseInfoDto courseInfoDto)
        {
            _courseInfoDtos.Remove(courseInfoDto);
        }
    }
}
