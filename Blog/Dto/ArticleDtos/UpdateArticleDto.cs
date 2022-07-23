using Application.Articles.Commands.UpdateArticle;
using Application.Common.Mappings;
using AutoMapper;
using System;

namespace Blog.Dto.ArticleDtos
{
    public class UpdateArticleDto : IMapWith<UpdateArticleCommand>
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Details { get; set; }
        public string Content { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateArticleDto, UpdateArticleCommand>();
        }
    }
}
