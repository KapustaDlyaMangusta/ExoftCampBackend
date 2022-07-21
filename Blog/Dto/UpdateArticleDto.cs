using Application.Articles.Commands.UpdateArticle;
using Application.Common.Mappings;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Dto
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
