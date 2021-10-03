using System;
using System.Collections.Generic;

namespace CourseSystem
{
    public class Model
    {
        int _courseSelectedNumber = 0;
        List<CourseInfoDto> _courseInfoDtos;

        public Model()
        {
            _courseInfoDtos = Course.GetCourseInfo();
        }

        // get parsed course information
        public List<CourseInfoDto> GetCourseInfo()
        {
            return _courseInfoDtos;
        }

        // get course header text of school timetable
        public Dictionary<string, string> GetCourseHeader()
        {
            Course course = new Course();
            return course.GetCourseHeader();
        }

        // update course ckecked state
        public void UpdateCourseChecked(int courseIndex)
        {
            _courseInfoDtos[courseIndex].UpdateChecked();
            if (_courseInfoDtos[courseIndex].IsChecked())
            {
                _courseSelectedNumber++;
                return;
            }
            _courseSelectedNumber--;
        }

        // check any course is checked
        public bool IsAnyCourseChecked()
        {
            return _courseSelectedNumber > 0;
        }
    }
}