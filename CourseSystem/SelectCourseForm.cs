using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CourseSystem
{
    public partial class SelectCourseForm : Form
    {
        private Model _model;
        public SelectCourseForm(Model model)
        {
            this._model = model;
            List<CourseInfoDto> courseInfo = model.GetCourseInfo();
            Dictionary<string, string> dataGridViewHeader = new Dictionary<string, string>();
            PrepareDataGridViewHeader(dataGridViewHeader);

            InitializeComponent();
            AddCheckBoxColumn();
            _submitConfirmButton.Enabled = false;

            _selectCourseDataGridView.DataSource = courseInfo;
            foreach (KeyValuePair<string, string> entry in dataGridViewHeader)
            {
                _selectCourseDataGridView.Columns[entry.Key].HeaderText = entry.Value;
            }
        }

        // enable submissionConfirmButton if any checkbox was checked
        private void SelectCourseDataGridViewCellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            foreach (DataGridViewRow row in _selectCourseDataGridView.Rows)
            {
                if ((bool)row.Cells[0].EditedFormattedValue)
                {
                    _submitConfirmButton.Enabled = true;
                    return;
                }
            }
            _submitConfirmButton.Enabled = false;
        }

        // add checkbox column
        private void AddCheckBoxColumn()
        {
            DataGridViewCheckBoxColumn selectCourseCheckBoxColumn = new DataGridViewCheckBoxColumn();
            selectCourseCheckBoxColumn.HeaderText = "選";
            _selectCourseDataGridView.Columns.Add(selectCourseCheckBoxColumn);
        }

        // prepare Chinese-English Dictionary for dataGridViewHeader
        private void PrepareDataGridViewHeader(Dictionary<string, string> dataGridViewHeader)
        {
            AddClassBasicInfoInHeaderDictionary(dataGridViewHeader);
            AddClassAdvancedInfoInHeaderDictionary(dataGridViewHeader);
            AddClassTimeInHeaderDictionary(dataGridViewHeader);
        }

        // add basic class information in Chinese-English Dictionary
        private static void AddClassBasicInfoInHeaderDictionary(Dictionary<string, string> dataGridViewHeader)
        {
            dataGridViewHeader.Add("Number", "課號");
            dataGridViewHeader.Add("Name", "課程名稱");
            dataGridViewHeader.Add("Stage", "階段");
            dataGridViewHeader.Add("Credit", "學分");
            dataGridViewHeader.Add("Hour", "時數");
            dataGridViewHeader.Add("RequiredType", "修");
            dataGridViewHeader.Add("Teacher", "教師");
            dataGridViewHeader.Add("Classroom", "教室");
        }

        // add advanced class information in Chinese-English Dictionary
        private static void AddClassAdvancedInfoInHeaderDictionary(Dictionary<string, string> dataGridViewHeader)
        {
            dataGridViewHeader.Add("NumberOfStudent", "人");
            dataGridViewHeader.Add("Note", "教學大綱與進度表");
            dataGridViewHeader.Add("NumberOfDropStudent", "撤");
            dataGridViewHeader.Add("TeacherAssistant", "教學助理");
            dataGridViewHeader.Add("Language", "授課語言");
            dataGridViewHeader.Add("Syllabus", "備註");
            dataGridViewHeader.Add("Audit", "隨班附讀");
            dataGridViewHeader.Add("Experiment", "實驗實習");
        }

        // add class time in Chinese-English Dictionary
        private static void AddClassTimeInHeaderDictionary(Dictionary<string, string> dataGridViewHeader)
        {
            dataGridViewHeader.Add("ClassTimeSunday", "日");
            dataGridViewHeader.Add("ClassTimeMonday", "一");
            dataGridViewHeader.Add("ClassTimeTuesday", "二");
            dataGridViewHeader.Add("ClassTimeWednesday", "三");
            dataGridViewHeader.Add("ClassTimeThursday", "四");
            dataGridViewHeader.Add("ClassTimeFriday", "五");
            dataGridViewHeader.Add("ClassTimeSaturday", "六");
        }
    }
}

