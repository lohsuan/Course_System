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

        // get course header text of school timetable
        public Dictionary<string, string> GetCourseHeader()
        {
            Course course = new Course();
            return course.GetCourseHeader();
        }
    }
}