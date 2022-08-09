using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvoEvents.Business.Users.Commands
{
    public class UpdateUserCommand : IRequest<bool>
    {
        public string Email { get; set; }   
        public string NewCompany { get; set; }
        public string NewFirstName{ get; set; } 
        public string NewLastName{ get; set; } 
        public string Password{ get; set; } 
        public string NewPassword { get; set; } 
    }
}