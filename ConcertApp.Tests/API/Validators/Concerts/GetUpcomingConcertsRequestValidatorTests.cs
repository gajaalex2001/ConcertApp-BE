using AutoFixture;
using ConcertApp.API.Requests.Concerts;
using FluentValidation.TestHelper;
using NUnit.Framework;
using Utility.Generators;

namespace ConcertApp.Tests.API.Validators.Concerts
{
    [TestFixture]
    public class GetUpcomingConcertsRequestValidatorTests
    {
        private GetUpcomingConcertsRequestValidator _validator;
        private IFixture _fixture;

        [SetUp]
        public void Init()
        {
            _validator = new GetUpcomingConcertsRequestValidator();
            _fixture = new Fixture();
        }

        [Test]
        public void WhenEmailMissing_ShouldReturnError()
        {
            var model = _fixture.Build<GetUpcomingConcertsRequest>()
                .Without(x => x.Email)
                .Create();

            _validator.TestValidate(model).ShouldHaveValidationErrorFor(model => model.Email);
        }

        [Test]
        public void WhenEmailBelowMinLength_ShouldReturnError()
        {
            var model = _fixture.Build<GetUpcomingConcertsRequest>()
                .With(x => x.Email, "a@b.com")
                .Create();

            _validator.TestValidate(model).ShouldHaveValidationErrorFor(model => model.Email);
        }

        [Test]
        public void WhenEmailAboveMaxLength_ShouldReturnError()
        {
            var model = _fixture.Build<GetUpcomingConcertsRequest>()
                .With(x => x.Email, CustomStringGenerator.RandomString(102))
                .Create();

            _validator.TestValidate(model).ShouldHaveValidationErrorFor(model => model.Email);
        }

        [Test]
        public void WhenEmailIsInvalid_ShouldReturnError()
        {
            var model = _fixture.Build<GetUpcomingConcertsRequest>()
                .With(x => x.Email, "invalidEmail")
                .Create();

            _validator.TestValidate(model).ShouldHaveValidationErrorFor(model => model.Email);
        }

        [Test]
        public void WhenCurrentDateMissing_ShouldReturnError()
        {
            var model = _fixture.Build<GetUpcomingConcertsRequest>()
                .Without(x => x.CurrentDate)
                .Create();

            _validator.TestValidate(model).ShouldHaveValidationErrorFor(model => model.CurrentDate);
        }
    }
}
