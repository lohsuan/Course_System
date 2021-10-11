using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseSystem
{
    public class CourseSelectingFormPresentationModel
    {
        private const string ADD_COURSE_SUCCESS = "加選成功\n";
        private const string ADD_COURSE_FAIL = "加選失敗\n";
        Model _model;

        public CourseSelectingFormPresentationModel()
        {
            this._model = new Model();
        }

        // get a class of course
        public List<CourseInfoDto> GetCourseInfo(int tabIndex)
        {
            return _model.GetCourseInfo(tabIndex);
        }

        // get a class of course
        public string GetDepartmentName(int tabIndex)
        {
            return _model.GetDepartmentName(tabIndex);
        }

        // get course header text of school timetable
        public Dictionary<string, string> GetCourseHeader()
        {
            return _model.GetCourseHeader();
        }

        // update course ckecked state
        public void UpdateCourseChecked(int curriculumIndex, int courseIndex)
        {
            _model.UpdateCourseChecked(curriculumIndex, courseIndex);
        }

        // check any course is checked
        public bool IsAnyCourseChecked()
        {
            return _model.IsAnyCourseChecked();
        }

        // check course doesn't overlap or has the same name
        public string CheckCoursesValidMessage()
        {
            string message = _model.GetCoursesValidMessage();
            if (message == "")
            {
                return ADD_COURSE_SUCCESS;
            }
            return ADD_COURSE_FAIL + message;
        }
    }
}
