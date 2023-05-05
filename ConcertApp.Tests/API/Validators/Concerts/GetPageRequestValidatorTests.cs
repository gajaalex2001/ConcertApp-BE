using AutoFixture;
using ConcertApp.API.Requests.Concerts;
using FluentValidation.TestHelper;
using NUnit.Framework;

namespace ConcertApp.Tests.API.Validators.Concerts
{
    [TestFixture]
    public class GetPageRequestValidatorTests
    {
        private GetPageRequestValidator _validator;
        private IFixture _fixture;

        [SetUp]
        public void Init()
        {
            _validator = new GetPageRequestValidator();
            _fixture = new Fixture();
        }

        [Test]
        public void WhenPageRequestMissing_ShouldReturnError()
        {
            var model = _fixture.Build<GetPageRequest>()
                .Without(x => x.PageRequest)
                .Create();

            _validator.TestValidate(model).ShouldHaveValidationErrorFor(model => model.PageRequest);
        }
    }
}
