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

        [TestMethod]
        public async Task GetExam_ValidExamId_ReturnsOkStatusAndData()
        {
            Mock<IExamRepository> examRepositoryMock = new Mock<IExamRepository>();
            int examId = 1;
            var examData = new Fixture().Create<Exam>();
            examRepositoryMock.Setup(repo => repo.Get(examId)).Returns(examData);
            ExamsController examsController = new ExamsController(examRepositoryMock.Object);

            var result = await examsController.GetExam(examId);
            var obj = result as ObjectResult;

            Assert.AreEqual(200, obj.StatusCode);
            Assert.AreEqual(examData, obj.Value);
        }

        [TestMethod]
        public async Task GetExam_ExceptionThrown_ReturnsBadRequestWithErrorMessage()
        {
            Mock<IExamRepository> examRepositoryMock = new Mock<IExamRepository>();
            int examId = 1;
            examRepositoryMock.Setup(repo => repo.Get(examId)).Throws(new Exception("Something went wrong"));
            ExamsController examsController = new ExamsController(examRepositoryMock.Object);

            var result = await examsController.GetExam(examId);
            var obj = result as ObjectResult;

            Assert.AreEqual(400, obj.StatusCode);
            Assert.AreEqual("Something went wrong", obj.Value);
        }

        [TestMethod]
        public async Task DeleteExam_ValidData_ReturnsOkStatusAndMessageTest()
        {
            Mock<IExamRepository> examRepositoryMock = new Mock<IExamRepository>();
            examRepositoryMock.Setup(repo => repo.Delete(It.IsAny<int>(), It.IsAny<int>()));
            ExamsController examsController = new ExamsController(examRepositoryMock.Object);

            var result = await examsController.DeleteExam(1, 2);
            var obj = result as ObjectResult;

            Assert.AreEqual(200, obj.StatusCode);
            Assert.AreEqual("deleted", obj.Value);
        }

        [TestMethod]
        public async Task DeleteExam_InvalidData_ReturnsBadRequestStatusTest()
        {
            Mock<IExamRepository> examRepositoryMock = new Mock<IExamRepository>();
            ExamsController examsController = new ExamsController(examRepositoryMock.Object);

            examsController.ModelState.AddModelError("examId", "Invalid examId");
            var result = await examsController.DeleteExam(1, 2);

            Assert.IsInstanceOfType(result, typeof(BadRequestResult));
        }

        [TestMethod]
        public async Task DeleteExam_ExceptionThrown_ReturnsBadRequestWithErrorMessageTest()
        {
            Mock<IExamRepository> examRepositoryMock = new Mock<IExamRepository>();
            examRepositoryMock.Setup(repo => repo.Delete(It.IsAny<int>(), It.IsAny<int>())).Throws(new Exception("Something went wrong"));
            ExamsController examsController = new ExamsController(examRepositoryMock.Object);

            var result = await examsController.DeleteExam(1, 2);
            var obj = result as ObjectResult;

            Assert.AreEqual(400, obj.StatusCode);
            Assert.AreEqual("Something went wrong", obj.Value);
        }

    }
}
