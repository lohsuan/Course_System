
using System;
using System.Collections.Generic;

namespace CourseSystem
{
    public class CourseInfoDto
    {
        private const int SUNDAY_INDEX = 0;
        private const int MONDAY_INDEX = 1;
        private const int TUESDAY_INDEX = 2;
        private const int WEDNESDAY_INDEX = 3;
        private const int THURSDAY_INDEX = 4;
        private const int FRIDAY_INDEX = 5;
        private const int SATURDAY_INDEX = 6;
        private string _departmentName;
        private int _courseStatus;

        public CourseInfoDto(string number, string name, string stage, string credit, string hour, 
            string requiredType, string teacher, string classTimeSunday, string classTimeMonday, string classTimeTuesday,
            string classTimeWednesday, string classTimeThursday, string classTimeFriday, string classTimeSaturday, string classroom, 
            string numberOfStudent, string numberOfDropStudent, string teacherAssistant, string language, 
            string note, string syllabus, string audit, string experiment, string departmentName)
        {
            this.Id = Guid.NewGuid().ToString();
            this.Number = number;
            this.Name = name;
            this.Stage = stage;
            this.Credit = credit;
            this.Hour = hour;
            this.RequiredType = requiredType;
            this.Teacher = teacher;
            this.ClassTimeSunday = classTimeSunday;
            this.ClassTimeMonday = classTimeMonday;
            this.ClassTimeTuesday = classTimeTuesday;
            this.ClassTimeWednesday = classTimeWednesday;
            this.ClassTimeThursday = classTimeThursday;
            this.ClassTimeFriday = classTimeFriday;
            this.ClassTimeSaturday = classTimeSaturday;
            this.Classroom = classroom;
            this.NumberOfStudent = numberOfStudent;
            this.NumberOfDropStudent = numberOfDropStudent;
            this.TeacherAssistant = teacherAssistant;
            this.Language = language;
            this.Syllabus = syllabus;
            this.Note = note;
            this.Audit = audit;
            this.Experiment = experiment;
            this._departmentName = departmentName;
            this._courseStatus = 0;
        }

        public CourseInfoDto() 
        {
        }

        public CourseInfoDto(CourseInfoDto other)
        {
            this.Id = Guid.NewGuid().ToString();
            SetCourseBaseInfo(other);
            SetCourseAdditionInfo(other);
        }

        // update course
        public void UpdateCourse(CourseInfoDto other)
        {
            SetCourseBaseInfo(other);
            SetCourseAdditionInfo(other);
        }

        // IsCourseInfoMeetNotNullRequire
        public bool IsCourseInfoMeetNotNullRequire()
        {
            return (this.Number != "") && (this.Name != "") && (this.Stage != "") && (this.Credit != "") && (this.Teacher != "") &&
                (this.Number != null) && (this.Name != null) && (this.Stage != null) && (this.Credit != null) && (this.Teacher != null);
        }

        // GetCourseInfoDtoData
        public List<string> GetCourseInfoDtoData()
        {
            return new List<string> 
            { 
                this.Id, this.Number, this.Name, this.Stage, this.Credit, this.Hour, this.RequiredType, this.Teacher, this.ClassTimeSunday, this.ClassTimeMonday, this.ClassTimeTuesday, this.ClassTimeWednesday, this.ClassTimeThursday, this.ClassTimeFriday, this.ClassTimeSaturday, this.Classroom, this.NumberOfStudent, this.NumberOfDropStudent, this.TeacherAssistant, this.Language, this.Note, this.Syllabus, this.Audit, this.Experiment 
            };
        }

        // SetCourseBaseInfo
        private void SetCourseBaseInfo(CourseInfoDto other)
        {
            _courseStatus = other.GetCourseStatus();
            this.Number = other.Number;
            this.Name = other.Name;
            this.Stage = other.Stage;
            this.Credit = other.Credit;
            this.Hour = other.Hour;
            this.RequiredType = other.RequiredType;
            this.Teacher = other.Teacher;
        }

