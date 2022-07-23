using Application.Common.Mappings;
using AutoMapper;
using Domain.Models;

namespace Application.Users.Queries.GetUserInfo
{
    public class UserInfoVm : IMapWith<User>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string AboutMe { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<User, UserInfoVm>();
        }
    }
}
