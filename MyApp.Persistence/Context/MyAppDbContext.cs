
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
        public DbSet<ContentVote>  ContentVotes { get; set; }
        public DbSet<Comment> Comments { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(MyAppDbContext).Assembly);

            modelBuilder.Entity<Content>().HasQueryFilter(c => !c.IsDeleted);
            modelBuilder.Entity<ContentVote>()
                .HasIndex(v => new { v.UserId, v.ContentId })
                .IsUnique(); 

            modelBuilder.Entity<ContentVote>()
                .HasOne(v => v.User)
                .WithMany(u => u.Votes)
                .HasForeignKey(v => v.UserId);

            modelBuilder.Entity<ContentVote>()
                .HasOne(v => v.Content)
                .WithMany(c => c.Votes)
                .HasForeignKey(v => v.ContentId);


            base.OnModelCreating(modelBuilder);
        }

    }
}
