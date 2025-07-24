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
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasIndex(x => x.Email).IsUnique();
            builder.Property(x => x.UserName).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Role).HasDefaultValue("User");

            builder.HasMany(x => x.Contents)
                   .WithOne(x => x.User)
                   .HasForeignKey(x => x.UserId);
        }
    }
}
