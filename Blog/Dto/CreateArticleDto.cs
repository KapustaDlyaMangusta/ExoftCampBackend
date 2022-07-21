using Application.Articles.Commands.CreateArticle;
using Application.Common.Mappings;
using AutoMapper;

namespace Blog.Dto
{
    public class CreateArticleDto : IMapWith<CreateArticleCommand>
    {
        public string Title { get; set; }
        public string Details { get; set; }
        public string Content { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateArticleDto, CreateArticleCommand>();
        }
    }
}
