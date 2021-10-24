using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CourseSystem
{
    public partial class CourseManagementForm : Form
    {
        private const string EDIT_COURSE = "編輯課程";
        private const string SAVE = "儲存";
        private CourseManagementFormPresentationModel _viewModel;

        public CourseManagementForm(Model model)
        {
            _viewModel = new CourseManagementFormPresentationModel(model);
            InitializeComponent();
            SetUpCourseListBox();
            _editCourseGroupBox.DataBindings.Add("Text", _viewModel, "CourseEditModeText");
            _numberTextBox.DataBindings.Add("Text", _viewModel, "SelectedCourseNumberText");
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
            _viewModel.GetSelectedCourseInfo(_courseListBox.SelectedIndex);


        }
    }
}
