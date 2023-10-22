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
    public class EmployeeControllerTest
    {
        private Mock<IExamRepository> _examRepositoryMock;
        private Fixture fixture;
        private ExamsController examsController;

        public EmployeeControllerTest()
        {
            fixture = new Fixture();
            _examRepositoryMock = new Mock<IExamRepository>(); 
        }

        [TestMethod]
        public async Task GetExamReturnOkTest() {
            var examList = fixture.CreateMany<Exam>(3).ToList();

            _examRepositoryMock.Setup(repo => repo.Get()).Returns(examList);

            examsController = new ExamsController(_examRepositoryMock.Object);

            var result = await examsController.GetExams();
            var obj = result as ObjectResult;

            Assert.AreEqual(200, obj.StatusCode);
        }

        [TestMethod]
        public async Task GetExamThrowException()
        {
            _examRepositoryMock.Setup(repo => repo.Get()).Throws(new Exception());

            examsController = new ExamsController(_examRepositoryMock.Object);

            var result = await examsController.GetExams();
            var obj = result as ObjectResult;

            Assert.AreEqual(400, obj.StatusCode);
        }
    }
}
