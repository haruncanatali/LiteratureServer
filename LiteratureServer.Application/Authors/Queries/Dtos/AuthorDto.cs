using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using LiteratureServer.Application.Common.Mappings;
using LiteratureServer.Application.Common.Models;
using LiteratureServer.Application.Literaries.Queries.Dtos;
using LiteratureServer.Domain.Entities;

namespace LiteratureServer.Application.Authors.Queries.Dtos
{
    public class AuthorDto : BaseDto, IMapFrom<Author>
    {
        public string FullName { get; set; }
        public string Bio { get; set; }
        public string Photo { get; set; }
        public List<LiteraryForAuthorDto> Literaries { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Author, AuthorDto>()
                .ForMember(dest => dest.Literaries, opt =>
                    opt.MapFrom(c => c.Literaries));
        }
    }
}
