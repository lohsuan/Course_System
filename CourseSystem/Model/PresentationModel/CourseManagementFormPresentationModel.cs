using System;
using System.Collections.Generic;

namespace CourseSystem
{
    public class CourseManagementFormPresentationModel
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
        public List<string> GetAllCourseName()
        {
            List<string> courseNames = new List<string>();
            foreach (CourseInfoDto course in _model.GetAllCourses())
                courseNames.Add(course.Name);
            return courseNames;
        }

        // GetSelectedCourseInfo to groupbox
        public void UpdateSelectedCourse(int selectedIndex)
        {
            _mode = Mode.Edit;
            _currentCourse = _model.GetCourseByIndex(selectedIndex);
            _editedCourse = new CourseInfoDto(_currentCourse);
        }

        // check is number or not
        public bool IsNumberInput(char keyChar)
        {
            return Char.IsDigit(keyChar) || Char.IsControl(keyChar) || (keyChar == DOT);
        }

        // Is Save/Add Course Button Enable
        public bool IsSaveButtonEnable(int hour)
        {
            return IsCourseInfoMeetNotNullRequire() && IsCheckedClassTimeEqualToHour(hour);
        }

        // IsTextBoxMeetNotNullRequirement
        public bool IsCourseInfoMeetNotNullRequire()
        {
            return _editedCourse.IsCourseInfoMeetNotNullRequire();
        }

        // Save button is Enable when total checked classtimes aree qual to hours (classTime checked change)
        public bool IsCheckedClassTimeEqualToHour(int hour)
        {
            return _checkedCourseAmount == hour;
        }

        // GetCourseStatus
        public int GetCourseStatus()
        {
            return _currentCourse.GetCourseStatus();
        }

        // GetNumber
        public string GetNumber()
        {
            return _currentCourse.Number;
        }

        // GetName
        public string GetName()
        {
            return _currentCourse.Name;
        }

        //GetStage
        public string GetStage()
        {
            return _currentCourse.Stage;
        }

        // GetCredit
        public string GetCredit()
        {
            return _currentCourse.Credit;
        }

        // GetTeacher
        public string GetTeacher()
        {
            return _currentCourse.Teacher;
        }

        // GetRequireType
        public object GetRequireType()
        {
            return _currentCourse.RequiredType;
        }

        // GetTeacherAssistant
        public string GetTeacherAssistant()
        {
            return _currentCourse.TeacherAssistant;
        }

        // GetLanguage
        public string GetLanguage()
        {
            return _currentCourse.Language;
        }

        // GetSyllabus
        public string GetSyllabus()
        {
            return _currentCourse.Syllabus;
        }

        // GetHour
        public object GetHour()
        {
            return _currentCourse.Hour;
        }

        // GetClass
        public object GetClass()
        {
            return _currentCourse.GetDepartmentName();
        }

        // GetClass
        public string[] GetAllClassName()
        {
            return _model.GetAllDepartmentName();
        }

        // get class time
        public List<string> GetClassTime()
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

        // UpdateCheckedCourseAmount
        public void UpdateCheckedCourse(bool editedFormattedValue)
        {
            if (editedFormattedValue)
                _checkedCourseAmount++;
            else
                _checkedCourseAmount--;
        }

        // SetCourseEditClassTime
        public void SetCourseEditClassTime(string[] classTime)
        {
            _editedCourse.SetCourseEditClassTime(classTime);
        }

        // SetCourseEditCourseStatus
        public void SetCourseEditCourseStatus(int selectedIndex)
        {
            _editedCourse.SetCourseStatus(selectedIndex);
        }

        // SetCourseEditNumber
        public void SetCourseEditNumber(string number)
        {
            _editedCourse.Number = number;
        }

        // SetCourseEditName
        public void SetCourseEditName(string name)
        {
            _editedCourse.Name = name;
        }

        // SetCourseEditStage
        public void SetCourseEditStage(string stage)
        {
            _editedCourse.Stage = stage;
        }

        // SetCourseEditCredit
        public void SetCourseEditCredit(string credit)
        {
            _editedCourse.Credit = credit;
        }

        // SetCourseEditTeacher
        public void SetCourseEditTeacher(string teacher)
        {
            _editedCourse.Teacher = teacher;
        }

        // SetCourseEditRequireType
        public void SetCourseEditRequireType(object selectedItem)
        {
            if (selectedItem != null)
                _editedCourse.RequiredType = selectedItem.ToString();
        }

        // SetCourseEditTeacherAssistant
        public void SetCourseEditTeacherAssistant(string teacherAssistant)
        {
            _editedCourse.TeacherAssistant = teacherAssistant;
        }

        // SetCourseEditLanguage
        public void SetCourseEditLanguage(string language)
        {
            _editedCourse.Language = language;
        }

        // SetCourseEditSyllabus
        public void SetCourseEditSyllabus(string syllabus)
        {
            _editedCourse.Syllabus = syllabus;
        }

        // SetCourseEditHourg
        public void SetCourseEditHour(object selectedItem)
        {
            if (selectedItem != null)
                _editedCourse.Hour = selectedItem.ToString();
        }

        // SetCourseEditClass
        public void SetCourseEditClass(object selectedItem)
        {
            if (selectedItem != null)
                _editedCourse.SetDepartmentName(selectedItem.ToString());
        }

        // save course
        public void UpdateOrAddCourse()
        {
            if (_mode.Equals(Mode.Edit))
            {
                var i1 = _editedCourse.GetDepartmentName();
                var i2 = _currentCourse.GetDepartmentName();

                if (_editedCourse.GetDepartmentName() != _currentCourse.GetDepartmentName())
                    _model.ChangeCourseClass(_currentCourse, _currentCourse.GetDepartmentName(), _editedCourse.GetDepartmentName());
                
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
        public void AddCourseMode()
        {
            _mode = Mode.Add;
            _checkedCourseAmount = 0;
            _editedCourse = new CourseInfoDto();
            _currentCourse = new CourseInfoDto();
        }
    }
}
