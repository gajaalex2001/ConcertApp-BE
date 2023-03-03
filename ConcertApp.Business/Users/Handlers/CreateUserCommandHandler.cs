using ConcertApp.Business.Users.Commands;
using ConcertApp.Data;
using ConcertApp.Data.Models.Users;
using MediatR;
using Utility.ErrorMessages;
using Utility.Exceptions.ErrorCodes;
using Utility.Exceptions.Models;

namespace ConcertApp.Business.Users.Handlers
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, bool>
    {
        private readonly ConcertAppContext _context;

        public CreateUserCommandHandler(ConcertAppContext context) 
        {
            _context = context;
        }

        public async Task<bool> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            User user = request.ToUser();
            CheckIfEmailUnique(user.Email);
            await _context.Users.AddAsync(user);

            return await _context.SaveChangesAsync() > 0;
        }

        private void CheckIfEmailUnique(string email)
        {
            if (_context.Users.Any(x => x.Email == email))
                throw new CustomException(ErrorCodes.User_EmailAlreadyExists, UserErrors.EmailAlreadyExists);
        }
    }
}
