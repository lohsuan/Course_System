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
        private const string CLASS = "班級";
        private const string ADD_CLASS = "新增班級";
        private Model _model;
        private CourseManagementFormPresentationModel _courseViewModel;
        private ClassManagementPresentationModel _classViewModel;

        public CourseManagementForm(Model model)
        {
            _courseViewModel = new CourseManagementFormPresentationModel(model);
            _classViewModel = new ClassManagementPresentationModel(model);
            _model = model;
            InitializeComponent();
            _classComboBox.Items.AddRange(_courseViewModel.GetAllClassName());
            SetUpCourseListBox();
            SetUpDataGridView();
            SetCourseGroupBoxEnabledMode(false);
            SetUpEvent();
            SetUpClassListBox();
        }

        // SetUpEvent
        private void SetUpEvent()
        {
            _model._courseDataCreateEvent += HandleCourseDataCreateEvent;
            _model._courseDataUpdateEvent += HandleCourseDataUpdateEvent;
            _model._courseImportEvent += HandleCourseImportEvent;
            _model._classAddEvent += HandleCourseImportEvent;
        }

        // HandleCourseDataUpdateEvent when update course
        private void HandleCourseDataUpdateEvent()
        {
            SetUpCourseListBox();
        }

        // HandleCourseDataUpdateEvent when update course
        private void HandleCourseImportEvent()
        {
            _classComboBox.Items.Clear();
            _classComboBox.Items.AddRange(_courseViewModel.GetAllClassName());
            SetUpCourseListBox();
            SetUpClassListBox();
        }

        // HandleCourseDataCreateEvent when add course
        private void HandleCourseDataCreateEvent()
        {
            ClearGroupBox();
            SetUpCourseListBox();
            SetCourseGroupBoxEnabledMode(false);
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
        private void SetCourseGroupBoxEnabledMode(bool flag)
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
            foreach (string courseName in _courseViewModel.GetAllCourseName())
            {
                _courseListBox.Items.Add(courseName);
            }
            _saveButton.Enabled = false;
        }

        // add all class to ClassListBox
        private void SetUpClassListBox()
        {
            _classListBox.Items.Clear();
            foreach (string className in _courseViewModel.GetAllClassName())
            {
                _classListBox.Items.Add(className);
            }
        }

        // on _courseListBox_SelectedIndexChanged set corresponding info to CourseGroupBox 
        private void ChangeCourseListBoxIndex(object sender, EventArgs e)
        {
            SetCourseGroupBoxEnabledMode(true);
            _editCourseGroupBox.Text = EDIT_COURSE;
            _saveButton.Text = SAVE;
            _addCourseButton.Enabled = true;
            _courseViewModel.UpdateSelectedCourse(_courseListBox.SelectedIndex);
            UpdateCourseGroupBox();
            _saveButton.Enabled = false;
        }

        // on _classListBox_SelectedIndexChanged set corresponding info to ClassGroupBox 
        private void ChangedClassListBoxSelectedIndex(object sender, EventArgs e)
        {
            _classNameTextBox.Enabled = false;
            _classGroupBox.Text = CLASS;
            _addClassButton.Enabled = true;
            _classNameTextBox.Text = _classListBox.SelectedItem.ToString();
            _classCourseListBox.Items.Clear();
            foreach (string courseName in _classViewModel.GetClassCourseNamesByIndex(_classListBox.SelectedIndex))
            {
                _classCourseListBox.Items.Add(courseName);
            }
            _addButton.Enabled = false;
        }

        // SetUpCourseGroupBox
        private void UpdateCourseGroupBox()
        {
            _numberTextBox.Text = _courseViewModel.GetNumber();
            _nameTextBox.Text = _courseViewModel.GetName();
            _stageTextBox.Text = _courseViewModel.GetStage();
            _creditTextBox.Text = _courseViewModel.GetCredit();
            _teacherTextBox.Text = _courseViewModel.GetTeacher();
            _requireTypeComboBox.SelectedItem = _courseViewModel.GetRequireType();
            _teacherAssistantTextBox.Text = _courseViewModel.GetTeacherAssistant();
            _languageTextBox.Text = _courseViewModel.GetLanguage();
            _syllabusTextBox.Text = _courseViewModel.GetSyllabus();
            _hourComboBox.SelectedItem = _courseViewModel.GetHour();
            _classComboBox.SelectedItem = _courseViewModel.GetClass();
            _courseStatusComboBox.SelectedIndex = _courseViewModel.GetCourseStatus();
            UpdateClassTime();
        }

        // update classtime data grid view
        private void UpdateClassTime()
        {
            ClearClassTimeDataGridView();
            foreach (string classTime in _courseViewModel.GetClassTime())
            {
                string[] columnRowData = classTime.Split(SPACE_KEY);
                _classTimeDataGridView.Rows[_courseTimes.IndexOf(columnRowData[1])].Cells[Int16.Parse(columnRowData[0]) + 1].Value = true;
            }
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
            e.Handled = !_courseViewModel.IsNumberInput(e.KeyChar);
        }

        // on _numberTextBox_TextChanged
        private void EditedTextBox(object sender, EventArgs e)
        {
            _courseViewModel.SetCourseEditNumber(_numberTextBox.Text);
            _courseViewModel.SetCourseEditName(_nameTextBox.Text);
            _courseViewModel.SetCourseEditStage(_stageTextBox.Text);
            _courseViewModel.SetCourseEditCredit(_creditTextBox.Text);
            _courseViewModel.SetCourseEditTeacher(_teacherTextBox.Text);
            _courseViewModel.SetCourseEditTeacherAssistant(_teacherAssistantTextBox.Text);
            _courseViewModel.SetCourseEditLanguage(_languageTextBox.Text);
            _courseViewModel.SetCourseEditSyllabus(_syllabusTextBox.Text);

            _saveButton.Enabled = IsSaveButtonEnable();
        }

        // on ComboBox SelectedIndexChanged
        private void ChangedComboBoxSelectedIndex(object sender, EventArgs e)
        {
            _courseViewModel.SetCourseEditCourseStatus(_courseStatusComboBox.SelectedIndex);
            _courseViewModel.SetCourseEditRequireType(_requireTypeComboBox.SelectedItem);
            _courseViewModel.SetCourseEditHour(_hourComboBox.SelectedItem);
            _courseViewModel.SetCourseEditClass(_classComboBox.SelectedItem);

            _saveButton.Enabled = IsSaveButtonEnable();
        }

        // on _classTimeDataGridView_CellContentClick (checkbox checked)
        private void CheckClassTimeDataGridView(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex > 0)
                _courseViewModel.UpdateCheckedCourse((bool)_classTimeDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].EditedFormattedValue);

            _saveButton.Enabled = IsSaveButtonEnable();
        }

        // IsSaveButtonEnable
        private bool IsSaveButtonEnable()
        {
            if (_hourComboBox.SelectedItem == null)
                return false;
            return _courseViewModel.IsSaveButtonEnable(Int32.Parse(_hourComboBox.SelectedItem.ToString()));
        }

        // on _addCourseButton_Click
        private void ClickAddCourseButton(object sender, EventArgs e)
        {
            _courseViewModel.AddCourseMode();
            SetCourseGroupBoxEnabledMode(true);
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
            string[] classTime = { "", "", "", "", "", "", "" };
            for (int i = 0; i < _courseTimes.Length; i++)
            {
                for (int j = 1; j <= WEEK_OF_DAY; j++)
                {
                    if ((bool)_classTimeDataGridView.Rows[i].Cells[j].Value)
                        classTime[j - 1] = classTime[j - 1] + _courseTimes[i].ToString() + SPACE_KEY;
                }
            }
            for (int i = 0; i < classTime.Length; i++)
                classTime[i] = classTime[i].Trim();
            _courseViewModel.SetCourseEditClassTime(classTime);
            _courseViewModel.UpdateOrAddCourse();
            _saveButton.Enabled = false;
        }

        // on _importClassButton_Click
        private void OpenImportCourseProgressForm(object sender, EventArgs e)
        {
            _importClassButton.Enabled = false;
            ImportCourseProgressForm importCourseProgressForm = new ImportCourseProgressForm(_model);
            importCourseProgressForm.ShowDialog();
            if (importCourseProgressForm.DialogResult == DialogResult.Cancel)
                _importClassButton.Enabled = true;
        }

        // _addClassButton_Click
        private void ClickAddClassButton(object sender, EventArgs e)
        {
            _courseViewModel.AddCourseMode();
            _classNameTextBox.Enabled = true;
            _classNameTextBox.Text = "";
            _classCourseListBox.Items.Clear();
            _classGroupBox.Text = ADD_CLASS;
            _addButton.Enabled = false;
            _addClassButton.Enabled = false;
        }

        // _classNameTextBox_TextChanged
        private void ChangedClassNameTextBoxText(object sender, EventArgs e)
        {
            _classViewModel.SetNewClassName(_classNameTextBox.Text);

            _addButton.Enabled = _classViewModel.IsAddButtonEnable();
        }

        // _addButton_Click
        private void ClickAddButton(object sender, EventArgs e)
        {
            _classViewModel.AddClass();
        }
    }
}
