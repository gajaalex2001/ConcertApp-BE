using AutoFixture;
using ConcertApp.API.Requests.Concerts;
using ConcertApp.Data.Models.Concerts;
using FluentValidation.TestHelper;
using NUnit.Framework;
using Utility.Generators;

namespace ConcertApp.Tests.API.Validators.Concerts
{
    [TestFixture]
    public class CreateConcertRequestValidatorTests
    {
        private CreateConcertRequestValidator _validator;
        private IFixture _fixture;

        [SetUp]
        public void Init()
        {
            _validator = new CreateConcertRequestValidator();
            _fixture = new Fixture();
        }

        [Test]
        public void WhenEmailMissing_ShouldReturnError()
        {
            var model = _fixture.Build<CreateConcertRequest>()
                .Without(x => x.Email)
                .Create();

            _validator.TestValidate(model).ShouldHaveValidationErrorFor(model => model.Email);
        }

        [Test]
        public void WhenEmailBelowMinLength_ShouldReturnError()
        {
            var model = _fixture.Build<CreateConcertRequest>()
                .With(x => x.Email, "a@b.com")
                .Create();

            _validator.TestValidate(model).ShouldHaveValidationErrorFor(model => model.Email);
        }

        [Test]
        public void WhenEmailAboveMaxLength_ShouldReturnError()
        {
            var model = _fixture.Build<CreateConcertRequest>()
                .With(x => x.Email, CustomStringGenerator.RandomString(102))
                .Create();

            _validator.TestValidate(model).ShouldHaveValidationErrorFor(model => model.Email);
        }

        [Test]
        public void WhenEmailIsInvalid_ShouldReturnError()
        {
            var model = _fixture.Build<CreateConcertRequest>()
                .With(x => x.Email, "invalidEmail")
                .Create();

            _validator.TestValidate(model).ShouldHaveValidationErrorFor(model => model.Email);
        }

        [Test]
        public void WhenNameMissing_ShouldReturnError()
        {
            var model = _fixture.Build<CreateConcertRequest>()
                .Without(x => x.Name)
                .Create();

            _validator.TestValidate(model).ShouldHaveValidationErrorFor(model => model.Name);
        }

        [Test]
        public void WhenNameBelowMinLength_ShouldReturnError()
        {
            var model = _fixture.Build<CreateConcertRequest>()
                .With(x => x.Name, "n")
                .Create();

            _validator.TestValidate(model).ShouldHaveValidationErrorFor(model => model.Name);
        }

        [Test]
        public void WhenNameAboveMaxLength_ShouldReturnError()
        {
            var model = _fixture.Build<CreateConcertRequest>()
                .With(x => x.Name, CustomStringGenerator.RandomString(102))
                .Create();

            _validator.TestValidate(model).ShouldHaveValidationErrorFor(model => model.Name);
        }

        [Test]
        public void WhenNameIsInvalid_ShouldReturnError()
        {
            var model = _fixture.Build<CreateConcertRequest>()
                .With(x => x.Name, "a$%^$&#")
                .Create();

            _validator.TestValidate(model).ShouldHaveValidationErrorFor(model => model.Name);
        }

        [Test]
        public void WhenDescriptionAboveMaxLength_ShouldReturnError()
        {
            var model = _fixture.Build<CreateConcertRequest>()
                .With(x => x.Description, CustomStringGenerator.RandomString(2002))
                .Create();

            _validator.TestValidate(model).ShouldHaveValidationErrorFor(model => model.Description);
        }

        [Test]
        public void WhenDescriptionIsInvalid_ShouldReturnError()
        {
            var model = _fixture.Build<CreateConcertRequest>()
                .With(x => x.Description, "$*#@%^!)#^(F")
                .Create();

            _validator.TestValidate(model).ShouldHaveValidationErrorFor(model => model.Description);
        }

        [Test]
        public void WhenLocationMissing_ShouldReturnError()
        {
            var model = _fixture.Build<CreateConcertRequest>()
                .Without(x => x.Location)
                .Create();

            _validator.TestValidate(model).ShouldHaveValidationErrorFor(model => model.Location);
        }

