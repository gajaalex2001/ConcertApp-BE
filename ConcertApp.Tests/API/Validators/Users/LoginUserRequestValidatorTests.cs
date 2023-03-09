using AutoFixture;
using ConcertApp.API.Requests.Users;
using FluentValidation.TestHelper;
using NUnit.Framework;
using Utility.Generators;

namespace ConcertApp.Tests.API.Validators.Users
{
    [TestFixture]
    public class LoginUserRequestValidatorTests
    {
        private LoginUserRequestValidator _validator;
        private IFixture _fixture;

        [SetUp]
        public void Init()
        {
            _validator = new LoginUserRequestValidator();
            _fixture = new Fixture();
        }

        [Test]
        public void WhenEmailMissing_ShouldReturnError()
        {
            var model = _fixture.Build<LoginUserRequest>()
                .Without(x => x.Email)
                .Create();

            _validator.TestValidate(model).ShouldHaveValidationErrorFor(model => model.Email);
        }

        [Test]
        public void WhenPasswordMissing_ShouldReturnError()
        {
            var model = _fixture.Build<LoginUserRequest>()
                .Without(x => x.Password)
                .Create();

            _validator.TestValidate(model).ShouldHaveValidationErrorFor(model => model.Password);
        }

        [Test]
        public void WhenEmailBelowMinLength_ShouldReturnError()
        {
            var model = _fixture.Build<LoginUserRequest>()
                .With(x => x.Email, "a@b.com")
                .Create();

            _validator.TestValidate(model).ShouldHaveValidationErrorFor(model => model.Email);
        }

        [Test]
        public void WhenPasswordBelowMinLength_ShouldReturnError()
        {
            var model = _fixture.Build<LoginUserRequest>()
                .With(x => x.Password, "p")
                .Create();

            _validator.TestValidate(model).ShouldHaveValidationErrorFor(model => model.Password);
        }

        [Test]
        public void WhenEmailAboveMaxLength_ShouldReturnError()
        {
            var model = _fixture.Build<LoginUserRequest>()
                .With(x => x.Email, CustomStringGenerator.RandomString(102))
                .Create();

            _validator.TestValidate(model).ShouldHaveValidationErrorFor(model => model.Email);
        }

        [Test]
        public void WhenPasswordAboveMaxLength_ShouldReturnError()
        {
            var model = _fixture.Build<LoginUserRequest>()
                .With(x => x.Password, CustomStringGenerator.RandomString(32))
                .Create();

            _validator.TestValidate(model).ShouldHaveValidationErrorFor(model => model.Password);
        }

        [Test]
        public void WhenEmailIsInvalid_ShouldReturnError()
        {
            var model = _fixture.Build<LoginUserRequest>()
                .With(x => x.Email, "invalid email")
                .Create();

            _validator.TestValidate(model).ShouldHaveValidationErrorFor(model => model.Email);
        }

        [Test]
        public void WhenPasswordIsInvalid_ShouldReturnError()
        {
            var model = _fixture.Build<LoginUserRequest>()
                .With(x => x.Password, "invalid password")
                .Create();

            _validator.TestValidate(model).ShouldHaveValidationErrorFor(model => model.Password);
        }
    }
}
