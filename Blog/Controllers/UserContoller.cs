using Application.Users.Commands.EditUserInfo;
using Application.Users.Queries.GetUserInfo;
using AutoMapper;
using Blog.Dto.UserDtos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;


namespace Blog.Controllers
{
    [ApiController]
    public class UserContoller : BaseController
    {
        private readonly IMapper _mapper;
        public UserContoller(IMapper mapper) => _mapper = mapper;

        [HttpGet("GetUserInfoById")]
        public async Task<ActionResult<UserInfoVm>> GetArticleContent(Guid userId)
        {
            var vm = await Mediator.Send(new GetUserInfoQuery
            {
                UserId = userId
            });

            return Ok(vm);
        }

        [HttpPut("EditUserInfo")]
        public async Task<IActionResult> UpdateArticle([FromBody] EditUserInfoDto editUserInfoDto)
        {
            var command = _mapper.Map<EditUserInfoCommand>(editUserInfoDto);
            command.UserId = UserId;
            await Mediator.Send(command);
            return NoContent();
        }
    }
}
