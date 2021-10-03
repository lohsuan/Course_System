using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;

namespace CourseSystem
{
    class Course
    {
        private const string CLASS_URL = "https://aps.ntut.edu.tw/course/tw/Subj.jsp?format=-4&year=110&sem=1&code=2433";
        private const string CLASS_INFORMATION_XPATH = "//body/table";
        private const int NUMBER = 0;
        private const int NAME = 1;
        private const int STAGE = 2;
        private const int CREDIT = 3;
        private const int HOUR = 4;
        private const int REQUIRE_TYPE = 5;
        private const int TEACHER = 6;
        private const int CLASS_TIME_SUNDAY = 7;
        private const int CLASS_TIME_MONDAY = 8;
        private const int CLASS_TIME_TUESDAY = 9;
        private const int CLASS_TIME_WEDNESDAY = 10;
        private const int CLASS_TIME_THURSDAY = 11;
        private const int CLASS_TIME_FRIDAY = 12;
        private const int CLASS_TIME_SATURDAY = 13;
        private const int CLASSROOM = 14;
        private const int NUMBER_OF_STUDENT = 15;
        private const int NUMBER_OF_DROP_STUDENT = 16;
        private const int TEACHER_ASSISTANT = 17;
        private const int LANGUAGE = 18;
        private const int SYLLABUS = 19;
        private const int NOTE = 20;
        private const int AUDIT = 21;
        private const int EXPERIMENT = 22;
        private string[] _courseHeaderKeys = { CourseHeaderConstant.NUMBER_HEADER_KEY, CourseHeaderConstant.NAME_HEADER_KEY, CourseHeaderConstant.STAGE_HEADER_KEY, CourseHeaderConstant.CREDIT_HEADER_KEY, CourseHeaderConstant.HOUR_HEADER_KEY, CourseHeaderConstant.REQUIRED_TYPE_HEADER_KEY, CourseHeaderConstant.TEACHER_HEADER_KEY, CourseHeaderConstant.CLASSROOM_HEADER_KEY, CourseHeaderConstant.NUMBER_OF_STUDENT_HEADER_KEY, CourseHeaderConstant.NOTE_HEADER_KEY, CourseHeaderConstant.NUMBER_OF_DROP_STUDENT_HEADER_KEY, CourseHeaderConstant.TEACHER_ASSISTANT_HEADER_KEY, CourseHeaderConstant.LANGUAGE_HEADER_KEY, CourseHeaderConstant.SYLLABUS_HEADER_KEY, CourseHeaderConstant.AUDIT_HEADER_KEY, CourseHeaderConstant.EXPERIMENT_HEADER_KEY, CourseHeaderConstant.CLASS_TIME_SUNDAY_HEADER_KEY, CourseHeaderConstant.CLASS_TIME_MONDAY_HEADER_KEY, CourseHeaderConstant.CLASS_TIME_TUESDAY_HEADER_KEY, CourseHeaderConstant.CLASS_TIME_WEDNESDAY_HEADER_KEY, CourseHeaderConstant.CLASS_TIME_THURSDAY_HEADER_KEY, CourseHeaderConstant.CLASS_TIME_FRIDAY_HEADER_KEY, CourseHeaderConstant.CLASS_TIME_SATURDAY_HEADER_KEY };
        private string[] _courseHeaderValues = { CourseHeaderConstant.NUMBER_HEADER_VALUE, CourseHeaderConstant.NAME_HEADER_VALUE, CourseHeaderConstant.STAGE_HEADER_VALUE, CourseHeaderConstant.CREDIT_HEADER_VALUE, CourseHeaderConstant.HOUR_HEADER_VALUE, CourseHeaderConstant.REQUIRED_TYPE_HEADER_VALUE, CourseHeaderConstant.TEACHER_HEADER_VALUE, CourseHeaderConstant.CLASSROOM_HEADER_VALUE, CourseHeaderConstant.NUMBER_OF_STUDENT_HEADER_VALUE, CourseHeaderConstant.NOTE_HEADER_VALUE, CourseHeaderConstant.NUMBER_OF_DROP_STUDENT_HEADER_VALUE, CourseHeaderConstant.TEACHER_ASSISTANT_HEADER_VALUE, CourseHeaderConstant.LANGUAGE_HEADER_VALUE, CourseHeaderConstant.SYLLABUS_HEADER_VALUE, CourseHeaderConstant.AUDIT_HEADER_VALUE, CourseHeaderConstant.EXPERIMENT_HEADER_VALUE, CourseHeaderConstant.CLASS_TIME_SUNDAY_HEADER_VALUE, CourseHeaderConstant.CLASS_TIME_MONDAY_HEADER_VALUE, CourseHeaderConstant.CLASS_TIME_TUESDAY_HEADER_VALUE, CourseHeaderConstant.CLASS_TIME_WEDNESDAY_HEADER_VALUE, CourseHeaderConstant.CLASS_TIME_THURSDAY_HEADER_VALUE, CourseHeaderConstant.CLASS_TIME_FRIDAY_HEADER_VALUE, CourseHeaderConstant.CLASS_TIME_SATURDAY_HEADER_VALUE };

