using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace CourseSystem
{
    class CourseManagementFormPresentationModel : INotifyPropertyChanged
    {
        //: INotifyPropertyChanged
        private Model _model;
        private bool _isEditMode = true;
        public event PropertyChangedEventHandler PropertyChanged;
        private CourseInfoDto _currentCourse = new CourseInfoDto();

        public CourseManagementFormPresentationModel(Model model)
        {
            _model = model;
        }

        // get all course name
        internal List<string> GetAllCourseName()
        {
            List<string> courseNames = new List<string>();
            foreach (CourseInfoDto course in _model.GetAllCourses())
                courseNames.Add(course.Name);
            return courseNames;
        }

        // GetSelectedCourseInfo to groupbox
        internal void GetSelectedCourseInfo(int selectedIndex)
        {
            _isEditMode = true;
            _currentCourse = _model.GetCourseByIndex(selectedIndex);
            notify("CourseEditModeText");
            notify("SelectedCourseNumberText");
        }

        // databinding: notify function
        private void notify(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        public string CourseEditModeText
        {
            get
            {
                if (_isEditMode)
                    return "編輯課程";
                return "新增課程";
            }
        }

        public string SelectedCourseNumberText
        {
            get
            {
                return _currentCourse.Number;
            }
        }
    }
}
