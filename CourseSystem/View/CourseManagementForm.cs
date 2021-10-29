using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CourseSystem
{
    public partial class CourseManagementForm : Form
    {
        private const string SAVE = "儲存";
        private const string EDIT_COURSE = "編輯課程";
        private const string ADD = "新增";
        private const string ADD_COURSE = "新增課程";
        private readonly string _courseTimes = "1234N56789ABCD";
        private const int WEEK_OF_DAY = 7;
        private const char SPACE_KEY = ' ';
        private Model _model;
        private CourseManagementFormPresentationModel _viewModel;

        public CourseManagementForm(Model model)
        {
            _viewModel = new CourseManagementFormPresentationModel(model);
            _model = model;
            InitializeComponent();
            SetUpCourseListBox();
            SetUpDataGridView();
            SetGroupBoxEnabledMode(false);
            SetUpEvent();
            //_addCourseButton.DataBindings("Enabled", _viewModel, "IsButtonEnabled");
            //_addCourseButton.DataBindings(nameof(_addCourseButton.Enabled), _viewModel, nameof(_viewModel.IsButtonEnabled));
        }

        // SetUpEvent
        private void SetUpEvent()
        {
            _model._courseDataCreateEvent += HandleCourseDataCreateEvent;
            _model._courseDataUpdateEvent += HandleCourseDataUpdateEvent;
            _stageTextBox.KeyPress += CheckNumberInput;
            _creditTextBox.KeyPress += CheckNumberInput;
            _nameTextBox.TextChanged += EditedTextBox;
            _stageTextBox.TextChanged += EditedTextBox;
            _creditTextBox.TextChanged += EditedTextBox;
            _teacherTextBox.TextChanged += EditedTextBox;
            _teacherAssistantTextBox.TextChanged += EditedTextBox;
            _languageTextBox.TextChanged += EditedTextBox;
            _syllabusTextBox.TextChanged += EditedTextBox;
            _courseStatusComboBox.SelectedIndexChanged += ChangedComboBoxSelectedIndex;
            _requireTypeComboBox.SelectedIndexChanged += ChangedComboBoxSelectedIndex;
            _classComboBox.SelectedIndexChanged += ChangedComboBoxSelectedIndex;
        }

        // HandleCourseDataUpdateEvent when update course
        private void HandleCourseDataUpdateEvent()
        {
            SetUpCourseListBox();
        }

        // HandleCourseDataCreateEvent when add course
        private void HandleCourseDataCreateEvent()
        {
            ClearGroupBox();
            SetUpCourseListBox();
            SetGroupBoxEnabledMode(false);
            _addCourseButton.Enabled = true;
        }

        // ClearGroupBox
        private void ClearGroupBox()
        {
            ClearGroupBoxText();
            ClearClassTimeDataGridView();
            ClearGroupBoxSelectItem();
        }

        // set group box enabled mode
        private void SetGroupBoxEnabledMode(bool flag)
        {
            _courseStatusComboBox.Enabled = flag;
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
            for (int classTime = 0; classTime < _courseTimes.Length; classTime++)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.Cells.Add(new DataGridViewTextBoxCell
                {
                    Value = _courseTimes[classTime],
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
            _courseListBox.Items.Clear();
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

        // update classtime data grid view
        private void UpdateClassTime()
        {
            ClearClassTimeDataGridView();
            foreach (string classTime in _viewModel.GetClassTime())
            {
                string[] columnRowData = classTime.Split(SPACE_KEY);
                _classTimeDataGridView.Rows[_courseTimes.IndexOf(columnRowData[1])].Cells[Int16.Parse(columnRowData[0]) + 1].Value = true;
            }
        }

        // on _classTimeDataGridView_CellContentClick (checkbox checked)
        private void CheckClassTimeDataGridView(object sender, DataGridViewCellEventArgs e)
        {
            _viewModel.SetCourseEditClassTime((e.ColumnIndex - 1).ToString(), _courseTimes[e.RowIndex].ToString());

            _saveButton.Enabled = _viewModel.IsClassTimeChangedAndMeetRequirement();
        }

        // clean up data grid view
        private void ClearClassTimeDataGridView()
        {
            for (int i = 0; i < _courseTimes.Length; i++)
            {
                for (int j = 1; j <= WEEK_OF_DAY; j++)
                    _classTimeDataGridView.Rows[i].Cells[j].Value = false;
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

            _saveButton.Enabled = _viewModel.IsSelectedItemChangedAndHourCorrect();
        }

        // on _addCourseButton_Click
        private void ClickAddCourseButton(object sender, EventArgs e)
        {
            _viewModel.AddCourseMode();
            SetGroupBoxEnabledMode(true);
            SetAddCourseInitialGroupBoxMode();
            _editCourseGroupBox.Text = ADD_COURSE;
            _saveButton.Text = ADD;
            _saveButton.Enabled = false;
            _addCourseButton.Enabled = false;
        }

        // add course initial mode in groupbox
        private void SetAddCourseInitialGroupBoxMode()
        {
            _courseStatusComboBox.SelectedIndex = 0;
            _requireTypeComboBox.SelectedIndex = 0;
            _hourComboBox.SelectedIndex = 0;
            _classComboBox.SelectedIndex = 0;
            ClearGroupBoxText();
            ClearClassTimeDataGridView();
        }

        // clear group box textbox text
        private void ClearGroupBoxText()
        {
            _numberTextBox.Text = "";
            _nameTextBox.Text = "";
            _stageTextBox.Text = "";
            _creditTextBox.Text = "";
            _teacherTextBox.Text = "";
            _teacherAssistantTextBox.Text = "";
            _languageTextBox.Text = "";
            _syllabusTextBox.Text = "";
        }

        // clear group box textbox text
        private void ClearGroupBoxSelectItem()
        {
            _courseStatusComboBox.SelectedItem = null;
            _requireTypeComboBox.SelectedItem = null;
            _hourComboBox.SelectedItem = null;
            _classComboBox.SelectedItem = null;
        }

        // on _saveButton_Click
        private void ClickSaveButton(object sender, EventArgs e)
        {
            _viewModel.UpdateOrAddCourse();
            _saveButton.Enabled = false;
        }
    }
}
