using FluentValidation;
using Utility.ErrorMessages;
using Utility.Regexes;

namespace ConcertApp.API.Requests.Users
{
    public class CreateUserRequest
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
    }

    public class CreateUserRequestValidator : AbstractValidator<CreateUserRequest>
    {
        public CreateUserRequestValidator() 
        {
            RuleFor(x => x.Email)
                .NotEmpty()
                .WithMessage(UserErrors.EmailLength)
                .Length(10, 100)
                .WithMessage(UserErrors.EmailLength)
                .Matches(Regexes.Email)
                .WithMessage(UserErrors.EmailFormat);

            RuleFor(x => x.Password)
                .NotEmpty()
                .WithMessage(UserErrors.PasswordLength)
                .Length(3, 30)
                .WithMessage(UserErrors.PasswordLength)
                .Matches(Regexes.NoWhiteSpace)
                .WithMessage(UserErrors.PasswordFormat);

            RuleFor(x => x.FirstName)
                .NotEmpty()
                .WithMessage(UserErrors.FirstName)
                .Length(2, 100)
                .WithMessage(UserErrors.FirstName)
                .Matches(Regexes.AlphaNumericSpaceDash)
                .WithMessage(UserErrors.FirstName);

            RuleFor(x => x.LastName)
                .NotEmpty()
                .WithMessage(UserErrors.LastName)
                .Length(2, 100)
                .WithMessage(UserErrors.LastName)
                .Matches(Regexes.AlphaNumericSpaceDash)
                .WithMessage(UserErrors.LastName);

            RuleFor(x => x.PhoneNumber)
                .NotEmpty()
                .WithMessage(UserErrors.PhoneNumber)
                .Length(10, 15)
                .WithMessage(UserErrors.PhoneNumber)
                .Matches(Regexes.PhoneNumber)
                .WithMessage(UserErrors.PhoneNumber);
        }
    }
}
