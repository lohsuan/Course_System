using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseSystem
{
    public class Curriculum
    {
        private List<CourseInfoDto> _curriculums;

        public Curriculum(List<CourseInfoDto> curriculums)
        {
            this._curriculums = curriculums;
        }

        // get curriculum
        public List<CourseInfoDto> GetCourses()
        {
            return _curriculums;
        }

        public string GetDepartmentName(int index)
        {
            return Department.GetDepartmentName(index);
        }
    }
}
