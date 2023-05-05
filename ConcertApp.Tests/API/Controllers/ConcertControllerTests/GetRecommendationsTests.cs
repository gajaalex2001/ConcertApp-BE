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
    public class GetRecommendationsTests
    {
        private ConcertController _controller;
        private Mock<IMediator> _mediator;
        private GetRecommendationsRequest _request;

        [SetUp]
        public void Init()
        {
            _mediator = new Mock<IMediator>();

            _controller = new ConcertController(_mediator.Object);

            _request = new GetRecommendationsRequest { };
        }

        [Test]
        public async Task ShouldSendGetRecommendationsQuery()
        {
            _mediator.Setup(m => m.Send(It.IsAny<GetRecommendationsQuery>(), It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(new List<Concert>()));

            var result = await _controller.GetRecommendations(_request);

            _mediator.Verify(m => m.Send(It.IsAny<GetRecommendationsQuery>(), It.IsAny<CancellationToken>()), Times.Once);
        }

        [Test]
        public async Task WhenRequestCompletes_ShouldReturnStatusOk()
        {
            var result = await _controller.GetRecommendations(_request);

            result.Result.Should().BeOfType<OkObjectResult>();
        }

        [TearDown]
        public void Clean()
        {
            _controller.Dispose();
        }
    }
}
