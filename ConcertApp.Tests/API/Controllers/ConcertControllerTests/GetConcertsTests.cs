using ConcertApp.API.Controllers;
using ConcertApp.API.Models;
using ConcertApp.API.Requests.Concerts;
using ConcertApp.Business.Concerts.Models;
using ConcertApp.Business.Concerts.Queries;
using ConcertApp.Business.Pagination;
using ConcertApp.Data.Models.UserConcerts;
using FluentAssertions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;

namespace ConcertApp.Tests.API.Controllers.ConcertControllerTests
{
    [TestFixture]
    public class GetConcertsTests
    {
        private ConcertController _controller;
        private Mock<IMediator> _mediator;
        private GetPageRequest _request;

        [SetUp]
        public void Init()
        {
            _mediator = new Mock<IMediator>();

            _controller = new ConcertController(_mediator.Object);

            _request = new GetPageRequest 
            {
                Filters = new ConcertFilters
                {
                    Email = "email@yahoo.com",
                    MusicGenre = Data.Models.Concerts.MusicGenre.Rock,
                    UserStatus = UserStatus.Participant
                },
                PageRequest = new PageRequest
                {
                    ItemsPerPage = 10,
                    PageIndex = 1,
                }
            };
        }

        [Test]
        public async Task ShouldSendGetConcertsQuery()
        {
            _mediator.Setup(m => m.Send(It.IsAny<GetPageQuery>(), It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(new Page<Concert>()));

            var result = await _controller.GetConcerts(_request);

            _mediator.Verify(m => m.Send(It.IsAny<GetPageQuery>(), It.IsAny<CancellationToken>()), Times.Once);
        }

        [Test]
        public async Task WhenRequestCompletes_ShouldReturnStatusOk()
        {
            var result = await _controller.GetConcerts(_request);

            result.Result.Should().BeOfType<OkObjectResult>();
        }

        [TearDown]
        public void Clean()
        {
            _controller.Dispose();
        }
    }
}
