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
    public class GetUpcomingConcertsTests
    {
        private ConcertController _controller;
        private Mock<IMediator> _mediator;
        private GetUpcomingConcertsRequest _request;

        [SetUp]
        public void Init()
        {
            _mediator = new Mock<IMediator>();

            _controller = new ConcertController(_mediator.Object);

            _request = new GetUpcomingConcertsRequest { };
        }

        [Test]
        public async Task ShouldSendGetUpcomingConcertsQuery()
        {
            _mediator.Setup(m => m.Send(It.IsAny<GetUpcomingConcertsQuery>(), It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(new List<Concert>()));

            var result = await _controller.GetUpcomingConcerts(_request);

            _mediator.Verify(m => m.Send(It.IsAny<GetUpcomingConcertsQuery>(), It.IsAny<CancellationToken>()), Times.Once);
        }

        [Test]
        public async Task WhenRequestCompletes_ShouldReturnStatusOk()
        {
            var result = await _controller.GetUpcomingConcerts(_request);

            result.Result.Should().BeOfType<OkObjectResult>();
        }

        [TearDown]
        public void Clean()
        {
            _controller.Dispose();
        }
    }
}
