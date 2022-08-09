using EvoEvents.Business.Users.Commands;
using EvoEvents.Data;
using EvoEvents.Data.Models.Users;
using Infrastructure.Utilities.CustomException;
using Infrastructure.Utilities.Errors;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace EvoEvents.Business.Users.Handlers
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, bool>
    {
        private readonly EvoEventsContext _context;

        public UpdateUserCommandHandler(EvoEventsContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(UpdateUserCommand command, CancellationToken cancellationToken)
        {
            var user = GetUser(command);
            ValidateUserInformation(user);
            UpdateUser(command, user);

            return await _context.SaveChangesAsync() > 0;

        }

        private User GetUser(UpdateUserCommand command)
        {
            if (command.Password is not null)
            {
                return _context.Users.Include(u => u.Information).FirstOrDefault(u => u.Email == command.Email && u.Password == command.Password);
            }
            return _context.Users.Include(u => u.Information).FirstOrDefault(u => u.Email == command.Email);
        }

        private void UpdateUser(UpdateUserCommand request, User user)
        {
            if (request.Password is not null)
            {
                user.Password = request.NewPassword;
            }
            user.Information = new UserDetail
            {
                FirstName = request.NewFirstName,
                LastName = request.NewLastName,
                Company = request.NewCompany
            };
        }

        private void ValidateUserInformation(User user)
        {
            if (user == null)
            {
                throw new CustomException(ErrorCode.User_WrongCredentials, ErrorMessage.WrongCredentialsError);
            }
        }
    }
}