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
using rft.Repositories.UserRepository;

namespace ApiTests
{
    [TestClass]
    public class UsersControllerTests
    {
        [TestMethod]
        public async Task GetUsers_ReturnsOkStatusCode()
        {
            Mock<IUserRepository> userRepositoryMock = new Mock<IUserRepository>();
            var userList = new List<User> { new User(), new User(), new User() };
            userRepositoryMock.Setup(repo => repo.Get()).Returns(userList);
            UsersController usersController = new UsersController(userRepositoryMock.Object);

            var result = await usersController.GetUsers();

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(ActionResult));
            var actionResult = result as ActionResult;

            var statusCode = actionResult as Microsoft.AspNetCore.Mvc.ObjectResult;
            Assert.IsNotNull(statusCode);
            Assert.AreEqual(200, statusCode.StatusCode);
        }

        [TestMethod]
        public async Task GetUsers_Exception_ReturnsBadRequest()
        {
            Mock<IUserRepository> userRepositoryMock = new Mock<IUserRepository>();
            userRepositoryMock.Setup(repo => repo.Get()).Throws(new Exception("Internal Server Error"));
            UsersController usersController = new UsersController(userRepositoryMock.Object);

            var result = await usersController.GetUsers();

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(ActionResult));
            var actionResult = result as ActionResult;

            var statusCode = actionResult as Microsoft.AspNetCore.Mvc.ObjectResult;
            Assert.IsNotNull(statusCode);
            Assert.AreEqual(400, statusCode.StatusCode);
        }
    }
}
