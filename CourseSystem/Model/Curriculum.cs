using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseSystem
{
    public class Curriculum
    {
        private List<CourseInfoDto> _selectedCourse = new List<CourseInfoDto>();

        // get curriculum
        public List<CourseInfoDto> GetCurriculum()
        {
            return _selectedCourse;
        }

        // add course to curriculum
        internal void AddCourse(List<CourseInfoDto> checkedCourses)
        {
            _selectedCourse.AddRange(checkedCourses);
        }

        // delete course from curriculum
        internal void RemoveCourse(string id)
        {
            CourseInfoDto course = _selectedCourse.Find(x => x.Id.Equals(id));
            _selectedCourse.Remove(course);
        }
    }
}
