using EvoEvents.Business.Users.Commands;
using EvoEvents.Business.Users.Queries;

namespace EvoEvents.API.Requests.Users
{
    public static class UserExtensions
    {
        public static CreateUserCommand ToCommand(this CreateUserRequest request)
        {
            return new CreateUserCommand
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                Password = request.Password,
                Company = request.Company
            };
        }

        public static UpdateUserCommand ToCommand(this UpdateUserRequest request)
        {
            return new UpdateUserCommand
            {
                Email = request.Email,
                NewCompany = request.NewCompany,
                NewFirstName = request.NewFirstName,
                NewLastName = request.NewLastName,
                Password = request.Password,
                NewPassword = request.NewPassword
            };
        }

        public static LoginQuery ToQuery(this LoginRequest request)
        {
            return new LoginQuery
            {
                Email = request.Email,
                Password = request.Password,
            };
        }
    }
}