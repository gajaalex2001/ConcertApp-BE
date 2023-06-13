using ConcertApp.API.Controllers;
using ConcertApp.API.Requests.Users;
using ConcertApp.Business.Users.Models;
using ConcertApp.Business.Users.Queries;
using FluentAssertions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;

namespace ConcertApp.Tests.API.Controllers.UserControllerTests
{
    [TestFixture]
    public class LoginTests
    {
        private UserController _controller;
        private Mock<IMediator> _mediator;
        private LoginUserRequest _request;

        [SetUp]
        public void Init()
        {
            _mediator = new Mock<IMediator>();

            _controller = new UserController(_mediator.Object);

            _request = new LoginUserRequest
            {
                Email = "test.email@email.com",
                Password = "0775123321"
            };
        }


        [Test]
        public async Task ShouldSendLoginUserQuery()
        {
            _mediator.Setup(m => m.Send(It.IsAny<LoginUserQuery>(), It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(new UserInformation()));

            var result = await _controller.LoginUser(_request);

            _mediator.Verify(m => m.Send(It.IsAny<LoginUserQuery>(), It.IsAny<CancellationToken>()), Times.Once);
        }

        [Test]
        public async Task WhenRequestCompletes_ShouldReturnStatusOk()
        {
            var result = await _controller.LoginUser(_request);

            result.Result.Should().BeOfType<OkObjectResult>();
        }

        [TearDown]
        public void Clean()
        {
            _controller.Dispose();
        }
    }
}
