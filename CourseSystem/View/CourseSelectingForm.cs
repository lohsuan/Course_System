using System.Collections.Generic;
using System.Windows.Forms;

namespace CourseSystem
{
    public partial class CourseSelectingForm : Form
    {
        private CourseSelectingFormPresentationModel _viewModel;
        private int _currentTabIndex;

        public CourseSelectingForm()
        {
            this._viewModel = new CourseSelectingFormPresentationModel();
            InitializeComponent();
            // handle unupdate checkbox problem when user click the same checkbox to fast
            this._firstTabDataGridView.CellContentDoubleClick += ClickDataGridViewCellContent;
            this._secondTabDataGridView.CellContentClick += ClickDataGridViewCellContent;
            SetUp();
        }

        // prepare the initial course view
        private void SetUp()
        {
            _submitConfirmButton.Enabled = false;
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
            _tabPage1.Controls.Add(_firstTabDataGridView);
            _tabPage2.Controls.Add(_secondTabDataGridView);
            _tabPage1.Text = _viewModel.GetDepartmentName(0);
            _tabPage2.Text = _viewModel.GetDepartmentName(1);

        }

        // when checkbox of dataGridView is clicked
        private void ClickDataGridViewCellContent(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                CheckOutCheckBoxAndConfirmButtonProperty(e);
            }
        }

        // enable _submitConfirmButton if any checkbox was checked
        private void CheckOutCheckBoxAndConfirmButtonProperty(DataGridViewCellEventArgs e)
        {
            _viewModel.UpdateCourseChecked(_currentTabIndex, e.RowIndex);
            if (_viewModel.IsAnyCourseChecked())
            {
                _submitConfirmButton.Enabled = true;
                return;
            }
            _submitConfirmButton.Enabled = false;
        }

        // on _submitConfirmButton click
        private void ConfirmAndSubmitCourse(object sender, System.EventArgs e)
        {
            string message = _viewModel.CheckCoursesValidMessage();
            MessageBox.Show(message);
        }

        // on _viewOutcomeButton click
        private void OpenCourseSelectionResultForm(object sender, System.EventArgs e)
        {
            this._viewOutcomeButton.Enabled = false;
            CourseSelectionResultForm courseSelectionResultForm = new CourseSelectionResultForm();
            courseSelectionResultForm.Show();
            courseSelectionResultForm.FormClosed += this.HandleCourseSelectionResultFormClose;
        }

        // on CourseSelectionResultForm closed
        private void HandleCourseSelectionResultFormClose(object sender, FormClosedEventArgs e)
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

