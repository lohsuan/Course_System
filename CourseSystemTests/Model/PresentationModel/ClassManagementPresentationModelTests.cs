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
    ///  Number of test method in ModelTest: 5
    /// </summary>
    
    [TestClass()]
    public class ClassManagementPresentationModelTests
    {
        Model _model;
        ClassManagementPresentationModel _viewModel;

        // TestInitialize
        [TestInitialize]
        public void Initialize()
        {
            _model = new Model();
            _viewModel = new ClassManagementPresentationModel(_model);
        }

        // ClassManagementPresentationModelTest
        [TestMethod()]
        public void ClassManagementPresentationModelTest()
        {
            Assert.IsNotNull(_viewModel);
        }

        // GetClassCourseNamesByIndexTest
        [TestMethod()]
        public void GetClassCourseNamesByIndexTest()
        {
            List<string> courseNames = _viewModel.GetClassCourseNamesByIndex(0);
            Assert.AreEqual("班週會及導師時間", courseNames[0]);
            Assert.AreEqual("體育", courseNames[1]);
            Assert.AreEqual("博雅選修課程", courseNames[2]);
        }

        // SetNewCourseNameTest
        [TestMethod()]
        public void SetNewCourseNameTest()
        {
            _viewModel.SetNewClassName("new class");
            _viewModel.AddClass();
            Assert.AreEqual(3, _model.GetDepartments().Count);
            Assert.AreEqual("new class", _model.GetDepartmentName(2));
        }

        // IsAddButtonEnableTest
        [TestMethod()]
        public void IsAddButtonEnableTest()
        {
            _viewModel.SetNewClassName("");
            Assert.IsFalse(_viewModel.IsAddButtonEnable());

            _viewModel.SetNewClassName("123");
            Assert.IsTrue(_viewModel.IsAddButtonEnable());
        }

        // AddClassTest
        [TestMethod()]
        public void AddClassTest()
        {
            _viewModel.SetNewClassName("new class");
            _viewModel.AddClass();
            Assert.AreEqual(3, _model.GetDepartments().Count);
            Assert.AreEqual("new class", _model.GetDepartmentName(2));
        }
    }
}