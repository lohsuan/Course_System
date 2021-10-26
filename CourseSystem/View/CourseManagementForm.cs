using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CourseSystem
{
    public partial class CourseManagementForm : Form
    {
        private const string EDIT_COURSE = "編輯課程";
        private const string SAVE = "儲存";
        private const int TOTAL_CLASS_TIME = 9;
        private const int WEEK_OF_DAY = 7;
        private const char SPACE_KEY = ' ';
        private CourseManagementFormPresentationModel _viewModel;

        public CourseManagementForm(Model model)
        {
            _viewModel = new CourseManagementFormPresentationModel(model);
            InitializeComponent();
            SetUpCourseListBox();
            SetUpDataGridView();
            SetGroupBoxEnabledMode(false);
            SetUpEvent();
        }

        // SetUpEvent
        private void SetUpEvent()
        {
            _stageTextBox.KeyPress += CheckNumberInput;
            _creditTextBox.KeyPress += CheckNumberInput;

            _nameTextBox.TextChanged += EditedTextBox;
            _stageTextBox.TextChanged += EditedTextBox;
            _creditTextBox.TextChanged += EditedTextBox;
            _teacherTextBox.TextChanged += EditedTextBox;
            _teacherAssistantTextBox.TextChanged += EditedTextBox;
            _languageTextBox.TextChanged += EditedTextBox;
            _syllabusTextBox.TextChanged += EditedTextBox;

            //_courseStatusComboBox.SelectedIndexChanged += ChangedComboBoxSelectedIndex;
            _requireTypeComboBox.SelectedIndexChanged += ChangedComboBoxSelectedIndex;
            _classComboBox.SelectedIndexChanged += ChangedComboBoxSelectedIndex;
        }

        // set group box enabled mode
        private void SetGroupBoxEnabledMode(bool flag)
        {
            //_courseStatusComboBox.Enabled = flag;
            _numberTextBox.Enabled = flag;
            _nameTextBox.Enabled = flag;
            _stageTextBox.Enabled = flag;
            _creditTextBox.Enabled = flag;
            _teacherTextBox.Enabled = flag;
            _requireTypeComboBox.Enabled = flag;
            _teacherAssistantTextBox.Enabled = flag;
            _languageTextBox.Enabled = flag;
            _syllabusTextBox.Enabled = flag;
            _hourComboBox.Enabled = flag;
            _classComboBox.Enabled = flag;
            _classTimeDataGridView.Enabled = flag;
        }

        // set class time initial row status
        private void SetUpDataGridView()
        {
            for (int classTime = 1; classTime <= TOTAL_CLASS_TIME; classTime++)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.Cells.Add(new DataGridViewTextBoxCell
                {
                    Value = classTime,
                });
                for (int day = 0; day < WEEK_OF_DAY; day++)
                {
                    row.Cells.Add(new DataGridViewCheckBoxCell()
                    {
                        Value = false
                    });
                    _classTimeDataGridView.Columns[day + 1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }
                _classTimeDataGridView.Rows.Add(row);
            }
        }

        // add all courses to CourseListBox
        private void SetUpCourseListBox()
        {
            foreach (string courseName in _viewModel.GetAllCourseName())
            {
                _courseListBox.Items.Add(courseName);
            }
            _saveButton.Enabled = false;
        }

        // on _courseListBox_SelectedIndexChanged set corresponding info to CourseGroupBox 
        private void ChangeCourseListBoxIndex(object sender, EventArgs e)
        {
            SetGroupBoxEnabledMode(true);
            _editCourseGroupBox.Text = EDIT_COURSE;
            _saveButton.Text = SAVE;
            _addCourseButton.Enabled = true;
            _viewModel.UpdateSelectedCourse(_courseListBox.SelectedIndex);
            UpdateCourseGroupBox();
            _saveButton.Enabled = false;
        }

        // SetUpCourseGroupBox
        private void UpdateCourseGroupBox()
        {
            _numberTextBox.Text = _viewModel.GetNumber();
            _nameTextBox.Text = _viewModel.GetName();
            _stageTextBox.Text = _viewModel.GetStage();
            _creditTextBox.Text = _viewModel.GetCredit();
            _teacherTextBox.Text = _viewModel.GetTeacher();
            _requireTypeComboBox.SelectedItem = _viewModel.GetRequireType();
            _teacherAssistantTextBox.Text = _viewModel.GetTeacherAssistant();
            _languageTextBox.Text = _viewModel.GetLanguage();
            _syllabusTextBox.Text = _viewModel.GetSyllabus();
            _hourComboBox.SelectedItem = _viewModel.GetHour();
            _classComboBox.SelectedItem = _viewModel.GetClass();
            UpdateClassTime();
        }

        // update classtime datagrid view
        private void UpdateClassTime()
        {
            for (int i = 0; i < TOTAL_CLASS_TIME; i++)
            {
                for (int j = 1; j <= WEEK_OF_DAY; j++)
                    _classTimeDataGridView.Rows[i].Cells[j].Value = false;
            }
            foreach (string classTime in _viewModel.GetClassTime())
            {
                string[] columnRowData = classTime.Split(SPACE_KEY);
                _classTimeDataGridView.Rows[Int16.Parse(columnRowData[1]) - 1].Cells[Int16.Parse(columnRowData[0]) + 1].Value = true;
            }
        }

        // on _numberTextBox_KeyPress
        private void CheckNumberInput(object sender, KeyPressEventArgs e)
        {
            e.Handled = !_viewModel.IsNumberInput(e.KeyChar);
        }

        // on _numberTextBox_TextChanged
        private void EditedTextBox(object sender, EventArgs e)
        {
            _viewModel.SetCourseEditNumber(_numberTextBox.Text);
            _viewModel.SetCourseEditName(_nameTextBox.Text);
            _viewModel.SetCourseEditStage(_stageTextBox.Text);
            _viewModel.SetCourseEditCredit(_creditTextBox.Text);
            _viewModel.SetCourseEditTeacher(_teacherTextBox.Text);
            _viewModel.SetCourseEditTeacherAssistant(_teacherAssistantTextBox.Text);
            _viewModel.SetCourseEditLanguage(_languageTextBox.Text);
            _viewModel.SetCourseEditSyllabus(_syllabusTextBox.Text);

            _saveButton.Enabled = _viewModel.IsTextChangedAndMeetRequirement();
        }

        // on _hourComboBox_SelectedIndexChanged
        private void ChangedComboBoxSelectedIndex(object sender, EventArgs e)
        {
            _viewModel.SetCourseEditRequireType(_requireTypeComboBox.SelectedItem);
            _viewModel.SetCourseEditHour(_hourComboBox.SelectedItem);
            _viewModel.SetCourseEditClass(_classComboBox.SelectedItem);

            _saveButton.Enabled = _viewModel.IsItemChangedAndHourCorrect();
        }


    }
}
