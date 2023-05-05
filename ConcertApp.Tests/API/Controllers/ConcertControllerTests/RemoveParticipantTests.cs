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
    public class RemoveParticipantTests
    {
        private ConcertController _controller;
        private Mock<IMediator> _mediator;
        private RemoveParticipantRequest _request;

        [SetUp]
        public void Init()
        {
            _mediator = new Mock<IMediator>();

            _controller = new ConcertController(_mediator.Object);

            _request = new RemoveParticipantRequest { };
        }

        [Test]
        public async Task ShouldSendRemoveParticipantCommand()
        {
            _mediator.Setup(m => m.Send(It.IsAny<RemoveParticipantCommand>(), It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(new bool()));

            var result = await _controller.RemoveParticipant(_request);

            _mediator.Verify(m => m.Send(It.IsAny<RemoveParticipantCommand>(), It.IsAny<CancellationToken>()), Times.Once);
        }

        [Test]
        public async Task WhenRequestCompletes_ShouldReturnStatusOk()
        {
            var result = await _controller.RemoveParticipant(_request);

            result.Result.Should().BeOfType<OkObjectResult>();
        }

        [TearDown]
        public void Clean()
        {
            _controller.Dispose();
        }
    }
}
