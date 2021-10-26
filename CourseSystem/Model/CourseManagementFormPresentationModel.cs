using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace CourseSystem
{

    class CourseManagementFormPresentationModel
    {
        private const char SPACE_KEY = ' ';
        private Model _model;
        private CourseInfoDto _currentCourse;
        private CourseInfoDto _editedCourse;

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
            _currentCourse = _model.GetCourseByIndex(selectedIndex);
            _editedCourse = new CourseInfoDto(_currentCourse);
        }

        // check is number or not
        internal bool IsNumberInput(char keyChar)
        {
            return Char.IsDigit(keyChar) || Char.IsControl(keyChar) || (keyChar == '.');
        }

        // Save button is Enable when info is edited
        internal bool IsTextChangedAndMeetRequirement()
        {
            return (_currentCourse.Number != _editedCourse.Number) || (_currentCourse.Name != _editedCourse.Name) || (_currentCourse.Stage != _editedCourse.Stage) || (_currentCourse.Credit != _editedCourse.Credit) || (_currentCourse.Teacher != _editedCourse.Teacher) || (_currentCourse.TeacherAssistant != _editedCourse.TeacherAssistant) || (_currentCourse.Language != _editedCourse.Language) || (_currentCourse.Syllabus != _editedCourse.Syllabus) && (_editedCourse.Number != "") && (_editedCourse.Name != "") && (_editedCourse.Stage != "") && (_editedCourse.Credit != "") && (_editedCourse.Teacher != "");
        }

        internal bool IsItemChangedAndHourCorrect()
        {
            return (_currentCourse.RequiredType != _editedCourse.RequiredType) || (_currentCourse.Hour!= _editedCourse.Hour) || (_currentCourse.GetDepartmentName() != _editedCourse.GetDepartmentName());
        }

        /// /////////////////////////////////////////////////////////////////////////////////////////////

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

        // get class time
        internal List<string> GetClassTime()
        {
            List<string> classTimes = GetClassTime(_currentCourse);
            List<string> result = new List<string>();
            for (int i = 0; i < classTimes.Count; i++)
            {
                if (classTimes[i] != "")
                {
                    foreach (string time in classTimes[i].Split(SPACE_KEY))
                    {
                        result.Add(i.ToString() + SPACE_KEY + time);
                    }
                }
            }
            return result;
        }

        // get class time
        private List<string> GetClassTime(CourseInfoDto courseInfoDto)
        {
            return courseInfoDto.GetClassTime();
        }

        /// ////////////////////////////////////////////////////////////////////

        internal void SetCourseEditNumber(string number)
        {
            _editedCourse.Number = number;
        }

        internal void SetCourseEditName(string name)
        {
            _editedCourse.Name = name;
        }

        internal void SetCourseEditStage(string stage)
        {
            _editedCourse.Stage = stage;
        }

        internal void SetCourseEditCredit(string credit)
        {
            _editedCourse.Credit = credit;
        }

        internal void SetCourseEditTeacher(string teacher)
        {
            _editedCourse.Teacher = teacher;
        }

        internal void SetCourseEditRequireType(object selectedItem)
        {
            if (selectedItem != null)
                _editedCourse.RequiredType = selectedItem.ToString();
        }

        internal void SetCourseEditTeacherAssistant(string teacherAssistant)
        {
            _editedCourse.TeacherAssistant = teacherAssistant;
        }

        internal void SetCourseEditLanguage(string language)
        {
            _editedCourse.Language = language;
        }

        internal void SetCourseEditSyllabus(string syllabus)
        {
            _editedCourse.Syllabus = syllabus;
        }

        internal void SetCourseEditHour(object selectedItem)
        {
            if (selectedItem != null)
                _editedCourse.Hour = selectedItem.ToString();
        }

        internal void SetCourseEditClass(object selectedItem)
        {
            if (selectedItem != null)
                _editedCourse.SetDepartmentName(selectedItem.ToString());
        }

    }
}
