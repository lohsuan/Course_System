
using System;
using System.Collections.Generic;

namespace CourseSystem
{
    public class CourseInfoDto
    {
        private string _departmentName;

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
        }

        public CourseInfoDto() 
        {
        }

        public CourseInfoDto(CourseInfoDto other)
        {

            this.Number = other.Number;
            this.Name = other.Name;
            this.Stage = other.Stage;
            this.Credit = other.Credit;
            this.Hour = other.Hour;
            this.RequiredType = other.RequiredType;
            this.Teacher = other.Teacher;
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

        // update course
        internal void UpdateCourse(CourseInfoDto other)
        {
            this.Number = other.Number;
            this.Name = other.Name;
            this.Stage = other.Stage;
            this.Credit = other.Credit;
            this.Hour = other.Hour;
            this.RequiredType = other.RequiredType;
            this.Teacher = other.Teacher;
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

        public string Id
        {
            get;
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
