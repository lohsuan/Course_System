using System.Collections.Generic;
using System.Windows.Forms;

namespace CourseSystem
{
    public partial class CourseSelectionResultForm : Form
    {
        private const int ID = 1;
        private CourseSelectionResultFormPresentationModel _viewModel;
        private Model _model;
        public CourseSelectionResultForm(Model model)
        {
            _model = model;
            this._viewModel = new CourseSelectionResultFormPresentationModel(model);
            _model._courseDataUpdateEvent += HandleCourseDataUpdateEvent;
            _model._courseSelectEvent += HandleCourseDataUpdateEvent;
            InitializeComponent();
            PrepareDeleteButtonColumn();
            PrepareCurriculum();
            _courseSelectionResultDataGridView.Columns[1].Visible = false;

        }

        // on CourseManagementSystem form closed
        private void HandleCourseDataUpdateEvent()
        {
            PrepareCurriculum();
        }

        // PrepareCurriculum
        private void PrepareCurriculum()
        {
            _courseSelectionResultDataGridView.Rows.Clear();
            List<CourseInfoDto> courseInfoDtos = _viewModel.GetCurriculum();
            foreach (var course in courseInfoDtos)
            {
                string[] courseRow = { "", course.Id, course.Number, course.Name, course.Stage, course.Credit, course.Hour,
                            course.RequiredType, course.Teacher, course.ClassTimeSunday, course.ClassTimeMonday, course.ClassTimeTuesday,
                            course.ClassTimeWednesday, course.ClassTimeThursday, course.ClassTimeFriday, course.ClassTimeSaturday, course.Classroom,
                            course.NumberOfStudent, course.NumberOfDropStudent, course.TeacherAssistant, course.Language,
                            course.Note, course.Syllabus, course.Audit, course.Experiment };
                _courseSelectionResultDataGridView.Rows.Add(courseRow);
            }
        }

        // prepare delete button cloumn
        private void PrepareDeleteButtonColumn()
        {
            DataGridViewButtonColumn deleteColumn = new DataGridViewButtonColumn();
            deleteColumn.HeaderText = "退";
            deleteColumn.Name = "deleteColumn";
            deleteColumn.Text = "退選";
            deleteColumn.UseColumnTextForButtonValue = true;
            _courseSelectionResultDataGridView.Columns.Insert(0, deleteColumn);
        }

        // when drop class button of dataGridView is clicked
        private void ClickDataGridViewCellContent(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                string id = _courseSelectionResultDataGridView.Rows[e.RowIndex].Cells[ID].Value.ToString();
                _viewModel.CancelSelectCourse(id);
                _courseSelectionResultDataGridView.Rows.RemoveAt(e.RowIndex);
            }
        }
    }
}
