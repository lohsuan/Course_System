using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CourseSystem
{
    public partial class CourseManagementForm : Form
    {
        private const string EDIT_COURSE = "編輯課程";
        private const string SAVE = "儲存";
        private const int TOTAL_CLASS_TIME = 8;
        private const int WEEK_OF_DAY = 7;
        private CourseManagementFormPresentationModel _viewModel;

        public CourseManagementForm(Model model)
        {
            _viewModel = new CourseManagementFormPresentationModel(model);
            InitializeComponent();
            SetUpCourseListBox();

            _classTimedataGridView.Rows.Clear();
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
                    _classTimedataGridView.Columns[day+1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }
                _classTimedataGridView.Rows.Add(row);
            }
        }

        // SetUpCourseListBox
        private void SetUpCourseListBox()
        {
            foreach (string courseName in _viewModel.GetAllCourseName())
            {
                _courseListBox.Items.Add(courseName);
            }
            _saveButton.Enabled = false;
        }

        // on _courseListBox_SelectedIndexChanged
        private void ChangeCourseListBoxIndex(object sender, EventArgs e)
        {
            _editCourseGroupBox.Text = EDIT_COURSE;
            _saveButton.Text = SAVE;
            _addCourseButton.Enabled = true;
            _viewModel.UpdateSelectedCourse(_courseListBox.SelectedIndex);
            UpdateCourseGroupBox();

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
        }
    }
}
