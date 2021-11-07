using System;
using System.Threading;
using System.Windows.Forms;

namespace CourseSystem
{
    public partial class ImportCourseProgressForm : Form
    {
        private const string IMPORT_CLASS_TEXT = "正在匯入課程...";
        private const int ONE_HUNDRED = 100;
        private const int SLEEP_TIME = 550;
        private const string PERCENT = "%";
        Model _model;
        ImportCourseProgressFormPresentationModel _viewModel;
        private string[] _computerScienceCoursePathes = { CourseConstant.COMPUTER_SCIENCE_FRESHMAN_CLASS_URL, CourseConstant.COMPUTER_SCIENCE_SOPHOMORE_CLASS_URL, CourseConstant.COMPUTER_SCIENCE_JUNIOR_CLASS_URL, CourseConstant.COMPUTER_SCIENCE_SENIOR_CLASS_URL, CourseConstant.COMPUTER_SCIENCE__GRADUATE_SCHOOL_URL };

        public ImportCourseProgressForm(Model model)
        {
            _model = model;
            _viewModel = new ImportCourseProgressFormPresentationModel(model);
            InitializeComponent();
        }

        // on ImportCourseProgressForm_Shown
        private void LoadClasses(object sender, EventArgs e)
        {
            SetUp();
            for (int i = 0; i < _computerScienceCoursePathes.Length; i++)
            {
                _viewModel.ImportClass(_computerScienceCoursePathes[i]);
                _importClassProgressBar.PerformStep();
                _importClassLabel.Text = IMPORT_CLASS_TEXT + ((double)(i + 1) / _importClassProgressBar.Maximum * ONE_HUNDRED).ToString() + PERCENT;
                _importClassLabel.Refresh();
                Thread.Sleep(SLEEP_TIME);
            }
            _model.NotifyCourseImport();
            this.Close();
        }

        // set up progress bar and refresh label
        private void SetUp()
        {
            _importClassProgressBar.Minimum = 0;
            _importClassProgressBar.Maximum = _computerScienceCoursePathes.Length;
            _importClassProgressBar.Step = 1;
            _importClassLabel.Refresh();
        }
    }
}
