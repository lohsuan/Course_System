using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace CourseSystem
{

    class CourseManagementFormPresentationModel
    {
        private Model _model;
        private bool _isEditMode = true;
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
        internal void UpdateSelectedCourse(int selectedIndex)
        {
            _isEditMode = true;
            _currentCourse = _model.GetCourseByIndex(selectedIndex);
        }

        // GetNumber
        internal string GetNumber()
        {
            return _currentCourse.Number;
        }

        // GetName
        internal string GetName()
        {
            return _currentCourse.Name;
        }

        //GetStage
        internal string GetStage()
        {
            return _currentCourse.Stage;
        }

        // GetCredit
        internal string GetCredit()
        {
            return _currentCourse.Credit;
        }

        // GetTeacher
        internal string GetTeacher()
        {
            return _currentCourse.Teacher;
        }

        // GetRequireType
        internal object GetRequireType()
        {
            return _currentCourse.RequiredType;
        }

        // GetTeacherAssistant
        internal string GetTeacherAssistant()
        {
            return _currentCourse.TeacherAssistant;
        }

        // GetLanguage
        internal string GetLanguage()
        {
            return _currentCourse.Language;
        }

        // GetSyllabus
        internal string GetSyllabus()
        {
            return _currentCourse.Syllabus;
        }

        // GetHour
        internal object GetHour()
        {
            return _currentCourse.Hour;
        }

        // GetClass
        internal object GetClass()
        {
            return _currentCourse.GetDepartmentName();
        }

    }
}
