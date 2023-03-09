using ConcertApp.API.Controllers;
using ConcertApp.API.Requests.Users;
using ConcertApp.Business.Users.Commands;
using FluentAssertions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;

namespace ConcertApp.Tests.API.Controllers.UserControllerTests
{
    [TestFixture]
    public class CreateUserTests
    {
        private UserController _controller;
        private Mock<IMediator> _mediator;
        private CreateUserRequest _request;

        [SetUp]
        public void Init()
        {
            _mediator = new Mock<IMediator>();

            _controller = new UserController(_mediator.Object);

            _request = new CreateUserRequest
            {
                Email = "test.email@email.com",
                Password = "totallysafepassword",
                FirstName = "Hugh",
                LastName = "Mongous",
                PhoneNumber = "0775123321",
            };
        }

        [Test]
        public async Task ShouldSendCreateUserCommand()
        {
            _mediator.Setup(m => m.Send(It.IsAny<CreateUserCommand>(), It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(new bool()));

            var result = await _controller.CreateUser(_request);

            _mediator.Verify(m => m.Send(It.IsAny<CreateUserCommand>(), It.IsAny<CancellationToken>()), Times.Once);
        }

        [Test]
        public async Task WhenRequestCompletes_ShouldReturnStatusOk()
        {
            var result = await _controller.CreateUser(_request);

            result.Result.Should().BeOfType<OkObjectResult>();
        }

        [TearDown]
        public void Clean()
        {
            _controller.Dispose();
        }
    }
}
