
namespace CourseSystem
{
    class ImportCourseProgressFormPresentationModel
    {
        private Model _model;

        public ImportCourseProgressFormPresentationModel(Model model)
        {
            _model = model;
        }

        // import class
        public void ImportClass(string coursePath)
        {
            _model.ImportClass(coursePath);
        }
    }
}
