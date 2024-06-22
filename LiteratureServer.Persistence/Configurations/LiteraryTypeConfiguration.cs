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
    public class LiteraryTypeConfiguration : IEntityTypeConfiguration<LiteraryType>
    {
        public void Configure(EntityTypeBuilder<LiteraryType> builder)
        {
            builder.Property(c => c.Name).IsRequired();
            builder.Property(c => c.Description).IsRequired();
        }
    }
}
