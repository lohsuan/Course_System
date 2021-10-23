using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseSystem
{
    class CourseManagementFormPresentationModel
    {
        private Model _model;

        public CourseManagementFormPresentationModel(Model model)
        {
            _model = model;
        }

        // get all course
        internal List<CourseInfoDto> GetAllCourses()
        {
            return _model.GetAllCourses();
        }

    }
}
