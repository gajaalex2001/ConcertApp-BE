﻿using AutoFixture;
using ConcertApp.API.Requests.Concerts;
using FluentValidation.TestHelper;
using NUnit.Framework;

namespace ConcertApp.Tests.API.Validators.Concerts
{
    [TestFixture]
    public class GetConcertRequestValidatorTests
    {
        private GetConcertRequestValidator _validator;
        private IFixture _fixture;

        [SetUp]
        public void Init()
        {
            _validator = new GetConcertRequestValidator();
            _fixture = new Fixture();
        }

        [Test]
        public void WhenConcertIdMissing_ShouldReturnError()
        {
            var model = _fixture.Build<GetConcertRequest>()
                .Without(x => x.ConcertId)
                .Create();

            _validator.TestValidate(model).ShouldHaveValidationErrorFor(model => model.ConcertId);
        }

        [Test]
        public void WhenConcertIdBelow0_ShouldReturnError()
        {
            var model = _fixture.Build<GetConcertRequest>()
                .With(x => x.ConcertId, -1)
                .Create();

            _validator.TestValidate(model).ShouldHaveValidationErrorFor(model => model.ConcertId);
        }
    }
}
