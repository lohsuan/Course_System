using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace CourseSystem
{

    class CourseManagementFormPresentationModel
    {
        enum Mode
        {
            Add,
            Edit
        }
        private const char SPACE_KEY = ' ';
        private const char DOT = '.';
        private Model _model;
        private CourseInfoDto _currentCourse = new CourseInfoDto();
        private CourseInfoDto _editedCourse = new CourseInfoDto();
        private Mode _mode = Mode.Edit;

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
            _mode = Mode.Edit;
            _currentCourse = _model.GetCourseByIndex(selectedIndex);
            _editedCourse = new CourseInfoDto(_currentCourse);
        }

        // check is number or not
        internal bool IsNumberInput(char keyChar)
        {
            return Char.IsDigit(keyChar) || Char.IsControl(keyChar) || (keyChar == DOT);
        }

        // Save button is Enable when textbox text is edited and meet not empty requirement
        internal bool IsTextChangedAndMeetRequirement()
        {
            if ((_editedCourse.Number == "") || (_editedCourse.Name == "") || (_editedCourse.Stage == "") || (_editedCourse.Credit == "") || (_editedCourse.Teacher == ""))
                return false;
            return (_currentCourse.Number != _editedCourse.Number) || (_currentCourse.Name != _editedCourse.Name) || (_currentCourse.Stage != _editedCourse.Stage) || (_currentCourse.Credit != _editedCourse.Credit) || (_currentCourse.Teacher != _editedCourse.Teacher) || (_currentCourse.TeacherAssistant != _editedCourse.TeacherAssistant) || (_currentCourse.Language != _editedCourse.Language) || (_currentCourse.Syllabus != _editedCourse.Syllabus);
        }

        // Save button is Enable when select item chenged
        internal bool IsSelectedItemChangedAndHourCorrect()
        {
            return (_currentCourse.RequiredType != _editedCourse.RequiredType) || (_currentCourse.Hour != _editedCourse.Hour) || (_currentCourse.GetDepartmentName() != _editedCourse.GetDepartmentName());
        }

        // Save button is Enable when classTime checked change and total checked classtimes aree qual to hours
        internal bool IsClassTimeChangedAndMeetRequirement()
        {
            throw new NotImplementedException();
        }

        /// Get model data /////////////////////////////////////////////////////////////////////////////////////////////

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

        /// Set _editedCourse data ////////////////////////////////////////////////////////////////////

        // SetCourseEditNumber
        internal void SetCourseEditNumber(string number)
        {
            _editedCourse.Number = number;
        }

        // SetCourseEditName
        internal void SetCourseEditName(string name)
        {
            _editedCourse.Name = name;
        }

        // SetCourseEditStage
        internal void SetCourseEditStage(string stage)
        {
            _editedCourse.Stage = stage;
        }

        // SetCourseEditCredit
        internal void SetCourseEditCredit(string credit)
        {
            _editedCourse.Credit = credit;
        }

        // SetCourseEditTeacher
        internal void SetCourseEditTeacher(string teacher)
        {
            _editedCourse.Teacher = teacher;
        }

        // SetCourseEditRequireType
        internal void SetCourseEditRequireType(object selectedItem)
        {
            if (selectedItem != null)
                _editedCourse.RequiredType = selectedItem.ToString();
        }

        // SetCourseEditTeacherAssistant
        internal void SetCourseEditTeacherAssistant(string teacherAssistant)
        {
            _editedCourse.TeacherAssistant = teacherAssistant;
        }

        // SetCourseEditLanguage
        internal void SetCourseEditLanguage(string language)
        {
            _editedCourse.Language = language;
        }

        // SetCourseEditSyllabus
        internal void SetCourseEditSyllabus(string syllabus)
        {
            _editedCourse.Syllabus = syllabus;
        }

        // SetCourseEditHour
        internal void SetCourseEditHour(object selectedItem)
        {
            if (selectedItem != null)
                _editedCourse.Hour = selectedItem.ToString();
        }

        // SetCourseEditClass
        internal void SetCourseEditClass(object selectedItem)
        {
            if (selectedItem != null)
                _editedCourse.SetDepartmentName(selectedItem.ToString());
        }

        // SetCourseEditClassTime
        internal void SetCourseEditClassTime(int columnIndex, int rowIndex)
        {
            //_editedCourse.ClassTimeMonday
        }

        // save course
        internal void UpdateOrAddCourse()
        {
            if (_mode.Equals(Mode.Edit))
            {
                _currentCourse.UpdateCourse(_editedCourse);
                _model.NotifyCourseUpdated();
            }
            else
            {
                _model.AddCourse(_editedCourse);
                _model.NotifyCourseCreated();
            }
        }

        // add course mode
        internal void AddCourseMode()
        {
            _mode = Mode.Add;
            _editedCourse = new CourseInfoDto();
        }
    }
}
