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

        // get selected course
        public List<CourseInfoDto> GetOpeningCourseCurriculum()
        {
            return _model.GetCurriculum().FindAll(x => x.GetCourseStatus() == 0);
        }

        // unselect course
        public void CancelSelectCourse(string id)
        {
            _model.CancelSelectCourseFromCurriculum(id);
            _model.NotifyCourseCancelSelect();
        }
    }
}
