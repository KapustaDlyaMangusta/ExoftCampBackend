using System;
using MediatR;

namespace Application.Users.Commands.EditUserInfo
{
    public class EditUserInfoCommand : IRequest
    {
        public Guid UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string AboutMe { get; set; }
    }
}
