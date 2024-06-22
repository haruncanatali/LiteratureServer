using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LiteratureServer.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LiteratureServer.Persistence.Configurations
{
    public class LiteraryConfiguration : IEntityTypeConfiguration<Literary>
    {
        public void Configure(EntityTypeBuilder<Literary> builder)
        {
            builder.Property(c => c.Name).IsRequired();
            builder.Property(c => c.PageCount).IsRequired();
            builder.Property(c => c.Description).IsRequired();
            builder.Property(c => c.AuthorId).IsRequired();
            builder.Property(c => c.PeriodId).IsRequired();
            builder.Property(c => c.LiteraryTypeId).IsRequired();
        }
    }
}
