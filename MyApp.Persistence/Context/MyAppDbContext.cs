using Microsoft.EntityFrameworkCore;
using MyApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Persistence.Context
{
    public class MyAppDbContext : DbContext
    {

        public MyAppDbContext(DbContextOptions<MyAppDbContext> options)
            : base(options)
        {
        }
        
        public DbSet<User> Users { get; set; }
        public DbSet<Content> Contents { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(MyAppDbContext).Assembly);

            modelBuilder.Entity<Content>().HasQueryFilter(c => !c.IsDeleted);

            base.OnModelCreating(modelBuilder);
        }

    }
}
