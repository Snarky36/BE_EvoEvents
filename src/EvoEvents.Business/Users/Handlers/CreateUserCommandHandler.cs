using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using EvoEvents.Business.Users.Commands;
using EvoEvents.Data;
using Infrastructure.Utilities.ErrorStrings;
using MediatR;

namespace EvoEvents.Business.Users.Handlers
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, bool>
    {
        private readonly EvoEventsContext _context;

        public CreateUserCommandHandler(EvoEventsContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(CreateUserCommand command, CancellationToken cancellationToken)
        {
            ValidateEmail(command.Email);

            AddUser(command);

            return await _context.SaveChangesAsync() > 0;
        }

        private void AddUser(CreateUserCommand command)
        {
            _context.Users.Add(command.ToUser());
        }

        private void ValidateEmail(string email)
        {
            if (_context.Users.Any(u => u.Email == email))
            {
                throw new ApplicationException(ErrorMessages.UniqueEmailError);
            }
        }
    }
}
