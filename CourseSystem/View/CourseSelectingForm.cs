using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;

namespace CourseSystem
{
    public partial class CourseSelectingForm : Form
    {
        private const int COURSE_NUMBER = 1;
        private CourseSelectingFormPresentationModel _viewModel;
        private Model _model;
        private int _currentTabIndex;
        private List<DataGridView> _dataGridViews = new List<DataGridView>();
        private List<TabPage> _tabPages = new List<TabPage>();
        
        public CourseSelectingForm(Model model)
        {
            _model = model;
            _viewModel = new CourseSelectingFormPresentationModel(model);
            InitializeComponent();
            PrepareEvent();
            _dataGridViews.Add(_firstTabDataGridView);
            _dataGridViews.Add(_secondTabDataGridView);
            _tabPages.Add(_tabPage1);
            _tabPages.Add(_tabPage2);
            if (_tabPages.Count < _viewModel.GetDepartmentAmount())
            {
                for (int i = _tabPages.Count; i < _viewModel.GetDepartmentAmount(); i++)
                    AddNewDataGridViewAndTab();
            }
            SetUpDataGridView();
            ReloadNotSelectedCourse();
        }

        // PrepareEvent
        private void PrepareEvent()
        {
            _firstTabDataGridView.CellContentDoubleClick += ClickDataGridViewCellContent;
            _model._courseDataCreateEvent += HandleCourseChangeEvent;
            _model._courseDataUpdateEvent += HandleCourseChangeEvent;
            _model._courseCancelSelectEvent += HandleCourseChangeEvent;
            _model._courseSelectEvent += HandleCourseChangeEvent;
            _model._courseImportEvent += HandleCourseImportEvent;
            _model._classAddEvent += HandleCourseImportEvent;
        }

        // HandleCourseChangeEvent Create, Update, Cancel Select Event
        private void HandleCourseChangeEvent()
        {
            ReloadNotSelectedCourse();
        }

        // HandleCourseImportEvent
        private void HandleCourseImportEvent()
        {
            for (int i = _tabPages.Count; i < _viewModel.GetDepartmentAmount(); i++)
            {
                AddNewDataGridViewAndTab();
            }
            ReloadNotSelectedCourse();
        }

        // AddNewDatagridViewAndTab when course import
        private void AddNewDataGridViewAndTab()
        {
            DataGridView dataGridView = new DataGridView();
            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            dataGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;
            dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView.RowHeadersVisible = false;
            dataGridView.Size = _firstTabDataGridView.Size;
            _dataGridViews.Add(dataGridView);
            dataGridView.CellContentClick += ClickDataGridViewCellContent;
            dataGridView.CellContentDoubleClick += ClickDataGridViewCellContent;
            AddCheckBoxColumn(dataGridView);

            TabPage tabPage = new TabPage();
            tabPage.Size = new System.Drawing.Size(1471, 495);
            _courseTabControl.Controls.Add(tabPage);
            tabPage.Controls.Add(dataGridView);
            _tabPages.Add(tabPage);
        }

        // PrepareDataGridViewHeader
        private void PrepareDataGridViewHeader(DataGridView dataGridView)
        {
            Dictionary<string, string> dataGridViewHeader = _viewModel.GetCourseHeader();
            foreach (KeyValuePair<string, string> entry in dataGridViewHeader)
            {
                dataGridView.Columns[entry.Key].HeaderText = entry.Value;
            }
            dataGridView.Columns[1].Visible = false;
        }

        // uncheck all course and check box
        private void ReloadNotSelectedCourse()
        {
            List<List<CourseInfoDto>> notSelectedCourses = _viewModel.GetNotSelectedCourse();
            for (int i = 0; i < _dataGridViews.Count; i++)
            {
                _dataGridViews[i].DataSource = notSelectedCourses[i];
                _tabPages[i].Text = _viewModel.GetDepartmentName(i);
            }
        }

        // prepare the initial course view
        private void SetUpDataGridView()
        {
            _submitConfirmButton.Enabled = false;
            _secondTabDataGridView.CellContentClick += ClickDataGridViewCellContent;
            _secondTabDataGridView.CellContentDoubleClick += ClickDataGridViewCellContent;
            AddCheckBoxColumn(_firstTabDataGridView);
            AddCheckBoxColumn(_secondTabDataGridView);
            _firstTabDataGridView.DataSource = _viewModel.GetCourseInfo(0);
            _secondTabDataGridView.DataSource = _viewModel.GetCourseInfo(1);
            Dictionary<string, string> dataGridViewHeader = _viewModel.GetCourseHeader();
            foreach (KeyValuePair<string, string> entry in dataGridViewHeader)
            {
                _firstTabDataGridView.Columns[entry.Key].HeaderText = entry.Value;
                _secondTabDataGridView.Columns[entry.Key].HeaderText = entry.Value;
            }
            _firstTabDataGridView.Columns[1].Visible = false;
            _secondTabDataGridView.Columns[1].Visible = false;
        }

        // when checkbox of dataGridView is clicked
        private void ClickDataGridViewCellContent(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
                CheckOutCheckBoxAndConfirmButtonProperty(e);
        }

        // enable _submitConfirmButton if any checkbox was checked
        private void CheckOutCheckBoxAndConfirmButtonProperty(DataGridViewCellEventArgs e)
        {
            string courseNumber = _dataGridViews[_currentTabIndex].Rows[e.RowIndex].Cells[COURSE_NUMBER].Value.ToString();
            _viewModel.UpdateCourseChecked(_currentTabIndex, courseNumber);
            _submitConfirmButton.Enabled = _viewModel.IsAnyCourseChecked();
        }

        // on _submitConfirmButton click
        private void ConfirmAndSubmitCourse(object sender, System.EventArgs e)
        {
            string message = _viewModel.CheckCoursesValidMessage();
            if (_viewModel.IsAddCourseSuccess())
            {
                _submitConfirmButton.Enabled = false;
                SelectCheckedCourse();
            }
            MessageBox.Show(message);
        }

        // selecte and uncheck checked course
        private void SelectCheckedCourse()
        {
            _viewModel.SelectCheckedCourse();
        }

        // on _viewOutcomeButton click
        private void OpenCourseSelectionResultForm(object sender, System.EventArgs e)
        {
            _viewOutcomeButton.Enabled = false;
            CourseSelectionResultForm courseSelectionResultForm = new CourseSelectionResultForm(_model);
            courseSelectionResultForm.Show();
            courseSelectionResultForm.FormClosed += this.HandleCourseSelectionResultFormClose;
        }

        // on CourseSelectionResultForm closed
        private void HandleCourseSelectionResultFormClose(object sender, System.EventArgs e)
        {
            _viewOutcomeButton.Enabled = true;
        }

        // add checkbox column
        private void AddCheckBoxColumn(DataGridView dataGridView)
        {
            DataGridViewCheckBoxColumn selectCourseCheckBoxColumn = new DataGridViewCheckBoxColumn();
            selectCourseCheckBoxColumn.HeaderText = "選";
            dataGridView.Columns.Add(selectCourseCheckBoxColumn);
        }

        // on tab index changed
        private void ChangeTabIndex(object sender, System.EventArgs e)
        {
            _currentTabIndex = _courseTabControl.SelectedIndex;
            PrepareDataGridViewHeader(_dataGridViews[_courseTabControl.SelectedIndex]);
        }
    }
}

