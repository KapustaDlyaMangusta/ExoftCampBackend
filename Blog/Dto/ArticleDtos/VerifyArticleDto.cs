using Application.Articles.Commands.VerifyArticle;
using Application.Common.Mappings;
using AutoMapper;
using Domain.Enums;
using System;

namespace Blog.Dto.ArticleDtos
{
    public class VerifyArticleDto : IMapWith<VerifyArticleCommand>
    {
        public Guid Id { get; set; }
        public State State { get; set; }
        public Role Role { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<VerifyArticleDto, VerifyArticleCommand>();
        }
    }
}
