using Application.Articles.Commands.CreateArticle;
using Application.Articles.Commands.DeleteArticle;
using Application.Articles.Commands.UpdateArticle;
using Application.Articles.Commands.VerifyArticle;
using Application.Articles.Queries;
using Application.Articles.Queries.GetArticleContent;
using Application.Articles.Queries.GetArticleList;
using Application.Articles.Queries.GetUserArticleList;
using AutoMapper;
using Blog.Dto.ArticleDtos;
using Domain.Enums;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Blog.Controllers
{
    [ApiController]
    public class ArticleController : BaseController
    {
        private readonly IMapper _mapper;

        public ArticleController(IMapper mapper) => _mapper = mapper;

        [HttpGet("GetListOfArticles")]
        public async Task<ActionResult<ArticleListVm>> GetList(State state)
        {
            var vm = await Mediator.Send(new GetArticleListQuery
            {
                State = state
            });

            return Ok(vm);
        }

        [HttpGet("GetArticleContentById")]
        public async Task<ActionResult<ArticleContentVm>> GetArticleContent(Guid id)
        {
            var vm = await Mediator.Send(new GetArticleContentQuery
            {
                Id = id
            });

            return Ok(vm);
        }

        [HttpGet("GetUserArticles")]
        public async Task<ActionResult<ArticleListVm>> GetUserArticles(Guid userId)
        {
            var vm = await Mediator.Send(new GetUserArticleListQuery
            {
                UserId = userId
            });

            return Ok(vm);
        }

        [HttpPost("CreateArticle")]
        public async Task<ActionResult<Guid>> CreateArticle([FromBody] CreateArticleDto createArticleDto)
        {
            var command = _mapper.Map<CreateArticleCommand>(createArticleDto);
            command.UserId = UserId;
            var articleId = await Mediator.Send(command);
            return Ok(articleId);
        }

        [HttpPut("UpdateArticle")]
        public async Task<IActionResult> UpdateArticle([FromBody] UpdateArticleDto updateArticleDto)
        {
            var command = _mapper.Map<UpdateArticleCommand>(updateArticleDto);
            command.UserId = UserId;
            await Mediator.Send(command);
            return NoContent();
        }

        [HttpPut("VerifyArticle")]
        public async Task<IActionResult> VerufyArticle([FromBody] VerifyArticleDto verifyArticleDto)
        {
            var command = _mapper.Map<VerifyArticleCommand>(verifyArticleDto);
            command.UserId = UserId;
            await Mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("DeleteArticle")]
        public async Task<IActionResult> DeleteArticle(Guid id)
        {

            var articleId = await Mediator.Send(new DeleteArticleCommand
            {
                Id = id,
                UserId = UserId
            });
            return NoContent();
        }
    }
}
