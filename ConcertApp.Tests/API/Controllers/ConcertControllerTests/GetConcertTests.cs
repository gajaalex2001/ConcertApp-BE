using ConcertApp.API.Controllers;
using ConcertApp.API.Requests.Concerts;
using ConcertApp.Business.Concerts.Models;
using ConcertApp.Business.Concerts.Queries;
using FluentAssertions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;

namespace ConcertApp.Tests.API.Controllers.ConcertControllerTests
{
    [TestFixture]
    public class GetConcertTests
    {
        private ConcertController _controller;
        private Mock<IMediator> _mediator;
        private GetConcertRequest _request;

        [SetUp]
        public void Init()
        {
            _mediator = new Mock<IMediator>();

            _controller = new ConcertController(_mediator.Object);

            _request = new GetConcertRequest { };
        }

        [Test]
        public async Task ShouldSendGetConcertQuery()
        {
            _mediator.Setup(m => m.Send(It.IsAny<GetConcertQuery>(), It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(new ConcertDetails()));

            var result = await _controller.GetConcert(_request);

            _mediator.Verify(m => m.Send(It.IsAny<GetConcertQuery>(), It.IsAny<CancellationToken>()), Times.Once);
        }

        [Test]
        public async Task WhenRequestCompletes_ShouldReturnStatusOk()
        {
            var result = await _controller.GetConcert(_request);

            result.Result.Should().BeOfType<OkObjectResult>();
        }

        [TearDown]
        public void Clean()
        {
            _controller.Dispose();
        }
    }
}
