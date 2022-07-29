using EvoEvents.Business.Users.Commands;
using EvoEvents.Data.Models.Users;
using System;
using System.Linq;

namespace EvoEvents.Business.Users
{
    public static class UserExtensions
    {
        public static User ToUser(this CreateUserCommand command)
        {
            return new User
            {
                Email = command.Email,
                Password = command.Password,
                Created = DateTime.Now,

                Information = new UserDetail
                {
                    LastName = command.LastName,
                    FirstName = command.FirstName,
                    Company = command.Company
                }
            };
        }
        public static bool IsEmailDuplicate(this IQueryable<User> users, CreateUserCommand command)
        {
            return users.Any(u => u.Email == command.Email);
        }
    }
}
