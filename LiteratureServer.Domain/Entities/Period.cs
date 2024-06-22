using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LiteratureServer.Domain.Base;

namespace LiteratureServer.Domain.Entities
{
    public class Period : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public List<Literary> Literaries { get; set; }
    }
}
