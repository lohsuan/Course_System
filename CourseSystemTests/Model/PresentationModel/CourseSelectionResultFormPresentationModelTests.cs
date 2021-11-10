using Microsoft.VisualStudio.TestTools.UnitTesting;
using CourseSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseSystem.Tests
{
    /// <summary>
    /// Number of test method: 3
    /// </summary>
    [TestClass()]
    public class CourseSelectionResultFormPresentationModelTests
    {
        Model _model;
        CourseSelectionResultFormPresentationModel _viewModel;

        // TestInitialize
        [TestInitialize]
        public void Initialize()
        {
            _model = new Model();
            _viewModel = new CourseSelectionResultFormPresentationModel(_model);
        }

        // CourseSelectionResultFormPresentationModelTest
        [TestMethod()]
        public void CourseSelectionResultFormPresentationModelTest()
        {
            Assert.IsNotNull(_viewModel);
            Assert.IsNotNull(_model);
        }

        // GetOpeningCourseCurriculumTest
        [TestMethod()]
        public void GetOpeningCourseCurriculumTest()
        {
            CourseSelectingFormPresentationModel courseSelectingFormPresentationModel = new CourseSelectingFormPresentationModel(_model);
            List<CourseInfoDto> courseInfoDtos = courseSelectingFormPresentationModel.GetCourseInfo(0);
            courseSelectingFormPresentationModel.UpdateCourseChecked(0, courseInfoDtos[1].Id);
            courseSelectingFormPresentationModel.UpdateCourseChecked(0, courseInfoDtos[2].Id);
            courseSelectingFormPresentationModel.SelectCheckedCourse();

            List<CourseInfoDto> coursesCurriculum = _viewModel.GetOpeningCourseCurriculum();

            Assert.AreEqual(2, coursesCurriculum.Count);
            Assert.AreEqual(courseInfoDtos[1].Id, coursesCurriculum[0].Id);
            Assert.AreEqual(courseInfoDtos[2].Id, coursesCurriculum[1].Id);

            courseInfoDtos[2].SetCourseStatus(1);
            List<CourseInfoDto> openingCoursesCurriculum = _viewModel.GetOpeningCourseCurriculum();

            Assert.AreEqual(1, openingCoursesCurriculum.Count);
            Assert.AreEqual(courseInfoDtos[1].Id, openingCoursesCurriculum[0].Id);
        }

        // CancelSelectCourseTest
        [TestMethod()]
        public void CancelSelectCourseTest()
        {
            CourseSelectingFormPresentationModel courseSelectingFormPresentationModel = new CourseSelectingFormPresentationModel(_model);
            List<CourseInfoDto> courseInfoDtos = courseSelectingFormPresentationModel.GetCourseInfo(0);
            courseSelectingFormPresentationModel.UpdateCourseChecked(0, courseInfoDtos[1].Id);
            courseSelectingFormPresentationModel.UpdateCourseChecked(0, courseInfoDtos[2].Id);
            courseSelectingFormPresentationModel.SelectCheckedCourse();

            List<CourseInfoDto> coursesCurriculum = _viewModel.GetOpeningCourseCurriculum();

            Assert.AreEqual(2, coursesCurriculum.Count);
            Assert.AreEqual(courseInfoDtos[1].Id, coursesCurriculum[0].Id);
            Assert.AreEqual(courseInfoDtos[2].Id, coursesCurriculum[1].Id);

            _viewModel.CancelSelectCourse(courseInfoDtos[1].Id);
            coursesCurriculum = _viewModel.GetOpeningCourseCurriculum();

            Assert.AreEqual(1, coursesCurriculum.Count);
            Assert.AreEqual(courseInfoDtos[2].Id, coursesCurriculum[0].Id);
        }
    }
}