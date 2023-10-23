using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoFixture;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using rft.Controllers;
using rft.Models;
using rft.Repositories.ExamRepository;

namespace ApiTests
{
    [TestClass]
    public class ExamsControllerTests
    {
        [TestMethod]
        public async Task GetExam_ReturnOk_StatusCodeTest() {
            Mock<IExamRepository> examRepositoryMock= new Mock<IExamRepository>();
            var examList = new Fixture().CreateMany<Exam>(3).ToList();

            examRepositoryMock.Setup(repo => repo.Get()).Returns(examList);
            ExamsController examsController = new ExamsController(examRepositoryMock.Object);

            var result = await examsController.GetExams();
            var obj = result as ObjectResult;


            Assert.AreEqual(200, obj.StatusCode);
        }

        [TestMethod]
        public async Task GetExam_ThrowException_StatusCodeTest()
        {
            Mock<IExamRepository> examRepositoryMock = new Mock<IExamRepository>();
            examRepositoryMock.Setup(repo => repo.Get()).Throws(new Exception());

            ExamsController examsController = new ExamsController(examRepositoryMock.Object);

            var result = await examsController.GetExams();
            var obj = result as ObjectResult;

            Assert.AreEqual(400, obj.StatusCode);
        }

        [TestMethod]
        public async Task PutExam_ReturnOk_StatusCodeTest()
        {
            Mock<IExamRepository> examRepositoryMock = new Mock<IExamRepository>();
            Exam exam = new Fixture().Create<Exam>();
            examRepositoryMock.Setup(repo => repo.Put(It.IsAny<Exam>(),It.IsAny<int>())).Returns(exam);

            ExamsController examsController = new ExamsController(examRepositoryMock.Object);

            var result = await examsController.PutExam(exam,1);
            var obj = result as ObjectResult;

            Assert.AreEqual(200, obj.StatusCode);
        }

        [TestMethod]
        public async Task PutExam_ThrowException_StatusCodeTest()
        {
            Mock<IExamRepository> examRepositoryMock = new Mock<IExamRepository>();
            Exam exam = new Fixture().Create<Exam>();
            examRepositoryMock.Setup(repo => repo.Put(It.IsAny<Exam>(), It.IsAny<int>())).Throws(new Exception());

            ExamsController examsController = new ExamsController(examRepositoryMock.Object);

            var result = await examsController.PutExam(exam, 1);
            var obj = result as ObjectResult;

            Assert.AreEqual(400, obj.StatusCode);
        }

        [TestMethod]
        public async Task PostExam_ReturnOk_StatusCodeTest()
        {
            Mock<IExamRepository> examRepositoryMock = new Mock<IExamRepository>();
            Exam exam = new Fixture().Create<Exam>();
            examRepositoryMock.Setup(repo => repo.Post(It.IsAny<Exam>(), It.IsAny<int>())).Returns(exam);

            ExamsController examsController = new ExamsController(examRepositoryMock.Object);

            var result = await examsController.PostExam(exam, 1);
            var obj = result as ObjectResult;

            Assert.AreEqual(200, obj.StatusCode);
        }

        [TestMethod]
        public async Task PostExam_ThrowException_StatusCodeTest()
        {
            Mock<IExamRepository> examRepositoryMock = new Mock<IExamRepository>();
            Exam exam = new Fixture().Create<Exam>();
            examRepositoryMock.Setup(repo => repo.Post(It.IsAny<Exam>(), It.IsAny<int>())).Throws(new Exception());

            ExamsController examsController = new ExamsController(examRepositoryMock.Object);

            var result = await examsController.PostExam(exam, 1);
            var obj = result as ObjectResult;

            Assert.AreEqual(400, obj.StatusCode);
        }

    }
}
