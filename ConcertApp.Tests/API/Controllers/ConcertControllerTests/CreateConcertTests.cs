using ConcertApp.API.Controllers;
using ConcertApp.API.Requests.Concerts;
using ConcertApp.Business.Concerts.Commands;
using FluentAssertions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;

namespace ConcertApp.Tests.API.Controllers.ConcertControllerTests
{
    [TestFixture]
    public class CreateConcertTests
    {
        private ConcertController _controller;
        private Mock<IMediator> _mediator;
        private CreateConcertRequest _request;

        [SetUp]
        public void Init()
        {
            _mediator = new Mock<IMediator>();

            _controller = new ConcertController(_mediator.Object);

            _request = new CreateConcertRequest{};
        }

        [Test]
        public async Task ShouldSendCreateConcertCommand()
        {
            _mediator.Setup(m => m.Send(It.IsAny<CreateConcertCommand>(), It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(new bool()));

            var result = await _controller.CreateConcert(_request);

            _mediator.Verify(m => m.Send(It.IsAny<CreateConcertCommand>(), It.IsAny<CancellationToken>()), Times.Once);
        }

        [Test]
        public async Task WhenRequestCompletes_ShouldReturnStatusOk()
        {
            var result = await _controller.CreateConcert(_request);

            result.Result.Should().BeOfType<OkObjectResult>();
        }

        [TearDown]
        public void Clean()
        {
            _controller.Dispose();
        }
    }
}
