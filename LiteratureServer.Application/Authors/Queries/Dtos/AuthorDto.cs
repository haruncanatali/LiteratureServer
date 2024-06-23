using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LiteratureServer.Application.Common.Mappings;
using LiteratureServer.Application.Common.Models;
using LiteratureServer.Domain.Entities;

namespace LiteratureServer.Application.Authors.Queries.Dtos
{
    public class AuthorDto : BaseDto, IMapFrom<Author>
    {
        public string FullName { get; set; }
        public string Bio { get; set; }
        public string Photo { get; set; }
    }
}
