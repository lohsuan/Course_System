using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CourseSystem
{
    public partial class CourseManagementForm : Form
    {
        private CourseManagementFormPresentationModel _viewModel;

        public CourseManagementForm(Model model)
        {
            this._viewModel = new CourseManagementFormPresentationModel(model);
            InitializeComponent();
            List<CourseInfoDto> courses = _viewModel.GetAllCourses();
            foreach (CourseInfoDto course in courses)
            {
                _courseListBox.Items.Add(course.Name);
            }
            _saveButton.Enabled = false;
        }

        // _courseListBox_Click
        private void ClickCourseListBox(object sender, EventArgs e)
        {
            int selectedIndex = _courseListBox.SelectedIndex;
            //_viewModel
        }
    }
}
