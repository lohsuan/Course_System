using System.Collections.Generic;
using System.Text;
using HtmlAgilityPack;

namespace CourseSystem
{
    class Course
    {
        private string[] _courseHeaderKeys = { CourseHeaderConstant.NUMBER_HEADER_KEY, CourseHeaderConstant.NAME_HEADER_KEY, CourseHeaderConstant.STAGE_HEADER_KEY, CourseHeaderConstant.CREDIT_HEADER_KEY, CourseHeaderConstant.HOUR_HEADER_KEY, CourseHeaderConstant.REQUIRED_TYPE_HEADER_KEY, CourseHeaderConstant.TEACHER_HEADER_KEY, CourseHeaderConstant.CLASSROOM_HEADER_KEY, CourseHeaderConstant.NUMBER_OF_STUDENT_HEADER_KEY, CourseHeaderConstant.NOTE_HEADER_KEY, CourseHeaderConstant.NUMBER_OF_DROP_STUDENT_HEADER_KEY, CourseHeaderConstant.TEACHER_ASSISTANT_HEADER_KEY, CourseHeaderConstant.LANGUAGE_HEADER_KEY, CourseHeaderConstant.SYLLABUS_HEADER_KEY, CourseHeaderConstant.AUDIT_HEADER_KEY, CourseHeaderConstant.EXPERIMENT_HEADER_KEY, CourseHeaderConstant.CLASS_TIME_SUNDAY_HEADER_KEY, CourseHeaderConstant.CLASS_TIME_MONDAY_HEADER_KEY, CourseHeaderConstant.CLASS_TIME_TUESDAY_HEADER_KEY, CourseHeaderConstant.CLASS_TIME_WEDNESDAY_HEADER_KEY, CourseHeaderConstant.CLASS_TIME_THURSDAY_HEADER_KEY, CourseHeaderConstant.CLASS_TIME_FRIDAY_HEADER_KEY, CourseHeaderConstant.CLASS_TIME_SATURDAY_HEADER_KEY };
        private string[] _courseHeaderValues = { CourseHeaderConstant.NUMBER_HEADER_VALUE, CourseHeaderConstant.NAME_HEADER_VALUE, CourseHeaderConstant.STAGE_HEADER_VALUE, CourseHeaderConstant.CREDIT_HEADER_VALUE, CourseHeaderConstant.HOUR_HEADER_VALUE, CourseHeaderConstant.REQUIRED_TYPE_HEADER_VALUE, CourseHeaderConstant.TEACHER_HEADER_VALUE, CourseHeaderConstant.CLASSROOM_HEADER_VALUE, CourseHeaderConstant.NUMBER_OF_STUDENT_HEADER_VALUE, CourseHeaderConstant.NOTE_HEADER_VALUE, CourseHeaderConstant.NUMBER_OF_DROP_STUDENT_HEADER_VALUE, CourseHeaderConstant.TEACHER_ASSISTANT_HEADER_VALUE, CourseHeaderConstant.LANGUAGE_HEADER_VALUE, CourseHeaderConstant.SYLLABUS_HEADER_VALUE, CourseHeaderConstant.AUDIT_HEADER_VALUE, CourseHeaderConstant.EXPERIMENT_HEADER_VALUE, CourseHeaderConstant.CLASS_TIME_SUNDAY_HEADER_VALUE, CourseHeaderConstant.CLASS_TIME_MONDAY_HEADER_VALUE, CourseHeaderConstant.CLASS_TIME_TUESDAY_HEADER_VALUE, CourseHeaderConstant.CLASS_TIME_WEDNESDAY_HEADER_VALUE, CourseHeaderConstant.CLASS_TIME_THURSDAY_HEADER_VALUE, CourseHeaderConstant.CLASS_TIME_FRIDAY_HEADER_VALUE, CourseHeaderConstant.CLASS_TIME_SATURDAY_HEADER_VALUE };

        // using HtmlAgilityPack to parse course information
        public List<CourseInfoDto> CourseInfoCrawler(string coursePath)
        {
            HtmlWeb webClient = new HtmlWeb();
            webClient.OverrideEncoding = Encoding.Default;
            HtmlDocument document = webClient.Load(coursePath);
            List<CourseInfoDto> courseInfoDtos = new List<CourseInfoDto>();
            HtmlNode nodeTable = document.DocumentNode.SelectSingleNode(CourseConstant.CLASS_INFORMATION_XPATH);
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
        private CourseInfoDto CourseInfoDtoFactory(HtmlNodeCollection nodeTableDatas)
        {
            return new CourseInfoDto(
                nodeTableDatas[CourseConstant.NUMBER].InnerText.Trim(), nodeTableDatas[CourseConstant.NAME].InnerText.Trim(), 
                nodeTableDatas[CourseConstant.STAGE].InnerText.Trim(), nodeTableDatas[CourseConstant.CREDIT].InnerText.Trim(), 
                nodeTableDatas[CourseConstant.HOUR].InnerText.Trim(), nodeTableDatas[CourseConstant.REQUIRE_TYPE].InnerText.Trim(),
                nodeTableDatas[CourseConstant.TEACHER].InnerText.Trim(), nodeTableDatas[CourseConstant.CLASS_TIME_SUNDAY].InnerText.Trim(), 
                nodeTableDatas[CourseConstant.CLASS_TIME_MONDAY].InnerText.Trim(), nodeTableDatas[CourseConstant.CLASS_TIME_TUESDAY].InnerText.Trim(), 
                nodeTableDatas[CourseConstant.CLASS_TIME_WEDNESDAY].InnerText.Trim(), nodeTableDatas[CourseConstant.CLASS_TIME_THURSDAY].InnerText.Trim(),
                nodeTableDatas[CourseConstant.CLASS_TIME_FRIDAY].InnerText.Trim(), nodeTableDatas[CourseConstant.CLASS_TIME_SATURDAY].InnerText.Trim(), 
                nodeTableDatas[CourseConstant.CLASSROOM].InnerText.Trim(), nodeTableDatas[CourseConstant.NUMBER_OF_STUDENT].InnerText.Trim(), 
                nodeTableDatas[CourseConstant.NUMBER_OF_DROP_STUDENT].InnerText.Trim(), nodeTableDatas[CourseConstant.TEACHER_ASSISTANT].InnerText.Trim(),
                nodeTableDatas[CourseConstant.LANGUAGE].InnerText.Trim(), nodeTableDatas[CourseConstant.SYLLABUS].InnerText.Trim(), 
                nodeTableDatas[CourseConstant.NOTE].InnerText.Trim(), nodeTableDatas[CourseConstant.AUDIT].InnerText.Trim(), 
                nodeTableDatas[CourseConstant.EXPERIMENT].InnerText.Trim());
        }

        // 移除不需要的網站資訊
        private void RemoveNoUseTableRow(HtmlNodeCollection nodeTableRow)
        {
            nodeTableRow.RemoveAt(0); // 移除 tbody
            string[] department = nodeTableRow[0].InnerText.Split('\n');
            Department.AddDepartmentName(department[0]);
            nodeTableRow.RemoveAt(0); // 移除 <tr>資工三
            nodeTableRow.RemoveAt(0); // 移除 table header
            nodeTableRow.RemoveAt(GetLastRowIndex(nodeTableRow)); // 移除 <tr>小計
        }

        // get last row index
        private int GetLastRowIndex(HtmlNodeCollection nodeTableRow)
        {
            return nodeTableRow.Count - 1;
        }
    }
}