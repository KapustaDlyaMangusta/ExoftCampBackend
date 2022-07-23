using Application.Common.Mappings;
using Application.Users.Commands.EditUserInfo;
using AutoMapper;

namespace Blog.Dto.UserDtos
{
    public class EditUserInfoDto : IMapWith<EditUserInfoCommand>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string AboutMe { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<EditUserInfoDto, EditUserInfoCommand>();
        }
    }
}