        // using HtmlAgilityPack to parse course information
        public static List<CourseInfoDto> GetCourseInfo()
        {
            HtmlWeb webClient = new HtmlWeb();
            webClient.OverrideEncoding = Encoding.Default;
            HtmlDocument document = webClient.Load(CLASS_URL);
            List<CourseInfoDto> courseInfoDtos = new List<CourseInfoDto>();
            HtmlNode nodeTable = document.DocumentNode.SelectSingleNode(CLASS_INFORMATION_XPATH);
            HtmlNodeCollection nodeTableRow = nodeTable.ChildNodes;
            RemoveNoUseTableRow(nodeTableRow);
            foreach (var node in nodeTableRow)
            {
                HtmlNodeCollection nodeTableDatas = node.ChildNodes;
                nodeTableDatas.RemoveAt(0); // 移除 #text
                courseInfoDtos.Add(CourseInfoDtoFactory(nodeTableDatas));
            }
            return courseInfoDtos;
        }

        // get course header text of school timetable
        public Dictionary<string, string> GetCourseHeader()
        {
            Dictionary<string, string> courseHeader = new Dictionary<string, string>();
            for (int courseHeaderIndex = 0; courseHeaderIndex < _courseHeaderKeys.Length; courseHeaderIndex++)
            {
                courseHeader.Add(_courseHeaderKeys[courseHeaderIndex], _courseHeaderValues[courseHeaderIndex]);
            }
            return courseHeader;
        }

        // factory for making CourseInfoDto
        private static CourseInfoDto CourseInfoDtoFactory(HtmlNodeCollection nodeTableDatas)
        {
            return new CourseInfoDto(
                nodeTableDatas[NUMBER].InnerText.Trim(), nodeTableDatas[NAME].InnerText.Trim(), nodeTableDatas[STAGE].InnerText.Trim(),
                nodeTableDatas[CREDIT].InnerText.Trim(), nodeTableDatas[HOUR].InnerText.Trim(), nodeTableDatas[REQUIRE_TYPE].InnerText.Trim(),
                nodeTableDatas[TEACHER].InnerText.Trim(), nodeTableDatas[CLASS_TIME_SUNDAY].InnerText.Trim(), nodeTableDatas[CLASS_TIME_MONDAY].InnerText.Trim(),
                nodeTableDatas[CLASS_TIME_TUESDAY].InnerText.Trim(), nodeTableDatas[CLASS_TIME_WEDNESDAY].InnerText.Trim(), nodeTableDatas[CLASS_TIME_THURSDAY].InnerText.Trim(),
                nodeTableDatas[CLASS_TIME_FRIDAY].InnerText.Trim(), nodeTableDatas[CLASS_TIME_SATURDAY].InnerText.Trim(), nodeTableDatas[CLASSROOM].InnerText.Trim(),
                nodeTableDatas[NUMBER_OF_STUDENT].InnerText.Trim(), nodeTableDatas[NUMBER_OF_DROP_STUDENT].InnerText.Trim(), nodeTableDatas[TEACHER_ASSISTANT].InnerText.Trim(),
                nodeTableDatas[LANGUAGE].InnerText.Trim(), nodeTableDatas[SYLLABUS].InnerText.Trim(), nodeTableDatas[NOTE].InnerText.Trim(),
                nodeTableDatas[AUDIT].InnerText.Trim(), nodeTableDatas[EXPERIMENT].InnerText.Trim());
        }

        // 移除不需要的網站資訊
        private static void RemoveNoUseTableRow(HtmlNodeCollection nodeTableRow)
        {
            nodeTableRow.RemoveAt(0); // 移除 tbody
            nodeTableRow.RemoveAt(0); // 移除 <tr>資工三
            nodeTableRow.RemoveAt(0); // 移除 table header
            int lastRowIndex = nodeTableRow.Count - 1;
            nodeTableRow.RemoveAt(lastRowIndex); // 移除 <tr>小計
        }
    }
}