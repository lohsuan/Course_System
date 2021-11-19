using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseSystem
{
    class ClassManagementPresentationModel
    {
        private Model _model;
        private string _newCourseName;

        public ClassManagementPresentationModel(Model model)
        {
            _model = model;
        }

        // GetClassCourseByIndex
        internal List<string> GetClassCourseNamesByIndex(int selectedIndex)
        {
            return _model.GetClassCourseByDepartmentIndex(selectedIndex);
        }

        // SetNewCourseName
        internal void SetNewCourseName(string text)
        {
            _newCourseName = text;
        }

        // IsAddButtonEnable
        internal bool IsAddButtonEnable()
        {
            return _newCourseName != "";
        }

        // AddClass
        internal void AddClass()
        {
            _model.AddClass(_newCourseName);
            _model.NotifyClassAdd();
        }
    }
}