        // SetCourseAdditionInfo
        private void SetCourseAdditionInfo(CourseInfoDto other)
        {
            this.ClassTimeSunday = other.ClassTimeSunday;
            this.ClassTimeMonday = other.ClassTimeMonday;
            this.ClassTimeTuesday = other.ClassTimeTuesday;
            this.ClassTimeWednesday = other.ClassTimeWednesday;
            this.ClassTimeThursday = other.ClassTimeThursday;
            this.ClassTimeFriday = other.ClassTimeFriday;
            this.ClassTimeSaturday = other.ClassTimeSaturday;
            this.Classroom = other.Classroom;
            this.NumberOfStudent = other.NumberOfStudent;
            this.NumberOfDropStudent = other.NumberOfDropStudent;
            this.TeacherAssistant = other.TeacherAssistant;
            this.Language = other.Language;
            this.Syllabus = other.Syllabus;
            this.Note = other.Note;
            this.Audit = other.Audit;
            this.Experiment = other.Experiment;
            this._departmentName = other._departmentName;
        }

        // SetCourseEditClassTime
        internal void SetCourseEditClassTime(string[] classTime)
        {
            this.ClassTimeSunday = classTime[SUNDAY_INDEX];
            this.ClassTimeMonday = classTime[MONDAY_INDEX];
            this.ClassTimeTuesday = classTime[TUESDAY_INDEX];
            this.ClassTimeWednesday = classTime[WEDNESDAY_INDEX];
            this.ClassTimeThursday = classTime[THURSDAY_INDEX];
            this.ClassTimeFriday = classTime[FRIDAY_INDEX];
            this.ClassTimeSaturday = classTime[SATURDAY_INDEX];
        }

        // override of Equal in CourseInfoDto
        public bool Equals(CourseInfoDto other)
        {                
            return this.Id.Equals(other.Id);
        }

        // get classtime
        public List<string> GetClassTime()
        {
            return new List<string> 
            { 
                ClassTimeSunday, ClassTimeMonday , ClassTimeTuesday, ClassTimeWednesday, ClassTimeThursday, ClassTimeFriday, ClassTimeSaturday
            };
        }

        // SetCourseStatus
        public void SetCourseStatus(int courseStatus)
        {
            _courseStatus = courseStatus;
        }

        // GetCourseStatus
        public int GetCourseStatus()
        {
            return _courseStatus;
        }

        // get departmentname
        public string GetDepartmentName()
        {
            return _departmentName;
        }

        // set department name
        internal void SetDepartmentName(string departmentName)
        {
            _departmentName = departmentName;
        }

        public string Id
        {
            get; set;
        }

        public string Number
        {
            get; set;
        }

        public string Name
        {
            get; set;
        }

        public string Stage
        {
            get; set;
        }

        public string Credit
        {
            get; set;
        }

        public string Hour
        {
            get; set;
        }

        public string RequiredType
        {
            get; set;
        }

        public string Teacher
        {
            get; set;
        }

        public string ClassTimeSunday
        {
            get; set;
        }

        public string ClassTimeMonday
        {
            get; set;
        }

        public string ClassTimeTuesday
        {
            get; set;
        }

        public string ClassTimeWednesday
        {
            get; set;
        }

        public string ClassTimeThursday
        {
            get; set;
        }

        public string ClassTimeFriday
        {
            get; set;
        }

        public string ClassTimeSaturday
        {
            get; set;
        }

        public string Classroom
        {
            get; set;
        }

        public string NumberOfStudent
        {
            get; set;
        }

        public string NumberOfDropStudent
        {
            get; set;
        }

        public string TeacherAssistant
        {
            get; set;
        }

        public string Language
        {
            get; set;
        }
        
        public string Note
        {
            get; set;
        }

        public string Syllabus
        {
            get; set;
        }

        public string Audit
        {
            get; set;
        }

        public string Experiment
        {
            get; set;
        }
    }
}
