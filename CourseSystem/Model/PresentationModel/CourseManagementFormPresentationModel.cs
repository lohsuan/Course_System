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
        private int _checkedCourseAmount = 0;

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

        // Is Save/Add Course Button Enable
        internal bool IsSaveButtonEnable(int hour)
        {
            return IsCourseInfoMeetNotNullRequire() && IsCheckedClassTimeEqualToHour(hour);
        }

        // IsTextBoxMeetNotNullRequirement
        internal bool IsCourseInfoMeetNotNullRequire()
        {
            return _editedCourse.IsCourseInfoMeetNotNullRequire();
        }

        // Save button is Enable when total checked classtimes aree qual to hours (classTime checked change)
        internal bool IsCheckedClassTimeEqualToHour(int hour)
        {
            return _checkedCourseAmount == hour;
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
            _checkedCourseAmount = 0;
            List<string> classTimes = GetClassTime(_currentCourse);
            List<string> result = new List<string>();
            for (int i = 0; i < classTimes.Count; i++)
            {
                if (classTimes[i] != "")
                {
                    foreach (string time in classTimes[i].Split(SPACE_KEY))
                    {
                        result.Add(i.ToString() + SPACE_KEY + time);
                        _checkedCourseAmount++;
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

        // UpdateCheckedCourseAmount
        internal void UpdateCheckedCourse(bool editedFormattedValue)
        {
            if (editedFormattedValue)
                _checkedCourseAmount++;
            else
                _checkedCourseAmount--;
        }

        // SetCourseEditClassTime
        internal void SetCourseEditClassTime(string[] classTime)
        {
            _editedCourse.SetCourseEditClassTime(classTime);
        }

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
            _checkedCourseAmount = 0;
            _editedCourse = new CourseInfoDto();
            _currentCourse = new CourseInfoDto();
        }
    }
}