        [Test]
        public void WhenLocationBelowMinLength_ShouldReturnError()
        {
            var model = _fixture.Build<CreateConcertRequest>()
                .With(x => x.Location, "n")
                .Create();

            _validator.TestValidate(model).ShouldHaveValidationErrorFor(model => model.Location);
        }

        [Test]
        public void WhenLocationAboveMaxLength_ShouldReturnError()
        {
            var model = _fixture.Build<CreateConcertRequest>()
                .With(x => x.Location, CustomStringGenerator.RandomString(102))
                .Create();

            _validator.TestValidate(model).ShouldHaveValidationErrorFor(model => model.Location);
        }

        [Test]
        public void WhenLocationIsInvalid_ShouldReturnError()
        {
            var model = _fixture.Build<CreateConcertRequest>()
                .With(x => x.Location, "a$%^$&#")
                .Create();

            _validator.TestValidate(model).ShouldHaveValidationErrorFor(model => model.Location);
        }

        [Test]
        public void WhenGenreMissing_ShouldReturnError()
        {
            var model = _fixture.Build<CreateConcertRequest>()
                .Without(x => x.Genre)
                .Create();

            _validator.TestValidate(model).ShouldHaveValidationErrorFor(model => model.Genre);
        }

        [Test]
        public void WhenGenreNotInEnum_ShouldReturnError()
        {
            var model = _fixture.Build<CreateConcertRequest>()
                .With(x => x.Genre, (MusicGenre)(-1))
                .Create();

            _validator.TestValidate(model).ShouldHaveValidationErrorFor(model => model.Genre);
        }

        [Test]
        public void WhenCapacityMissing_ShouldReturnError()
        {
            var model = _fixture.Build<CreateConcertRequest>()
                .Without(x => x.Capacity)
                .Create();

            _validator.TestValidate(model).ShouldHaveValidationErrorFor(model => model.Capacity);
        }

        [Test]
        public void WhenCapacityNotInRange_ShouldReturnError()
        {
            var model = _fixture.Build<CreateConcertRequest>()
                .With(x => x.Capacity, -12)
                .Create();

            _validator.TestValidate(model).ShouldHaveValidationErrorFor(model => model.Capacity);
        }

        [Test]
        public void WhenStartDateMissing_ShouldReturnError()
        {
            var model = _fixture.Build<CreateConcertRequest>()
                .Without(x => x.StartDate)
                .Create();

            _validator.TestValidate(model).ShouldHaveValidationErrorFor(model => model.StartDate);
        }

        [Test]
        public void WhenStartDateBeforeNow_ShouldReturnError()
        {
            var model = _fixture.Build<CreateConcertRequest>()
                .With(x => x.StartDate, DateTime.Now.AddMonths(-1))
                .Create();

            _validator.TestValidate(model).ShouldHaveValidationErrorFor(model => model.StartDate);
        }

        [Test]
        public void WhenEndDateMissing_ShouldReturnError()
        {
            var model = _fixture.Build<CreateConcertRequest>()
                .Without(x => x.EndDate)
                .Create();

            _validator.TestValidate(model).ShouldHaveValidationErrorFor(model => model.EndDate);
        }

        [Test]
        public void WhenEndDateBeforeNow_ShouldReturnError()
        {
            var model = _fixture.Build<CreateConcertRequest>()
                .With(x => x.EndDate, DateTime.Now.AddMonths(-1))
                .Create();

            _validator.TestValidate(model).ShouldHaveValidationErrorFor(model => model.EndDate);
        }

        [Test]
        public void WhenEndDateBeforeStartDate_ShouldReturnError()
        {
            var model = _fixture.Build<CreateConcertRequest>()
                .With(x => x.StartDate, DateTime.Now.AddMonths(-1))
                .With(x => x.EndDate, DateTime.Now.AddMonths(-3))
                .Create();

            _validator.TestValidate(model).ShouldHaveValidationErrorFor(model => model);
        }
    }
}
