using System;
using System.Collections.Generic;

namespace CourseSystem
{
    public class Model
    {
        // get parsed course information
        public List<CourseInfoDto> GetCourseInfo()
        {
            return Course.GetCourseInfo();
        }

    }
}