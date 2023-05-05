using AutoFixture;
using ConcertApp.API.Models;
using ConcertApp.API.Requests.Concerts;
using ConcertApp.Data.Models.Concerts;
using ConcertApp.Data.Models.UserConcerts;
using FluentValidation.TestHelper;
using NUnit.Framework;
using Utility.Generators;

namespace ConcertApp.Tests.API.Validators.Concerts
{
    [TestFixture]
    public class ConcertFiltersValidatorTests
    {
        private ConcertFiltersValidator _validator;
        private IFixture _fixture;

        [SetUp]
        public void Init()
        {
            _validator = new ConcertFiltersValidator();
            _fixture = new Fixture();
        }

        [Test]
        public void WhenGenreNotInEnum_ShouldReturnError()
        {
            var model = _fixture.Build<ConcertFilters>()
                .Without(x => x.Email)
                .Without(x => x.UserStatus)
                .With(x => x.MusicGenre, (MusicGenre)(-1))
                .Create();

            _validator.TestValidate(model).ShouldHaveValidationErrorFor(model => model.MusicGenre);
        }

        [Test]
        public void WhenUserStatusNotInEnum_ShouldReturnError()
        {
            var model = _fixture.Build<ConcertFilters>()
                .With(x => x.UserStatus, (UserStatus)(-1))
                .Create();

            _validator.TestValidate(model).ShouldHaveValidationErrorFor(model => model.UserStatus);
        }

        [Test]
        public void WhenEmailBelowMinLength_ShouldReturnError()
        {
            var model = _fixture.Build<ConcertFilters>()
                .With(x => x.Email, "a@b.com")
                .Create();

            _validator.TestValidate(model).ShouldHaveValidationErrorFor(model => model.Email);
        }

        [Test]
        public void WhenEmailAboveMaxLength_ShouldReturnError()
        {
            var model = _fixture.Build<ConcertFilters>()
                .With(x => x.Email, CustomStringGenerator.RandomString(102))
                .Create();

            _validator.TestValidate(model).ShouldHaveValidationErrorFor(model => model.Email);
        }

        [Test]
        public void WhenEmailIsInvalid_ShouldReturnError()
        {
            var model = _fixture.Build<ConcertFilters>()
                .With(x => x.Email, "invalidEmail")
                .Create();

            _validator.TestValidate(model).ShouldHaveValidationErrorFor(model => model.Email);
        }

        [Test]
        public void WhenEmailExistsAndUserStatusNotExists_ShouldReturnError()
        {
            var model = _fixture.Build<ConcertFilters>()
                .Without(x => x.UserStatus)
                .With(x => x.Email, "email@yahoo.com")
                .Create();

            _validator.TestValidate(model).ShouldHaveValidationErrorFor(model => model);
        }

        [Test]
        public void WhenUserStatusExistsAndEmailNotExists_ShouldReturnError()
        {
            var model = _fixture.Build<ConcertFilters>()
                .Without(x => x.Email)
                .With(x => x.UserStatus, UserStatus.Organizer)
                .Create();

            _validator.TestValidate(model).ShouldHaveValidationErrorFor(model => model);
        }
    }
}
