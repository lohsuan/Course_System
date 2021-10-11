using System;
using System.Collections.Generic;

namespace CourseSystem
{
    public class Model
    {
        private const char SPACE_KEY = ' ';
        private const string DASH = "-";
        private const string CHINESE_COMMA = "、";
        private const string ADD_COURSE_FAIL_MESSAGE_HEAD = "「";
        private const string ADD_COURSE_FAIL_MESSAGE_TAIL = "」";
        private const string OVERLAP_HEAD = "\n衝堂 : ";
        private const string CHANGE_LINE = "\n";
        private const string SAME_COURSE_NAME_HEAD = "\n課程名稱相同 : ";
        private string[] _coursePathes = { CourseConstant.COMPUTER_SCIENCE_JUNIOR_CLASS_URL, CourseConstant.ELECTRIC_ENGINEERING_JUNIOR_CLASS_URL };
        int _courseSelectedNumber = 0;
        List<Curriculum> _curriculums = new List<Curriculum>();

        // get parsed course information
        public List<CourseInfoDto> GetCourseInfo(int classIndex)
        {
            Course course = new Course();
            List<CourseInfoDto> classCourseInfoDtos = course.CourseInfoCrawler(_coursePathes[classIndex]);
            _curriculums.Add(new Curriculum(classCourseInfoDtos));
            return classCourseInfoDtos;
        }

        // get department name
        public string GetDepartmentName(int index)
        {
            return _curriculums[index].GetDepartmentName(index);
        }

        // get course header text of school timetable
        public Dictionary<string, string> GetCourseHeader()
        {
            Course course = new Course();
            return course.GetCourseHeader();
        }

        // update course ckecked state
        public void UpdateCourseChecked(int curriculumIndex, int courseIndex)
        {
            List<CourseInfoDto> courses = _curriculums[curriculumIndex].GetCourses();
            courses[courseIndex].UpdateChecked();
            if (courses[courseIndex].IsChecked())
            {
                _courseSelectedNumber++;
                return;
            }
            _courseSelectedNumber--;
        }

        // get course valid message
        public string GetCoursesValidMessage()
        {
            return CheckAnyCourseOverlapMessage() + CheckAnyCourseHasTheSameNameMessage();
        }

        // message for checking course overlape
        private string CheckAnyCourseOverlapMessage()
        {
            Dictionary<string, string> classMap = new Dictionary<string, string>(); // ex: <"4 1", "博雅選修課程 291704">
            
            foreach (Curriculum curriculum in _curriculums)
            {
                List<CourseInfoDto> courses = curriculum.GetCourses();
                foreach (CourseInfoDto courseInfoDto in courses)
                {
                    if (courseInfoDto.IsChecked())
                    {
                        string message = CheckCheckedCourseOverlapMessage(courseInfoDto, classMap);
                        if (message != "")
                            return message;
                    }
                }
            }
            return "";
        }

        // check checked course overlapping
        private string CheckCheckedCourseOverlapMessage(CourseInfoDto courseInfoDto, Dictionary<string, string> classMap)
        {
            List<string> classTimes = GetClassTime(courseInfoDto);
            for (int i = 0; i < classTimes.Count; i++)
            {
                if (classTimes[i] != "")
                {
                    foreach (string time in classTimes[i].Split(SPACE_KEY))
                    {
                        string key = i.ToString() + SPACE_KEY + time;
                        if (classMap.ContainsKey(key))
                        {
                            return OVERLAP_HEAD + PrepareCourseOverlapMessage(courseInfoDto, classMap, key) + CHANGE_LINE;
                        }
                        classMap.Add(key, GetCourseNumber(courseInfoDto) + DASH + GetCourseName(courseInfoDto));
                    }
                }
            }
            return "";
        }

        // prepare course overlap message
        private static string PrepareCourseOverlapMessage(CourseInfoDto courseInfoDto, Dictionary<string, string> classMap, string key)
        {
            string result = "";
            result += ADD_COURSE_FAIL_MESSAGE_HEAD + classMap[key] + ADD_COURSE_FAIL_MESSAGE_TAIL + CHINESE_COMMA;
            classMap[key] = GetCourseNumber(courseInfoDto) + DASH + GetCourseName(courseInfoDto);
            result += ADD_COURSE_FAIL_MESSAGE_HEAD + classMap[key] + ADD_COURSE_FAIL_MESSAGE_TAIL;
            return result;
        }

        // message for checking course name conflict
        private string CheckAnyCourseHasTheSameNameMessage()
        {
            var classMap = new Dictionary<string, string>(); // ex: <"博雅選修課程", "博雅選修課程 291704">
            foreach (Curriculum curriculum in _curriculums)
            {
                List<CourseInfoDto> courses = curriculum.GetCourses();
                foreach (CourseInfoDto courseInfoDto in courses)
                {
                    if (courseInfoDto.IsChecked())
                    {
                        string message = CheckCheckedCourseHasTheSameName(courseInfoDto, classMap);
                        if (message != "")
                            return message;
                    }
                }
            }
            return "";
        }

        // check checked course has the same name
        private string CheckCheckedCourseHasTheSameName(CourseInfoDto courseInfoDto, Dictionary<string, string> classMap)
        {
            string key = courseInfoDto.Name;
            if (classMap.ContainsKey(key))
            {
                string message = "";
                message += ADD_COURSE_FAIL_MESSAGE_HEAD + classMap[key] + ADD_COURSE_FAIL_MESSAGE_TAIL + CHINESE_COMMA;
                classMap[key] = GetCourseNumber(courseInfoDto) + SPACE_KEY + GetCourseName(courseInfoDto);
                message += ADD_COURSE_FAIL_MESSAGE_HEAD + classMap[key] + ADD_COURSE_FAIL_MESSAGE_TAIL;
                return SAME_COURSE_NAME_HEAD + message + CHANGE_LINE;
            }
            else
            {
                classMap.Add(key, GetCourseNumber(courseInfoDto) + SPACE_KEY + GetCourseName(courseInfoDto));
            }
            return "";
        }

        // check any course is checked
        public bool IsAnyCourseChecked()
        {
            return _courseSelectedNumber > 0;
        }

        // get course name
        private static string GetCourseName(CourseInfoDto courseInfoDto)
        {
            return courseInfoDto.Name;
        }

        // get course number
        private static string GetCourseNumber(CourseInfoDto courseInfoDto)
        {
            return courseInfoDto.Number;
        }

        // get class time
        private List<string> GetClassTime(CourseInfoDto courseInfoDto)
        {
            return courseInfoDto.GetClassTime();
        }
    }
}