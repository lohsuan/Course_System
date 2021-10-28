using System.Collections.Generic;
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
        public CourseSelectingForm(Model model)
        {
            _model = model;
            _viewModel = new CourseSelectingFormPresentationModel(model);
            InitializeComponent();
            // handle unupdate checkbox problem when user click the same checkbox to fast
            _firstTabDataGridView.CellContentDoubleClick += ClickDataGridViewCellContent;
            _model._courseDataCreateEvent += HandleCourseChangeEvent;
            _model._courseDataUpdateEvent += HandleCourseChangeEvent;
            _model._courseCancelSelectEvent += HandleCourseChangeEvent;
            _model._courseSelectEvent += HandleCourseChangeEvent;
            _dataGridViews.Add(_firstTabDataGridView);
            _dataGridViews.Add(_secondTabDataGridView);
            SetUpDataGridView();
            ReloadNotSelectedCourse();
        }

        // HandleCourseChangeEvent Create, Update, Cancel Select Event
        private void HandleCourseChangeEvent()
        {
            ReloadNotSelectedCourse();
        }

        // prepare the initial course view
        private void SetUpDataGridView()
        {
            _submitConfirmButton.Enabled = false;
            this._secondTabDataGridView.CellContentClick += ClickDataGridViewCellContent;
            this._secondTabDataGridView.CellContentDoubleClick += ClickDataGridViewCellContent;
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
            SetUpTab();
        }

        // set tab control and tab text
        private void SetUpTab()
        {
            _tabPage1.Controls.Add(_firstTabDataGridView);
            _tabPage2.Controls.Add(_secondTabDataGridView);
            _tabPage1.Text = _viewModel.GetDepartmentName(0);
            _tabPage2.Text = _viewModel.GetDepartmentName(1);
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
                //ReloadNotSelectedCourse();
            }
            MessageBox.Show(message);
        }

        // selecte and uncheck checked course
        private void SelectCheckedCourse()
        {
            _viewModel.SelectCheckedCourse();
        }

        // uncheck all course and check box
        private void ReloadNotSelectedCourse()
        {
            List<List<CourseInfoDto>> notSelectedCourses = _viewModel.GetNotSelectedCourse();
            for (int i = 0; i < _dataGridViews.Count; i++)
            {
                _dataGridViews[i].DataSource = notSelectedCourses[i];
            }
        }

        // on _viewOutcomeButton click
        private void OpenCourseSelectionResultForm(object sender, System.EventArgs e)
        {
            this._viewOutcomeButton.Enabled = false;
            CourseSelectionResultForm courseSelectionResultForm = new CourseSelectionResultForm(_model);
            courseSelectionResultForm.Show();
            courseSelectionResultForm.FormClosed += this.HandleCourseSelectionResultFormClose;
        }

        // on CourseSelectionResultForm closed
        private void HandleCourseSelectionResultFormClose(object sender, System.EventArgs e)
        {
            this._viewOutcomeButton.Enabled = true;
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
        }
    }
}

