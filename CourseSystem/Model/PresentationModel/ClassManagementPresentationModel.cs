using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseSystem
{
    public class ClassManagementPresentationModel
    {
        private Model _model;
        private string _newCourseName;

        public ClassManagementPresentationModel(Model model)
        {
            _model = model;
        }

        // GetClassCourseByIndex
        public List<string> GetClassCourseNamesByIndex(int selectedIndex)
        {
            return _model.GetClassCourseByDepartmentIndex(selectedIndex);
        }

        // SetNewCourseName
        public void SetNewClassName(string text)
        {
            _newCourseName = text;
        }

        // IsAddButtonEnable
        public bool IsAddButtonEnable()
        {
            return _newCourseName != "";
        }

        // AddClass
        public void AddClass()
        {
            _model.AddClass(_newCourseName);
            _model.NotifyClassAdd();
        }
    }
}
