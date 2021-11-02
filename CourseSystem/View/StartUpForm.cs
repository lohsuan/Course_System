using System;
using System.Windows.Forms;

namespace CourseSystem
{
    public partial class StartUpForm : Form
    {
        Model _model;
        public StartUpForm()
        {
            _model = new Model();
            InitializeComponent();
        }

        // on _courseSelectingSystemButton click
        private void OpenCourseSelectingSystem(object sender, EventArgs e)
        {
            this._courseSelectingSystemButton.Enabled = false;
            CourseSelectingForm courseSelectingForm = new CourseSelectingForm(_model);
            courseSelectingForm.Show();
            courseSelectingForm.FormClosed += this.HandleCourseSelectingSystemClose;
        }

        // on _courseManagementSystemButton click
        private void OpenCourseManagementSystem(object sender, EventArgs e)
        {
            this._courseManagementSystemButton.Enabled = false;
            CourseManagementForm courseManagementForm = new CourseManagementForm(_model);
            courseManagementForm.Show();
            courseManagementForm.FormClosed += this.HandleCourseManagementSystemClose;
        }

        // on CourseSelectingSystem form closed
        private void HandleCourseSelectingSystemClose(object sender, FormClosedEventArgs e)
        {
            this._courseSelectingSystemButton.Enabled = true;
        }

        // on CourseManagementSystem form closed
        private void HandleCourseManagementSystemClose(object sender, FormClosedEventArgs e)
        {
            this._courseManagementSystemButton.Enabled = true;
        }

        // exit program
        private void Exit(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
