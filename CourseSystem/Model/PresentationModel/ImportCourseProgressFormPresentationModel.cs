
namespace CourseSystem
{
    public class ImportCourseProgressFormPresentationModel
    {
        private Model _model;
        private string[] _computerScienceCoursePathes = { CourseConstant.COMPUTER_SCIENCE_FRESHMAN_CLASS_URL, CourseConstant.COMPUTER_SCIENCE_SOPHOMORE_CLASS_URL, CourseConstant.COMPUTER_SCIENCE_JUNIOR_CLASS_URL, CourseConstant.COMPUTER_SCIENCE_SENIOR_CLASS_URL, CourseConstant.COMPUTER_SCIENCE__GRADUATE_SCHOOL_URL };

        public ImportCourseProgressFormPresentationModel(Model model)
        {
            _model = model;
        }

        // import class
        public void ImportClass(string coursePath)
        {
            _model.ImportClass(coursePath);
        }

        // GetComputerScienceCoursePathes
        public string[] GetComputerScienceCoursePathes()
        {
            return _computerScienceCoursePathes;
        }
    }
}
