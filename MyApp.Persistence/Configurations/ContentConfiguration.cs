using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Persistence.Configurations
{
    public class ContentConfiguration : IEntityTypeConfiguration<Content>
    {
        public void Configure(EntityTypeBuilder<Content> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Title).IsRequired().HasMaxLength(200);
            builder.Property(x => x.Body).IsRequired();
            builder.Property(x => x.IsDeleted).HasDefaultValue(false);
        }
    }
}
