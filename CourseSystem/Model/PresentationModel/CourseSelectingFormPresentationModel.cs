using System;
using System.Collections.Generic;

namespace CourseSystem
{
    public class CourseSelectingFormPresentationModel
    {
        private const char SPACE_KEY = ' ';
        private const string DASH = "-";
        private const string CHINESE_COMMA = "、";
        private const string ADD_COURSE_FAIL_MESSAGE_HEAD = "「";
        private const string ADD_COURSE_FAIL_MESSAGE_TAIL = "」";
        private const string OVERLAP_HEAD = "\n衝堂 : ";
        private const string CHANGE_LINE = "\n";
        private const string SAME_COURSE_NAME_HEAD = "\n課程名稱相同 : ";
        private const string ADD_COURSE_SUCCESS = "加選成功";
        private const string ADD_COURSE_FAIL = "加選失敗";
        Model _model;
        bool _isAddCourseSuccess = false;
        List<CourseInfoDto> _notCheckedCourses = new List<CourseInfoDto>();
        List<CourseInfoDto> _checkedCourses = new List<CourseInfoDto>();

        public CourseSelectingFormPresentationModel(Model model)
        {
            this._model = model;
        }

        // get a class of course
        public List<CourseInfoDto> GetCourseInfo(int tabIndex)
        {
            var result = _model.GetCourseInfo(tabIndex);
            _notCheckedCourses.AddRange(result);
            return result;
        }

        // get a class of course
        public string GetDepartmentName(int tabIndex)
        {
            return _model.GetDepartmentName(tabIndex);
        }

        // get course header text of school timetable
        public Dictionary<string, string> GetCourseHeader()
        {
            return _model.GetCourseHeader();
        }

        // update course checked state
        public void UpdateCourseChecked(int tabIndex, string id)
        {
            CourseInfoDto course;
            course = _notCheckedCourses.Find(x => x.Id.Equals(id));
            if (course == null)
            {
                course = _checkedCourses.Find(x => x.Id.Equals(id));
                _notCheckedCourses.Add(course);
                _checkedCourses.Remove(course);
            }
            else
            {
                _notCheckedCourses.Remove(course);
                _checkedCourses.Add(course);
            }
        }

        // get department amount
        public int GetDepartmentAmount()
        {
            return _model.GetDepartmentAmount();
        }

        // check any course is checked
        public bool IsAnyCourseChecked()
        {
            return _checkedCourses.Count > 0;
        }

        // check course doesn't overlap or has the same name
        public string CheckCoursesValidMessage()
        {
            string message = CheckAnyCourseOverlapMessage() + CheckAnyCourseHasTheSameNameMessage();
            if (message == "")
            {
                _isAddCourseSuccess = true;
                return ADD_COURSE_SUCCESS;
            }
            _isAddCourseSuccess = false;
            return ADD_COURSE_FAIL + message;
        }

        // get course valid message
        private string CheckAnyCourseOverlapMessage()
        {
            Dictionary<string, string> classMap = new Dictionary<string, string>(); // ex: <"4 1", "博雅選修課程 291704">
            foreach (CourseInfoDto courseInfoDto in _checkedCourses)
            {
                string message = CheckCheckedCourseOverlapMessage(courseInfoDto, classMap);
                if (message != "")
                    return message;
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
        private string PrepareCourseOverlapMessage(CourseInfoDto courseInfoDto, Dictionary<string, string> classMap, string key)
        {
            string result = "";
            result += ADD_COURSE_FAIL_MESSAGE_HEAD + classMap[key] + ADD_COURSE_FAIL_MESSAGE_TAIL + CHINESE_COMMA;
            classMap[key] = GetCourseNumber(courseInfoDto) + DASH + GetCourseName(courseInfoDto);
            result += ADD_COURSE_FAIL_MESSAGE_HEAD + classMap[key] + ADD_COURSE_FAIL_MESSAGE_TAIL;
            return result;
        }

        // message for checking course overlape
        private string CheckAnyCourseHasTheSameNameMessage()
        {
            Dictionary<string, string> classMap = new Dictionary<string, string>(); // ex: <"4 1", "博雅選修課程 291704">
            foreach (CourseInfoDto courseInfoDto in _checkedCourses)
            {
                string key = GetCourseName(courseInfoDto);
                if (classMap.ContainsKey(key))
                {
                    string message = "";
                    message += ADD_COURSE_FAIL_MESSAGE_HEAD + classMap[key] + ADD_COURSE_FAIL_MESSAGE_TAIL + CHINESE_COMMA;
                    classMap[key] = GetCourseNumber(courseInfoDto) + SPACE_KEY + GetCourseName(courseInfoDto);
                    message += ADD_COURSE_FAIL_MESSAGE_HEAD + classMap[key] + ADD_COURSE_FAIL_MESSAGE_TAIL;
                    return SAME_COURSE_NAME_HEAD + message + CHANGE_LINE;
                }
                else
                    classMap.Add(key, GetCourseNumber(courseInfoDto) + SPACE_KEY + GetCourseName(courseInfoDto));
            }
            return "";
        }

        // get _isAddCourseSuccess
        public bool IsAddCourseSuccess()
        {
            return _isAddCourseSuccess;
        }

        // get course name
        private string GetCourseName(CourseInfoDto courseInfoDto)
        {
            return courseInfoDto.Name;
        }

        // get course number
        private string GetCourseNumber(CourseInfoDto courseInfoDto)
        {
            return courseInfoDto.Number;
        }

        // get class time
        private List<string> GetClassTime(CourseInfoDto courseInfoDto)
        {
            return courseInfoDto.GetClassTime();
        }

        // select checked course
        public void SelectCheckedCourse()
        {
            _model.SelectCheckedCourseToCurriculum(_checkedCourses);
            _model.NotifyCourseSelect();
        }

        // get selected row index
        public List<List<CourseInfoDto>> GetNotSelectedCourse()
        {
            _checkedCourses.Clear();
            _notCheckedCourses.Clear();
            List<CourseInfoDto> curriculum = _model.GetCurriculum();
            List<Department> departments = _model.GetDepartments();
            List<List<CourseInfoDto>> result = new List<List<CourseInfoDto>>();
            foreach (Department department in departments)
            {
                GetDepartmentNotSelectedCourse(curriculum, result, department);
            }
            return result;
        }

        // get each department unselected course
        private void GetDepartmentNotSelectedCourse(List<CourseInfoDto> curriculum, List<List<CourseInfoDto>> result, Department department)
        {
            List<CourseInfoDto> classCourses = department.GetCourseInfoDtos();
            List<CourseInfoDto> classNotSelectedCourse = new List<CourseInfoDto>();
            foreach (CourseInfoDto courseInfoDto in classCourses)
            {
                if (!curriculum.Contains(courseInfoDto) && courseInfoDto.GetCourseStatus() == 0)
                {
                    classNotSelectedCourse.Add(courseInfoDto);
                    _notCheckedCourses.Add(courseInfoDto);
                }
            }
            result.Add(classNotSelectedCourse);
        }
    }
}
