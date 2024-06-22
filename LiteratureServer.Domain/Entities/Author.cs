using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LiteratureServer.Domain.Base;

namespace LiteratureServer.Domain.Entities
{
    public class Author : BaseEntity
    {
        public string FullName { get; set; }
        public string Bio { get; set; }
        public string Photo { get; set; }

        public List<Literary> Literaries { get; set; }
    }
}
