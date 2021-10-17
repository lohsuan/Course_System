using System.Collections.Generic;

namespace CourseSystem
{
    public class CourseSelectionResultFormPresentationModel
    {
        Model _model;
        public CourseSelectionResultFormPresentationModel(Model model)
        {
            _model = model;
        }

        // get course header text of school timetable
        public Dictionary<string, string> GetCourseHeader()
        {
            return _model.GetCourseHeader();
        }

        // get selected course
        internal List<CourseInfoDto> GetCurriculum()
        {
            return _model.GetCurriculum();
        }

        // unselect course
        internal void CancelSelectCourse(string courseNumber)
        {
            _model.CancelSelectCourseFromCurriculum(courseNumber);
        }
    }
}
