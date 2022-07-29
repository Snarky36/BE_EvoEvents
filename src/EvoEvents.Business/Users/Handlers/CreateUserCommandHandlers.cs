using System;
using System.Threading;
using System.Threading.Tasks;
using EvoEvents.Business.Users.Commands;
using EvoEvents.Data;
using MediatR;

namespace EvoEvents.Business.Users.Handlers
{
    public class CreateUserCommandHandlers : IRequestHandler<CreateUserCommand, bool>
    {
        private readonly EvoEventsContext _context;

        public CreateUserCommandHandlers(EvoEventsContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(CreateUserCommand command, CancellationToken cancellationToken)
        {
            if (_context.Users.IsEmailDuplicate(command))
            {
                throw new ApplicationException("Email should be unique");
            }
            await _context.Users.AddAsync(command.ToUser());

            return await _context.SaveChangesAsync() > 0;   
        }
    }
}
