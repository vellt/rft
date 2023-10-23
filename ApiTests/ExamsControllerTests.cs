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
            Fixture fixture = new Fixture();
            var examList = fixture.CreateMany<Exam>(3).ToList();

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
            Fixture fixture = new Fixture();
            examRepositoryMock.Setup(repo => repo.Get()).Throws(new Exception());

            ExamsController examsController = new ExamsController(examRepositoryMock.Object);

            var result = await examsController.GetExams();
            var obj = result as ObjectResult;

            Assert.AreEqual(400, obj.StatusCode);
        }

    }
}
