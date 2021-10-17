﻿
using System;
using System.Collections.Generic;

namespace CourseSystem
{
    public class CourseInfoDto
    {
        public CourseInfoDto(string number, string name, string stage, string credit, string hour, 
            string requiredType, string teacher, string classTimeSunday, string classTimeMonday, string classTimeTuesday,
            string classTimeWednesday, string classTimeThursday, string classTimeFriday, string classTimeSaturday, string classroom, 
            string numberOfStudent, string numberOfDropStudent, string teacherAssistant, string language, 
            string note, string syllabus, string audit, string experiment)
        {
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
        }

        public CourseInfoDto(CourseInfoDto previousCourseInfoDto)
        {
            this.Number = previousCourseInfoDto.Number;
            this.Name = previousCourseInfoDto.Name;
            this.Stage = previousCourseInfoDto.Stage;
            this.Credit = previousCourseInfoDto.Credit;
            this.Hour = previousCourseInfoDto.Hour;
            this.RequiredType = previousCourseInfoDto.RequiredType;
            this.Teacher = previousCourseInfoDto.Teacher;
            this.ClassTimeSunday = previousCourseInfoDto.ClassTimeSunday;
            this.ClassTimeMonday = previousCourseInfoDto.ClassTimeMonday;
            this.ClassTimeTuesday = previousCourseInfoDto.ClassTimeTuesday;
            this.ClassTimeWednesday = previousCourseInfoDto.ClassTimeWednesday;
            this.ClassTimeThursday = previousCourseInfoDto.ClassTimeThursday;
            this.ClassTimeFriday = previousCourseInfoDto.ClassTimeFriday;
            this.ClassTimeSaturday = previousCourseInfoDto.ClassTimeSaturday;
            this.Classroom = previousCourseInfoDto.Classroom;
            this.NumberOfStudent = previousCourseInfoDto.NumberOfStudent;
            this.NumberOfDropStudent = previousCourseInfoDto.NumberOfDropStudent;
            this.TeacherAssistant = previousCourseInfoDto.TeacherAssistant;
            this.Language = previousCourseInfoDto.Language;
            this.Syllabus = previousCourseInfoDto.Syllabus;
            this.Note = previousCourseInfoDto.Note;
            this.Audit = previousCourseInfoDto.Audit;
            this.Experiment = previousCourseInfoDto.Experiment;
        }

        // override of Equal in CourseInfoDto
        public bool Equals(CourseInfoDto other)
        {                
            return this.Number.Equals(other.Number);
        }

        // get classtime
        public List<string> GetClassTime()
        {
            return new List<string> 
            { 
                ClassTimeSunday, ClassTimeMonday , ClassTimeTuesday, ClassTimeWednesday, ClassTimeThursday, ClassTimeFriday, ClassTimeSaturday
            };
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

        public string Note
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
