using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LiteratureServer.Domain.Base;

namespace LiteratureServer.Domain.Entities
{
    public class Literary : BaseEntity
    {
        public string Name { get; set; }
        public int PageCount { get; set; }
        public string Description { get; set; }

        public long LiteraryTypeId{ get; set; }
        public long PeriodId { get; set; }
        public long AuthorId { get; set; }

        public LiteraryType LiteraryType { get; set; }
        public Period Period { get; set; }
        public Author Author { get; set; }
    }
}
