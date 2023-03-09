using AutoFixture;
using ConcertApp.API.Requests.Users;
using FluentValidation.TestHelper;
using NUnit.Framework;
using Utility.Generators;

namespace ConcertApp.Tests.API.Validators.Users
{
    [TestFixture]
    public class CreateUserRequestValidatorTests
    {
        private CreateUserRequestValidator _validator;
        private IFixture _fixture;

        [SetUp]
        public void Init()
        {
            _validator = new CreateUserRequestValidator();
            _fixture = new Fixture();
        }

        [Test]
        public void WhenEmailMissing_ShouldReturnError()
        {
            var model = _fixture.Build<CreateUserRequest>()
                .Without(x => x.Email)
                .Create();

            _validator.TestValidate(model).ShouldHaveValidationErrorFor(model => model.Email);
        }

        [Test]
        public void WhenPasswordMissing_ShouldReturnError()
        {
            var model = _fixture.Build<CreateUserRequest>()
                .Without(x => x.Password)
                .Create();

            _validator.TestValidate(model).ShouldHaveValidationErrorFor(model => model.Password);
        }

        [Test]
        public void WhenFirstNameMissing_ShouldReturnError()
        {
            var model = _fixture.Build<CreateUserRequest>()
                .Without(x => x.FirstName)
                .Create();

            _validator.TestValidate(model).ShouldHaveValidationErrorFor(model => model.FirstName);
        }

        [Test]
        public void WhenLastNameMissing_ShouldReturnError()
        {
            var model = _fixture.Build<CreateUserRequest>()
                .Without(x => x.LastName)
                .Create();

            _validator.TestValidate(model).ShouldHaveValidationErrorFor(model => model.LastName);
        }

        [Test]
        public void WhenPhoneNumberMissing_ShouldReturnError()
        {
            var model = _fixture.Build<CreateUserRequest>()
                .Without(x => x.PhoneNumber)
                .Create();

            _validator.TestValidate(model).ShouldHaveValidationErrorFor(model => model.PhoneNumber);
        }

        [Test]
        public void WhenEmailBelowMinLength_ShouldReturnError()
        {
            var model = _fixture.Build<CreateUserRequest>()
                .With(x => x.Email, "a@b.com")
                .Create();

            _validator.TestValidate(model).ShouldHaveValidationErrorFor(model => model.Email);
        }

        [Test]
        public void WhenPasswordBelowMinLength_ShouldReturnError()
        {
            var model = _fixture.Build<CreateUserRequest>()
                .With(x => x.Password, "p")
                .Create();

            _validator.TestValidate(model).ShouldHaveValidationErrorFor(model => model.Password);
        }

        [Test]
        public void WhenFirstNameBelowMinLength_ShouldReturnError()
        {
            var model = _fixture.Build<CreateUserRequest>()
               .With(x => x.FirstName, "f")
               .Create();

            _validator.TestValidate(model).ShouldHaveValidationErrorFor(model => model.FirstName);
        }

        [Test]
        public void WhenLastNameBelowMinLength_ShouldReturnError()
        {
            var model = _fixture.Build<CreateUserRequest>()
               .With(x => x.LastName, "f")
               .Create();

            _validator.TestValidate(model).ShouldHaveValidationErrorFor(model => model.LastName);
        }

        [Test]
        public void WhenPhoneNumberBelowMinLength_ShouldReturnError()
        {
            var model = _fixture.Build<CreateUserRequest>()
               .With(x => x.PhoneNumber, "123")
               .Create();

            _validator.TestValidate(model).ShouldHaveValidationErrorFor(model => model.PhoneNumber);
        }

        [Test]
        public void WhenEmailAboveMaxLength_ShouldReturnError()
        {
            var model = _fixture.Build<CreateUserRequest>()
                .With(x => x.Email, CustomStringGenerator.RandomString(102))
                .Create();

            _validator.TestValidate(model).ShouldHaveValidationErrorFor(model => model.Email);
        }

        [Test]
        public void WhenPasswordAboveMaxLength_ShouldReturnError()
        {
            var model = _fixture.Build<CreateUserRequest>()
                .With(x => x.Password, CustomStringGenerator.RandomString(33))
                .Create();

            _validator.TestValidate(model).ShouldHaveValidationErrorFor(model => model.Password);
        }

        [Test]
        public void WhenFirstNameAboveMaxLength_ShouldReturnError()
        {
            var model = _fixture.Build<CreateUserRequest>()
                .With(x => x.FirstName, CustomStringGenerator.RandomString(102))
                .Create();

            _validator.TestValidate(model).ShouldHaveValidationErrorFor(model => model.FirstName);
        }

        [Test]
        public void WhenLastNameAboveMaxLength_ShouldReturnError()
        {
            var model = _fixture.Build<CreateUserRequest>()
                .With(x => x.LastName, CustomStringGenerator.RandomString(102))
                .Create();

            _validator.TestValidate(model).ShouldHaveValidationErrorFor(model => model.LastName);
        }

        [Test]
        public void WhenPhoneNumberAboveMaxLength_ShouldReturnError()
        {
            var model = _fixture.Build<CreateUserRequest>()
                .With(x => x.PhoneNumber, "07442134631273124")
                .Create();

            _validator.TestValidate(model).ShouldHaveValidationErrorFor(model => model.PhoneNumber);
        }

        [Test]
        public void WhenEmailIsInvalid_ShouldReturnError()
        {
            var model = _fixture.Build<CreateUserRequest>()
                .With(x => x.Email, "invalidEmail")
                .Create();

            _validator.TestValidate(model).ShouldHaveValidationErrorFor(model => model.Email);
        }

        [Test]
        public void WhenPasswordIsInvalid_ShouldReturnError()
        {
            var model = _fixture.Build<CreateUserRequest>()
                .With(x => x.Password, "invalid password")
                .Create();

            _validator.TestValidate(model).ShouldHaveValidationErrorFor(model => model.Password);
        }

        [Test]
        public void WhenFirstNameIsInvalid_ShouldReturnError()
        {
            var model = _fixture.Build<CreateUserRequest>()
                .With(x => x.FirstName, "first%$@##^@Name()[]")
                .Create();

            _validator.TestValidate(model).ShouldHaveValidationErrorFor(model => model.FirstName);
        }

        [Test]
        public void WhenLastNameIsInvalid_ShouldReturnError()
        {
            var model = _fixture.Build<CreateUserRequest>()
                .With(x => x.LastName, "last%$@##^@Name()[]")
                .Create();

            _validator.TestValidate(model).ShouldHaveValidationErrorFor(model => model.LastName);
        }

        [Test]
        public void WhenPhoneNumberIsInvalid_ShouldReturnError()
        {
            var model = _fixture.Build<CreateUserRequest>()
                .With(x => x.PhoneNumber, "0799123321")
                .Create();

            _validator.TestValidate(model).ShouldHaveValidationErrorFor(model => model.PhoneNumber);
        }
    }
}
