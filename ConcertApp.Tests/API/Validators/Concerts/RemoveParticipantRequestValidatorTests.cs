using AutoFixture;
using ConcertApp.API.Requests.Concerts;
using FluentValidation.TestHelper;
using NUnit.Framework;
using Utility.Generators;

namespace ConcertApp.Tests.API.Validators.Concerts
{
    [TestFixture]
    public class RemoveParticipantRequestValidatorTests
    {
        private RemoveParticipantRequestValidator _validator;
        private IFixture _fixture;

        [SetUp]
        public void Init()
        {
            _validator = new RemoveParticipantRequestValidator();
            _fixture = new Fixture();
        }

        [Test]
        public void WhenEmailMissing_ShouldReturnError()
        {
            var model = _fixture.Build<RemoveParticipantRequest>()
                .Without(x => x.Email)
                .Create();

            _validator.TestValidate(model).ShouldHaveValidationErrorFor(model => model.Email);
        }

        [Test]
        public void WhenEmailBelowMinLength_ShouldReturnError()
        {
            var model = _fixture.Build<RemoveParticipantRequest>()
                .With(x => x.Email, "a@b.com")
                .Create();

            _validator.TestValidate(model).ShouldHaveValidationErrorFor(model => model.Email);
        }

        [Test]
        public void WhenEmailAboveMaxLength_ShouldReturnError()
        {
            var model = _fixture.Build<RemoveParticipantRequest>()
                .With(x => x.Email, CustomStringGenerator.RandomString(102))
                .Create();

            _validator.TestValidate(model).ShouldHaveValidationErrorFor(model => model.Email);
        }

        [Test]
        public void WhenEmailIsInvalid_ShouldReturnError()
        {
            var model = _fixture.Build<RemoveParticipantRequest>()
                .With(x => x.Email, "invalidEmail")
                .Create();

            _validator.TestValidate(model).ShouldHaveValidationErrorFor(model => model.Email);
        }

        [Test]
        public void WhenConcertIdMissing_ShouldReturnError()
        {
            var model = _fixture.Build<RemoveParticipantRequest>()
                .Without(x => x.ConcertId)
                .Create();

            _validator.TestValidate(model).ShouldHaveValidationErrorFor(model => model.ConcertId);
        }

        [Test]
        public void WhenConcertIdBelow0_ShouldReturnError()
        {
            var model = _fixture.Build<RemoveParticipantRequest>()
                .With(x => x.ConcertId, -3)
                .Create();

            _validator.TestValidate(model).ShouldHaveValidationErrorFor(model => model.ConcertId);
        }
    }
}
