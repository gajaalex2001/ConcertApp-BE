using AutoFixture;
using ConcertApp.API.Models;
using FluentValidation.TestHelper;
using NUnit.Framework;

namespace ConcertApp.Tests.API.Validators.Concerts
{
    [TestFixture]
    public class PageRequestValidatorTests
    {
        private PageRequestValidator _validator;
        private IFixture _fixture;

        [SetUp]
        public void Init()
        {
            _validator = new PageRequestValidator();
            _fixture = new Fixture();
        }

        [Test]
        public void WhenPageIndexMissing_ShouldReturnError()
        {
            var model = _fixture.Build<PageRequest>()
                .Without(x => x.PageIndex)
                .Create();

            _validator.TestValidate(model).ShouldHaveValidationErrorFor(model => model.PageIndex);
        }

        [Test]
        public void WhenPageIndexBelow0_ShouldReturnError()
        {
            var model = _fixture.Build<PageRequest>()
                .With(x => x.PageIndex, -1)
                .Create();

            _validator.TestValidate(model).ShouldHaveValidationErrorFor(model => model.PageIndex);
        }

        [Test]
        public void WhenItemsPerPageMissing_ShouldReturnError()
        {
            var model = _fixture.Build<PageRequest>()
                .Without(x => x.ItemsPerPage)
                .Create();

            _validator.TestValidate(model).ShouldHaveValidationErrorFor(model => model.ItemsPerPage);
        }

        [Test]
        public void WhenItemsPerPageBelow0_ShouldReturnError()
        {
            var model = _fixture.Build<PageRequest>()
                .With(x => x.ItemsPerPage, -1)
                .Create();

            _validator.TestValidate(model).ShouldHaveValidationErrorFor(model => model.ItemsPerPage);
        }
    }
}
