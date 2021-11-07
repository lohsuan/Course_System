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


        public ImportCourseProgressForm(Model model)
        {
            _model = model;
            _viewModel = new ImportCourseProgressFormPresentationModel(model);
            InitializeComponent();
        }

        // on ImportCourseProgressForm_Shown
        private void LoadClasses(object sender, EventArgs e)
        {
            string[] computerScienceCoursePathes = _viewModel.GetComputerScienceCoursePathes();
            _importClassProgressBar.Minimum = 0;
            _importClassProgressBar.Maximum = computerScienceCoursePathes.Length;
            _importClassProgressBar.Step = 1;
            _importClassLabel.Refresh();

            for (int i = 0; i < computerScienceCoursePathes.Length; i++)
            {
                _viewModel.ImportClass(computerScienceCoursePathes[i]);
                _importClassProgressBar.PerformStep();
                _importClassLabel.Text = IMPORT_CLASS_TEXT + ((double)(i + 1) / _importClassProgressBar.Maximum * ONE_HUNDRED).ToString() + PERCENT;
                _importClassLabel.Refresh();
                Thread.Sleep(SLEEP_TIME);
            }
            _model.NotifyCourseImport();
            Close();
        }

    }
}
