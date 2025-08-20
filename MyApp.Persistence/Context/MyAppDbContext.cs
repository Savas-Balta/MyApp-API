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

            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                if (typeof(BaseAuditableEntity).IsAssignableFrom(entityType.ClrType))
                {
                    var p = Expression.Parameter(entityType.ClrType, "e");
                    var body = Expression.Equal(
                        Expression.Property(p, nameof(BaseAuditableEntity.IsDeleted)),
                        Expression.Constant(false));
                    modelBuilder.Entity(entityType.ClrType).HasQueryFilter(Expression.Lambda(body, p));
                }
            }

            modelBuilder.Entity<Content>().HasQueryFilter(c => !c.IsDeleted);
            modelBuilder.Entity<ContentVote>()
                .HasIndex(v => new { v.UserId, v.ContentId })
                .IsUnique(); 

            modelBuilder.Entity<ContentVote>()
                .HasOne(v => v.User)
                .WithMany(u => u.Votes)
                .HasForeignKey(v => v.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ContentVote>()
                .HasOne(v => v.Content)
                .WithMany(c => c.Votes)
                .HasForeignKey(v => v.ContentId)
                .OnDelete(DeleteBehavior.Restrict);


            base.OnModelCreating(modelBuilder);
        }

    }
}
