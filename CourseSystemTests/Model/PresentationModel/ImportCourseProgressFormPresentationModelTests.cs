using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CourseSystem.Tests
{
    /// <summary>
    /// Number of test method: 3
    /// </summary>
    [TestClass()]
    public class ImportCourseProgressFormPresentationModelTests
    {
        Model _model;
        ImportCourseProgressFormPresentationModel _viewModel;

        // TestInitialize
        [TestInitialize]
        public void Initialize()
        {
            _model = new Model();
            _viewModel = new ImportCourseProgressFormPresentationModel(_model);
        }

        // ImportCourseProgressFormPresentationModelTest
        [TestMethod()]
        public void ImportCourseProgressFormPresentationModelTest()
        {
            Assert.IsNotNull(_viewModel);
        }

        // ImportClassTest
        [TestMethod()]
        public void ImportClassTest()
        {
            int courseAmount = _model.GetAllCourses().Count;
            _viewModel.ImportClass("https://aps.ntut.edu.tw/course/tw/Subj.jsp?format=-4&year=110&sem=1&code=2701");
            Assert.IsTrue(courseAmount < _model.GetAllCourses().Count);
        }

        // GetComputerScienceCoursePathesTest
        [TestMethod()]
        public void GetComputerScienceCoursePathesTest()
        {
            string[] computerScienceCoursePathes = { CourseConstant.COMPUTER_SCIENCE_FRESHMAN_CLASS_URL, CourseConstant.COMPUTER_SCIENCE_SOPHOMORE_CLASS_URL, CourseConstant.COMPUTER_SCIENCE_JUNIOR_CLASS_URL, CourseConstant.COMPUTER_SCIENCE_SENIOR_CLASS_URL, CourseConstant.COMPUTER_SCIENCE__GRADUATE_SCHOOL_URL };
            string[] testPathes = _viewModel.GetComputerScienceCoursePathes();
            for (int i = 0; i < computerScienceCoursePathes.Length; i++)
            {
                Assert.AreEqual(testPathes[i], computerScienceCoursePathes[i]);
            }
        }
    }
}