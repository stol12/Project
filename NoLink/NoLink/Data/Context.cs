namespace NoLink.Data
{
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    public class Context : IdentityDbContext<User>
    {
        public Context(DbContextOptions<Context> options)
            : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Article> Articles { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Testimonial> Testimonials { get; set; }
        public DbSet<FormFile> Files { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {

            builder.Entity<User>()
                .HasMany(u => u.Articles)
                .WithOne(a => a.Author)
                .HasForeignKey(a => a.AuthorId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<User>()
                   .HasMany(u => u.Testimonials)
                   .WithOne(t => t.User)
                   .HasForeignKey(u => u.UserId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Service>()
                    .HasMany(u => u.Files)
                    .WithOne(f => f.Service)
                    .HasForeignKey(u => u.ServiceId)
                    .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Article>()
                
                    .HasMany(u => u.Files)
                    .WithOne(f => f.Article)
                    .HasForeignKey(u => u.ArticleId)
                    .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(builder);
        }

    }
}
