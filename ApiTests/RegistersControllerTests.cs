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
using rft.Repositories.RegisterRepository;

namespace ApiTests
{
    [TestClass]
    public class RegistersControllerTests
    {

        [TestMethod]
        public async Task GetRegister_ReturnsOkStatusCode()
        {
            Mock<IRegisterRepository> registerRepositoryMock = new Mock<IRegisterRepository>();
            var registerList = new Fixture().CreateMany<Register>(3).ToList();
            registerRepositoryMock.Setup(repo => repo.Get()).Returns(registerList);
            RegistersController registersController = new RegistersController(registerRepositoryMock.Object);

            var result = await registersController.GetRegisters();
            var obj = result as ObjectResult;

            Assert.AreEqual(200, obj.StatusCode);
        }

        [TestMethod]
        public async Task PostRegister_ValidData_ReturnsOkStatusCode()
        {

            Mock<IRegisterRepository> registerRepositoryMock = new Mock<IRegisterRepository>();
            Register register = new Register();
            Exam expectedExam = new Exam();
            registerRepositoryMock.Setup(repo => repo.Post(register)).Returns(expectedExam);

            RegistersController registersController = new RegistersController(registerRepositoryMock.Object);

            var result = await registersController.PostRegister(register);

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(ActionResult<Register>));
            var actionResult = result as ActionResult<Register>;

            var statusCode = actionResult.Result as Microsoft.AspNetCore.Mvc.ObjectResult;
            Assert.IsNotNull(statusCode);
            Assert.AreEqual(200, statusCode.StatusCode);
        }

        [TestMethod]
        public async Task PostRegister_InvalidData_ReturnsBadRequest()
        {
  
            Mock<IRegisterRepository> registerRepositoryMock = new Mock<IRegisterRepository>();
            Register register = new Register();
            registerRepositoryMock.Setup(repo => repo.Post(register)).Throws(new Exception("Invalid data"));

            RegistersController registersController = new RegistersController(registerRepositoryMock.Object);

            var result = await registersController.PostRegister(register);

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(ActionResult<Register>));
            var actionResult = result as ActionResult<Register>;

            var statusCode = actionResult.Result as Microsoft.AspNetCore.Mvc.ObjectResult;
            Assert.IsNotNull(statusCode);
            Assert.AreEqual(400, statusCode.StatusCode);
        }

        [TestMethod]
        public async Task DeleteRegister_ValidData_ReturnsOkStatusCode()
        {
            Mock<IRegisterRepository> registerRepositoryMock = new Mock<IRegisterRepository>();
            int registerId = 1;
            int userId = 1;
            registerRepositoryMock.Setup(repo => repo.Delete(registerId, userId));
            RegistersController registersController = new RegistersController(registerRepositoryMock.Object);

            var result = await registersController.DeleteRegister(registerId, userId);
            var obj = result as ObjectResult;

            Assert.AreEqual(200, obj.StatusCode);
        }


    }
}
